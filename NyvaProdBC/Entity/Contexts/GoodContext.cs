using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NyvaProdBC.Entity.Contexts
{
    /*
     * Created model with all-public properties and reachable constructor. Marked this model with a [Table("<TableName>")]
     * Created context, inheriting DbContext, containing public constructor, defined DbSet<<ModelType>> public property here
     * Context constructor inherrits from base, with connection string name argument
     */
    public class GoodContext : System.Data.Entity.DbContext
    {
        public GoodContext() : base("SomeeMangaConnection") { }
        public System.Data.Entity.DbSet<Good> Goods { get; set; }
    }
}