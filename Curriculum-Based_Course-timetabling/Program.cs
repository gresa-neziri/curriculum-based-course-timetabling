using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Curriculum_Based_Course_timetabling.Models;

namespace Curriculum_Based_Course_timetabling
{
    class Program
    {
        static void Main(string[] args)
        {
            IO.Read("FIM A");
            string text = "";
            Solution solution = new Solution();

             ILS ils = new ILS();
            solution = ils.FindSolution();
            foreach (var item in solution.assignments)
            {
                text += item.course.Id + " " + item.room.Id.Trim() + " " + item.timeslot.Day + " " + item.timeslot.Period + "\n";
            }
            Console.WriteLine(text);
            IO.Write(solution.assignments, solution.GetScore());
            Console.WriteLine("Score: {0} Courses {1}", solution.GetScore(),solution.assignments.Count);
            Console.ReadKey();
        }
            
    }
}
