using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocketApp
{
    public class TestService
    {
        private Timer _timer;
        WebSocketServer wssv;

        public TestService()
        {
            _timer = new Timer();

            _timer.Elapsed += _timer_Elapsed;

            wssv = new WebSocketServer("ws://localhost:8090");

        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            wssv.AddWebSocketService<Payment>("/Payment");
            wssv.Start();
        }
        public void Stop()
        {
            _timer.Stop();
            wssv.Stop();
        }


        public class Payment : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {

                var MessageData = e.Data;


                // Do Anything here



                string result = "result :- " + MessageData;

                // for specific user
                Sessions[ID].Context.WebSocket.Send(result);

                // For All Users

                Sessions.Broadcast(result);

            }
        }
    }
}
