using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screener
{
    public class Stock
    {
        private bool[] inScreener = new bool[2];
        private DateTime earningsDate;
        private double high52W;
        private double epsNextY;
        private double epsThisY;
        private double recom;
        private double currentRatio;
        private double targetPrice;
        private double price;
        private int fund;
        private int growth;
        private int valuation;
        private int totalScore;
        private int totalScore2;
        private int zacksRank;
        private string beforeAfterClose;
        private string zacksString;
        private string symbol;
        private string industry;
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

        public double EPSNextYValue
        {
            get { return epsNextY; }
            set { epsNextY = value; }
        }

        public double EPSThisYValue
        {
            get { return epsThisY; }
            set { epsThisY = value; }
        }

        public double TargetPriceValue
        {
            get { return targetPrice; }
            set { targetPrice = value; }
        }

        public double PriceValue
        {
            get { return price; }
            set { price = value; }
        }
        public string BeforeAfterCloseValue
        {
            get { return beforeAfterClose; }
            set { beforeAfterClose = value; }
        }

        public int TotalScoreValue
        {
            get { return totalScore; }
            set { totalScore = value; }
        }
        public int TotalScore2Value
        {
            get { return totalScore2; }
            set { totalScore2 = value; }
        }

        public int ZacksRankValue
        {
            get { return zacksRank; }
            set { zacksRank = value; }
        }
        public string ZacksStringValue
        {
            get { return zacksString; }
            set { zacksString = value; }
        }
        public DateTime GetEarningsDate() { return earningsDate; }
        public string GetEarningsDateString()
        {
            if (earningsDate != new DateTime(0)) { return earningsDate.ToShortDateString(); }
            return "NA";
        }

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
            if(dateStrings.Length > 2)
            {
                beforeAfterClose = dateStrings[2];
            } else
            {
                beforeAfterClose = "b";
            }
        }//end SetEarningsDate

        public void SetInScreener(int index, bool isIn)
        {
            if(index > 1 || 0 > index) { return; }
            inScreener[index] = isIn;
        }//end

        public bool GetInScreener(int index)
        {
            if(index > 1 || 0 > index) { return false; }
            return inScreener[index];
        }//end

        /// <summary>
        /// Calculates the total score of the Stock object
        /// </summary>
        public void CalculateTotalScore()
        {
            totalScore = GetFundOrGrowthScore(FundValue) + GetFundOrGrowthScore(GrowthValue)+ GetValuationScore() +
                GetRecomScore() + GetZacksRankScore() + GetHigh52WScore() + GetCurrentRatioScore() + GetEarningsDateScore();
            totalScore2 = (GetFundOrGrowthScore(FundValue) * 5) + (GetFundOrGrowthScore(GrowthValue) * 3)+
                (GetValuationScore() * 2) + (GetRecomScore() * 3) + (GetZacksRankScore() * 10) + GetEPSNextYScore(true) +
                GetEPSThisYScore(true) + GetTargetPriceScore(true);
        }//end CalculateTotalScore

        /// <summary>
        /// Gets the attributes of the Stock object in an enumerable object
        /// </summary>
        /// <returns>The attributes of the Stock object</returns>
        public IEnumerable<object> GetAttributesEnumerable(bool secondScreener)
        {
            if(secondScreener)
            {
                return new List<object>() { symbol, industry, fund, growth, valuation, epsThisY, epsNextY, recom, targetPrice, GetEarningsDateString(), zacksString, totalScore2 };
            } else
            {
                return new List<object>() { symbol, industry, fund, growth, valuation, high52W, recom, currentRatio, GetEarningsDateString(), zacksString, totalScore };
            }//end if-else
        }//end GetAttributesEnum

        /// <summary>
        /// Returns the score of the Fund or Value attribute depending on which value is sent to the function
        /// </summary>
        /// <param name="val">The value to be evaluated</param>
        /// <returns></returns>
        public int GetFundOrGrowthScore(int val) { return (val >= 7 ? 4 : val >= 4 ? 2 : -2); }

        /// <summary>
        /// Determines the score of the Valuation attribute and returns it to the calling program
        /// </summary>
        /// <returns></returns>
        public int GetValuationScore() { return (ValuationValue >= 5 ? 4 : ValuationValue >= 3 ? 2 : -2); }

        /// <summary>
        /// Determines the score of the High52W attribute and returns it to the calling program
        /// </summary>
        /// <returns></returns>
        public int GetHigh52WScore() { return (High52WValue <= -30 ? 4 : High52WValue <= -10 || High52WValue == Double.MinValue ? 2 : -2); }

        /// <summary>
        /// Determines the score of the Recom attribute and returns it to the calling program
        /// </summary>
        /// <returns></returns>
        public int GetRecomScore() { return (RecomValue <= 2 ? 4 : RecomValue <= 3 || RecomValue == Double.MinValue ? 2 : -2); }

        /// <summary>
        /// Determines the score of the Current Ratio attribute and returns it to the calling program
        /// </summary>
        /// <returns></returns>
        public int GetCurrentRatioScore() { return (CurrentRatioValue >= 3 ? 4 : CurrentRatioValue >= 1 || CurrentRatioValue == Double.MinValue ? 2 : -2); }

        /// <summary>
        /// Determines the score of the Zacks Rank attribute and returns it to the calling program
        /// </summary>
        /// <returns></returns>
        public int GetZacksRankScore() { return (ZacksRankValue == 1 ? 6 : ZacksRankValue == 2 ? 4 : ZacksRankValue == 3 ? 2 : ZacksRankValue == 4 ? -4 : -6); }

        public int GetEPSNextYScore(bool multiply = false)
        {
            var res = (EPSNextYValue >= 25 ? 4 : 25 > EPSNextYValue && EPSNextYValue >= 0 ? 2 : -2);
            if(multiply)
            {
                return res * 5;
            }
            return res;
        }
        public int GetEPSThisYScore(bool multiply = false)
        {
            var res = (EPSThisYValue >= 25 ? 4 : 25 > EPSThisYValue && EPSThisYValue >= 0 ? 2 : -2);
            if(multiply)
            {
                return res * 5;
            }
            return res;
        }
        public int GetTargetPriceScore(bool multiply = false)
        {
            var res = (TargetPriceValue > PriceValue ? 4 : -2);
            if(multiply)
            {
                return res * 2;
            }
            return res;
        }

        /// <summary>
        /// Determines the color of the attribute to be used in document saving and printing
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Color[] GetFormattingColors(bool secondScreener)
        {
            if(secondScreener)
            {
                return new System.Drawing.Color[] { GetAttributeColor(GetFundOrGrowthScore(FundValue)), GetAttributeColor(GetFundOrGrowthScore(GrowthValue)),
                GetAttributeColor(GetValuationScore()),GetAttributeColor(GetEPSThisYScore()), GetAttributeColor(GetEPSNextYScore()),
                GetAttributeColor(GetRecomScore()), GetAttributeColor(GetTargetPriceScore()),
                GetAttributeColor(GetEarningsDateScore()), GetAttributeColor(GetZacksRankScore(), true) };
            } else
            {
                return new System.Drawing.Color[] { GetAttributeColor(GetFundOrGrowthScore(FundValue)), GetAttributeColor(GetFundOrGrowthScore(GrowthValue)),
                GetAttributeColor(GetValuationScore()),GetAttributeColor(GetHigh52WScore()),
                GetAttributeColor(GetRecomScore()), GetAttributeColor(GetCurrentRatioScore()),
                GetAttributeColor(GetEarningsDateScore()), GetAttributeColor(GetZacksRankScore(), true) };
            }//end if-else
        }//end if

        private System.Drawing.Color GetAttributeColor(int val, bool isZacks = false)
        {
            if(!isZacks)
            {
                return val == 4 ? System.Drawing.Color.Green : val == 2 ? System.Drawing.Color.Yellow : System.Drawing.Color.Red;
            } else
            {
                return val == 6 ? System.Drawing.Color.Green : val == 4 ? System.Drawing.Color.Blue :
                    val == 2 ? System.Drawing.Color.Yellow : val == -4 ? System.Drawing.Color.Orange : System.Drawing.Color.Red;
            }
        }//end GetAttributeColor
        /// <summary>
        /// Returns the score for the earningsDate attribute.
        /// </summary>
        /// <returns></returns>
        private int GetEarningsDateScore()
        {
            var temp = GetEarningsDateTimeSpan();
            /*Determines if the earnings date is today or not.  If so determines if the earnings is from before or after close.
              If before check to verify that the time is after 9:30am, if after time needs to be after 4:00pm.  If the earnings
              date is after today's date always negative.  If before determine the range, ranges are 1 <= x <= 70, 71 <= x < 4 months
              and 4 months after*/
            if (temp == 0)
            {
                if (BeforeAfterCloseValue == "b")
                {
                    return (earningsDate.TimeOfDay > new TimeSpan(9, 30, 0) ? 4 : -2);
                }
                else
                {
                    return (earningsDate.TimeOfDay > new TimeSpan(16, 0, 0) ? 4 : -2);
                }//end nested if-else
            }
            else
            {
                if (1 <= temp && temp <= 70)
                {
                    return 4;
                }
                else if ((70 < temp && temp < (earningsDate - DateTime.Today.AddMonths(-4)).Days) || earningsDate == new DateTime(0))
                {
                    return 2;
                }
                else
                {
                    return -2;
                }//end nested if-else if-else
            }//end if-else
        }//end getEarningsDateScore

        /// <summary>
        /// Determines the number of days between the current day and the earningsDate value
        /// </summary>
        /// <returns>The number of days</returns>
        private int GetEarningsDateTimeSpan()
        {
            if (earningsDate > new DateTime(0))
            {
                /*Creates a variable to add to the hours, minutes, and seconds of a temp DateTime object to verify if the Month, Day, and Year
                  are all the same. The earnings date is less than the current date, returns the day interval from today to earningsDate.  If
                  the same, returns 0, else return -366*/
                int minusHours = earningsDate.TimeOfDay.Hours * -1;
                int minusMinutes = earningsDate.TimeOfDay.Minutes * -1;
                int minusSeconds = earningsDate.TimeOfDay.Seconds * -1;
                var temp = new DateTime(earningsDate.Year, earningsDate.Month, earningsDate.Day, earningsDate.Hour + minusHours, earningsDate.Minute + minusMinutes, earningsDate.Second + minusSeconds);
                var compare = DateTime.Today.CompareTo(temp);
                if (compare == 1) //DateTime.Today is later than earningsDate
                {
                    return (DateTime.Now - earningsDate).Days;
                }
                else if (compare == 0)//Same day
                {
                    return 0;
                }
                else //DateTime.Today is before earningsDate
                {
                    return -366;
                }
            }
            else
            {
                return -366;
            }
            //return (earningsDate > new DateTime(0) ? (DateTime.Now - earningsDate).Days : -366);
        }//end get EarningsDateTimeSpan

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
