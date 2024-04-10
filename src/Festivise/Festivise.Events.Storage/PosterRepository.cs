using Azure.Storage.Blobs;
using Festivise.Events.Api.Contracts.DTO;
using Festivise.Events.Storage.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Festivise.Events.Storage
{
    public class PosterRepository : IPosterRepository
    {
        private readonly IEventRepository _eventRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly PosterRepositoryOptions _options;

        public PosterRepository(IEventRepository eventRepository, IHttpClientFactory httpClientFactory, IOptions<PosterRepositoryOptions> options)
        {
            _options = options.Value;
            _eventRepository = eventRepository;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GenerateEventPosterAsync(EventResponseDTO eventDTO)
        {

            try
            {
                var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _options.DalleApiKey);
            client.Timeout = TimeSpan.FromMinutes(5);

            var prompt = $"Create a poster for {eventDTO.Name} from {eventDTO.StartTime} to {eventDTO.EndTime} at {eventDTO.Venue}. The description for the event is: {eventDTO.Description}";
            var content = new StringContent(JsonSerializer.Serialize(new { prompt = prompt, n = 1 }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/images/generations", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                // Log the response string for debugging purposes
                Console.WriteLine($"Response JSON: {responseString}");

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var responseObj = JsonSerializer.Deserialize<DalleResponse>(responseString, options);

                if (responseObj?.Data != null && responseObj.Data.Any())
                {
                    var imageUrl = responseObj.Data.First().Url;
                    var imageBytes = await DownloadImageAsync(imageUrl);
                    var blobUrl = await UploadImageToBlobAsync(eventDTO.Id.ToString(), imageBytes);
                    return blobUrl;
                }
                else
                {
                    // Handle the case where Data is null or empty
                    Console.WriteLine("The 'Data' array in the response is null or empty.");
                    return null;
                }
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Dall-e Api Error: {errorContent}");
                return null;
            }

            }catch(TaskCanceledException ex)
            {
                Console.WriteLine($"The request to the Dall-e API was cancelled: {ex.Message}");
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred while generating the poster: {ex.Message}");
                return null;
            }
            
        }

        private async Task<string> UploadImageToBlobAsync(string fileName, byte[] imageBystes)
        {
            var blobServiceClient = new BlobServiceClient(_options.AzureBlobConnectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient("event-posters");
            await blobContainerClient.CreateIfNotExistsAsync();

            var blobClient = blobContainerClient.GetBlobClient($"{fileName}.png");
            using var memoryStream = new System.IO.MemoryStream(imageBystes);
            await blobClient.UploadAsync(memoryStream, overwrite:true);
            return blobClient.Uri.ToString();
        }

        private async Task<byte[]> DownloadImageAsync(string imageUrl)
        {
            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromMinutes(5);
            return await client.GetByteArrayAsync(imageUrl);
        }
    }

   
}
