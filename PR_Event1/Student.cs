using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Event1
{
    public class Student
    {
        public string LastName { get; set; }
        public List<int> Grades { get; private set; } = new List<int>();
        // Подія додавання оцінки
        public event Action<int> GradeAdded;
        // Метод для додавання оцінки
        public void AddGrade(int grade)
        {
            Grades.Add(grade);
            GradeAdded?.Invoke(grade);
        }
    }
}
