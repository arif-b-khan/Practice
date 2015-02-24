using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return string.Format("First Name: {0}, LastName: {1}, Age: {2}", FirstName, LastName, Age);
        }
    }

    class Employee : Person
    {
        public int EmpId { get; set; }
        public int DesignationId { get; set; }
    }

    class Designations
    {
        public int DesignationId { get; set; }
        public string Designation { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //SimpleEven();
            //PersonFilteringAnonymous();
            JoinExpression();
        }
        static void SimpleEven()
        {
            int[] myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = from arr1 in myArray
                         where arr1 % 2 == 0
                         where arr1 > 5
                         orderby arr1 ascending
                         select arr1;

            foreach (int item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void PersonFilteringAnonymous()
        {
            List<Person> persons = new List<Person>(){new Person(){FirstName= "Arif", LastName="Khan", Age=30},
                new Person(){FirstName= "Tarik", LastName="Khan", Age=25},
                new Person(){FirstName= "Afreen", LastName="Khan", Age=26},
                new Person(){FirstName= "A", LastName="Khan", Age=26},
                new Person(){FirstName= "A", LastName="Khan", Age=25}

            }
                ;

            var result = from per in persons
                         orderby per.FirstName, per.Age
                         select new { First = per.FirstName, Last = per.LastName };

            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }

        }

        static void JoinExpression()
        {
            var empList = new List<Employee>(){new Employee(){FirstName= "A", LastName="A", EmpId=1, DesignationId=1},
                new Employee(){FirstName= "B", LastName="B", EmpId=2, DesignationId=2},
                new Employee(){FirstName= "C", LastName="C", EmpId=3, DesignationId=2},
                new Employee(){FirstName= "D", LastName="D", EmpId=4, DesignationId=3},
                    new Employee(){FirstName= "D", LastName="D", EmpId=4, DesignationId=0}
            
            };

            var designationList = new List<Designations>(){
                new Designations(){DesignationId= 1, Designation="Soft Eng 1"},
                new Designations(){DesignationId= 2, Designation="Manager"},
new Designations(){DesignationId= 3, Designation="AVP"},

                };

            var result = from emp1 in empList
                         join des in designationList
                         on emp1.DesignationId equals des.DesignationId
                         into g
                         from newG in g.DefaultIfEmpty(default(Designations))
                         select new { FName =  emp1.FirstName, Designation = newG != null ? newG.Designation : "Null" };

            //var result1 = empList.Join(designationList, e1 => e1.DesignationId, d1 => d1.DesignationId, (e1, d1) => { });
            var result2 = empList.GroupJoin(designationList, e1 => e1.DesignationId, d1 => d1.DesignationId, (emp, des) => des.DefaultIfEmpty(default(Designations)).SelectMany(d => ));

            foreach (var item in result2)
            {
                //Console.WriteLine("FirstName: {0}, Designation: {1}", item.FName, item.Designation);
            }

        }
    }
}
