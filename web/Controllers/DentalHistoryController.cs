using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using web.DTO.DentalHistory;
using web.DTO.DentalHistory.web.DTO.DentalHistory;
using web.Mapper;

namespace web.Controllers
{
    [Controller]
    [Route("api/v1/dental-history")]
    public class DentalHistoryController : Controller
    {
        private readonly IDentalHistoryEntityService _service;

        public DentalHistoryController(IDentalHistoryEntityService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDentalHistory([FromBody] AddDentalHistoryRequest request)
        {
            DentalHistory dentalHistoryCreated = await _service.CreateDentalHistoryAsync(
                request.UserId,
                request.Procedures,
                request.ConsultationDate,
                request.ToothCondition
            );

            DentalHistoryResponse response = DentalHistoryMapper.ToDTO(dentalHistoryCreated);
            return CreatedAtAction(nameof(CreateDentalHistory), response);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDentalHistories(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<DentalHistory> dentalHistories = await _service.GetDentalHistoriesAsync(pageNumber, pageSize);

            List<DentalHistoryResponse> response = DentalHistoryMapper.ToDTO(dentalHistories);
            return Ok(response);
        }

        [HttpGet("{dentalHistoryId}")]
        public async Task<ActionResult> GetDentalHistoryById(int dentalHistoryId)
        {
            DentalHistory dentalHistoryFounded = await _service.GetDentalHistoryByIdAsync(dentalHistoryId);

            if (dentalHistoryFounded == null)
            {
                return NotFound();
            }

            DentalHistoryResponse response = DentalHistoryMapper.ToDTO(dentalHistoryFounded);
            return Ok(response);
        }

        [HttpPatch("{dentalHistoryId}")]
        public async Task<ActionResult> UpdateDentalHistory(int dentalHistoryId, [FromBody] UpdateDentalHistoryRequest request)
        {
            DentalHistory dentalHistoryUpdated = await _service.UpdateDentalHistoryUserAsync(dentalHistoryId, request.NewProcedures);

            DentalHistoryResponse response = DentalHistoryMapper.ToDTO(dentalHistoryUpdated);
            return Ok(response);
        }

        [HttpDelete("{dentalHistoryId}")]
        public async Task<ActionResult> DeleteDentalHistory(int dentalHistoryId)
        {
            await _service.DeleteDentalHistoryAsync(dentalHistoryId);
            return NoContent();
        }
    }
}