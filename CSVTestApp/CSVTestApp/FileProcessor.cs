using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv
{
    public class FileProcessor
    {

        public static void FileSummary(List<FileData> fileDatas)
        {
            var data = fileDatas;
            var quantitySummary = data.Sum(x => x.Quantity);
            Console.WriteLine(quantitySummary);
            var categorySummary = GetCategorySummary(data);
            foreach (var category in categorySummary)
            {
                Console.WriteLine($@"{category.Key} : {category.Value}");
            }
            var yearlySummary = GetYearlySummary(data);
            foreach (var year in yearlySummary)
            {
                Console.WriteLine($@"{year.Key} : {year.Value}");
            }
        }

        public static Dictionary<string, int> GetCategorySummary(List<FileData> fileDatas)
        {
            var categorySummary = new Dictionary<string, int>();
            foreach (var data in fileDatas)
            {
                var keys = data.Category.Keys.ToList();
                if (categorySummary.ContainsKey(keys[0]))
                {
                    int value = 0;
                    bool hasValue = categorySummary.TryGetValue(keys[0], out value);
                    if (hasValue)
                    {
                        categorySummary[keys[0]] += data.Category[keys[0]];
                    }
                }
                else
                {
                    categorySummary.Add(keys[0], data.Category[keys[0]]);
                }
            }

            return categorySummary;
        }

        public static Dictionary<DateTime, int> GetYearlySummary(List<FileData> fileDatas)
        {
            var yearlySummary = new Dictionary<DateTime, int>();
            foreach (var data in fileDatas)
            {
                var key = data.Tm.Date;
                if (yearlySummary.ContainsKey(key))
                {
                    int value = 0;
                    bool hasValue = yearlySummary.TryGetValue(key, out value);
                    if (hasValue)
                    {
                        yearlySummary[key] += data.Quantity;
                    }
                }
                else
                {
                    yearlySummary.Add(key, data.Quantity);
                }
            }

            return yearlySummary;
        }
    }
}
