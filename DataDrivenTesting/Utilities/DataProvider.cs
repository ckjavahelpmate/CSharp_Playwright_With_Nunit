using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDrivenTesting.Utilities
{
    internal class DataProvider
    {
        public static IEnumerable<Dictionary<string, string>> data(String testcase)
        {
            String jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "TestData.json");

            JObject jObject = JObject.Parse(File.ReadAllText(jsonPath));

            JArray? jArray = jObject[testcase] as JArray;

            foreach (JObject item in jArray)
            {
                bool? isExecute = (bool?)item["Execute"];
                Dictionary<string, string> result = new Dictionary<string, string>();
                if (isExecute == true)
                {
                    foreach (JProperty prop in item.Properties())
                    {
                        result[prop.Name] = prop.Value.ToString();
                    }
                    yield return result;
                }
            }
        }
    }
}
