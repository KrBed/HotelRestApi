using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Csv
{
    class Program
    {
        private static Dictionary<string, int> _categorySummary = new Dictionary<string, int>();
        static List<FileData> fileDatas = new List<FileData>();
        private bool runTusk = true;
        public static void Main(string[] args)
        {
            var startTime = TimeSpan.Zero;
            var timePeriod = TimeSpan.FromSeconds(1);

            string path = "E:/TEMP_CSV_1";

            var csvFiles = Directory.GetFiles(path);
            var threadNumber = 1;

            Task task1 = Task.Run(() =>
            {
                {
                    lock (fileDatas)
                    {
                        FileProcessor.FileSummary(fileDatas);
                    }

                }
            });



            Parallel.ForEach(
                csvFiles,
                new ParallelOptions { MaxDegreeOfParallelism = threadNumber },
                file =>
                {

                    using (StreamReader reader = new StreamReader(file))
                    {

                        var counter = 0;
                        string row = String.Empty;


                        while ((row = reader.ReadLine()) != null)
                        {
                            if (counter != 0)
                            {
                                // Console.WriteLine(Task.CurrentId);
                                // Console.WriteLine(counter);
                                // Console.WriteLine(row);

                                var data = row.Split(';');

                                var fileData = new FileData(DateTime.Parse(data[0]),
                                    new Dictionary<string, int>() { { data[1], Int32.Parse(data[3]) } },
                                    Int32.Parse(data[3]));
                                lock (fileDatas)
                                {
                                    fileDatas.Add(fileData);
                                }

                            }

                            counter++;
                        }
                        // Console.WriteLine(counter);
                        // Console.WriteLine(Task.CurrentId);
                        // Console.WriteLine(file);



                    }
                }

            );

            // int count = 0;
            // foreach (var file in csvFiles)
            // {
            //     using (StreamReader reader = new StreamReader(file))
            //     {
            //         string row = "";
            //         while ((row = reader.ReadLine()) != null) count++;
            //     }
            // }

            Console.WriteLine("DataSummary");
            FileProcessor.FileSummary(fileDatas);
            Console.WriteLine("Counter");
            Console.WriteLine(fileDatas.Count);
            Console.WriteLine("File datas Count");
            Console.WriteLine(fileDatas.Count.ToString());
            // Console.WriteLine(count);
            Console.ReadKey();


        }
        static void FileSummary(List<FileData> fileDatas)
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

        static Dictionary<string, int> GetCategorySummary(List<FileData> fileDatas)
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

        static Dictionary<DateTime, int> GetYearlySummary(List<FileData> fileDatas)
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
