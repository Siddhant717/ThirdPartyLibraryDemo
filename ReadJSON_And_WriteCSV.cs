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
    public class ReadJSON_And_WriteCSV
    {

        public static void ImplementJsonToCsv()
        {
            string importFilePath = @"D:\class object-2\TPL\TPLDemo\TPLDemo\Utility\export.json";
            string exportFilePath = @"D:\class object-2\TPL\TPLDemo\TPLDemo\Utility\export.csv";

            IList<AddressData> addressData = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFilePath));

            Console.WriteLine("*************Reading from JsonFile  and write to CSV file************");

            //writing csv file
            using (var writer = new StreamWriter(exportFilePath))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords(addressData);
            }
        }

        
        
    }
}
