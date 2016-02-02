using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookYourTable.DAL.Handlers;

namespace BookYourTable.BLL.Handlers
{
    public class TryHandler
    {
        TryHandlerDAL th = new TryHandlerDAL();

        public void hasam()
        {
            th.IstantiateDatabase();
        }
    }
}
