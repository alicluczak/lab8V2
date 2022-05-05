using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8p2.Model
{
    class DbUczelnia : DbContext
    {
        public DbSet<Student> Studenci { get; set; }
        public DbUczelnia(): base(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Uczelnia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }

    }
}
