using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyvaProdBC.Entity.Contexts
{
    public class NyvaUserContext : System.Data.Entity.DbContext
    {
        public NyvaUserContext() : base("DefaultConnection") { }
        public System.Data.Entity.DbSet<NyvaUser> Users { get; set; }
    }
}