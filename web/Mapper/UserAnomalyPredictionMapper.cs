using MachineLearning;
using web.DTO.MachineLearning;

namespace web.Mapper;

public class UserAnomalyPredictionMapper
{
    static public List<UserAnomalyPredictionDTO> ToDto(List<AnomalyPrediction> anomalyPredictions)
    {
        return anomalyPredictions.Select(anomalyPrediction => new UserAnomalyPredictionDTO
        {
            IsAnomaly = anomalyPrediction.IsAnomaly,
            UserId = anomalyPrediction.UserId,
            Score = anomalyPrediction.Score,
        }).ToList();
    }
}