using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DbAppsHW3
{
    class Student
    {
        public static int StudentsCreated = 0;
        public Student()
        {
            Interlocked.Increment(ref StudentsCreated);
        }

        public Student(string name)
        {
            Interlocked.Increment(ref StudentsCreated);
            this.Name = name;
        }

        ~Student()
        {
            Interlocked.Decrement(ref StudentsCreated);
        }

        public string Name { get; set; }
    }
}
