
/*Dependency
 * Add all dll to your reference to your application
 * 
 *   <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
     <PackageReference Include="System.Management" Version="8.0.0" />
 * 
 * 
 * location should be on while using this library
 */

using System;
using MofslOpenApi;
using Newtonsoft.Json;
namespace ExampleMofslConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {

            //You will get Your api key from website 

            //You will get Your api key from website 
            string ApiKey = "";

            //Username and password is same as your trading account username and password
            string username = "";
            string password = "";
            string PanNoOrDob = ""; //client PAN no or Date of Birth --18/10/1998

            string BrowserName = "firebox";
            string BrowserVersion = "104.0.2";


            CMOFSLOPENAPI m_objconnect = new CMOFSLOPENAPI(ApiKey, "web", BrowserName, BrowserVersion);

            //in case of Desktop-- CMOFSLOPENAPI m_objconnect = new CMOFSLOPENAPI(ApiKey, "Desktop");

            //Enter base url 
            string Base_Url = "https://openapi.motilaloswal.com";

            m_objconnect.SetApiUrl(Base_Url);



            ////Username and password is same as your trading account username and password
           
            string vendorinfo = username;
            //Login by Clientcode and password
            /*
             * NOTE -
             TOTP – Send the 6 digit OTP on login using any Authenticator App.
              OR
              OTP – do not pass the otp parameter or pass it as blank.
             * 
             */
            Console.WriteLine("ENTER TOTP: ");
            string l_strTOTP = "";


            //In case of Otp take otp from user
            l_strTOTP = Console.ReadLine();

            loginResponse m_objlogin = new loginResponse();
            m_objlogin = m_objconnect.login(username, password, PanNoOrDob, vendorinfo, l_strTOTP);

            //m_objlogin = m_objconnect.login(username, password, PanNoOrDob, vendorinfo,l_strTOTP);

