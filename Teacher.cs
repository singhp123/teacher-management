using System;
using System.Collections.Generic;
using System.Text;

namespace TeacherManagement
{
    [Serializable]
    class Teacher
    {
        private int id;
        private string name;
        private string classTaken;
        private string section;

        public Teacher(int id, string name, string classTaken, string section)
        {
            this.Id = id;
            this.Name = name;
            this.ClassTaken = classTaken;
            this.Section = section;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string ClassTaken { get => classTaken; set => classTaken = value; }
        public string Section { get => section; set => section = value; }

        public override string ToString()
        {
            return "Teacher Details: " + id + " " + name + " " + classTaken + " " + section;
        }
    }
}
