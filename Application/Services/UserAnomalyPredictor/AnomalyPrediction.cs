using Microsoft.ML.Data;

namespace MachineLearning;

public class AnomalyPrediction
{
    [ColumnName("PredictedLabel")]
    public bool IsAnomaly { get; set; }
    [ColumnName("UserIdOut")]
    public int UserId { get; set; }
    public float Score { get; set; }
}