using OfficeOpenXml;
using System;
using System.IO;
using System.Threading.Tasks;
using testCS.Models;



namespace testCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            DemoContext context = new DemoContext();

            program.DatabaseCleanup(context);
            Console.WriteLine("done detele");

            string FilePath = "D:\\Web\\Test Everything\\testCS\\testCS\\Data.xlsx";
            FileInfo existingFile = new FileInfo(FilePath);
            ExcelPackage package = new ExcelPackage(existingFile);
            Console.WriteLine("writing Category");
            CategoryProcess categoryProcess = new CategoryProcess();
            categoryProcess.DoTheProcess(context, package);
            Console.WriteLine("writing products");
            //ProductProcess productProcess = new ProductProcess();
            //productProcess.DoTheProcess(context, package);
            Console.WriteLine("done~~");
        }

        void DatabaseCleanup(DemoContext context)
        {
            context.Products.RemoveRange(context.Products);
            context.Warehouses.RemoveRange(context.Warehouses);
            context.Categories.RemoveRange(context.Categories);
            context.SaveChanges();
        }
    }
}
