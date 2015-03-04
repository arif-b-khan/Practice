using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Web.Script.Serialization;
using System.IO;
using ModelSample;

namespace JsonAndXmlValidation
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //XMLValidation();
            //SerializeJsonData();
            //JsonValidation();
        }

        private static void SerializeJsonData()
        {
            List<Person> retPerson = Person.GetPersonList();
            var jS = new JavaScriptSerializer();
            string result = jS.Serialize(retPerson);
            using (FileStream fs = new FileStream("JsonData.json", FileMode.Create, FileAccess.Write, FileShare.Read)) { 
                Encoding encoding = Encoding.ASCII;
               byte [] resByte =  encoding.GetBytes(result);
               fs.Write(resByte, 0, resByte.Length);
               fs.Close();
            }
        }

        private static void JsonValidation()
        {
            
            string jsonPath = "JsonData.json";
            string content = File.ReadAllText(jsonPath, Encoding.ASCII);
            var javaSerializer = new JavaScriptSerializer();
            var dic = javaSerializer.Deserialize<List<Person>>(content);
            foreach (var item in dic)
            {
                Console.WriteLine(item.ToString());    
            }
        }

        static void XMLValidation()
        {
            string xmlPath = "Person.xml";
            string xsdPath = "Person.xsd";

            XmlReader reader = XmlReader.Create(xmlPath);
            XmlDocument doc = new XmlDocument();
            doc.Schemas.Add("", xsdPath);
            doc.Load(reader);
            ValidationEventHandler handler = new ValidationEventHandler((obj, sn) => {
                switch (sn.Severity)
                {
                    case XmlSeverityType.Error:
                        Console.WriteLine(sn.Message);
                        break;
                    case XmlSeverityType.Warning:
                        Console.WriteLine(sn.Message);
                        break;
                }
            });
            doc.Validate(handler);
        }
    }
}
