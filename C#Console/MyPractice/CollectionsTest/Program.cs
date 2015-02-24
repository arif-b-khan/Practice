using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTest
{
    [Serializable]
    public class Person : IComparable<Person>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return string.Format("EmployeeId = {0}, FirstName = {1}", Id, FirstName);
        }

        public int CompareTo(Person other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.FirstName.CompareTo(y.FirstName);
       }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new List<Person>()
            {                new Person(){Id = 1, FirstName="Mahad", LastName="B"},
                new Person(){Id = 4, FirstName="Arif", LastName="D"},
                new Person(){Id = 3, FirstName="Asif", LastName="E"},
                new Person(){Id = 2, FirstName="Tarik", LastName="A"}

            };
            
            PrintList(person);
            person.Sort((p1, p2) => { return p1.LastName.CompareTo(p2.LastName); });
            PrintList(person);
            
        }

        private static void PrintList(List<Person> person)
        {
            foreach (var p1 in person)
            {
                Console.WriteLine(p1.ToString());
            }
        }

    }
}
