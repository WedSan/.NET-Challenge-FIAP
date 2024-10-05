using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IMonitoringDataService
    {
        Task<MonitoringData> CreateMonitoringDataAsync(int userId, List<ReportDentalProblem> problems);

        Task<IEnumerable<MonitoringData>> GetMonitoringDataAsync(int pageNumber, int pageSize);

        Task<MonitoringData> GetMonitoringDataByIdAsync(int monitoringDataId);

        Task<MonitoringData> UpdateMonitoringDataAsync(int monitoringDataId, List<ReportDentalProblem> dentalProblems);

        Task DeleteMonitoringDataAsync(int monitoringDataId);
    }
}
