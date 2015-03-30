using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMapperExample
{
    public class Address
    {
        public int AddressId { get; set; }
        public string SAddress { get; set; }
        public List<AddressType> AddressType;
    }
}
