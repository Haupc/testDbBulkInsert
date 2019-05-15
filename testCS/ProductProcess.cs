using System;
using System.Collections.Generic;
using System.Text;
using testCS.Models;

namespace testCS
{
    class ProductProcess : DbProcess
    {

        List<Product> products = new List<Product>();
        public override string GetWorksheetName()
        {
            return "Product";
            throw new NotImplementedException();
        }

        public override void InsertToDb(DemoContext context)
        {
            context.BulkInsert(products);
            throw new NotImplementedException();
        }

        public override void InitList()
        {
            foreach (KeyValuePair<string, Guid> pair in GuidMap)
            {
                products.Add(new Product { Id = pair.Value, Name = pair.Key });
            }
            throw new NotImplementedException();
        }
    }
}
