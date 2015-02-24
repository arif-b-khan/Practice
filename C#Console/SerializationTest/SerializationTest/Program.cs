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
        public Person()
        {
            id = 1;
        }
        [XmlIgnore]
        private int id;

        public string FirstName { get; set; }
        public string LastName { get; set; }
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


    class Program
    {
        static void Main(string[] args)
        {

            //BinarySerializationExample();
            //XmlSerializationExample();
            //JsonSerializationExample();
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
           Stream sr = new FileStream("JsonData.json", FileMode.Create, FileAccess.Write,FileShare.None);
            jSer.WriteObject(sr, json);
            sr.Close();
        }

        public static JsonData JsonDeSerialize()
        {
            DataContractJsonSerializer jSer = new DataContractJsonSerializer(typeof(JsonData));
            JsonData retData = (JsonData) jSer.ReadObject(new FileStream("JsonData.json", FileMode.Open, FileAccess.Read, FileShare.None));
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
