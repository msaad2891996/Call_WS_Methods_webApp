using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Topshelf;

namespace WebSocketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var existCode = HostFactory.New(x =>
            {

                x.SetDisplayName("TestService");

                x.SetServiceName("TestService");

                x.SetInstanceName("TestService");

                x.SetDescription("TestService");


                x.Service<TestService>(sc =>
                {
                    sc.ConstructUsing(s => new TestService());

                    sc.WhenStarted(s => s.Start());

                    sc.WhenStopped(s => s.Stop());

                });



                x.RunAsLocalSystem();

            });


            existCode.Run();
        }
    }
}
