using domain;
using System;
using System.Collections.Generic;

namespace commerce
{
    public class CategoryConector
    {
        private List<Category> _categories;
        public CategoryConector()
        {
            this._categories = FetchCategories();
        }

        public List<Category> GetCategories() { 
            return this._categories; 
        } 
        private List<Category> FetchCategories()
        {
            List<Category> categoryList = new List<Category>();
            DataAccess db = new DataAccess();

            try
            {
                db.setQuery("select Id, Descripcion from CATEGORIAS");
                db.execute();

                while (db.sqlReader.Read())
                {
                    Category category = new Category(
                        (!(db.sqlReader["Id"] is DBNull)) ? (int)db.sqlReader["Id"] : 0,
                        (!(db.sqlReader["Descripcion"] is DBNull)) ? (string)db.sqlReader["Descripcion"] : ""
                        );
                    categoryList.Add(category);
                }

                return categoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.close();
            }
        }
    }
}
