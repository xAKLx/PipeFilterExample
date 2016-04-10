using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesFilterExample
{
    public class Student: IComparable<Student>
    {
        public String Name { get; set; }
        public uint Matricula { get; set; }
        public uint Age { get; set; }
        public bool IsMale { get; set; }

        public Student(String name, uint matricula, uint age, bool isMale)
        {
            Name = name;
            Matricula = matricula;
            Age = age;
            IsMale = isMale;
        }

        public int CompareTo(Student other)
        {
            return Matricula.CompareTo(other.Matricula);
        }
    }
}
