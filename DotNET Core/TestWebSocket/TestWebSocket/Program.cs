
/*Dependency
 * 
 * 
 * .Net Core 3.1 or Newer vserion
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
    <PackageReference Include="SuperSimpleTcp" Version="2.6.0.8" />
    <PackageReference Include="System.Management" Version="6.0.0" />
    <PackageReference Include="WebSocket4Net" Version="0.15.2" />
 * if you want to use tcp connection for live feed then use Connect("TCP") library otherwise need to put web(Connect("WEB");)
   
 */


using System;
using System.Net.Sockets;
using System.Threading;
using MofslOpenApi;
using Newtonsoft;
using Newtonsoft.Json;

namespace TestWebSocket
{
    internal class Program
    {
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
            //  CMOFSLOPENAPI m_objconnect = new CMOFSLOPENAPI(ApiKey, "DESKTOP");
            //DESKTOP OR WEB (in case web BrowserName, BrowserVersion)
            CMOFSLWebSocket l_objCMOFSLWebSocket = new CMOFSLWebSocket(ApiKey, "DESKTOP");

            l_objCMOFSLWebSocket.SetApiUrl(Base_Url);
            Console.WriteLine("ENTER TOTP: ");
            string l_strTOTP = "";


            //In case of Otp take otp from user
            l_strTOTP = Console.ReadLine();
            var l_data= l_objCMOFSLWebSocket.login(username, password, PanNoOrDob, VENDERINFO, l_strTOTP);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_data));
            Console.WriteLine("-------------------------------------------------------------------------");

          //  //In case of Otp take otp from user
          //  string read = Console.ReadLine();


          //  VerifyotpResponse l_objVerifyotpResponse = new VerifyotpResponse();
          //  l_objVerifyotpResponse = l_objCMOFSLWebSocket.VerifyOtp(read);


          //  //To see the output of Your request
          //  Console.WriteLine("------------VerifyOtp Output----------------------------------");
          //  Console.WriteLine(JsonConvert.SerializeObject(l_objVerifyotpResponse));
          //  Console.WriteLine("------------------------------------------------");

          //  ResendOtpResposne l_objResendOtpResposne = new ResendOtpResposne();
          //  l_objResendOtpResposne = l_objCMOFSLWebSocket.ResendOtp();


          ////  To see the output of Your request
          //  Console.WriteLine("------------Resend Otp Output----------------------------------");
          //  Console.WriteLine(JsonConvert.SerializeObject(l_objResendOtpResposne));
          //  Console.WriteLine("------------------------------------------------");




            l_objCMOFSLWebSocket.OnError += L_objCMOFSLWebSocket_OnError;
        //    l_objCMOFSLWebSocket.OnOpen += L_objCMOFSLWebSocket_OnOpen;
            l_objCMOFSLWebSocket.OnClose += L_objCMOFSLWebSocket_OnClose;
            l_objCMOFSLWebSocket.MessageReceived += L_objCMOFSLWebSocket_MessageReceived;
            //Connection Type - TCP or WEB
            l_objCMOFSLWebSocket.Connect("TCP");
            l_objCMOFSLWebSocket.IndexSubscriber("NSE");
            //l_objCMOFSLWebSocket.IndexUnSubscriber("NSE");
            l_objCMOFSLWebSocket.IndexUnSubscriber("BSE");
            Console.WriteLine(l_objCMOFSLWebSocket.Register("BSE", "CASH", 532540));
            Console.WriteLine("----------------------------");
            Console.WriteLine(l_objCMOFSLWebSocket.UnRegister("BSE", "CASH", 532540));


            ScripRegisterData scrip1 = new ScripRegisterData();
            scrip1.Exchange = "BSE";
            scrip1.ExchangeType = "CASH";
            scrip1.scripcode = 532540;


            ScripRegisterData scrip2 = new ScripRegisterData();
            scrip2.Exchange = "NSEFO";
            scrip2.ExchangeType = "DERIVATIVES";
            scrip2.scripcode = 11536;

            scrips l_objscrips = new scrips();
            l_objscrips.data.Add(scrip2);
            l_objscrips.data.Add(scrip1);
            

            Registerstatus L_objRegisterstatus = new Registerstatus();
            L_objRegisterstatus = l_objCMOFSLWebSocket.RegisterMultiScrip(l_objscrips);

            Console.WriteLine(JsonConvert.SerializeObject(L_objRegisterstatus)); //for register multiple scrip
                                                                                 //   Console.WriteLine(JsonConvert.SerializeObject(socket.Register("NSE", "CASH", 11536)));



            l_objCMOFSLWebSocket.TradeOnClose += L_objCMOFSLWebSocket_TradeOnClose;
            l_objCMOFSLWebSocket.TradeOnError += L_objCMOFSLWebSocket_TradeOnError;
            l_objCMOFSLWebSocket.TradeMessageReceived += L_objCMOFSLWebSocket_TradeMessageReceived;
            l_objCMOFSLWebSocket.Tradelogin();
            l_objCMOFSLWebSocket.OrderSubscribe();
            l_objCMOFSLWebSocket.OrderUnsubscribe();
            l_objCMOFSLWebSocket.TradeSubscribe();
            l_objCMOFSLWebSocket.TradeUnsubscribe();
          //  l_objCMOFSLWebSocket.Tradelogout();
            Console.ReadLine();
        }

        private static void L_objCMOFSLWebSocket_TradeMessageReceived(object sender, MessageEventArgs1 e)
        {
            Console.WriteLine("L_objCMOFSLWebSocket_TradeMessageReceived"+e.Message);
        }

        private static void L_objCMOFSLWebSocket_TradeOnError(object sender, MessageEventArgs2 e)
        {
            Console.WriteLine("L_objCMOFSLWebSocket_TradeOnError"+e.Message);
        }

        private static void L_objCMOFSLWebSocket_TradeOnClose(object sender, MessageEventArgs2 e)
        {
            Console.WriteLine("L_objCMOFSLWebSocket_TradeOnClose"+e.Message);
        }

        private static void L_objCMOFSLWebSocket_MessageReceived(object sender, MessageEventArgs1 e)
        {
            Console.WriteLine("L_objCMOFSLWebSocket_MessageReceived : "+e.Message);
        }

        private static void L_objCMOFSLWebSocket_OnClose(object sender, MessageEventArgs2 e)
        {
            Console.WriteLine("L_objCMOFSLWebSocket_OnClose "+e.Message);
        }

        private static void L_objCMOFSLWebSocket_OnOpen(object sender, MessageEventArgs2 e)
        {
            Console.WriteLine("L_objCMOFSLWebSocket_OnOpen "+e.Message);
        }

        private static void L_objCMOFSLWebSocket_OnError(object sender, MessageEventArgs2 e)
        {
            Console.WriteLine("L_objCMOFSLWebSocket_OnError "+e.Message);
        }
    }
}
