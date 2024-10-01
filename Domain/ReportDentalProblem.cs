﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReportDentalProblem
    {
        public int Id {  get; set; }

        public string Problem { get; set; }

        public ReportDentalProblem()
        {
        }

        public ReportDentalProblem(int id, string problem)
        {
            Id = id;
            this.Problem = problem;
        }
    }
}
