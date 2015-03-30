using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMapperExample
{
    public class MdlAddress
    {
        public int AddressId { get; set; }
        public string Address { get; set; }
        public List<MdlAddressType> CB_AddressType; 
    }
}
