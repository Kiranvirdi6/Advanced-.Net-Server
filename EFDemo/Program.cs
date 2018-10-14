using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           using (DBModelContainer db = new DBModelContainer()) {

               List<Student> StudentList = db.Students.ToList();
                foreach (Student s in StudentList)
                {
                    Console.WriteLine($"{s.sFirstName} {s.sLastName} ");
                }
                Console.ReadKey();
          }

        }
    }
}
