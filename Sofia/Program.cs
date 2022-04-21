using System;
using System.IO;

namespace ConsoleApp2
{
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
    class Program
    {
        static Student[] ReadData(string fileName)
        {
            string[] line = File.ReadAllLines(fileName);
            Student[] studs = new Student[line.Length];
            for (int i = 0; i < studs.Length; i++)
            {
                studs[i] = new Student(line[i]);
            }
            return studs;
        }
        static void RunMenu(Student[] studs)
        {
            int count = 0;
            for (int i = 0; i < studs.Length; i++)
            {
                if (studs[i].informaticsMark == '5' && studs[i].mathematicsMark == '5' && studs[i].physicsMark == '5')
                {
                    count++;
                    Console.WriteLine($"Прiзвище: {studs[i].surName}");
                    Console.WriteLine($"iм'я: {studs[i].firstName}");
                    Console.WriteLine($"По батьковi: {studs[i].patronymic}");
                    Console.WriteLine($"Розмiр стипендiї: {studs[i].scholarship}");
                }
            }
            Console.WriteLine($"Кiлькiсть студентiв, якi мають оцiнку 5 з усiх предметiв: {count}");
        }
        static void Main(string[] args)
        {
            Student[] studs = ReadData(@"C:\Users\Admin\Desktop\Палм\Лабораторна 3\ConsoleApp2\ConsoleApp2\bin\Debug\Data.txt");
            RunMenu(studs);
        }
    }
}
