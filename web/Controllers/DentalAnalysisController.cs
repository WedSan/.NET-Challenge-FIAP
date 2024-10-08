using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using web.DTO.DentalAnalysis;
using web.Mapper;

namespace web.Controllers
{
    [Controller]
    [Route("api/v1/dental-analysis")]
    public class DentalAnalysisController : Controller
    {
        private readonly IDentalAnalysisService _service;

        public DentalAnalysisController(IDentalAnalysisService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDentalAnalysis([FromBody] AddDentalAnalysisRequest request)
        {
            DentalAnalysis dentalAnalysisCreated = await _service.CreateDentalAnalysisAsync(request.UserId,
                                        request.AnalysisDate,
                                        request.ProbabilityProblem,
                                        request.MonitoringDataIdList);

            DentalAnalysisResponse response = DentalAnalysisMapper.ToDTO(dentalAnalysisCreated);
            return CreatedAtAction(nameof(CreateDentalAnalysis), response);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDentalAnalysis(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<DentalAnalysis> dentalAnalysisCreated = await _service.GetDentalAnalysisAsync(pageNumber, pageSize);

            List<DentalAnalysisResponse> response = DentalAnalysisMapper.ToDTO(dentalAnalysisCreated);
            return Ok(response);
        }

        [HttpGet("{dentalAnalysisId}")]
        public async Task<ActionResult> GetAllDentalAnalysisById(int dentalAnalysisId)
        {
            DentalAnalysis dentalAnalysisFounded = await _service.GetDentalAnalysisByIdAsync(dentalAnalysisId);

            DentalAnalysisResponse response = DentalAnalysisMapper.ToDTO(dentalAnalysisFounded);
            return Ok(response);
        }

        [HttpPatch("{dentalAnalysisId}")]
        public async Task<ActionResult> UpdateDentalAnalysis(int dentalAnalysisId, [FromBody] UpdateDentalAnalysis request)
        {
            DentalAnalysis dentalAnalysisUpdated = await _service.UpdateDentalAnalysisUserAsync(dentalAnalysisId, request.newProbabilityProblem);
                
            DentalAnalysisResponse response = DentalAnalysisMapper.ToDTO(dentalAnalysisUpdated);
            return Ok(response);
        }

        [HttpDelete("{dentalAnalysisId}")]
        public async Task<ActionResult> UpdateDentalAnalysis(int dentalAnalysisId)
        {
            await _service.DeleteDentalAnalysisAsync(dentalAnalysisId);

            return NoContent();
        }
    }
}
