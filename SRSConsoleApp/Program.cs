using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRSDAL;

namespace SRSConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int op;
            do
            {
                Console.Clear();
                op = getUserOption();

                switch (op)
                {
                    case 0:
                        Console.WriteLine("Thanks for usinG SRS.");
                        break;
                    case 1:
                        addNewStudent();
                        break;
                    case 2:
                        addNewCourse();
                        break;

                    case 3:
                        displayStudent();
                        break;
                    case 4:
                        displayCourses();
                        break;
                    case 5:
                        assignCourseToStudent();
                        break;
                    case 6:
                        enrollStudentToCourse();
                        break;
                    case 7:
                        displayCourseEnrollmentList();
                        break;
                    case 8:
                        displayStudentCourseSelectionList();
                        break;
                    default:
                        Console.WriteLine("Invalid Option Selected");
                        break;
                }
                Console.WriteLine("Press a key to Continue...");
                Console.ReadKey();
            } while (op != 0);
        }

        private static void displayStudentCourseSelectionList()
        {
            using (SRSDBEntities db = new SRSDBEntities())
            {
                var queryStudent = from s in db.Students
                                   select s;

                foreach (var s in queryStudent)
                {
                    Console.WriteLine($"{s.Id} - {s.FirstName} - {s.LastName}");
                    foreach (Course c in s.Courses)
                    {
                        Console.WriteLine($"         { c.Id}- { c.Code}-{ c.Title}");
                    }
                    Console.WriteLine();
                }

            }
        }
        private static void displayCourseEnrollmentList()
        {
            using (SRSDBEntities db = new SRSDBEntities())
            {
                List<Course> courseList = db.Courses.ToList();
                foreach (Course c in courseList)
                {
                    Console.WriteLine($"{ c.Id}- { c.Code}-{ c.Title}");
                    List<Student> StudentList = c.Students.ToList();
                    foreach (Student s in StudentList)
                    {
                        Console.WriteLine($"        {s.Id} - {s.FirstName} - {s.LastName}");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void enrollStudentToCourse()
        {
            displayStudent();
            Console.WriteLine("Student ID: ");
            int sID = Convert.ToInt32(Console.ReadLine());

            displayCourses();
            Console.WriteLine("Course ID: ");
            int cID = Convert.ToInt32(Console.ReadLine());


            using (SRSDBEntities db = new SRSDBEntities())
            {
                Student student = db.Students.Where(s => s.Id == sID).First();
                Course course = db.Courses.Find(cID);
                course.Students.Add(student);
                db.SaveChanges();
            }



        }

        private static void assignCourseToStudent()
        {
            displayCourses();
            Console.WriteLine("Course ID: ");
            int cID = Convert.ToInt32(Console.ReadLine());

            displayStudent();
            Console.WriteLine("Student ID: ");
            int sID = Convert.ToInt32(Console.ReadLine());

            using (SRSDBEntities db = new SRSDBEntities())
            {
                var queryCourse = from c in db.Courses
                                  where c.Id == cID
                                  select c;

                Course course = queryCourse.First();

                Student student = (from s in db.Students
                                   where s.Id == sID
                                   select s).First();

                student.Courses.Add(course);
                db.SaveChanges();

            }
        }

        private static void displayCourses()
        {
            using (SRSDBEntities db = new SRSDBEntities())
            {
                List<Course> CourseList = db.Courses.ToList();
                foreach (Course c in CourseList)
                {
                    Console.WriteLine($"{ c.Id}- { c.Code}-{ c.Title}");

                }

            }
        }

        private static void displayStudent()
        {
            Console.WriteLine("List os students");
            using (SRSDBEntities db = new SRSDBEntities())
            {
                var q = from s in db.Students
                        select s;
                foreach (Student s in q)
                {
                    Console.WriteLine($"{s.Id} - {s.FirstName} {s.LastName}");
                }
            }
        }

        private static void addNewCourse()
        {
            Console.Write("Course Code: ");
            string Code = Console.ReadLine();

            Console.Write("Course Title: ");
            string Title = Console.ReadLine();

            using (SRSDBEntities db = new SRSDBEntities())
            {
                db.Courses.Add(new Course() { Code = Code, Title = Title });
                db.SaveChanges();
            }
        }

        private static void addNewStudent()
        {
            Console.Write("FirstName: ");
            string FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string LastName = Console.ReadLine();

            Student s = new Student();
            s.FirstName = FirstName;
            s.LastName = LastName;

            using (SRSDBEntities db = new SRSDBEntities())
            {
                db.Students.Add(s);
                db.SaveChanges();
            }
        }

        private static int getUserOption()
        {
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. Add New Course");
            Console.WriteLine();

            Console.WriteLine("3. Display Student");
            Console.WriteLine("4. Display Course");
            Console.WriteLine();

            Console.WriteLine("5. Assign Course to Student");
            Console.WriteLine("6. Enroll Student to Course");
            Console.WriteLine();

            Console.WriteLine("7. Display Course Enrollment List");
            Console.WriteLine("8. Display Student Course Selection List");
            Console.WriteLine();

            Console.WriteLine("0. Exit");
            Console.WriteLine();

            Console.Write("Enter Your Option..");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
