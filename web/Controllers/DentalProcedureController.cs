using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using web.DTO.DentalProcedure;
using web.Mapper;

namespace web.Controllers
{
    [ApiController]
    [Route("api/v1/dental-procedure")]
    public class DentalProcedureController : Controller
    {
        private readonly IDentalProcedureService _service;

        public DentalProcedureController(IDentalProcedureService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<DentalProcedureResponse>> CreateDentalProcedure([FromBody] AddDentalProcedureRequest request)
        {
            var dentalProcedure = await _service.CreateDentalProcedureAsync(request.MonitoringDataId, request.Problem);
            var response = DentalProcedureMapper.ToDto(dentalProcedure);
            return CreatedAtAction(nameof(CreateDentalProcedure), response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DentalProcedureResponse>>> GetAllDentalProcedures(int pageNumber = 0, int pageSize = 10)
        {
            IEnumerable<DentalProcedure> dentalProcedures = await _service.GetDentalProcedureAsync(pageNumber, pageSize);
            IEnumerable<DentalProcedureResponse> response = DentalProcedureMapper.ToDto(dentalProcedures);
            return Ok(response);
        }

        [HttpGet("{dentalProcedureId}")]
        public async Task<ActionResult<DentalProcedureResponse>> GetDentalProcedureById(int dentalProcedureId)
        {
            var dentalProcedure = await _service.GetDentalProcedureByIdAsync(dentalProcedureId);
            var response = DentalProcedureMapper.ToDto(dentalProcedure);
            return Ok(response);
        }

        [HttpPatch("{dentalProcedureId}")]
        public async Task<ActionResult<DentalProcedureResponse>> UpdateDentalProcedure(int dentalProcedureId, [FromBody] UpdateDentalProcedureRequest updateRequest)
        {
            var updatedDentalProcedure = await _service.UpdateDentalProcedureAsync(dentalProcedureId, updateRequest.Problem);
            var response = DentalProcedureMapper.ToDto(updatedDentalProcedure);
            return Ok(response);
        }

        [HttpDelete("{dentalProcedureId}")]
        public async Task<ActionResult> DeleteDentalProcedure(int dentalProcedureId)
        {
            await _service.DeleteDentalProcedureAsync(dentalProcedureId);
            return NoContent();
        }
    }
}
