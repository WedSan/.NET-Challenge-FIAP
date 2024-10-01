using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DentalAnalysis
    {
        public int Id { get; init; }

        public User user { get; init; }

        public DateTime AnalysisDate { get; init; }

        public float ProbabilityProblem { get; init; }

        public List<MonitoringData> MonitoringDataList { get; init; }

        public DentalAnalysis(int id, User user, DateTime analysisDate, float probabilityProblem, List<MonitoringData> monitoringDataList)
        {
            Id = id;
            this.user = user;
            AnalysisDate = analysisDate;
            ProbabilityProblem = probabilityProblem;
            MonitoringDataList = monitoringDataList;
        }
    }
}
