using System;
using OfficeOpenXml;
using testCS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace testCS
{
    class CategoryProcess : DbProcess
    {
        public CategoryProcess()
        {
            InitRoot();
            InitList();
        }

        Guid rootId = Guid.NewGuid();

        List<Category> catList = new List<Category>();

        void InitRoot()
        {
            GuidMap.Add("ROOT", Guid.NewGuid());
        }

        string GetStringParent(string child)
        {
            return (child.Length > 4) ? child.Substring(0, child.Length - 4) : "ROOT";
        }

        string GetName(string name)
        {
            return (name.Length > 4) ? name.Substring(name.Length - 3) : "ROOT";
        }

        Nullable<Guid> GetParentId(string child)
        {
            
            string strParent = this.GetStringParent(child);
            if (!GuidMap.ContainsKey(strParent))
            {
                Guid newGuid = Guid.NewGuid();
                GuidMap.Add(strParent, newGuid);
                return newGuid;
            }
            Nullable<Guid> nullGuid = null;
            return (!strParent.Equals("ROOT")) ? GuidMap[strParent] : nullGuid;
        }

        public override void InitList()
        {
            foreach (KeyValuePair<string, Guid> pair in GuidMap)
            {
                catList.Add(new Category { Id = pair.Value,
                                           Name = pair.Key,
                                           ParentId = GetParentId(pair.Key)
                                          });
            }
        }

        public override void InsertToDb(DemoContext context)
        {
            context.BulkInsert(catList);
        }

        public override string GetWorksheetName()
        {
            return "Category";
            throw new NotImplementedException();
        }
    }
}
