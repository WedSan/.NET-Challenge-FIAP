using Microsoft.ML;

namespace MachineLearning;

public class UserAnomalyPredictor : IUserAnomalyPredictor
{

    private MLContext _mlContext;
    
    public UserAnomalyPredictor()
    {
        this._mlContext = new MLContext();
    }

    public List<AnomalyPrediction> GetAnomalies(List<UserActivity> userActivities)
    {
        
        var pipeline = _mlContext.Transforms.Concatenate(
                "Features", nameof(UserActivity.NumRelatos), nameof(UserActivity.NumProcedimentos))
            .Append(_mlContext.Transforms.CopyColumns("UserIdOut", nameof(UserActivity.UserId)))
            .Append(_mlContext.AnomalyDetection.Trainers.RandomizedPca(featureColumnName: "Features", rank: 2));

        var dataView = _mlContext.Data.LoadFromEnumerable(userActivities);
        var model = pipeline.Fit(dataView);

        var transformed = model.Transform(dataView);
        var predictions = _mlContext.Data.CreateEnumerable<AnomalyPrediction>(transformed, reuseRowObject: false);

        return predictions.ToList();
    }
}