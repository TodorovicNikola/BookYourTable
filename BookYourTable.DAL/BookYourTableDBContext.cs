using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookYourTable.DAL
{
    public class BookYourTableDBContext : DbContext
    {
        public BookYourTableDBContext() : base("BookYourTable")
        {

        }
    }
}
