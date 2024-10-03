﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MonitoringData
    {

        public int Id { get; set; }

        public User User { get; init; }

        public List<ReportDentalProblem> Problems { get; init; }

        public List<DentalAnalysis> DentalAnalyses { get; init; }

        public DateTime RegistrationDate { get; init; }

        public MonitoringData()
        {
        }

        public MonitoringData(int id, User user, List<ReportDentalProblem> problems, List<DentalAnalysis> dentalAnalyses, DateTime registrationDate)
        {
            Id = id;
            User = user;
            Problems = problems;
            DentalAnalyses = dentalAnalyses;
            RegistrationDate = registrationDate;
        }
    }
}