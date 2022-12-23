using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringParserEPRS
{
    public class ParserEngine
    {
        public (DateOnly, string) Parse(string _rawData)
        {
            var date = GetDate(_rawData);
            var ext = GetExt(_rawData);

            return (date, ext);
        }

        private DateOnly GetDate(string _rawData)
        {
            var splittedDate = _rawData.Split('-');
            splittedDate[2] = splittedDate[2].Substring(0, 4);

            for (int i = 0; i < splittedDate.Length; i++)
            {
                if (splittedDate[i].Length == 1)
                {
                    splittedDate[i] = $"0{splittedDate[i]}";
                }
            }

            string strDate = $"{splittedDate[0]}/{splittedDate[1]}/{splittedDate[2]}";
            DateOnly dt;
            var isValidate = DateOnly.TryParse(strDate, out dt);
            if (isValidate)
                return dt;
            else
                return new DateOnly();
        }

        private string GetExt(string _rawData)
        {
            int dotPosition = _rawData.LastIndexOf('.');
            int extLength = _rawData.Length - dotPosition;

            // if file has any 1 char after . and have .
            if (dotPosition + 1 >= _rawData.Length || dotPosition < 0)
            {
                //_result.Add("");
                return "";
            }
            string extRes = _rawData.Substring(dotPosition, extLength);
            return extRes;
        }

    }
}
