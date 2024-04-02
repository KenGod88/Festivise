using Festivise.Schedules.Storage.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Schedules.Storage
{
    public class ScheduleRepository : IScheduleRepository
    {
        public Task<ScheduleModel> CreateScheduleAsync(ScheduleModel schedule)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduleModel> GetScheduleAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
