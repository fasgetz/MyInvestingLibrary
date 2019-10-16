using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestingCalcLibrary
{
    /// <summary>
    /// Логика HTML
    /// </summary>
    internal class HtmlLogic
    {

        #region Свойства

        /// <summary>
        /// url адрес страницы
        /// </summary>
        private readonly string url;
        /// <summary>
        /// html документ
        /// </summary>
        private HtmlDocument document;
        /// <summary>
        /// Состояние загрузки html страницы
        /// </summary>
        private bool _htmlLoaded = false;

        /// <summary>
        /// Получить url страницы
        /// </summary>
        internal string GetUrl
        {
            get => url;
        }

        /// <summary>
        /// Загружена ли html страница
        /// </summary>
        internal bool htmlLoaded
        {
            get => _htmlLoaded;
        }
        #endregion

        #region Методы


        /// <summary>
        /// Загрузка HTML страницы
        /// </summary>
        /// <returns>true, если страница загружена</returns>
        internal bool LoadHtml()
        {
            try
            {
                // Если html страница не загружена, то загрузи
                if (htmlLoaded == false)
                {
                    document = new HtmlWeb().Load(url); // Загрузка html страницы по url
                    _htmlLoaded = true; // Ставим состояние, что страница загружена
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        /// <summary>
        /// Получение какого-то единичного результата в выборке документа
        /// </summary>
        /// <param name="xpath">Путь (в xpath)</param>
        /// <returns>Результат выборки документа</returns>
        internal string GetSingleNode(string xpath)
        {
            try
            {
                return document.DocumentNode.SelectSingleNode(xpath).InnerText;
            }
            catch (Exception)
            {
                return null; // Возвращаем null, в случае ошибки
            }
        }

        #endregion


        internal HtmlLogic(string url)
        {
            this.url = url;
        }

    }
}
