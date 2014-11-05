using System;
using System.Collections.Generic;

namespace GradeSchoolLibrary
{
    public class School
    {
        /// <summary>
        /// Private copy of the data
        /// </summary>
        private Dictionary<int, List<string>> _Data = new Dictionary<int, List<string>>();

        /// <summary>
        /// Publicly accessible DEEP COPY of the data that prevents private copy from being mutated outside.
        /// During experimentation, I found that return new Dictionary<int, List<string>>(_Data) returned a shallow copy
        /// that did not enforce immutability.
        /// </summary>
        public Dictionary<int, List<string>> Roster 
        { 
            get
            {
                Dictionary<int, List<string>> ret = new Dictionary<int, List<string>>();
                foreach(KeyValuePair<int, List<string>> x in _Data)
                {
                    List<string> list = new List<string>();
                    ret.Add(x.Key, new List<string>(x.Value));
                }
                return ret;
            }
        }

        /// <summary>
        /// Add a new student to a grade list and sort the list of names within grade
        /// </summary>
        /// <param name="name">Student name</param>
        /// <param name="grade">Student grade</param>
        public void Add(string name, int grade)
        {
            ensureSchoolHasGrade(grade);
            _Data[grade].Add(name);
            _Data[grade].Sort();
        }

        /// <summary>
        /// Return list of students in specified grade.  If nobody on list, then return a List<string> object with no elements
        /// rather than throwing an exception.
        /// </summary>
        /// <param name="grade">Grade of interest</param>
        /// <returns>List of students in that grade</returns>
        public List<string> Grade(int grade)
        {
            ensureSchoolHasGrade(grade);
            return Roster[grade];
        }

        /// <summary>
        /// Ensure that the internal data dictionary has an entry for the specified grade.  If not, then add it with a new list.
        /// </summary>
        /// <param name="grade"></param>
        private void ensureSchoolHasGrade(int grade)
        {
            if (!_Data.ContainsKey(grade))
            {
                _Data.Add(grade, (new List<string>()));
            }
        }
    }
}
