using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.DTO.DataMonitoring;
using web.Mapper;

namespace web.Controllers
{
    [Controller]
    [Route("api/v1/monitoring-data")]
    public class MonitoringDataController : Controller
    {
        private IMonitoringDataService _service;

        public MonitoringDataController(IMonitoringDataService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<MonitoringDataResponse>> CreateMonitoringData([FromBody] AddDataMonitoringRequest request)
        {
            MonitoringData monitoringData = await _service.CreateMonitoringDataAsync(request.UserId, MonitoringDataMapper.MapToDentalProblem(request.DentalProblems));
            MonitoringDataResponse response = MonitoringDataMapper.ToDto(monitoringData);
            return CreatedAtAction(nameof(CreateMonitoringData), response); 
        }
    }
}
