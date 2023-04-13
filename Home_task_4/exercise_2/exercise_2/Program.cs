using exercise_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string emails = "vitya.pomazan2001@gmail.com simple@example.com notwork@ must_work@ample.com dawdaw wdawdq rqw 21 1 ewe q eaWEawd sadasdasеdas t.oexample-indeed@strange-example.com a@asd viktor.pomazan\\@\\nure.ua bulgarian.butter.f.l.y@example.org";
            string[] validEmails;
            string[] invalidEmails;
            EmailValidator.GetEmails(emails, out validEmails, out invalidEmails);
            Printer.PrintEmails(emails, validEmails, invalidEmails);

        }
    }
}
