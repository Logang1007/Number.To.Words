using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Number.To.Words
{
    public class NumberHelper
    {

        public static string ToWords(Int64 number, string appendScale = "")
        {
            var wordConverter = new WordConverterParams().ConverterParams;
            string numString = "";
       
            if (number < 100)
            {
                if (number < 20)
                    numString = wordConverter.OnesList[number];
                else
                {
                    numString = wordConverter.TensList[number / 10];
                    if ((number % 10) > 0)
                        numString = string.Format(wordConverter.TensFormat, numString, wordConverter.OnesList[number % 10]);
                }
            }
            else
            {
                int pow = 0;
                string powStr = ""; 

                if (number < 1000)
                { 
                    pow = 100; 
                    powStr = wordConverter.ThousandList[0];
                }
                else
                { 
                    int log = (int)Math.Log(number, 1000);
              
                    pow = (int)Math.Pow(1000, log);
          
                    powStr = wordConverter.ThousandList[log];
                }

  
                numString = string.Format(wordConverter.LargeSmallComboFormat, ToWords(number / pow, powStr), ToWords(number % pow)).Trim();
            }

            return string.Format(wordConverter.ScaleFormat, numString, appendScale).Trim();
        }


   
    }


    class WordConverterParams
    {
       
        public (string[] OnesList, string[] TensList, string[] ThousandList, string TensFormat, string LargeSmallComboFormat, string ScaleFormat) ConverterParams
        {
            get
            {
                string[] onesList = {
    "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
    "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
};

                string[] tensList = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                string[] thousandList = { "hundred", "thousand", "million", "billion", "trillion", "quadrillion" };

                string tensFormat = "{0}-{1}"; 
                string largeSmallComboFormat = "{0} {1}"; 
                string scaleFormat = "{0} {1}"; 
                return (onesList, tensList, thousandList, tensFormat, largeSmallComboFormat, scaleFormat);
            }

        }
    }
}
