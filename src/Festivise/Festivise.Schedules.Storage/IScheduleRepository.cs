using Festivise.Schedules.Storage.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Schedules.Storage
{
    public interface IScheduleRepository
    {
        Task<ScheduleModel> CreateScheduleAsync(ScheduleModel schedule);
        Task<ScheduleModel> GetScheduleAsync(string id);
    }
}
