using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICLibrary
{
    public class NICOperations
    {
        public string NICFormat(string nic)
        {
            if (nic.Length == 10)
            {
                nic = "19" + nic;
            }
            return nic;
        }

        public string DayCheck(string nic)
        {
            int dayNum = Convert.ToInt32(nic.Substring(4, 3));

            int[] ly = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (dayNum > 500)
            {
                dayNum = dayNum - 500;
            }

            string birthYr = nic.Substring(0, 4);
            string month, day;

            int t1 = 0;
            int t2 = 0;


            for (int i = 0; i < ly.Length; i++)
            {
                if (t1 > dayNum)
                {
                    break;
                }

                t1 += ly[i];
                t2 = i;
            }


            if ((t2 + 1) < 10)
            {
                month = "0" + (t2 + 1).ToString();
            }
            else
            {
                month = (t2 + 1).ToString();
            }

            t1 = t1 - ly[t2];
            day = (dayNum - t1).ToString();

            return nic.Substring(0, 4) + "." + month + "." + day;
        }

        public string GenderCheck(string nic)
        {
            int genNum = Convert.ToInt32(nic.Substring(4, 3));

            if (genNum < 500)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }

        public string VoteCheck(string nic)
        {
            string voteLetter;
            string reverseNum = string.Join("", nic.Reverse());
            voteLetter = reverseNum.Substring(0, 1);

            if (voteLetter == "V")
            {
                return "Eligible";
            }
            else if (voteLetter == "X")
            {
                return "Not Eligible";
            }
            else
            {
                return "";
            }
        }
    }
}
