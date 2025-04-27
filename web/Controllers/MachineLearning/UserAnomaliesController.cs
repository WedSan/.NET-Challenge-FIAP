using MachineLearning;
using Microsoft.AspNetCore.Mvc;
using web.DTO.MachineLearning;
using web.Mapper;

namespace web.Controllers.MachineLearning;

[Controller]
[Route("api/v1/machine-learning/user-anomalies")]
public class UserAnomaliesController : Controller
{
    private readonly UserAnomalyPredictionService _userAnomalyPredictionService;

    public UserAnomaliesController(UserAnomalyPredictionService userAnomalyPredictionService)
    {
        _userAnomalyPredictionService = userAnomalyPredictionService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserAnomalyPredictionDTO>>> GetUserAnomalies()
    {
        var usersAnomalyPrediction = await _userAnomalyPredictionService.GetUsersAnomalyPrediction();
        return Ok(UserAnomalyPredictionMapper.ToDto(usersAnomalyPrediction));
    }
}