using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperExample
{
    public class MdlAddressType
    {
        public int AddressTypeId { get; set; }
        public string Address_TypeName { get; set; }
        public Nullable<long> BookId { get; set; }
    }
}
