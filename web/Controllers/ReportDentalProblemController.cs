using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.DTO.ReportDentalProblem; 
using web.Mapper; 

namespace web.Controllers
{
    [Controller]
    [Route("api/v1/report-dental-problems")]
    public class ReportDentalProblemController : Controller
    {
        private readonly IReportDentalProblemService _service;

        public ReportDentalProblemController(IReportDentalProblemService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReportDentalProblemResponse>> CreateReportDentalProblem([FromBody] AddReportDentalProblemRequest request)
        {
            ReportDentalProblem reportDentalProblem = await _service.CreateReportDentalProblemAsync(request.MonitoringDataId, request.Problem);
            ReportDentalProblemResponse response = ReportDentalProblemMapper.ToDto(reportDentalProblem);
            return CreatedAtAction(nameof(CreateReportDentalProblem), response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportDentalProblemResponse>>> GetAllReportDentalProblems(int pageNumber = 0, int pageSize = 10)
        {
            IEnumerable<ReportDentalProblem> reportDentalProblemList = await _service.GetReportDentalProblemAsync(pageNumber, pageSize);
            IEnumerable<ReportDentalProblemResponse> response = ReportDentalProblemMapper.ToDto(reportDentalProblemList);
            return Ok(response);
        }

        [HttpGet("{reportDentalProblemId}")]
        public async Task<ActionResult<ReportDentalProblemResponse>> GetReportDentalProblemById(int reportDentalProblemId)
        {
            ReportDentalProblem reportDentalProblem = await _service.GetReportDentalProblemByIdAsync(reportDentalProblemId);
            ReportDentalProblemResponse response = ReportDentalProblemMapper.ToDto(reportDentalProblem);
            return Ok(response);
        }

        [HttpPatch("{reportDentalProblemId}")]
        public async Task<ActionResult<ReportDentalProblemResponse>> UpdateReportDentalProblem(int reportDentalProblemId, [FromBody] UpdateReportDentalProblemRequest updateRequest)
        {
            ReportDentalProblem reportDentalProblemUpdated = await _service.UpdateReportDentalProblemAsync(reportDentalProblemId, updateRequest.Problem);
            ReportDentalProblemResponse response = ReportDentalProblemMapper.ToDto(reportDentalProblemUpdated);
            return Ok(response);
        }

        [HttpDelete("{reportDentalProblemId}")]
        public async Task<ActionResult> DeleteReportDentalProblem(int reportDentalProblemId)
        {
            await _service.DeleteReportDentalProblemaAsync(reportDentalProblemId);
            return NoContent();
        }
    }
}
