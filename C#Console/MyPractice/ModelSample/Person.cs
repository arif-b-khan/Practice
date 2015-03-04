using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelSample
{
   public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public static List<Person> GetPersonList()
        {
                       List<Person> person = new List<Person>();
                       person.Add(new Person() { FirstName = "Arif", LastName = "Khan", Age = 30 });
                       person.Add(new Person() { FirstName = "Asif", LastName = "Khan", Age = 30 });
                       person.Add(new Person() { FirstName = "Afreen", LastName = "Khatoon", Age = 26 });
                       person.Add(new Person() { FirstName = "Sameer", LastName = "Vaidya", Age = 30 });
                       return person;
        }
        public override string ToString()
        {
            return string.Format("FirstName: {0}, LastName: {1}, Age: {2}", FirstName, LastName, Age);
        }
    }
}
