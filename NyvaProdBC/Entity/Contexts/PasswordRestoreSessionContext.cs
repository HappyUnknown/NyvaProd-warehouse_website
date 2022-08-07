using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NyvaProdBC.Entity.Contexts
{
    public class PasswordRestoreSessionContext : DbContext
    {
        public PasswordRestoreSessionContext() : base("DefaultConnection") { }
        public DbSet<PasswordRestoreSession> PasswordSessions { get; set; }
    }
}