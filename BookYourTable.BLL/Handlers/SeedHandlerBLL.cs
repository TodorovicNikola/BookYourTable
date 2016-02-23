using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookYourTable.DAL.Handlers;

namespace BookYourTable.BLL.Handlers
{
    public class SeedHandlerBLL
    {
        SeedHandler _seedHandler = new SeedHandler();

        public void SeedDB()
        {
            _seedHandler.SeedDB();
        }
    }
}
