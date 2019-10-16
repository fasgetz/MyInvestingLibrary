using System;
using System.Collections.Generic;
using System.Text;

namespace InvestingCalcLibrary
{
    /// <summary>
    /// Класс, который выполняет вычисления
    /// </summary>
    internal static class Calculation
    {

        /// <summary>
        /// Метод, который получает разницу в % между числом a и б
        /// </summary>
        /// <param name="a">Число а</param>
        /// <param name="b">Число б</param>
        /// <returns>Получение разницы между числом а и б в %</returns>
        internal static double GetDifferenceProcent(double a, double b)
        {
            return ((a - b) / ((a + b) / 2)) * 100;
        }
    }
}
