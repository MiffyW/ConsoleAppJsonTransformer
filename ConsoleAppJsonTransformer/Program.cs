using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ConsoleAppJsonTransformer
{
    class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Feature { get; set; }
        public string Feature2 { get; set; }
        public string Feature3 { get; set; }

        public string Feature4 { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //List<Data> _data = new List<Data>();
            List<JObject> jObjects = new List<JObject>();

            for (int i = 0; i < 100000; i++)
            {
                var d = new Data()
                {
                    Id = i,
                    Name = "A Message",
                    Feature = "a feature",
                    Feature2 = "a feature 2",
                    Feature3 = "a feature 3",
                    Feature4 = "a feature 4",

                };

                jObjects.Add(JObject.FromObject(d));
            }


            Console.WriteLine(DateTime.Now + "Generated JObjects.");

            //for (int i = 0; i < jObjects.Count; i++)
            //{
            //    jObjects[i].Add("added_feature_1", "added feature 1");
            //    jObjects[i].Add("added_feature_2", "added feature 2");
            //    jObjects[i].Add("added_feature_3", "added feature 3");
            //    jObjects[i].Remove("Name");
            //}

            jObjects.ForEach(jObj =>
            {
                jObj.Add("added_feature_1", "added feature 1");
                //jObj.Add("added_feature_2", "added feature 2");
                //jObj.Add("added_feature_3", "added feature 3");
                //jObj.Remove("Name");
            });
            jObjects.ForEach(jObj =>
            {
                jObj.Add("added_feature_2", "added feature 2");
            });
            jObjects.ForEach(jObj =>
            {
                jObj.Add("added_feature_3", "added feature 3");
            });
            jObjects.ForEach(jObj =>
            {
                jObj.Remove("Name");
            });

            Console.WriteLine(DateTime.Now + "After manipulating JObjects.");

            string json = JsonConvert.SerializeObject(jObjects.ToArray());

            //write string to file
            System.IO.File.WriteAllText(@"D:\Workplace\src\Local\CSharp\ConsoleAppJsonTransformer\outputJson.json", json);
            Console.WriteLine(DateTime.Now + "After serialization and saving file.");

        }
    }


}
