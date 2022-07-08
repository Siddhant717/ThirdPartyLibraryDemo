using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLDemo
{
    public class ReadCSV_And_WriteJSON
    {
        public static void ImplementCSVToJSON()
        {
            string importFilePath = @"D:\class object-2\TPL\TPLDemo\TPLDemo\Utility\addresses.csv";
            string exportFilePath = @"D:\class object-2\TPL\TPLDemo\TPLDemo\Utility\export.json";

            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader,CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read Data successfully from addresses.csv");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.firstname);
                    Console.Write("\t" + addressData.lastname);
                    Console.Write("\t" + addressData.address);
                    Console.Write("\t" + addressData.city);
                    Console.Write("\t" + addressData.state);
                    Console.Write("\t" + addressData.code);

                }
                Console.WriteLine("\n*********Now reading frpm csv file and write to Json file**********");

                //writing data to Json file
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }

    }
     
}