            string ClientId = "";
            //To see the output of Your request
            Console.WriteLine("------------Login Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(m_objlogin));
            Console.WriteLine("------------------------------------------------");


            //In case of Otp take otp from user
            //string read = Console.ReadLine();


            //    VerifyotpResponse l_objVerifyotpResponse = new VerifyotpResponse();
            //    l_objVerifyotpResponse = m_objconnect.VerifyOtp(read);


            //    To see the output of Your request
            //Console.WriteLine("------------VerifyOtp Output----------------------------------");
            //    Console.WriteLine(JsonConvert.SerializeObject(l_objVerifyotpResponse));
            //    Console.WriteLine("------------------------------------------------");



                //ResendOtpResposne l_objResendOtpResposne = new ResendOtpResposne();
                //l_objResendOtpResposne = m_objconnect.ResendOtp();


                //To see the output of Your request
                //Console.WriteLine("------------Resend Otp Output----------------------------------");
                //Console.WriteLine(JsonConvert.SerializeObject(l_objResendOtpResposne));
                //Console.WriteLine("------------------------------------------------");





                //// VerifyotpResponse l_objVerifyotpResponse = new VerifyotpResponse();
                //l_objVerifyotpResponse = m_objconnect.VerifyOtp("");


                ////To see the output of Your request
                //Console.WriteLine("------------VerifyOtp Output----------------------------------");
                //Console.WriteLine(JsonConvert.SerializeObject(l_objVerifyotpResponse));
                //Console.WriteLine("------------------------------------------------");


                ////To see the output of Your request
                //Console.WriteLine("------------PlaceOrder Output----------------------------------");
                //Console.WriteLine(JsonConvert.SerializeObject(m_objconnect.PlaceOrder(orderinfo)));
                //Console.WriteLine("-----------------------------------------------------------------");


                //    To see Your profile
                GetProfileResponse GetProfile = new GetProfileResponse();
               GetProfile = m_objconnect.GetProfile(ClientId);

         //   To see the output of Your request
            Console.WriteLine("------------GetProfile Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(GetProfile));
            Console.WriteLine("-----------------------------------------------------------------");

            //-----------------------------------------------------
            //  PlaceOrder Rules
            PlaceOrderInfo orderinfo = new PlaceOrderInfo();
            orderinfo.exchange = "NSE";
            orderinfo.symboltoken = 11536;
            orderinfo.buyorsell = "BUY";
            orderinfo.ordertype = "LIMIT";
            orderinfo.producttype = "DELIVERY";
            orderinfo.orderduration = "DAY";
            orderinfo.quantityinlot = 1;

            orderinfo.price = 0;
            orderinfo.triggerprice = 0;

            orderinfo.disclosedquantity = 0;
            orderinfo.amoorder = "N";
            orderinfo.algoid = "";
            orderinfo.goodtilldate = "";
            orderinfo.tag = "";



            //PlaceOrderResponse PlaceOrderResponse = new PlaceOrderResponse();
            //PlaceOrderResponse = m_objconnect.PlaceOrder(orderinfo);

            //---------------------------------

            //////Modify Order rules
            ModifyOrder ModifyOrder = new ModifyOrder();
            ModifyOrder.uniqueorderid = ""; //Order id is Your uniqueOrder id 
            ModifyOrder.newordertype = "";
            ModifyOrder.neworderduration = "";
            ModifyOrder.newquantityinlot = 8;
            ModifyOrder.newdisclosedquantity = 0;
            ModifyOrder.newprice = 255;
            ModifyOrder.newtriggerprice = 0;
            ModifyOrder.newgoodtilldate = "";
            ModifyOrder.lastmodifiedtime = "";
            ModifyOrder.qtytradedtoday = 0;

            ModifyOrderResponse ModifyOrderResponse = new ModifyOrderResponse();
            ModifyOrderResponse = m_objconnect.ModifyOrder(ModifyOrder);

            Console.WriteLine("------------ModifyOrder Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(ModifyOrderResponse));
            Console.WriteLine("-----------------------------------------------------------------");


            //format of dateandtime --  15-Nov-2022 15:16:02 format 
            string l_datetime = "28-Aug-2024 15:16:02";
            // //to cancel your order you must  provide your order uniqueOrderid
            string uniqueOrderid = "28000041111111";
            CancelOrderResponse CancelOrderResponse = new CancelOrderResponse();
            CancelOrderResponse = m_objconnect.CancelOrder(uniqueOrderid, ClientId);

            Console.WriteLine("------------ CancelOrder Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(CancelOrderResponse));
            Console.WriteLine("-----------------------------------------------------------------");

            OrderBookResponse OrderBookResponse = new OrderBookResponse();
            OrderBookResponse = m_objconnect.GetOrderBook(l_datetime,ClientId);


            Console.WriteLine("------------ OrderBook Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(OrderBookResponse));
            Console.WriteLine("-----------------------------------------------------------------");

            TradeBookResponse l_TradeBookResponses = new TradeBookResponse();
            l_TradeBookResponses = m_objconnect.GetTradeBook(ClientId);

            Console.WriteLine("------------GetTradeBook Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_TradeBookResponses));
            Console.WriteLine("------------------------------------------------");



            //////to see your Position data
            PositionResponse PositionResponse = new PositionResponse();
            PositionResponse = m_objconnect.GetPosition(ClientId);

            Console.WriteLine("------------ Position Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(PositionResponse));
            Console.WriteLine("---------------------------------------------------------------");

         
            //To see your DPHolding data
            DPHoldingResponse DPHoldingResponse = new DPHoldingResponse();
            DPHoldingResponse = m_objconnect.GetDPHolding(ClientId);

            Console.WriteLine("------------DPHolding Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(DPHoldingResponse));
            Console.WriteLine("-----------------------------------------------------------------");

            //--------
            
            OrderBookResponse l_OrderBookResponsee = new OrderBookResponse();
            l_OrderBookResponsee = m_objconnect.Getorderdetailbyunqueorderid("28000021111111", ClientId);

            Console.WriteLine("------------Getorderdetailbyunqueorderid Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_OrderBookResponsee));
            Console.WriteLine("------------------------------------------------");

            TradeBookResponse l_TradeBookResponse = new TradeBookResponse();
            l_TradeBookResponse = m_objconnect.Gettradedetailbyuniqueorderid("28000021111111", ClientId);

            Console.WriteLine("------------Gettradedetailbyuniqueorderid Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_TradeBookResponse));
            Console.WriteLine("------------------------------------------------");

            PositionConversion PositionConversion = new PositionConversion();
            PositionConversion.exchange = "NSE";
            PositionConversion.scripcode = 1660;
            PositionConversion.quantity = 100;
            PositionConversion.oldproduct = "NORMAL";
            PositionConversion.newproduct = "VALUEPLUS";

            PositionConversionResponse PositionConversionResponse = new PositionConversionResponse();
            PositionConversionResponse = m_objconnect.PositionConversion(PositionConversion);

            Console.WriteLine("------------Position Conversion Output------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(PositionConversionResponse));
            Console.WriteLine("-----------------------------------------------------------------");


            //---------------------------


            LTPData LTPDatadata = new LTPData();

            LTPDatadata.exchange = "BSE";

            LTPDatadata.scripcode = 500219;
            LTPDataResponse LTPDataResponse = new LTPDataResponse();
            LTPDataResponse = m_objconnect.GetLtpData(LTPDatadata);

            Console.WriteLine("------------ LTP Data Output------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(LTPDataResponse));
            Console.WriteLine("-----------------------------------------------------------------");



        //    string Exchange_Name = "NSEFO";
            //ExchangeDataResponse ExchangeDataResponse = new ExchangeDataResponse();
            //ExchangeDataResponse = m_objconnect.GetInstrumentFile(Exchange_Name,"ClientCode");

            //Console.WriteLine("------------Instrument File Output----------------------------------");
            //Console.WriteLine(JsonConvert.SerializeObject(ExchangeDataResponse));
            //Console.WriteLine("-----------------------------------------------------------------");


            ////
            //To see your orderbook data
            //format of dateandtime --  15-Nov-2022 15:16:02 format 
            //String f_strdateandtime = "20-Dec-2022 15:16:02";


            //////to see your Position data
            ////PositionResponse PositionResponse = new PositionResponse();
            ////PositionResponse = m_objconnect.GetPosition();

            ////Console.WriteLine("------------ Position Output----------------------------------");
            ////Console.WriteLine(JsonConvert.SerializeObject(PositionResponse));
            ////Console.WriteLine("-----------------------------------------------------------------");



            ////PlaceOrder Rules 
            //PlaceOrderInfo orderinfo = new PlaceOrderInfo();
            //orderinfo.exchange = "BSE";
            //orderinfo.symboltoken = 532540;
            //orderinfo.buyorsell = "BUY";
            //orderinfo.ordertype = "MARKET";
            //orderinfo.producttype = "DELIVERY";
            //orderinfo.orderduration = "DAY";
            //orderinfo.quantityinlot = 1;
            //orderinfo.price = 0;
            //orderinfo.triggerprice = 0;

            //orderinfo.disclosedquantity = 0;
            //orderinfo.amoorder = "N";
            //orderinfo.algoid = "";
            //orderinfo.goodtilldate = "";
            //orderinfo.tag = "";


            //PlaceOrderResponse PlaceOrderResponse = new PlaceOrderResponse();
            //PlaceOrderResponse = m_objconnect.PlaceOrder(orderinfo);

            ////To see the output of Your request
            //Console.WriteLine("------------PlaceOrder Output----------------------------------");
            //Console.WriteLine(JsonConvert.SerializeObject(PlaceOrderResponse));
            //Console.WriteLine("-----------------------------------------------------------------");

            IndexltpdataRequest l_objIndexltpdataRequest = new IndexltpdataRequest();
            l_objIndexltpdataRequest.scripcode = "26000";
            l_objIndexltpdataRequest.exchangename = "NSE";
            IndexltpdataResponse l_objIndexltpdataResponse = new IndexltpdataResponse();
            l_objIndexltpdataResponse = m_objconnect.Getindexltpdata(l_objIndexltpdataRequest);
            //To see the output of Your request
            Console.WriteLine("------------Getindexltpdata Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_objIndexltpdataResponse));
            Console.WriteLine("-----------------------------------------------------------------");


         


            //PositionConversion Rules
         
            //

            ReportMargininsummary ReportMargininsummary = new ReportMargininsummary();
            ReportMargininsummary = m_objconnect.GetReportMarginSummary(ClientId);

            Console.WriteLine("------------ ReportMarginsummary Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(ReportMargininsummary));
            Console.WriteLine("-----------------------------------------------------------------");



            ReportMarginindetail ReportMarginindetail = new ReportMarginindetail();
            ReportMarginindetail = m_objconnect.GetReportMarginDetail(ClientId);

            Console.WriteLine("------------ReportMargindetail  Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(ReportMarginindetail));
            Console.WriteLine("-----------------------------------------------------------------");







            //  In Instrument file function provide your exchange name

            //string Exchange_Name = "NSE";
            //ExchangeDataResponse ExchangeDataResponse = new ExchangeDataResponse();
            //ExchangeDataResponse = m_objconnect.GetInstrumentFile("hhhh", Exchange_Name);

            //Console.WriteLine("------------Instrument File Output----------------------------------");
            //Console.WriteLine(JsonConvert.SerializeObject(ExchangeDataResponse));
            //Console.WriteLine("-----------------------------------------------------------------");




            //  OrderBookResponse l_OrderBookResponsee = new OrderBookResponse();
            l_OrderBookResponsee = m_objconnect.Getorderdetailbyunqueorderid("1700001T024312",ClientId);

            Console.WriteLine("------------Getorderdetailbyunqueorderid Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_OrderBookResponsee));
            Console.WriteLine("------------------------------------------------");

          //  TradeBookResponse l_TradeBookResponse = new TradeBookResponse();
            l_TradeBookResponse = m_objconnect.Gettradedetailbyuniqueorderid("1700004T024312", ClientId);

            Console.WriteLine("------------Gettradedetailbyuniqueorderid Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_TradeBookResponse));
            Console.WriteLine("------------------------------------------------");

            //

            //if you want orderbook from sp

            //Logout
          

            //This API is used to get Brokerage and Other Charges Detail 
            string Clientcode = "";//in case of dealer else pass blank
            string exchangename = "BSE";
            string series = "EQ";

            brokeragedetail l_Objbrokeragedetail = new brokeragedetail();

            l_Objbrokeragedetail = m_objconnect.Getbrokeragedeatil(Clientcode, exchangename, series);


            Console.WriteLine("------------ brokeragedetail Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_Objbrokeragedetail));
            Console.WriteLine("-----------------------------------------------------------------");
            //
            LogoutResponse m_objLogoutResponse = new LogoutResponse();
            m_objLogoutResponse = m_objconnect.Logout(ClientId);

            Console.WriteLine("------------Logout Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(m_objLogoutResponse));
            Console.WriteLine("------------------------------------------------");


            Console.ReadLine();
        }
    }
}
