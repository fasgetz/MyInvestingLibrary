using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InvestingCalcLibrary
{
    internal static class MyRegex
    {
        // [^a-zа-я\(\s!@\#\$%\^&\*\(\)_\+=\-'\\:\|/`~\.,\{}\)]+
        private static readonly Regex _invalidCharactersRegex = new Regex(@" ",
    RegexOptions.IgnoreCase);
        private static string ReplaceInvalidCharacters(string str) =>
           _invalidCharactersRegex.Replace(str, "");

        /// <summary>
        /// Метод для получения double значения (адаптировал под свою выборку в html документе)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static double GetDoubleValue(string value) =>
            Convert.ToDouble(ReplaceInvalidCharacters(value).Replace(".", ","));
    }
}
