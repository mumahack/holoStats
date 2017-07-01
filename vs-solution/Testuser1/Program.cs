using Com.Apiomat.Frontend;
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
        static void Main(string[] args)
        {
            new Program().Test2();
            Console.ReadKey();
        }

        async void Test2()
        {
            User myUser = new User("johnUUU", "1,618");

            // configure datastore with user credentials
            Datastore.ConfigureWithCredentials(myUser);
            // and save it
            await myUser.SaveAsync();
        }
    }
}
