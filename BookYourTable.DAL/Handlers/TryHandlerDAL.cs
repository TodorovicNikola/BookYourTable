using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BookYourTable.DAL.Handlers
{
    public class TryHandlerDAL
    {
        BookYourTableDBContext dbC = new BookYourTableDBContext();
        
        public void IstantiateDatabase()
        {

            Debug.WriteLine("Message is wrin");

            var hasan = dbC.Users;
            foreach (var has in hasan)
            {
                Debug.WriteLine("Message is written");
            }
        }
    }
}
