
using System.Text.RegularExpressions;

namespace RegularExpression
{
    public static class RegularExpressionStore
    {
        // should return a bool indicating whether the input string is
        // a valid team international email address: firstName.lastName@domain (serhii.mykhailov@teaminternational.com etc.)
        // address cannot contain numbers
        // address cannot contain spaces inside, but can contain spaces at the beginning and end of the string
       
        public static bool Method1(string input)
        {
            return Regex.IsMatch(input, @"(?:\s*[a-zA-Z.]+@[a-zA-Z-]+\.com\b\s*)");

        }

        // the method should return a collection of field names from the json input
        public static IEnumerable<string> Method2(string inputJson)
        {
            string[] collectionOfFieldName = Regex.Matches(inputJson, @"""([^""]+?)""\s*:")
           .Select(m => m.Groups[1].Value).ToArray();
            return collectionOfFieldName;

        }

        // the method should return a collection of field values from the json input
        public static IEnumerable<string> Method3(string inputJson)
        {
            var collectionOfFieldValues = Regex.Matches(inputJson, @"[:]""?(\w+)|null|true|false")
                .Select(m => m.Groups[1].Value).ToArray();

            return collectionOfFieldValues;
        }

        // the method should return a collection of field names from the xml input
        public static IEnumerable<string> Method4(string inputXml)
        {
            var collectionOfFieldNames = Regex.Matches(inputXml, @"<([^\/>T\s?]+)[\/]*").Select(m => m.Groups[1].Value);
            return collectionOfFieldNames;
        }

        // the method should return a collection of field values from the input xml
        // omit null values
        public static IEnumerable<string> Method5(string inputXml)
        {
            var collectionOfFieldValues= Regex.Matches(inputXml, @"<\w+>(.+?)<\/\w+>").Select(m => m.Groups[1].Value);
            return collectionOfFieldValues;
        }

        // read from the input string and return Ukrainian phone numbers written in the formats of 0671234567 | +380671234567 | (067)1234567 | (067) - 123 - 45 - 67
        // +38 - optional Ukrainian country code
        // (067)-123-45-67 | 067-123-45-67 | 38 067 123 45 67 | 067.123.45.67 etc.
        // make a decision for operators 067, 068, 095 and any subscriber part.
        // numbers can be separated by symbols , | ; /
        public static IEnumerable<string> Method6(string input)
        {
            
           string changedInput=Regex.Replace(input,"(\\|)|(\\;)|(\\,)","\n\"");
           var inputMatch = Regex.Matches(changedInput, @"(\+38\d+|\+38[\s][0-9]{3}[\s][0-9]{3}[\s][0-9]{2}[\s][0-9]{2}|\(067\)[\s][-][\s][0-9]{3}[\s][-][\s][0-9]{2}[\s][-][\s][0-9]{2}|\(067\)\d+|\(067\)[-][0-9]{3}[-][0-9]{2}[-][0-9]{2}|067[-][0-9]{3}[-][0-9]{2}[-][0-9]{2}|067[.][0-9]{3}[.][0-9]{2}[.][0-9]{2}|068[\s][0-9]{4}[\s][0-9]{3}|095\d+)").Select(m => m.Groups[1].Value); ;
           return inputMatch;

            //different version:(\+38\d+|\+38\s\d+\s\d+.\d+\s\d+|\(?067\)\d+|\(?067\)\s\-\s\d+\s\-\s\d+\s\-\s\d+|\(?067\)\-\d+\-\d+\-\d+|\(?067\-\d+\-\d+\-\d+|\(?067\.\d+\.\d+\.\d+|\(?068\s\)?\d+\s\d+|\(?095\)?\d+)
        }

    }
}