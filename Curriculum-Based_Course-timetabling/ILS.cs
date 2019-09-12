using Curriculum_Based_Course_timetabling.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curriculum_Based_Course_timetabling
{
    class ILS
    {
        readonly int iterations;
        readonly int seconds;

        public ILS(int seconds = 60 , int iterations = 1000)
        {
            this.iterations = iterations;
            this.seconds = seconds;
        }

        public Solution FindSolution()
        {
            DateTime startTime = DateTime.Now;
            Random rnd = new Random();
            int iterations_count = 0;
            List<int> T = new List<int>() { 15, 11, 12,100, 14,15};
            Solution S = new Solution();
            S.assignments = S.GenerateSolution();
            Console.WriteLine("Score ne fillim : {0}",S.GetScore());
            Solution H = new Solution();
            H=H.Copy(S.assignments);
            Solution Best = new Solution();
            Best = Best.Copy(S.assignments);
            var R = new Solution();

            Stopwatch s = new Stopwatch();
            s.Start();

            while (iterations_count < iterations && s.Elapsed < TimeSpan.FromSeconds(seconds))
            {
                int climb_iterations = 0;
                int time = T[rnd.Next(T.Count)];

                while (iterations_count < iterations && climb_iterations < time && s.Elapsed < TimeSpan.FromSeconds(seconds))
                {
                    R = R.Copy(S.assignments);
                    R.Tweak();
       
                    var random = rnd.Next(1, 70);
                    if (R.GetScore() < S.GetScore() )
                    {
                        S = S.Copy(R.assignments);
                    }
                    climb_iterations++;
                }

                if (S.GetScore() < Best.GetScore())
                {
                  
                    Best = Best.Copy(S.assignments);
                }

                H =H.Copy( NewHomeBase(H, S).assignments);
                S = S.Copy(H.assignments);

                S.Perturb();
                iterations_count++;

                Console.WriteLine(Best.GetScore());
                if(Best.GetScore()==0)
                {
                    break;
                }
            }

            s.Stop();
            return Best;
        }

        public Solution NewHomeBase(Solution H, Solution S)
        {
            return S.GetScore() < H.GetScore() ? S : H;
        }

        private bool TimeDifferenceReached(DateTime startTime,int total_execution_seconds)
        {
            bool result = (int)DateTime.Now.Subtract(startTime).TotalSeconds > total_execution_seconds ? true : false;
            return result;
        }
    }
}
