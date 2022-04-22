using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba_3_Coop
{
    class Program
    {
        // Заповнення структури
        static Student[] ReadData(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            Student[] students = new Student[lines.Length];
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student(lines[i]);
            }
            return students;
        }
        // Гриб С.

        // Поставничий Д.
        static void RunMenuDenys(Student[] students, string fileName)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].mathematicsMark == 2 || students[i].physicsMark == 2 || students[i].informaticsMark == 2 ||
                    students[i].mathematicsMark == '-' || students[i].physicsMark == '-' || students[i].informaticsMark == '-')
                {
                    students[i].scholarship = 0;
                    Console.WriteLine(students[i].surName + " " + students[i].mathematicsMark + " " + students[i].physicsMark + " " + students[i].informaticsMark);
                    var write = from line in File.ReadLines(fileName)
                                where line.StartsWith(students[i].surName)
                                select line;
                    File.AppendAllLines("data_new.txt", write);
                }
            }
        }
        static void Main(string[] args)
        {
            int choise;
            do
            {
                Console.WriteLine("Виберiть студента:");
                Console.WriteLine("1 - Студент: Гриб С. Варiант: 5");
                Console.WriteLine("2 - Студент: Поставничий Д. Варiант: 7");
                //Console.WriteLine("3 - Студент: Гончаренко К. Варiант: 11");
                Console.WriteLine("0 - Повернутись назад");
                choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {

                            break;
                        }
                    case 2:
                        {
                            Student[] studs = ReadData("input.txt");
                            RunMenuDenys(studs, "input.txt");
                            break;
                        }
                    //case 3:
                    //    {
                    //       
                    //        break;
                    //    }
                    case 0:
                        {
                            Console.WriteLine("Повертаємось до вибору блоку");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введено неправильне число");
                            break;
                        }
                }
            } while (choise != 0);
        }
        struct Student
        {
            public string surName;
            public string firstName;
            public string patronymic;
            public char sex;
            public string dateOfBirth;
            public char mathematicsMark;
            public char physicsMark;
            public char informaticsMark;
            public int scholarship;
            public Student(string lineWithAllData)
            {
                string[] data = lineWithAllData.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                surName = data[0];
                firstName = data[1];
                patronymic = data[2];
                sex = char.Parse(data[3]);
                dateOfBirth = data[4];
                mathematicsMark = char.Parse(data[5]);
                physicsMark = char.Parse(data[6]);
                informaticsMark = char.Parse(data[7]);
                scholarship = int.Parse(data[8]);
            }
        }
    }
}
