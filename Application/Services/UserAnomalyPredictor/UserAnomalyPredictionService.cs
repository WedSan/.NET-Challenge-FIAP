using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace MachineLearning;

public class UserAnomalyPredictionService
{
    private IUserAnomalyPredictor _userAnomalyPredictor;
    private IEntityRepository<User> _userRepository;
    private IEntityRepository<ReportDentalProblem> _reportDentalProblemRepository;
    private IEntityRepository<DentalProcedure> _dentalProcedureRepository;

    public UserAnomalyPredictionService(IUserAnomalyPredictor userAnomalyPredictor,
                                        IEntityRepository<User> userRepository, IEntityRepository<ReportDentalProblem> reportDentalProblemRepository, IEntityRepository<DentalProcedure> dentalProcedureRepository)
    {
        this._userAnomalyPredictor = userAnomalyPredictor;
        _userRepository = userRepository;
        _reportDentalProblemRepository = reportDentalProblemRepository;
        _dentalProcedureRepository = dentalProcedureRepository;
    }

    public async Task<List<AnomalyPrediction>> GetUsersAnomalyPrediction()
    {
        var userList = await this._userRepository.GetAllAsync(1, 10000);
        var reportDentalProblemList = await this._reportDentalProblemRepository.GetAllAsync(1, 10000);
        var dentalProcedures = await this._dentalProcedureRepository.GetAllAsync(1, 10000);
        List<UserActivity> userActivities = new List<UserActivity>();
        userList.ForEach(user=>
        {
            var userDentalProblemReport =
                reportDentalProblemList.FindAll(report => report.MonitoringData.User.Id == user.Id);

            var userDentalProcedures = dentalProcedures.FindAll(
                dentalProcedure => dentalProcedure.DentalHistory.User.Id == user.Id);
            
            userActivities.Add(new UserActivity(
                user.Id,
                userDentalProblemReport.Count(),
                userDentalProcedures.Count()));
        });

        return _userAnomalyPredictor.GetAnomalies(userActivities);
    }
}