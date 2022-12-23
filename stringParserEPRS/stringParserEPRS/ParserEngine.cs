namespace stringParserEPRS
{
    public class ParserEngine
    {
        public (DateOnly FileDate, string FileExt) Parse(string _rawData)
        {
            var date = GetDate(_rawData);
            var ext = GetExt(_rawData);

            return (date, ext);
        }

        private DateOnly GetDate(string _rawData)
        {
            var splittedDate = _rawData.Split('-');
            if (splittedDate.Length != 3)
            {
                return new DateOnly();
            }

            splittedDate[2] = splittedDate[2].Substring(0, 4);

            foreach (var item in splittedDate)
            {
                var isNumeric = int.TryParse(item, out int n);
                if (!isNumeric)
                    return new DateOnly();
            }

            string strDate = $"{splittedDate[0]}/{splittedDate[1]}/{splittedDate[2]}";
            var isValidate = DateOnly.TryParse(strDate, out DateOnly dt);
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
                return "";
            }
            string extRes = _rawData.Substring(dotPosition, extLength);
            return extRes;
        }

    }
}
