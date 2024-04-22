using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Event1
{
    public class Group
    {
        public string Name { get; set; }
        public int Count5 { get; private set; }
        public int Count4 { get; private set; }
        public int Count3 { get; private set; }
        // Подія оновлення групи
        public event Action GroupUpdated;
        // Конструктор групи
        public Group(string name, params Student[] students)
        {
            Name = name;
            foreach (var student in students)
            {
                student.GradeAdded += UpdateGrades;
            }
        }
        // Метод для оновлення кількості оцінок
        private void UpdateGrades(int grade)
        {
            if (grade == 5)
                Count5++;
            else if (grade == 4)
                Count4++;
            else if (grade == 3)
                Count3++;
            GroupUpdated?.Invoke();
        }
    }

}
