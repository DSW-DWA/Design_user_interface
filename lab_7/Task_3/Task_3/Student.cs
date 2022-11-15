using System.Collections.Generic;
using System.Windows.Documents;

namespace Task_3
{
    public class Student
    {
        public List<int> MarkList { get; }
        public int Id { get; } 
        public int Score { get; }

        public Student(int id, List<int> markList, int score)
        {
            MarkList = markList;
            Id = id;
            Score = score;
        }
    }
}