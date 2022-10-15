using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace signUpLoginEFMvc.Models
{
    public class signupContext : DbContext
    {

        public DbSet<SignUp> signUps { get; set; }  
    }
}