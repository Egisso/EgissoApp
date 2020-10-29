﻿using System;

namespace EgissoApp
{
    class SnilsValidator
    {
        public static Boolean SNILSValidate(String snils)
        {
            try
            {
                snils = snils.Replace(" ", "").Replace("-", "");
                int controlSum = SNILSContolCalc(snils);
                int strControlSum = int.Parse(snils.Substring(9, 2));
                return (controlSum == strControlSum);
            }
            catch
            {
                return false;
            }
            
        }

        public static int SNILSContolCalc(String snils)
        {
            snils = snils.Substring(0, 9);
            int totalSum = 0;
            for (int i = 8, j = 0; i >= 0; i--, j++)
            {
                int digit = int.Parse(snils[i].ToString());
                totalSum += digit * (j + 1);
            }

            return SNILSCheckControlSum(totalSum);
        }

        private static int SNILSCheckControlSum(int _controlSum)
        {
            int result;
            if (_controlSum < 100)
            {
                result = _controlSum;
            }
            else if (_controlSum <= 101)
            {
                result = 0;
            }
            else
            {
                int balance = _controlSum % 101;
                result = SNILSCheckControlSum(balance);
            }
            return result;
        }
    }
}