using System;
using System.Collections.Generic;

namespace domain
{
    public class ArticleListConector
    {
        public List<Article> Listar()
        {
            List<Article> ArticlesList = new List<Article>();
            DataAccess data = new DataAccess();

            try
            {
                data.setQuery("select art.Id artId, Codigo, Nombre, art.Descripcion artDescrip, imagenUrl imagen, m.Descripcion brand, m.Id brandId, c.Descripcion category, c.Id categoryId FROM Articulos art, IMAGENES img, CATEGORIAS c, MARCAS m where art.Id = img.IdArticulo and art.IdMarca = m.Id and art.IdCategoria = c.Id ");
                data.execute();

                while (data.sqlReader.Read())
                {
                    Article aux = new Article();
                    aux.ArticleId = (int)data.sqlReader["ArtId"];
                    aux.Name = (string)data.sqlReader["Nombre"];
                    aux.Description = (string)data.sqlReader["artDescrip"];
                    aux.ArticleCode = (string)data.sqlReader["Codigo"];
                    aux.Image = (string)data.sqlReader["imagen"];
                    aux.ArticleCategory = new Category((int)(data.sqlReader["categoryId"]),(string)data.sqlReader["category"]);
                    aux.ArticleBrand = new Brand((int)data.sqlReader["brandId"], (string)data.sqlReader["brand"]);
              
                    ArticlesList.Add(aux);
                }
                return ArticlesList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.close();
            }
        }
        public void CreateArticle(Article art)
        {
            DataAccess acces = new DataAccess();

            try
            {
                //for(int i = 0; i < art.Image.Length)
                acces.setQuery("INSERT INTO ARTICULOS (Nombre, Descripcion, Precio, ) values('" + art.Name + "', '" + art.Description + "' "+ art.Price +")");
                acces.executeAction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Listar();
                acces.close();
            }
        }
    }

    
}

