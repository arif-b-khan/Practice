using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMapperExample
{
    public class AddressType
    {
        public int AddressTypeId { get; set; }
        public string Address_TypeName { get; set; }
        public Nullable<long> BookId { get; set; }
    }
}
