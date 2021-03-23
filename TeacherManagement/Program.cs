using System;
using System.Collections.Generic;
using System.IO;

namespace TeacherManagement
{
    class Program
    {
        static string dir = @"c:\temp";
        static string serializationFile = Path.Combine(dir, "teachers.bin");
        static int choice = 0;
        static Random random = new Random();
        static void Main(string[] args)
        {
            bool showOption = true;
            while (showOption)
            {
                showOption = showMenu();
            }



            Console.Write("Press any key to close the application");
            Console.ReadKey();

        }

        private static bool showMenu()
        {
            Console.WriteLine("Teacher Management\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Select operation to perform");
            Console.WriteLine("\t1 - Add Teacher ");
            Console.WriteLine("\t2 - Update Teacher");
            Console.WriteLine("\t3 - See all teacher");
            Console.WriteLine("\t4 - Exit");
            Console.Write("Your option? ");
            Console.WriteLine("Type a number, and then press Enter");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("You selected to add teacher");
                    Console.WriteLine("Enter teacher name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter class taken");
                    string classTaken = Console.ReadLine();
                    Console.WriteLine("Enter section name");
                    string section = Console.ReadLine();
                    Teacher teacher = new Teacher(random.Next(), name, classTaken, section);
                    List<Teacher> teacherList = getTeacherList();
                    teacherList.Add(teacher);
                    saveTeacherToFile(teacherList);
                    return true;
                case 2:
                    Console.WriteLine("You selected to update teacher");
                    Console.WriteLine("Enter Teacher id to update");
                    int idfromUser = Convert.ToInt32(Console.ReadLine());
                    List<Teacher> teachers = getTeacherList();
                    foreach (Teacher item in teachers)
                    {
                        if (item.Id == idfromUser)
                        {
                            Console.WriteLine("Enter teacher name");
                            string updatedName = Console.ReadLine();
                            Console.WriteLine("Enter class taken");
                            string updatedClassTaken = Console.ReadLine();
                            Console.WriteLine("Enter section name");
                            string updatedSection = Console.ReadLine();
                            item.Name = updatedName;
                            item.ClassTaken = updatedClassTaken;
                            item.Section = updatedSection;
                            saveTeacherToFile(teachers);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid id entered,Please enter a valid ID");
                        }
                    }
                    return true;
                case 3:
                    Console.WriteLine("You selected to see all teacher");
                    List<Teacher> teacherListFromFile = getTeacherList();
                    foreach (Teacher item in teacherListFromFile)
                    {
                        Console.WriteLine(item);
                    }

                    return true;
                case 4:
                    return false;
                default:
                    Console.WriteLine("Invalid option selected ");
                    return true;

            }
        }

        private static void saveTeacherToFile(List<Teacher> teacherList)
        {
            using (Stream stream = File.Open(serializationFile, FileMode.OpenOrCreate))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, teacherList);
            }
        }

        private static List<Teacher> getTeacherList()
        {
            using (Stream stream = File.Open(serializationFile, FileMode.OpenOrCreate))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                if (stream.Length < 1)
                {
                    return new List<Teacher>();
                }
                else
                {
                    List<Teacher> teacherListFromFile = (List<Teacher>)bformatter.Deserialize(stream);
                    return teacherListFromFile;
                }

            }
        }


    }
}
