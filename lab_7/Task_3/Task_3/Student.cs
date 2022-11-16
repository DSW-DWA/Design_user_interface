using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Documents;

namespace Task_3
{
    public class Student
    {
        public List<int> MarkList { get; }
        public int Id { get; } 
        public int Score { get; }

        public double Sum
        {
            get
            {
                var sum = MarkList.Count * 5 + 0.0;
                foreach (var mark in MarkList)
                {
                    switch (mark)
                    {
                        case 1:
                        {
                            sum += 0.5;
                            break;
                        }
                        case 2:
                        {
                            sum += 0.4;
                            break;
                        }
                        case 3:
                        {
                            sum += 0.3;
                            break;
                        }
                        case 4:
                        {
                            sum += 0.2;
                            break;
                        }
                        case 5:
                        {
                            sum += 0.1;
                            break;
                        }
                    }
                }

                return sum + Score;
            }
        }

        public Student(int id, List<int> markList, int score)
        {
            MarkList = markList;
            Id = id;
            Score = score;
        }
    }
}