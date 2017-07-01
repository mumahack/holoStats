using Com.Apiomat.Frontend;
using Com.Apiomat.Frontend.AnycubicPrinterConnector;
using Com.Apiomat.Frontend.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testuser1
{
    class Program
    {
        private static bool printerReceived;
        private static IList<Printer> printers;
        private static double temperatur;

        static void Main(string[] args)
        {
            new Program().GetPrinters();
            //new Program().UpdateData();
            Console.ReadKey();
        }

        async void Test2()
        {
            User myUser = new User("johnWWW", "1,618");

            // configure datastore with user credentials
            Datastore.ConfigureWithCredentials(myUser);
            // and save it
            await myUser.SaveAsync();
        }

        private void UpdateData()
        {
            Program.printers[0].LoadToolHistoryAsync("order by time limit 1").ContinueWith(x => {
                Program.temperatur = x.Result[0].TemperatureActual;
            });
        }


        private void GetPrinters()
        {
            User myUser = new User("johnWWW", "1,618");

            // configure datastore with user credentials
            Datastore.ConfigureWithCredentials(myUser);

            Printer.GetPrintersAsync(null).ContinueWith(x => {
                Program.printerReceived = true;
                Program.printers = x.Result;
                UpdateData();
            });
        }

    }
}
