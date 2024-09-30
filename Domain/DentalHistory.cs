﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DentalHistory
    {
        public int ID { get; init; }

        public User User { get; init; }

        public List<DentalProcedure> Procedures { get; init; }

        public DateTime ConsultationDate { get; init; }
           
        public String ToothCondition { get; init; }

        public DentalHistory(int iD, User user, List<DentalProcedure> procedures, DateTime consultationDate, string toothCondition)
        {
            ID = iD;
            User = user;
            Procedures = procedures;
            ConsultationDate = consultationDate;
            ToothCondition = toothCondition;
        }
    }
}