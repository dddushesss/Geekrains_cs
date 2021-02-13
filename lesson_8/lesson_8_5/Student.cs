using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8_5
{
    [Serializable]
    public class Student : IComparable<Student>
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;

        public int age;

        // Создаем конструктор
        public Student()
        {

        }

        public Student(string firstName, string lastName, string university, string faculty, string department,
            int course, int age, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }

        public int CompareTo(Student other)
        {
            if (other != null)
            {
                return this.age - other.age;
            }

            throw new ArgumentException("Объект не является студентом");
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}, {city}, {age} " +
                   (age % 10 == 1 ? "год" : (age % 10 > 1 && age % 10 < 5) ? "года" : "лет") +
                   $", группа {group}, университет {university}, факультет {faculty}, кафедра {department}, {course} курс, ";
        }
    }
}
