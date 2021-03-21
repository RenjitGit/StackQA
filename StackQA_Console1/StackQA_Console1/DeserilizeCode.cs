using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackQA_Console1
{
    public class DeserilizeCode
    {
        public DeserilizeCode()
        {

            var jsonee = GetJson();
            try
            {
                List<Balance> userAccts = JsonConvert.DeserializeObject<List<Balance>>(jsonee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private string GetJson()
        {
            string str = @"[
{
    ""id"": 1,
    ""accountnumber"": ""001303000023"",
    ""accounttitle"": ""MEGA CROWN "",
    ""accountdesc"": ""MEGA CROWN "",
    ""productType"": ""Loan"",
    ""prodname"": ""SME TERM LOAN                                                                                       "",
    ""bookbalance"": -200000.00,
    ""effectivebalance"": -200000.000000,
    ""currentbalance"": -200000.0000
},
{
    ""id"": 2,
    ""accountnumber"": ""1020145429"",
    ""accounttitle"": ""MEGA CROWN"",
    ""accountdesc"": ""CORPORATE "",
    ""productType"": ""Current"",
    ""prodname"": ""CORPORATE CURRENT ACCOUNT                                                                           "",
    ""bookbalance"": 3000.00,
    ""effectivebalance"": 23000.000000,
    ""currentbalance"": 3000.0000
}]";
            return str;
        }
    }

    public class Balance1
    {
        public int id { get; set; }
        public string accountnumber { get; set; }
        public string accounttitle { get; set; }
        public string accountdesc { get; set; }
        public string productType { get; set; }
        public string prodname { get; set; }
        public double bookbalance { get; set; }
        public double effectivebalance { get; set; }
        public double currentbalance { get; set; }
    }

    public class Balance
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("productType")]
        public string AccountType { get; set; }

        [JsonProperty("accountnumber")]
        public string AccountNumber { get; set; }
        public string accounttitle { get; set; }
        public string accountdesc { get; set; }
        public string prodname { get; set; }
        public double effectivebalance { get; set; }
        //public double currentbalance { get; set; }

        [JsonProperty("currentbalance")]
        public double balance { get; set; }
        public string AccountBalance { get; set; }

        //public string AccountBalance
        //{
        //    get
        //    {
        //        string bal = this.balance.ToString();
        //        var newBal = Math.Round(Convert.ToDouble(bal), 2).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-us")).Replace("$", "N");
        //        return newBal;
        //    }

        //    set
        //    {
        //        AccountBalance = value;
        //    }
        //}
        //public ImageSource WalletImage
        //{
        //    get
        //    {
        //        var img = ImageAsset.WalletImage;
        //        return img;
        //    }
        //    set
        //    {
        //        WalletImage = value;
        //    }

        //}

        //public Transaction transactions { get; set; }
    }
}
