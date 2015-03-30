using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperExample
{
    public class MdlContact
    {
        public long ContactId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<MdlAddress> CB_Addresses { get; set; }
        public List<MdlNumber> CB_Numbers { get; set; }
    }
}
