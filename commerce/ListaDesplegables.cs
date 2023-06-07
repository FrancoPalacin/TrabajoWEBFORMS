using System;
using System.Collections.Generic;


namespace domain
{
    public class ListaDesplegables
    {
        public List<Brand> Listar()
        {
            List<Brand> brandList = new List<Brand>();
            DataAccess newAcces = new DataAccess();
 
            try
            {
                newAcces.setQuery("select Id, Descripcion from Marcas");
                newAcces.execute();

                 while (newAcces.sqlReader.Read())
                {
                    Brand brand = new Brand();
                    brand.Id = (int)newAcces.sqlReader["Id"];
                    brand.Description = (string)newAcces.sqlReader["Descripcion"];

                    brandList.Add(brand);
                }

                    return brandList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                newAcces.close();
            }
        }
    }
}
