﻿using fbognini.i18n.Persistence.Entities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace fbognini.i18n
{
    public interface II18nRepository
    {
        string BaseUriResource { get; }
        //string Translate(string language, int source);
        List<string> Languages { get; }


        IEnumerable<Language> GetLanguages();

        IEnumerable<Translation> AddTranslations(string textId, string resourceId, string description, Dictionary<string, string> translations);
        IEnumerable<Translation> GetTranslations(string languageId, string textId, string resourceId, DateTime? since = null);

        void UpdateTranslation(Translation translation);
        void UpdateTranslations(List<Translation> translations);

        void ImportExcel(string path, bool all, bool deletenotmatched);
        byte[] ExportExcel();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translations"></param>
        /// <param name="all">if true, import all rows, otherwise import only updated rows</param>
        /// <param name="deletenotmatched">if true, delete translation when not found</param>
        void ImportTranslations(IEnumerable<Translation> translations, bool all, bool deletenotmatched);

        internal void DetachAllEntities();
    }
}
