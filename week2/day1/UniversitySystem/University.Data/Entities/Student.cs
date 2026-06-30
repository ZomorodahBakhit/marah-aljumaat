using System;
using System.Collections.Generic;
using System.Text;

namespace University.Data.Entities
{
    public class Student
    {
       // Id(int), Name(string), Email(string)
       public int StudentId { get; set; }
       public string StudentName { get; set; }
       public string StudentEmail { get; set; }
    }
}
