
/*Dependency
 * 
 * 
 * .Net framework 4.7.1 or Newer vserion
 * Install Newtonsoft.Json  and websocket-sharp-NonPreRelease latest version from Nuget package manger
 * install-package System.Management -Version 6.0.0
 * install package SuperSimpleTcp 2.6.0.8
 * if you want to use tcp connection for live feed then use MofslOpenApi_TCP library otherwise use MofslOpenApi library
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MofslOpenApi;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace TestMofslWebSocket
{
    class TestWebSocket
    {
        public static CMOFSLWebSocket socket = new CMOFSLWebSocket();

        static void Main(string[] args)
        {
            //You will get Your api key from website 
            string ApiKey = "";

            //Username and password is same as your trading account username and password
            string username = "";
            string password = "";
            string PanNoOrDob = ""; //client PAN no or Date of Birth --18/10/1998

            //set base url 
            string Base_Url = "https://openapi.motilaloswaluat.com";

            string BrowserName = "firebox";
            string BrowserVersion = "104.0.2";

            string VENDERINFO = username;
            // CMOFSLOPENAPI m_objconnect = new CMOFSLOPENAPI(ApiKey, "WEB", BrowserName, BrowserVersion);
            CMOFSLOPENAPI m_objconnect = new CMOFSLOPENAPI(ApiKey, "DESKTOP");



            m_objconnect.SetApiUrl(Base_Url);   

            string TOTP = "";
            //Login by Clientcode and password
            loginResponse m_objlogin = new loginResponse();
            m_objlogin = m_objconnect.login(username, password, PanNoOrDob, VENDERINFO, TOTP);

            //To see the output of Your request
            Console.WriteLine("------------Login Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(m_objlogin));
            Console.WriteLine("------------------------------------------------");

            

            Thread l_threadMarketwatch = new Thread(Marketwatch);
            Thread l_threadtrade = new Thread(trade);
            //l_threadMarketwatch.Start();
               l_threadtrade.Start();
            Console.ReadLine();
        }

        public static void Marketwatch()

        {

            socket.MessageReceived += Socket_MessageReceived1;
            socket.OnClose += Socket_OnClose;


            socket.connect();
     //Single Scrip Register
     //  socket.Register("BSE", "CASH", 532540);
     //   socket.UnRegister("BSE", "CASH", 532540);


     //register multiple scip



            ScripRegisterData scrip2 = new ScripRegisterData();
            scrip2.Exchange = "NSEFO";
            scrip2.ExchangeType = "derivatives";
            scrip2.scripcode = 39238;

            scrips l_objscrips = new scrips();
            l_objscrips.data.Add(scrip2);


            Registerstatus L_objRegisterstatus = new Registerstatus();
            L_objRegisterstatus = socket.RegisterMultiScrip(l_objscrips);

            Console.WriteLine(JsonConvert.SerializeObject(L_objRegisterstatus)); //for register multiple scrip
                                                                                 //   Console.WriteLine(JsonConvert.SerializeObject(socket.Register("NSE", "CASH", 11536)));


            //for register index scrip
            socket.IndexRegister("NSE");

            //Unregister index
            socket.IndexDeregister("NSE");


        }



        private static void Socket_OnClose(object sender, MessageEventArgs2 e)
        {
            Console.WriteLine(e.Message);
        }

        public static void trade()
        {
          
                CMOFSLWebSocket socket = new CMOFSLWebSocket();
                socket.TradeMessageReceived += Socket_TradeMessageReceived;
                socket.TradeOnClose += Socket_TradeOnClose;

                socket.Tradelogin();
                //  socket.OrderSubscribe();
                //socket.OrderUnsubscribe();
                socket.TradeSubscribe();
                socket.Tradelogout();
         
            //socket.TradeUnsubscribe();
            //socket.Tradelogout();

        }

        private static void Socket_TradeOnClose(object sender, MessageEventArgs2 e)
        {
            Console.WriteLine(e.Message);
        }

        private static void Socket_TradeMessageReceived(object sender, MessageEventArgs1 e)
        {
            Console.WriteLine(e.Message);
        }

        private static void Socket_MessageReceived1(object sender, MessageEventArgs1 e)
        {
            /*
             
             */



            string l_strtype = e.MessageType;
            Console.WriteLine(e.Message);


            switch (l_strtype)
            {

                case "LTP":
                    
                    break;

                case "MarketDepth":
                  

                    break;

                case "DAYOHLC":
                  
                    break;

                case "DPR":
              
                    break;
                case "Open_Interest":
                 


                    break;


            }
        }
    }
}

