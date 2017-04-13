using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylerEfLibrary
{
    public class CategoryFunctions
    {
        private ReportModel db = new ReportModel();

        //Return all categories
        public List<tblCategoryType> getCategories()
        {
            var cats = db.tblCategoryTypes;
            return cats.ToList<tblCategoryType>();
        }

        //Return category by id
        public tblCategoryType getCategoryById(int id) {

            tblCategoryType cat = db.tblCategoryTypes.Find(id);
            return cat;

        }

        //Update a category
        public int updateCategory(tblCategoryType cat)
        {
            tblCategoryType temp = db.tblCategoryTypes.Find(cat.ID);
            if (temp != null)
            {
                return addCategory(cat);
            }
            else
            {
                return -1;
            }
        }
        //Persist a category
        public int addCategory(tblCategoryType cat)
        {
            try
            {
                db.tblCategoryTypes.AddOrUpdate(cat);
                db.SaveChanges();
                return cat.ID;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        //Delete a category
        public bool deleteCategory(int id) {
            try
            {
                tblCategoryType cat = db.tblCategoryTypes.Find(id);
                db.tblCategoryTypes.Remove(cat);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
