using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using User.Models;

namespace User.Data
{
    public class UserContext:DbContext
    {
        public UserContext() : base("UserContext")
        {

        }

        public DbSet<Person> People { get; set; }



    }
}