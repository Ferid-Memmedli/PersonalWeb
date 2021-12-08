using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace PersonalWeb.HelperMethods
{
    public static class JsonFileManager
    {
        public static TObject JsonConvertToObject<TObject>(string pathJsonFile) where TObject : class, new()
        {
            using (StreamReader r = new StreamReader(AppRoot() + pathJsonFile))
            {
                return JsonConvert.DeserializeObject<TObject>(r.ReadToEnd());
            }
        }

        public static void ObjectToWriteJson(string pathJsonFile, string jsonValue)
        {
            using (StreamWriter w = new StreamWriter(AppRoot() + pathJsonFile, false, Encoding.UTF8, 4))
            {
                w.WriteAsync(jsonValue);
                w.Close();
            }
        }
        public static string AppRoot()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath ?? string.Empty).Value;
            return $"{appRoot}/";
        }
    }
}