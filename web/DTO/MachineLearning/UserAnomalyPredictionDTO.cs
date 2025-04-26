namespace web.DTO.MachineLearning;

public record UserAnomalyPredictionDTO
{

    public bool IsAnomaly { get; set; }
    public int UserId { get; set; }
    public float Score { get; set; }
}