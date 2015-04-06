using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetOperators
{
    public class Person : IEquatable<Person>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return string.Format("Firstname: {0}, Lastname: {1}, Age: {2}", Firstname, Lastname, Age);
        }

        public bool Equals(Person other)
        {
            if (other.Id.Equals(this.Id) && other.Firstname.Equals(this.Firstname, StringComparison.OrdinalIgnoreCase) && other.Age.Equals(this.Age) && other.Lastname.Equals(this.Lastname, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public static IEqualityComparer<Person> GetEqualityComparer()
        {
            return new PersonComparer();
        }

        class PersonComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            {
                if (x.Id.Equals(y.Id))
                {
                    return true;
                }
                return false;
            }

            public int GetHashCode(Person obj)
            {
                int hCode = obj.Id.GetHashCode();
                return hCode.GetHashCode();
            }
        }
    }




    class Program
    {
        public static List<Person> GetPerson1()
        {
            return new List<Person>() { 
            new Person(){Id=0,Firstname="arif", Lastname="khan", Age=30},
            new Person(){Id=0,Firstname="asif", Lastname="khan", Age=29},
                        new Person(){Id=2,Firstname="Sadiq", Lastname="khan", Age=2},
            new Person(){Id=3,Firstname="afreen", Lastname="khan", Age=30}
            };
        }
        public static List<Person> GetPerson2()
        {
            return new List<Person>() { 
            new Person(){Id=1,Firstname="Tarik", Lastname="khan", Age=26},
            new Person(){Id=2,Firstname="Mahad", Lastname="khan", Age=2},
            new Person(){Id=3,Firstname="afreen", Lastname="khan", Age=30},
            };
        }
        static void Main(string[] args)
        {
            List<Person> person1 = GetPerson1();
            List<Person> person2 = null;
            Console.WriteLine("entities to insert");
            foreach (var person in person1.Where(e => e.Id == 0))
            {
                Console.WriteLine(person.ToString());
            }

            Console.WriteLine("entities to delete");
            foreach (var person in person2.Except(person1, Person.GetEqualityComparer()))
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine("entities to update");
            foreach (var person in person1.Intersect(person2, Person.GetEqualityComparer()))
            {
                Person pCheck = person2.Where(p => p.Id == person.Id).Single();
                if (pCheck != null && !pCheck.Equals(person))
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }
    }
}
