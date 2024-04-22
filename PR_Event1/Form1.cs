using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_Event1
{
    public partial class Form1 : Form
    {

        private List<Student> students = new List<Student>();
        private Group group;
        public Form1()
        {
            InitializeComponent();

            // Створюємо об'єкти студентів
            for (int i = 0; i < 2; i++)
            {
                students.Add(new Student());
            }

            // Створюємо об'єкт групи
            group = new Group("Group 1", students.ToArray());

            // Підписуємося на подію оновлення групи
            group.GroupUpdated += UpdateForm;

            // Оновлюємо дані групи одразу
            UpdateForm();

            // Додаємо обробник події для вибору елемента у ListBox
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }
        // Метод для оновлення форми
        private void UpdateForm()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add($"Group: {group.Name}");
            listBox1.Items.Add($"Count of 5: {group.Count5}");
            listBox1.Items.Add($"Count of 4: {group.Count4}");
            listBox1.Items.Add($"Count of 3: {group.Count3}");
            for (int i = 0; i < students.Count; i++)
            {
                listBox1.Items.Add($"Student{i + 1} Grades: {string.Join(", ", students[i].Grades)}");
            }
        }
        // Обробник події для додавання оцінки для першого студента
        private void button1_Click_1(object sender, EventArgs e)
        {
            int grade;
            if (int.TryParse(textBox1.Text, out grade))
            {
                students[0].AddGrade(grade);
            }
            textBox1.Clear();
        }
        // Обробник події для додавання оцінки для всіх студентів
        private void button2_Click_1(object sender, EventArgs e)
        {
            int grade;
            if (int.TryParse(textBox2.Text, out grade))
            {
                foreach (var student in students)
                {
                    student.AddGrade(grade);
                }
            }
            textBox2.Clear();
        }

        // Обробник події для вибору елемента у ListBox
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Перевіряємо, чи є вибраний елемент
            if (listBox1.SelectedIndex != -1)
            {
                // Визначаємо індекс студента, якому будемо додавати оцінку
                int studentIndex = listBox1.SelectedIndex - 4;

                // Додавання оцінки до вибраного студента
                int grade;
                if (int.TryParse(textBox1.Text, out grade))
                {
                    if (studentIndex >= 0 && studentIndex < students.Count)
                    {
                        students[studentIndex].AddGrade(grade);
                    }
                }
                textBox1.Clear();
            }
        }
        // Обробник події для зміни студента
        private void button3_Click_1(object sender, EventArgs e)
        {
            // Змінюємо об'єкт student1 на новий екземпляр Student
            students[0] = new Student();
            // Перепризначаємо підписку на подію для нового student1
            group = new Group("Group 1", students.ToArray());
            // Підписуємося на подію оновлення групи
            group.GroupUpdated += UpdateForm;

            UpdateForm();
        }
    }
}
