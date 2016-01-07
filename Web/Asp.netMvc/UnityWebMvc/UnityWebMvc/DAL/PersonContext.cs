using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnityWebMvc.Models;
namespace UnityWebMvc.DAL
{
    public class PersonContext : DbContext
    {
        public PersonContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}