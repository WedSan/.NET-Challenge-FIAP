namespace MachineLearning;

public interface IUserAnomalyPredictor
{
    List<AnomalyPrediction> GetAnomalies(List<UserActivity> userActivities);
}