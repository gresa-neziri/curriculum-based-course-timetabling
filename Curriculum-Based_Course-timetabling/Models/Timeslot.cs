﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curriculum_Based_Course_timetabling.Models
{
    class Timeslot
    {
        public int Day { get; set; }
        public int Period { get; set; }
       
        public Timeslot(int Day,int Period)
        {
            this.Period = Period;
            this.Day = Day;
        }
    }
}
