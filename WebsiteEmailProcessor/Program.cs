using BookYourTable.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebsiteEmailProcessor
{
    class Program
    {
        

        static void Main(string[] args)
        {

            QueueProcessor.StartProcessing();
            while (Console.ReadKey().Key != ConsoleKey.Q)
            {
                Thread.Sleep(0);
            }


        }

       
    }
}
