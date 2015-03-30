using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperExample
{
    public class Contact
    {
        public long ContactId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Number> Numbers { get; set; }
    }
}
