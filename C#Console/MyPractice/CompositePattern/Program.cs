using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            int golds = 1023;
            var arif = new Person { Name = "Arif" };
            var afreen = new Person { Name = "Afreen" };
            var developers = new Group { Name = "Developer", Members = { new Person { Name = "Ankit" }, new Person { Name = "Niyati" } } };
            var groupList = new Group { Name = "All Members", Members = { developers, arif, afreen } };
            groupList.Gold = golds;
            groupList.Statistic();
        }
    }

    class Person : Party
    {
        public string Name { get; set; }
        public int Gold { get; set; }

        public void Statistic()
        {
            Console.WriteLine("Name: {0} Gold: {1}", Name, Gold);
        }
    }

    class Group : Party
    {
        public Group()
        {
            Members = new List<Party>();
        }
        public string Name { get; set; }
        public List<Party> Members { get; set; }


        public int Gold
        {
            get
            {
                int goldCount = 0;
                foreach (var party in Members)
                {
                    goldCount += party.Gold;
                }
                return goldCount;
            }
            set
            {
                int shareOfGold = value / Members.Count;
                int leftOver = value % Members.Count;

                foreach (var member in Members)
                {
                    member.Gold += shareOfGold + leftOver;
                    leftOver = 0;
                }
            }
        }

        public void Statistic()
        {
            Console.WriteLine("---"+Name);
            foreach (var member in Members)
                member.Statistic();
        }
    }

    internal interface Party
    {
        int Gold { get; set; }
        void Statistic();
    }
}
