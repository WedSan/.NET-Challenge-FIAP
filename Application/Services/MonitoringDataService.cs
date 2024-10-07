using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MonitoringDataService : IMonitoringDataService
    {
        private readonly IEntityRepository<MonitoringData> _entityRepository;

        private readonly IUserService _userService;

        public MonitoringDataService(IEntityRepository<MonitoringData> entityRepository, IUserService userService)
        {
            _entityRepository = entityRepository;
            _userService = userService;
        }

        public async Task<MonitoringData> CreateMonitoringDataAsync(int userId, List<ReportDentalProblem> problems)
        { 
            User user = await _userService.GetUserByIdAsync(userId);
            MonitoringData monitoringData = new MonitoringData
            {
                User = user,
                Problems = problems,
                RegistrationDate = DateTime.Now,
            };
            await _entityRepository.AddAsync(monitoringData);
            await _entityRepository.SaveChangesAsync();
            return monitoringData;
        }

        public Task DeleteMonitoringDataAsync(int monitoringDataId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MonitoringData>> GetMonitoringDataAsync(int pageNumber, int pageSize)
        {
            return await _entityRepository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<MonitoringData> GetMonitoringDataByIdAsync(int monitoringDataId)
        {
            return await _entityRepository.GetByIdAsync(monitoringDataId);
        }

        public Task<MonitoringData> UpdateMonitoringDataAsync(int monitoringDataId, List<ReportDentalProblem> dentalProblems)
        {
            throw new NotImplementedException();
        }
    }
}
