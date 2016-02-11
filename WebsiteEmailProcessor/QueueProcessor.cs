using BookYourTable.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WebsiteEmailProcessor
{
    public class QueueProcessor
    {
        private static MessageQueue msgQ = null;
        private static object lockObject = new Object();
        private static SmtpClient smtpClient;

        public static void StartProcessing()
        {
            initializeSmtpClient();

            String queuePath = @".\private$\SendEmailQueue";

            new SendEmailQueueService().InsureQueueExsists(queuePath);
            msgQ = new MessageQueue(queuePath);
            msgQ.Formatter = new XmlMessageFormatter();

            /*
            The MessagePropertyFilter used by the queue to filter the set 
            of properties it receives or peeks for each message. 

            This filter is a set of Boolean values restricting the message
            properties that the MessageQueue receives or peeks. When the MessageQueue
            receives or peeks a message from the server queue, it retrieves only those
            properties for which the MessageReadPropertyFilter value is true.

            https://msdn.microsoft.com/en-us/library/system.messaging.messagequeue.messagereadpropertyfilter(v=vs.110).aspx
            */
            msgQ.MessageReadPropertyFilter.SetAll();
            msgQ.ReceiveCompleted += new ReceiveCompletedEventHandler(msgQ_RecieveCompleted);
            msgQ.BeginReceive();
        }

        static void msgQ_RecieveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            lock (lockObject) //mutex
            {
                MailMessageWrapper mailMessageWrapper = (MailMessageWrapper)e.Message.Body;
                MailMessage msg = mailMessageWrapper.BuildMail();
                smtpClient.Send(msg);

                Debug.WriteLine("HASAN JEBENI SAKIC PIZDA MU MATERINA");
                Console.WriteLine("Message recieved: " + mailMessageWrapper.Body);
            }

            msgQ.BeginReceive();
        }

        static void initializeSmtpClient()
        {
            smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("nikola58tod@gmail.com", "gimnazija58");
            smtpClient.EnableSsl = true;
        }

    }
}
