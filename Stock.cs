using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screener
{
    class Stock
    {
        private string symbol;
        private string industry;
        private int fund;
        private int growth;
        private int valuation;
        private double high52W;
        private double recom;
        private double currentRatio;
        private DateTime earningsDate;
        private string beforeAfterClose;
        public string SymbolValue
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public string IndustryValue
        {
            get { return industry; }
            set { industry = value; }
        }

        public int FundValue
        {
            get { return fund; }
            set { fund = value; }
        }

        public int GrowthValue
        {
            get { return growth; }
            set { growth = value; }
        }

        public int ValuationValue
        {
            get { return valuation; }
            set { valuation = value; }
        }

        public double High52WValue
        {
            get { return high52W; }
            set { high52W = value; }
        }

        public double RecomValue
        {
            get { return recom; }
            set { recom = value; }
        }

        public double CurrentRatioValue
        {
            get { return currentRatio; }
            set { currentRatio = value; }
        }

        public string BeforeAfterCloseValue
        {
            get { return beforeAfterClose; }
            set { beforeAfterClose = value; }
        }
        public DateTime GetEarningsDate() { return earningsDate; }
        public string GetEarningsDateString() { return earningsDate.ToShortDateString(); }

        public void SetEarningsDate(string value)
        {
            if(value == "-")
            {
                earningsDate = new DateTime(0);
                return;
            }

            var dateStrings = value.Split(new char[] { ' ', '/' });
            var tempDate = DateTime.Now;
            earningsDate = new DateTime(tempDate.Year, GetMonthDigit(dateStrings[0]), int.Parse(dateStrings[1]), tempDate.Hour, tempDate.Minute, tempDate.Second);
            beforeAfterClose = dateStrings[2];
        }//end SetEarningsDate

        /// <summary>
        /// Returns the digit for the month
        /// </summary>
        /// <param name="month">The month abbreviation string from Finviz</param>
        /// <returns>The month in int format</returns>
        private int GetMonthDigit(string month)
        {
            switch(month)
            {
                case "Jan":
                    return 1;
                case "Feb":
                    return 2;
                case "Mar":
                    return 3;
                case "Apr":
                    return 4;
                case "May":
                    return 5;
                case "Jun":
                    return 6;
                case "Jul":
                    return 7;
                case "Aug":
                    return 8;
                case "Sep":
                    return 9;
                case "Oct":
                    return 10;
                case "Nov":
                    return 11;
                case "Dec":
                    return 12;
                default:
                    return 1;
            }//end switch
        }//end GetMonthDigit
    }//end Stock
}//end Screener
