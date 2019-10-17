using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace InvestingCalcLibrary
{

    /// <summary>
    /// Класс, в котором содержится логика
    /// </summary>
    public class InvestingLogic
    {

        #region Свойства

        private readonly DateTime StartDateInvesting; // Дата начала инвестиций
        private readonly double StartShareBuying; // Стоимость покупки пая
        private readonly double StartCapital; // Стартовый капитал
        private double YourCapital; // Твой капитал на данный момент
        private double CurrentPriceShare; // Текущая цена пая
        private string CurrentDate; // Текущая дата
        private HtmlLogic logic; // html логика
        private double EarningSum; // Заработанная сумма

        /// <summary>
        /// Заработанная сумма
        /// </summary>
        public double GetEarningSum
        {
            get => EarningSum;
        }

        /// <summary>
        /// Получение разница процента между стартовым и заработанным капиталом
        /// </summary>
        public double GetDifferenceProcent
        {
            get => Calculation.GetDifferenceProcent(YourCapital, StartCapital);
        }

        /// <summary>
        /// Возвращаем, загружен ли html документ
        /// </summary>
        public bool htmlIsLoaded
        {
            get
            {
                if (logic == null)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Получить текущую дату
        /// </summary>
        public string GetCurrentDate
        {
            get => CurrentDate;
        }

        /// <summary>
        /// Текущая цена пая
        /// </summary>
        public double GetCurrentPriceShare
        {
            get => CurrentPriceShare;
        }

        /// <summary>
        /// Количество купленных паев
        /// </summary>
        public double GetCountShare
        {
            get
            {
                return StartCapital / StartShareBuying;
            }
        }

        /// <summary>
        /// Получить изначальную стоимость покупки пая
        /// </summary>
        public double GetStartShareBuying
        {
            get => StartShareBuying;
        }

        /// <summary>
        /// Получить дату начала инвестирования
        /// </summary>
        public DateTime GetDateInvesting
        {
            get => StartDateInvesting;
        }

        /// <summary>
        /// Получить стартовый капитал
        /// </summary>
        public double GetStartCapital
        {
            get => StartCapital;
        }

        /// <summary>
        /// Получить текущий капитал
        /// </summary>
        public double GetCurrentCapital
        {
            get => YourCapital; // Текущий капитал
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="date">Дата начала инвестирования</param>
        /// <param name="StartShareBuying">Стоимость пая</param>
        /// <param name="StartCapital">Стартовый капитал</param>
        public InvestingLogic(DateTime date, double StartShareBuying, double StartCapital)
        {
            StartDateInvesting = date;
            this.StartCapital = StartCapital;
            this.StartShareBuying = StartShareBuying;
            YourCapital = StartCapital;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Загрузка html страницы
        /// </summary>
        public void LoadHtml(string url)
        {
            logic = new HtmlLogic(url);
            logic.LoadHtml(); // Загружаем html страницу


        }


        /// <summary>
        /// Метод для инициализации данных
        /// </summary>
        public void Initialization(string xpath_currentprice = "//div/table/tbody/tr/td[@class='nowrap main rublast']", string xpath_currentdate = "//div/table/thead/tr/th[@class='nowrap main']")
        {
            CurrentPriceShare = MyRegex.GetDoubleValue(logic.GetSingleNode(xpath_currentprice));
            CurrentDate = logic.GetSingleNode(xpath_currentdate);

            // Получаем заработанную сумму
            EarningSum = (CurrentPriceShare - StartShareBuying) * GetCountShare;

            YourCapital = StartCapital + EarningSum; // Текущий капитал = стартовая сумма + заработанная
        }

        #endregion

    }
}
