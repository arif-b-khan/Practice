using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationTest
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    [DataContract]
    public class JsonData
    {
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
    [Serializable]
    public class Order
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlIgnore]
        public bool IsDirty { get; set; }
        [XmlArray("Lines")]
        [XmlArrayItem("OrderLines")]
        public List<OrderLine> OrderLines { get; set; }
    }

    [Serializable]
    public class VIPOrder : Order
    {
        public string Description { get; set; }
    }

    [Serializable]
    public class OrderLine
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlAttribute]
        public int Amount { get; set; }
        [XmlElement("OrderedProduct")]
        public Product Product { get; set; }
    }
    [Serializable]
    public class Product
    {
        [XmlAttribute]
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    class Program
    {
        private static Order CreateOrder()
        {
            Product p1 = new Product { ID = 1, Description = "p2", Price = 9 };
            Product p2 = new Product { ID = 2, Description = "p3", Price = 6 };
            Order order = new VIPOrder
            {
                ID = 4,
                Description = "Order for John Doe. Use the nice giftwrap",
                OrderLines = new List<OrderLine>
                {
                new OrderLine { ID = 5, Amount = 1, Product = p1},
                new OrderLine { ID = 6 ,Amount = 10, Product = p2},
                }
            };
            return order;
        }
        static void Main(string[] args)
        {

            //BinarySerializationExample();
            //XmlSerializationExample();
            //JsonSerializationExample();
            HeirarchicalSerializationExample();
        }

        private static void HeirarchicalSerializationExample()
        {
            Order order = CreateOrder();
            var xmlSerializer = new XmlSerializer(typeof(Order), new Type[]{typeof(VIPOrder)});
            var writer = new StringWriter();
            xmlSerializer.Serialize(writer, order);
           string result =  writer.ToString();
           Console.WriteLine(result);
        }

        public static void JsonSerializationExample()
        {
            JsonData data = new JsonData() { FirstName = "Arif", LastName = "Khan" };
            JsonSerialization(data);
            JsonData retData = JsonDeSerialize();
        }

        public static void JsonSerialization(JsonData json)
        {
            DataContractJsonSerializer jSer = new DataContractJsonSerializer(typeof(JsonData));
            Stream sr = new FileStream("JsonData.json", FileMode.Create, FileAccess.Write, FileShare.None);
            jSer.WriteObject(sr, json);
            sr.Close();
        }

        public static JsonData JsonDeSerialize()
        {
            DataContractJsonSerializer jSer = new DataContractJsonSerializer(typeof(JsonData));
            JsonData retData = (JsonData)jSer.ReadObject(new FileStream("JsonData.json", FileMode.Open, FileAccess.Read, FileShare.None));
            return retData;
        }

        public static void XmlSerializationExample()
        {
            Person perSer = new Person() { FirstName = "Arif", LastName = "Khan" };
            XmlSerialization(perSer);
            Person retPer = XmlDeserialization();
        }

        private static Person XmlDeserialization()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            StreamReader writer = new StreamReader("Person.xml");
            Person person = (Person)serializer.Deserialize(writer);
            writer.Close();
            return person;
        }

        public static void XmlSerialization(Person person)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            StreamWriter writer = new StreamWriter("Person.xml");
            serializer.Serialize(writer, person);
            writer.Close();
        }

        public static void BinarySerializationExample()
        {
            Person perSer = new Person() { FirstName = "Arif", LastName = "Khan" };
            BinarySerialization(perSer);
            Person serobj = BinaryDeSerialize();

        }
        public static void BinarySerialization(Person person)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream str = new FileStream("Person.bin", FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            formatter.Serialize(str, person);
            str.Close();
        }

        public static Person BinaryDeSerialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream str = new FileStream("Person.bin", FileMode.Open, FileAccess.Read, FileShare.None);
            Person retPerson = (Person)formatter.Deserialize(str);
            str.Close();
            return retPerson;
        }
    }
}
