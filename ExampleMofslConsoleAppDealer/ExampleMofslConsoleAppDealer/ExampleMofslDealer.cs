

/*Add all dll to your reference to your application
 * .Net framework 4.7.1 or Newer version --install-package System.Management -Version 6.0.0
   install Newtonsoft.Json latest
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MofslOpenApi;
using Newtonsoft.Json;

namespace ExampleMofslConsoleAppDealer
{
    class ExampleMofslDealer
    {
        static void Main(string[] args)
        {

            //You will get Your api key from website 
            string ApiKey = "";

            //Username and password is same as your trading account username and password
            string username = "";
            string password = "";
            string PanNoOrDob = ""; //client PAN no or Date of Birth --18/10/1998
            string vendorinfo = "";

            string SourceId = "Web"; //Web Or Desktop --
                                     //if Your SourceId is web then pass browsername and browser version in case of Desktop you dont need to passanyting

            string BrowserName = "firebox";
            string BrowserVersion = "104.0.2";
            CMOFSLOPENAPI m_objconnect = new CMOFSLOPENAPI(ApiKey, "web", BrowserName, BrowserVersion);


            //initialize MofslOpenApi using Apikey
         //   CMOFSLOPENAPI m_objconnect = new CMOFSLOPENAPI(ApiKey, "Desktop");

            //Enter base url 
            string Base_Url = "https://uatopenapi.motilaloswal.com";
            m_objconnect.SetApiUrl(Base_Url);

            //Login by Clientcode and password
            loginResponse m_objlogin = new loginResponse();
            m_objlogin = m_objconnect.login(username, password, PanNoOrDob, vendorinfo);



            //To see the output of Your request
            Console.WriteLine("------------Login Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(m_objlogin));
            Console.WriteLine("------------------------------------------------");


            //To see Your client profile you must provide the clientcode of your client
            string clientcode = "";
            GetProfileResponse GetProfile = new GetProfileResponse();
            GetProfile = m_objconnect.GetProfile(clientcode);

            //To see the output of Your request
            Console.WriteLine("------------GetProfile Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(GetProfile));
            Console.WriteLine("-----------------------------------------------------------------");



            //PlaceOrder Rules 
            PlaceOrderInfo orderinfo = new PlaceOrderInfo();
            orderinfo.clientcode = clientcode;
            orderinfo.exchange = "NSE";
            orderinfo.symboltoken = 1660;
            orderinfo.buyorsell = "BUY";
            orderinfo.ordertype = "LIMIT";
            orderinfo.producttype = "NORMAL";
            orderinfo.orderduration = "GTD";
            orderinfo.quantityinlot = 1;

            orderinfo.price = 235.35;
            orderinfo.triggerprice = 0;

            orderinfo.disclosedquantity = 0;
            orderinfo.amoorder = "N";
            orderinfo.algoid = "";
            orderinfo.goodtilldate = "25-Feb-2022";
            orderinfo.tag = "";

            PlaceOrderResponse PlaceOrderResponse = new PlaceOrderResponse();
            PlaceOrderResponse = m_objconnect.PlaceOrder(orderinfo);

            //To see the output of Your request
            Console.WriteLine("------------PlaceOrder Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(PlaceOrderResponse));
            Console.WriteLine("-----------------------------------------------------------------");


            //Modify Order rules
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

            //to cancel your order please provide your order uniqueOrderid
            string uniqueOrderid = "1700008T024312";
            CancelOrderResponse CancelOrderResponse = new CancelOrderResponse();
            CancelOrderResponse = m_objconnect.CancelOrder(clientcode, uniqueOrderid);

            Console.WriteLine("------------ CancelOrder Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(CancelOrderResponse));
            Console.WriteLine("-----------------------------------------------------------------");

            //To see Your client OrderBook data you must provide the clientcode of your client
            OrderBookResponse OrderBookResponse = new OrderBookResponse();
            OrderBookResponse = m_objconnect.GetOrderBook(clientcode);

            //ReportMargininsummary ReportMargininsummary = new ReportMargininsummary();
            //ReportMargininsummary = m_objconnect.GetReportMarginSummary(clientcode);

            //Console.WriteLine("------------ ReportMarginsummary Output----------------------------------");
            //Console.WriteLine(JsonConvert.SerializeObject(ReportMargininsummary));
            //Console.WriteLine("-----------------------------------------------------------------");



            //ReportMarginindetail ReportMarginindetail = new ReportMarginindetail();
            //ReportMarginindetail = m_objconnect.GetReportMarginDetail(clientcode);

            //Console.WriteLine("------------ReportMargindetail summary Output----------------------------------");
            //Console.WriteLine(JsonConvert.SerializeObject(ReportMarginindetail));
            //Console.WriteLine("-----------------------------------------------------------------");


            Console.WriteLine("------------ OrderBook Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(OrderBookResponse));
            Console.WriteLine("-----------------------------------------------------------------");

            //To see Your client TradeBook data you must provide the clientcode of your client

            //format of dateandtime --  15-Nov-2022 15:16:02 format 
            String f_strdateandtime = "20-Dec-2022 15:16:02";

            TradeBookResponse TradeBookResponse = new TradeBookResponse();
            TradeBookResponse = m_objconnect.GetTradeBook(clientcode, f_strdateandtime);

            Console.WriteLine("------------ TradeBook Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(TradeBookResponse));
            Console.WriteLine("-----------------------------------------------------------------");

            //To see Your client Position Data you must provide the clientcode of your client
            PositionResponse PositionResponse = new PositionResponse();
            PositionResponse = m_objconnect.GetPosition(clientcode);

            Console.WriteLine("------------ Position Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(PositionResponse));
            Console.WriteLine("-----------------------------------------------------------------");

            //To see Your client DPHolding Data you must provide the clientcode of your client
            DPHoldingResponse DPHoldingResponse = new DPHoldingResponse();
            DPHoldingResponse = m_objconnect.GetDPHolding(clientcode);

            Console.WriteLine("------------DPHolding Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(DPHoldingResponse));
            Console.WriteLine("-----------------------------------------------------------------");

            //To see Your client RMS Summary you must provide the clientcode of your client
            ReportMargin RMSSummary = new ReportMargin();
            RMSSummary = m_objconnect.GetReportMargin(clientcode);

            Console.WriteLine("------------Report Margin Summary Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(RMSSummary));
            Console.WriteLine("-----------------------------------------------------------------");


            //LtpData rules
            LTPData LTPDatadata = new LTPData();
            LTPDatadata.clientcode = clientcode;
            LTPDatadata.exchange = "BSE";

            LTPDatadata.scripcode = 500317;
            LTPDataResponse LTPDataResponse = new LTPDataResponse();
            LTPDataResponse = m_objconnect.GetLtpData(LTPDatadata);

            Console.WriteLine("------------ LTP Data Output------------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(LTPDataResponse));
            Console.WriteLine("-----------------------------------------------------------------");

            //PositionConversion Rules
            PositionConversion PositionConversion = new PositionConversion();
            PositionConversion.clientcode = clientcode;
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


            //In Instrument file function provide your exchange name and clientcode
            string Exchange_Name = "NSEFO";
            ExchangeDataResponse ExchangeDataResponse = new ExchangeDataResponse();
            ExchangeDataResponse = m_objconnect.GetInstrumentFile(clientcode, Exchange_Name);

            Console.WriteLine("------------Instrument File Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(ExchangeDataResponse));
            Console.WriteLine("-----------------------------------------------------------------");


            OrderBookResponse l_OrderBookResponse = new OrderBookResponse();
            l_OrderBookResponse = m_objconnect.Getorderdetailbyunqueorderid(clientcode, "1700008T024312");

            Console.WriteLine("------------Getorderdetailbyunqueorderid Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_OrderBookResponse));
            Console.WriteLine("------------------------------------------------");

            TradeBookResponse l_TradeBookResponse = new TradeBookResponse();
            l_TradeBookResponse = m_objconnect.Gettradedetailbyuniqueorderid(clientcode, "1700008T024312");

            Console.WriteLine("------------Gettradedetailbyuniqueorderid Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_TradeBookResponse));
            Console.WriteLine("------------------------------------------------");



            //Logout 
            LogoutResponse m_objLogoutResponse = new LogoutResponse();
            m_objLogoutResponse = m_objconnect.Logout(clientcode);

            Console.WriteLine("------------Logout Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(m_objLogoutResponse));
            Console.WriteLine("------------------------------------------------");

            //This API is used to get Brokerage and Other Charges Detail 
            string Clientcode = "";//in case of dealer else pass blank
            string exchangename = "NSE";
            string series = "EQ";

            brokeragedetail l_Objbrokeragedetail = new brokeragedetail();

            l_Objbrokeragedetail = m_objconnect.Getbrokeragedeatil(Clientcode, exchangename, series);


            Console.WriteLine("------------ brokeragedetail Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_Objbrokeragedetail));
            Console.WriteLine("-----------------------------------------------------------------");

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

            string l_strclientcode = ""; //in case of dealer
            participantsdetail l_Objparticipantsdetail = new participantsdetail();
            l_Objparticipantsdetail = m_objconnect.Getparticipantsdetail(l_strclientcode);

            Console.WriteLine("------------ participantsdetail Output----------------------------------");
            Console.WriteLine(JsonConvert.SerializeObject(l_Objparticipantsdetail));
            Console.WriteLine("----



        }
    }
}
