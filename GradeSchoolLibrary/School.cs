using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeSchoolLibrary
{
    public class School
    {
        public Dictionary<int, List<string>> Roster { get; private set; }

        public School()
        {
            Roster = new Dictionary<int, List<string>>();
        }

        public void Add(string name, int grade)
        {
            ensureSchoolHasGrade(grade);
            Roster[grade].Add(name);
            Roster[grade].Sort();
        }

        public List<string> Grade(int grade)
        {
            ensureSchoolHasGrade(grade);
            return Roster[grade];
        }

        private void ensureSchoolHasGrade(int grade)
        {
            if (!Roster.ContainsKey(grade))
            {
                Roster.Add(grade, new List<string>());
            }
        }
    }
}
