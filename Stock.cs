using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screener
{
    public class Stock
    {
        private string symbol;
        private string industry;
        private int fund;
        private int growth;
        private int valuation;
        private int totalScore;
        private int zacksRank;
        private Dictionary<string, double> doubles = new Dictionary<string, double>()
        {
            ["high52W"] = 0,
        };
        private double high52W;
        private double recom;
        private double currentRatio;
        private double marketCap;
        public double MarketCapValue
        {
            get { return marketCap; }
            set { marketCap = value; }
        }
        private char marketCapChar;
        public char MarketCapCharValue
        {
            get { return marketCapChar; }
            set { marketCapChar = value; }
        }
        private double pe;
        public double PEValue
        {
            get { return pe; }
            set { pe = value; }
        }
        private double forwardPE;
        public double ForwardPEValue
        {
            get { return forwardPE; }
            set { forwardPE = value; }
        }
        private double peg;
        public double PEGValue
        {
            get { return peg; }
            set { peg = value; }
        }
        private double ps;
        public double PSValue
        {
            get { return ps; }
            set { ps = value; }
        }
        private double pb;
        public double PBValue
        {
            get { return pb; }
            set { pb = value; }
        }
        private double pc;
        public double PCValue
        {
            get { return pc; }
            set { pc = value; }
        }
        private double pfcf;
        public double PFCFValue
        {
            get { return pfcf; }
            set { pfcf = value; }
        }
        private double dividend;
        public double DividendValue
        {
            get { return dividend; }
            set { dividend = value; }
        }
        private double payoutRatio;
        public double PayoutRatioValue
        {
            get { return payoutRatio; }
            set { payoutRatio = value; }
        }
        private double eps;
        public double EPSValue
        {
            get { return eps; }
            set { eps = value; }
        }
        private double epsThisY;
        public double EPSThisYValue
        {
            get { return epsThisY; }
            set { epsThisY = value; }
        }
        private double epsNextY;
        public double EPSNextYValue
        {
            get { return epsNextY; }
            set { epsNextY = value; }
        }
        private double epsPast5Y;
        public double EPSPast5YValue
        {
            get { return epsPast5Y; }
            set { epsPast5Y = value; }
        }
        private double salesPast5Y;
        public double SalesPast5YValue
        {
            get { return salesPast5Y; }
            set { salesPast5Y = value; }
        }
        private double epsQQ;
        public double EPSQQValue
        {
            get { return epsQQ; }
            set { epsQQ = value; }
        }
        private double salesQQ;
        public double SalesQQValue
        {
            get { return salesQQ; }
            set { salesQQ = value; }
        }
        private double outstanding;
        public double OutstandingValue
        {
            get { return outstanding; }
            set { outstanding = value; }
        }
        private char outstandingChar;
        public char OutstandingCharValue
        {
            get { return outstandingChar; }
            set { outstandingChar = value; }
        }
        private double floatVal;
        public double FloatValue
        {
            get { return floatVal; }
            set { floatVal = value; }
        }
        private char floatChar;
        public char FloatCharValue
        {
            get { return floatChar; }
            set { floatChar = value; }
        }
        private double insiderOwn;
        public double InsiderOwnValue
        {
            get { return insiderOwn; }
            set { insiderOwn = value; }
        }
        private double insiderTrans;
        public double InsiderTransValue
        {
            get { return insiderTrans; }
            set { insiderTrans = value; }
        }
        private double instOwn;
        public double InstOwnValue
        {
            get { return instOwn; }
            set { instOwn = value; }
        }
        private double instTrans;
        public double InstTransValue
        {
            get { return instTrans; }
            set { instTrans = value; }
        }
        private double floatShort;
        public double FloatShortValue
        {
            get { return floatShort; }
            set { floatShort = value; }
        }
        private double shortRatio;
        public double ShortRatioValue
        {
            get { return shortRatio; }
            set { shortRatio = value; }
        }
        private double roa;
        public double ROAValue
        {
            get { return roa; }
            set { roa = value; }
        }
        private double roe;
        public double ROEValue
        {
            get { return roe; }
            set { roe = value; }
        }
        private double roi;
        public double ROIValue
        {
            get { return roi; }
            set { roi = value; }
        }
        private double quickRatio;
        public double QuickRatioValue
        {
            get { return quickRatio; }
            set { quickRatio = value; }
        }
        private double lTDebtEq;
        public double LTDebtEqValue
        {
            get { return lTDebtEq; }
            set { lTDebtEq = value; }
        }
        private double debtEq;
        public double DebtEqValue
        {
            get { return debtEq; }
            set { debtEq = value; }
        }
        private double grossM;
        public double GrossMValue
        {
            get { return grossM; }
            set { grossM = value; }
        }
        private double operM;
        public double OperMValue
        {
            get { return operM; }
            set { operM = value; }
        }
        private double profitM;
        public double ProfitMValue
        {
            get { return profitM; }
            set { profitM = value; }
        }
        private double perfWeek;
        public double PerfWeekValue
        {
            get { return perfWeek; }
            set { perfWeek = value; }
        }
        private double perfMonth;
        public double PerfMonthValue
        {
            get { return perfMonth; }
            set { perfMonth = value; }
        }
        private double perfQuarter;
        public double PerfQuarterValue
        {
            get { return perfQuarter; }
            set { perfQuarter = value; }
        }
        private double perfHalf;
        public double PerfHalfValue
        {
            get { return perfHalf; }
            set { perfHalf = value; }
        }
        private double perfYear;
        public double PerfYearValue
        {
            get { return perfYear; }
            set { perfYear = value; }
        }
        private double perfYTD;
        public double PerfYTDValue
        {
            get { return perfYTD; }
            set { perfYTD = value; }
        }
        private double beta;
        public double BetaValue
        {
            get { return beta; }
            set { beta = value; }
        }
        private double atr;
        public double ATRValue
        {
            get { return atr; }
            set { atr = value; }
        }
        private double volatilityW;
        public double VolatilityWValue
        {
            get { return volatilityW; }
            set { volatilityW = value; }
        }
        private double volatilityM;
        public double VolatilityMValue
        {
            get { return volatilityM; }
            set { volatilityM = value; }
        }
        private double[] sma = new double[3];
        public double SMA20
        {
            get { return sma[0]; }
            set { sma[0] = value; }
        }
        public double SMA50
        {
            get { return sma[1]; }
            set { sma[1] = value; }
        }
        public double SMA200
        {
            get { return sma[2]; }
            set { sma[2] = value; }
        }
        private double[] day50 = new double[2];
        public double High50Day
        {
            get { return day50[0]; }
            set { day50[0] = value; }
        }
        public double Low50Day
        {
            get { return day50[1]; }
            set { day50[1] = value; }
        }
        private double low52W;
        public double Low52WValue
        {
            get { return low52W; }
            set { low52W = value; }
        }
        private double rsi;
        public double RSIValue
        {
            get { return rsi; }
            set { rsi = value; }
        }
        private double fromOpen;
        public double FromOpenValue
        {
            get { return fromOpen; }
            set { fromOpen = value; }
        }
        private double gap;
        public double GAPValue
        {
            get { return gap; }
            set { gap = value; }
        }
        private double avgVolume;
        public double AvgVolumeValue
        {
            get { return avgVolume; }
            set { avgVolume = value; }
        }
        private double relVolume;
        public double RelVolumeValue
        {
            get { return relVolume; }
            set { relVolume = value; }
        }
        private double price;
        public double PriceValue
        {
            get { return price; }
            set { price = value; }
        }
        private double change;
        public double ChangeValue
        {
            get { return change; }
            set { change = value; }
        }
        private double volume;
        public double VolumeValue
        {
            get { return volume; }
            set { volume = value; }
        }
        private double targetPrice;
        public double TargetPriceValue
        {
            get { return targetPrice; }
            set { targetPrice = value; }
        }
        private double ipoDate;
        public double IPODateValue
        {
            get { return ipoDate; }
            set { ipoDate = value; }
        }
        private DateTime earningsDate;
        private string beforeAfterClose;
        private string zacksString;
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

        public int TotalScoreValue
        {
            get { return totalScore; }
            set { totalScore = value; }
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
            beforeAfterClose = dateStrings[2];
        }//end SetEarningsDate

        /// <summary>
        /// Calculates the total score of the Stock object
        /// </summary>
        public void CalculateTotalScore()
        {
            totalScore += GetFundOrGrowthScore(FundValue);
            totalScore += GetFundOrGrowthScore(GrowthValue);
            totalScore += GetValuationScore();
            totalScore += GetHigh52WScore();
            totalScore += GetRecomScore();
            totalScore += GetCurrentRatioScore();
            totalScore += GetEarningsDateScore();
            totalScore += GetZacksRankScore();
        }

        /// <summary>
        /// Gets the attributes of the Stock object in an enumerable object
        /// </summary>
        /// <returns>The attributes of the Stock object</returns>
        public IEnumerable<object> GetAttributesEnumerable()
        {
            return new List<object>() { symbol, industry, fund, growth, valuation, high52W, recom, currentRatio, GetEarningsDateString(), zacksString, totalScore };
        }

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

        /// <summary>
        /// Determines the color of the attribute to be used in document saving and printing
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Color[] GetFormattingColors()
        {
            return new System.Drawing.Color[] { GetAttributeColor(GetFundOrGrowthScore(FundValue)), GetAttributeColor(GetFundOrGrowthScore(GrowthValue)), GetAttributeColor(GetValuationScore()), GetAttributeColor(GetHigh52WScore()), GetAttributeColor(GetRecomScore()), GetAttributeColor(GetCurrentRatioScore()), GetAttributeColor(GetEarningsDateScore()), GetAttributeColor(GetZacksRankScore(), true) };
        }

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
