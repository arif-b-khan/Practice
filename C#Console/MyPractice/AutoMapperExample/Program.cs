using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.CreateMap<Contact, MdlContact>().ForMember("CB_Addresses", a => a.Ignore()).ForMember(
                "CB_Numbers", n => n.MapFrom(m => m.Numbers)
                );
            Mapper.CreateMap<AddressType, MdlAddressType>();
            Mapper.CreateMap<Address, MdlAddress>().ForMember("Address", a => a.MapFrom(ad => ad.SAddress)).ForMember(md => md.CB_AddressType, ad => ad.MapFrom(adt => adt.AddressType));
            Mapper.CreateMap<Number, MdlNumber>().ForMember("Number", n => n.MapFrom(nm => nm.SNumber));
            Mapper.AssertConfigurationIsValid();
            List<MdlContact> result = Mapper.Map<List<MdlContact>>(GetAddress());

        }

        public static List<Contact> GetAddress()
        {

            List<Address> addressList = new List<Address>() {
            new Address(){AddressId = 1, SAddress="address1", AddressType= new List<AddressType>(){new AddressType(){AddressTypeId=1, BookId=1, Address_TypeName="Home"}}}
            };

            var contactList = new List<Contact>()
            {
               new Contact(){Firstname = "Arif", Lastname="Khan",
                   ContactId=1, Addresses= addressList, Numbers=new List<Number>{new Number(){NumberId=1, SNumber="9728801001", NumberType=1}}
            }
            };

            return contactList;
        }
    }
}
