using NyvaProdBC.Entity;
using NyvaProdBC.Entity.Contexts;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyvaProdTest_ExcelCRUD
{
    public static class NyvaExcel
    {
        public static string ExcelName { get; set; } = "product_table.xlsx";
        public static void Recreate()
        {
            File.Create(ExcelName).Close();
        }
        public static void Create()
        {
            if (!File.Exists(ExcelName)) Recreate();
        }
        private static void DeleteIfExists()
        {
            System.IO.FileInfo file = new FileInfo(ExcelName);
            if (file.Exists)
                file.Delete();
        }
        private static async System.Threading.Tasks.Task SaveExcel(System.Collections.Generic.List<Good> products)
        {
            System.IO.FileInfo file = new FileInfo(ExcelName);
            DeleteIfExists();
            using (var pkg = new OfficeOpenXml.ExcelPackage(file))
            {
                string sheetname = "Report of " + DateTime.Now.ToString("dd-MM-yy");
                var ws = pkg.Workbook.Worksheets.Add(Name: sheetname);
                var range = ws.Cells[Address: "A1"].LoadFromCollection(products, PrintHeaders: true);
                range.AutoFitColumns();
                await pkg.SaveAsync();
            }
        }
        public static async System.Threading.Tasks.Task<System.Collections.Generic.List<Good>> ReadExcel()
        {
            System.IO.FileInfo file = new FileInfo(ExcelName);
            var output = new System.Collections.Generic.List<Good>();
            using (var pkg = new OfficeOpenXml.ExcelPackage(file))
            {
                await pkg.LoadAsync(file);
                var ws = pkg.Workbook.Worksheets[PositionID: 0];
                int row = 3;//Skip colnames
                Console.WriteLine($"Reading: {ws.Cells[row, 1].Value?.ToString()}");
                while (string.IsNullOrWhiteSpace(ws.Cells[row, 1].Value?.ToString()) == false)
                {
                    try
                    {
                        var p = new Good();
                        p.Id = int.Parse(ws.Cells[row, 1].Value.ToString());
                        p.Name = ws.Cells[row, 2].Value.ToString();
                        p.Description = ws.Cells[row, 3].Value.ToString();

                        double orderPrice;
                        double.TryParse(ws.Cells[row, 4].Value.ToString(), out orderPrice);
                        p.OrderPrice = orderPrice;

                        double profit;
                        double.TryParse(ws.Cells[row, 5].Value.ToString(), out profit);
                        p.Profit = profit;

                        double apf;
                        double.TryParse(ws.Cells[row, 7].Value.ToString(), out apf);
                        p.APF = apf;

                        int totalAmount;
                        int.TryParse(ws.Cells[row, 10].Value.ToString(), out totalAmount);
                        p.TotalAmount = totalAmount;

                        int amountSold;
                        int.TryParse(ws.Cells[row, 11].Value.ToString(), out amountSold);
                        p.AmountSold = amountSold;

                        double weightKg;
                        double.TryParse(ws.Cells[row, 13].Value.ToString(), out weightKg);
                        p.WeightKg = weightKg;

                        //There is no difference
                        //
                        //Whether we put to ImageUrl text or number data [non-type sensitive]
                        //Whether we put characters as /, :, ' [non-syntax sensitive]
                        //Whether we put the url to another cell [cell non-format-corrupted]
                        //Whether we swap ImageUrl and RecievedOn set values [DB table cell is fine]
                        //
                        //We end up with ImageUrl field set as cell id
                        //Unless we set it directly from code. Why?
                        //Despite we do not set its value as cell id
                        //
                        //It seems to be something wrong with me

                        p.ImagesUrl = ws.Cells[row, 14].ToString(); //"https://i.pinimg.com/564x/2d/b7/d8/2db7d8c53b818ce838ad8bf6a4768c71.jpg";//IMAGE IS CELL ID SMH
                        p.RecievedOn = ws.Cells[row, 15].ToString();//Swapping excel values here does not make any difference, but only setts image url different cell id

                        int regionCode;
                        int.TryParse(ws.Cells[row, 17].Value.ToString(), out regionCode);
                        p.Barcode.RegionCode = regionCode;

                        int producerCode;
                        int.TryParse(ws.Cells[row, 18].Value.ToString(), out producerCode);
                        p.Barcode.ProducerCode = producerCode;

                        int goodCode;
                        int.TryParse(ws.Cells[row, 19].Value.ToString(), out goodCode);
                        p.Barcode.GoodCode = goodCode;

                        int controlDigit;
                        int.TryParse(ws.Cells[row, 20].Value.ToString(), out controlDigit);
                        p.Barcode.ControlDigit = controlDigit;

                        output.Add(p);
                    }
                    catch (Exception ex) { Console.WriteLine($"{ws.Cells[row, 3]} - {ex.Message}"); }
                    row++;
                }
                return output;
            }
        }
        public static void DbToExcel(string name = "")
        {
            if (name == "") name = ExcelName;
            FileInfo file = new FileInfo(name);
            var input = new GoodContext().Goods.ToList();
            int row = 3;//Skip colnames
            using (var pkg = new ExcelPackage(file))
            {
                var workSheet = pkg.Workbook.Worksheets.Add("Товари");
                var ws = pkg.Workbook.Worksheets["Товари"];
                foreach (Good g in input)
                {
                    ws.Cells[row, 1].Value = g.Id;
                    ws.Cells[row, 2].Value = g.Name;
                    ws.Cells[row, 3].Value = g.Description;
                    ws.Cells[row, 4].Value = g.OrderPrice;
                    ws.Cells[row, 5].Value = g.Profit;
                    ws.Cells[row, 7].Value = g.APF;
                    ws.Cells[row, 10].Value = g.TotalAmount;
                    ws.Cells[row, 11].Value = g.AmountSold;
                    ws.Cells[row, 13].Value = g.WeightKg;
                    ws.Cells[row, 14].Value = g.ImagesUrl;
                    ws.Cells[row, 15].Value = g.RecievedOn;
                    ws.Cells[row, 17].Value = g.Barcode.RegionCode;
                    ws.Cells[row, 18].Value = g.Barcode.ProducerCode;
                    ws.Cells[row, 19].Value = g.Barcode.GoodCode;
                    ws.Cells[row, 20].Value = g.Barcode.ControlDigit;
                    row++;
                }
            }
        }
        public static void ExampleToExcel(string name)
        {
            List<Good> goods = new GoodContext().Goods.ToList();
            // Creating an instance
            // of ExcelPackage
            ExcelPackage excel = new ExcelPackage();

            // name of the sheet
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

            // setting the properties
            // of the work sheet 
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            // Setting the properties
            // of the first row
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            // Header of the Excel sheet
            workSheet.Cells[1, 1].Value = "Id";
            workSheet.Cells[1, 2].Value = "Name";
            workSheet.Cells[1, 3].Value = "Description";
            workSheet.Cells[1, 4].Value = "OrderPrice";
            workSheet.Cells[1, 5].Value = "Profit";
            workSheet.Cells[1, 7].Value = "APF";
            workSheet.Cells[1, 10].Value = "TotalAmount";
            workSheet.Cells[1, 11].Value = "AmountSold";
            workSheet.Cells[1, 13].Value = "WeightKg";
            workSheet.Cells[1, 14].Value = "ImagesUrl";
            workSheet.Cells[1, 15].Value = "RecievedOn";
            workSheet.Cells[1, 17].Value = "RegionCode";
            workSheet.Cells[1, 18].Value = "ProducerCode";
            workSheet.Cells[1, 19].Value = "GoodCode";
            workSheet.Cells[1, 20].Value = "ControlDigit";

            // Inserting the article data into excel
            // sheet by using the for each loop
            // As we have values to the first row 
            // we will start with second row
            int row = 2;

            foreach (var g in goods)
            {
                workSheet.Cells[row, 1].Value = g.Id;
                workSheet.Cells[row, 2].Value = g.Name;
                workSheet.Cells[row, 3].Value = g.Description;
                workSheet.Cells[row, 4].Value = g.OrderPrice;
                workSheet.Cells[row, 5].Value = g.Profit;
                workSheet.Cells[row, 7].Value = g.APF;
                workSheet.Cells[row, 10].Value = g.TotalAmount;
                workSheet.Cells[row, 11].Value = g.AmountSold;
                workSheet.Cells[row, 13].Value = g.WeightKg;
                workSheet.Cells[row, 14].Value = g.ImagesUrl;
                workSheet.Cells[row, 15].Value = g.RecievedOn;
                workSheet.Cells[row, 17].Value = g.Barcode.RegionCode;
                workSheet.Cells[row, 18].Value = g.Barcode.ProducerCode;
                workSheet.Cells[row, 19].Value = g.Barcode.GoodCode;
                workSheet.Cells[row, 20].Value = g.Barcode.ControlDigit;
                row++;
            }

            // By default, the column width is not 
            // set to auto fit for the content
            // of the range, so we are using
            // AutoFit() method here. 
            for (int i = 1; i < 20; i++)
            {
                workSheet.Column(i).AutoFit();
            }

            // file name with .xlsx extension

            if (File.Exists(name))
                File.Delete(name);

            //// Create excel file on physical disk 
            File.Create(name).Close();

            //// Write content to excel file 
            File.WriteAllBytes(name, excel.GetAsByteArray());
            ////Close Excel package
            excel.Dispose();
        }
        static void SetGood(Good to, Good from)
        {
            to.AmountSold = from.AmountSold;
            to.APF = from.AmountSold;
            to.Barcode = from.Barcode;
            to.Description = from.Description;
            to.Id = from.Id;
            to.ImagesUrl = from.ImagesUrl;
            to.Name = from.Name;
            to.OrderPrice = from.OrderPrice;
            to.Profit = from.Profit;
            to.RecievedOn = from.RecievedOn;
            to.TotalAmount = from.TotalAmount;
            to.WeightKg = from.WeightKg;
        }
        public static async void ExcelToDb()
        {
            var db = new GoodContext();
            var goods = db.Goods.ToList();
            var excelGoods = await ReadExcel();
            for (int exi = 0; exi < excelGoods.Count; exi++)
            {
                int dbindex = -1;
                for (int dbi = 0; dbi < goods.Count; dbi++)
                {
                    if (excelGoods[exi].Id == goods[dbi].Id)
                    {
                        dbindex = dbi;
                    }
                }
                if (dbindex != -1)
                {
                    Console.WriteLine($"Exi-{exi} to dbi-{dbindex}");
                    goods[dbindex].AmountSold = excelGoods[exi].AmountSold;
                    goods[dbindex].APF = excelGoods[exi].APF;
                    goods[dbindex].Barcode = excelGoods[exi].Barcode;
                    goods[dbindex].Description = excelGoods[exi].Description;
                    goods[dbindex].Id = excelGoods[exi].Id;
                    goods[dbindex].ImagesUrl = excelGoods[exi].ImagesUrl;//"https://i.pinimg.com/564x/2d/b7/d8/2db7d8c53b818ce838ad8bf6a4768c71.jpg";
                    goods[dbindex].Name = excelGoods[exi].Name;
                    goods[dbindex].OrderPrice = excelGoods[exi].OrderPrice;
                    goods[dbindex].Profit = excelGoods[exi].Profit;
                    goods[dbindex].RecievedOn = DateTime.Today.ToString();
                    goods[dbindex].TotalAmount = excelGoods[exi].TotalAmount;
                    goods[dbindex].WeightKg = excelGoods[exi].WeightKg;
                }
                else
                {
                    Console.WriteLine($"Dbi-{dbindex} == -1");
                }
            }
            db.SaveChanges();
        }
    }
}
