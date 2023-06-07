using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace domain
{
    public class ArticleConector
    {
        public List<Article> Listar()
        {
            List<Article> ArticlesList = new List<Article>();
            DataAccess data = new DataAccess();

            try
            {
                data.setQuery("Select A.Id as artId, Nombre as name, A.Descripcion as artDescrip, Codigo as artCode, Precio as price, C.Descripcion as category, A.IdCategoria as categoryId, " +
                    "M.Descripcion as brand, A.IdMarca as brandId From ARTICULOS A, CATEGORIAS C, MARCAS M Where C.Id = A.IdCategoria And M.Id = A.IdMarca");
                data.execute();

                while (data.sqlReader.Read())
                {
                    Article aux = new Article();
                    aux.ArticleId = (!(data.sqlReader["artId"] is DBNull)) ? (int)data.sqlReader["artId"] : 0;
                    aux.Name = (!(data.sqlReader["name"] is DBNull)) ? (string)data.sqlReader["name"] : "";
                    aux.Description = (!(data.sqlReader["artDescrip"] is DBNull)) ? (string)data.sqlReader["artDescrip"] : "";
                    aux.ArticleCode = (!(data.sqlReader["artCode"] is DBNull)) ? (string)data.sqlReader["artCode"] : "";
                    aux.Price = (!(data.sqlReader["price"] is DBNull)) ? (decimal)data.sqlReader["price"] : 0;
                    aux.ArticleCategory = new Category(
                        (!(data.sqlReader["categoryId"] is DBNull)) ? (int)data.sqlReader["categoryId"] : 0,
                        (!(data.sqlReader["category"] is DBNull)) ? (string)data.sqlReader["category"] : ""
                        );
                    aux.ArticleBrand = new Brand(
                        (!(data.sqlReader["brandId"] is DBNull)) ? (int)data.sqlReader["brandId"] : 0,
                        (!(data.sqlReader["brand"] is DBNull)) ? (string)data.sqlReader["brand"] : ""
                        );

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

        public Article ListarConId(int id)
        {
            DataAccess data = new DataAccess();
            try
            {

                data.setQuery("SELECT A.Id as artId, A.Nombre as Nombre, A.Codigo as artCode, A.Precio as price, A.Descripcion as artDescrip, M.Descripcion brand, M.Id brandId, C.Descripcion as category, C.Id as categoryId FROM Articulos A, MARCAS M, CATEGORIAS C WHERE A.Id = C.id and M.Id = A.Id and A.Id = @id");

                data.setearParametro("@id", id);
                data.execute();

                while (data.sqlReader.Read())
                {

                    Article aux = new Article();
                    aux.ArticleId = (!(data.sqlReader["artId"] is DBNull)) ? (int)data.sqlReader["artId"] : 0;
                    aux.Name = (!(data.sqlReader["Nombre"] is DBNull)) ? (string)data.sqlReader["Nombre"] : "";
                    aux.Description = (!(data.sqlReader["artDescrip"] is DBNull)) ? (string)data.sqlReader["artDescrip"] : "";
                    aux.ArticleCode = (!(data.sqlReader["artCode"] is DBNull)) ? (string)data.sqlReader["artCode"] : "";
                    aux.Price = (!(data.sqlReader["price"] is DBNull)) ? (decimal)data.sqlReader["price"] : 0;
                    aux.ArticleCategory = new Category(
                        (!(data.sqlReader["categoryId"] is DBNull)) ? (int)data.sqlReader["categoryId"] : 0,
                        (!(data.sqlReader["category"] is DBNull)) ? (string)data.sqlReader["category"] : ""
                        );
                    aux.ArticleBrand = new Brand(
                        (!(data.sqlReader["brandId"] is DBNull)) ? (int)data.sqlReader["brandId"] : 0,
                        (!(data.sqlReader["brand"] is DBNull)) ? (string)data.sqlReader["brand"] : ""
                        );

                    return aux;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<DetallesArticulos> GetArticleWithCartDetails()
        {
            List<DetallesArticulos> ArticulosList = new List<DetallesArticulos>();
            List<Article> articles = ListarConSp();

            foreach (Article article in articles)
            {
                DetallesArticulos articleWithCartDetail = new DetallesArticulos
                {
                    ArticleId = article.ArticleId,
                    ArticleCode = article.ArticleCode,
                    Name = article.Name,
                    Description = article.Description,
                    ArticleBrand = article.ArticleBrand,
                    ArticleCategory = article.ArticleCategory,
                    ArticleImage = article.ArticleImage,
                    Image = article.Image,
                    Price = Math.Round(article.Price, 2),
                    PrecioArt = Math.Round(article.Price + (article.Price * 15 / 100), 2),
                    CantidadArt = 0
                };

                ArticulosList.Add(articleWithCartDetail);
            }

            return ArticulosList;

        }
        public List<Article> ListarConSp()
        {
            List<Article> list = new List<Article>();
            DataAccess data = new DataAccess();
            try
            {
                data.StoredProcedure("SP_ArtList");

                data.execute();

                while (data.sqlReader.Read())
                {

                    Article aux = new Article();
                    aux.ArticleId = (!(data.sqlReader["artId"] is DBNull)) ? (int)data.sqlReader["artId"] : 0;
                    aux.Name = (!(data.sqlReader["Nombre"] is DBNull)) ? (string)data.sqlReader["Nombre"] : "";
                    aux.Description = (!(data.sqlReader["artDescrip"] is DBNull)) ? (string)data.sqlReader["artDescrip"] : "";
                    aux.ArticleCode = (!(data.sqlReader["artCode"] is DBNull)) ? (string)data.sqlReader["artCode"] : "";
                    aux.Price = (!(data.sqlReader["price"] is DBNull)) ? (decimal)data.sqlReader["price"] : 0;
                    aux.ArticleCategory = new Category(
                        (!(data.sqlReader["categoryId"] is DBNull)) ? (int)data.sqlReader["categoryId"] : 0,
                        (!(data.sqlReader["category"] is DBNull)) ? (string)data.sqlReader["category"] : ""
                        );
                    aux.ArticleBrand = new Brand(
                        (!(data.sqlReader["brandId"] is DBNull)) ? (int)data.sqlReader["brandId"] : 0,
                        (!(data.sqlReader["brand"] is DBNull)) ? (string)data.sqlReader["brand"] : ""
                        );
                    aux.ArticleImage = new ImagenArticulo(
                        (!(data.sqlReader["imageId"] is DBNull)) ? (int)data.sqlReader["imageId"] : 0,
                        (!(data.sqlReader["artId"] is DBNull)) ? (int)data.sqlReader["artId"] : 0,
                        (!(data.sqlReader["imageUrl"] is DBNull)) ? (string)data.sqlReader["imageUrl"] : ""
                        );

                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public void Modify(Article article)
        {
            DataAccess dataAcces = new DataAccess();

            try
            {
                dataAcces.setQuery("update Articulos set Codigo = @cod , Nombre = @name, Descripcion = @description, IdMarca = @idMarca, Precio = @price  where Id= @id");
                dataAcces.setearParametro("@cod", article.ArticleCode);
                dataAcces.setearParametro("@name", article.Name);
                dataAcces.setearParametro("@description", article.Description);
                dataAcces.setearParametro("@idMarca", article.ArticleBrand.Id);
                dataAcces.setearParametro("@id", article.ArticleId);
                dataAcces.setearParametro("@price", article.Price);

                dataAcces.executeAction();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dataAcces.close();
            }

        }

        public int CreateNewArticle(Article newArt)
        {
            DataAccess acces = new DataAccess();

            try
            {
                string query = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, Precio) OUTPUT Inserted.ID values('" + newArt.ArticleCode + "', '" + newArt.Name + "', '" + newArt.Description + "', " + newArt.ArticleBrand.Id + ", " + newArt.Price + ")";
                acces.setQuery(query);
                int newArticleId = (int)acces.executeScalar();
                acces.ClearQuery();

                acces.setQuery("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) values(" + newArticleId + ", '" + newArt.Image + "')");
                acces.executeAction();
                return newArticleId;
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

        public void eliminar(int id)
        {
            try
            {
                DataAccess data = new DataAccess();
                data.setQuery("delete from Articulos where id = @id");
                data.setearParametro("@id", id);
                data.executeAction();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Article> filtrar(string brand, string category, string filter)
        {
            List<Article> list = new List<Article>();
            DataAccess data = new DataAccess();
            try
            {
                string consulta = "Select A.Id artId, A.Codigo cod, A.Nombre nombre, A.Descripcion descrip, A.Precio price, M.Descripcion brand, M.Id brandId, C.Descripcion category, C.Id categoryId From ARTICULOS A, MARCAS M, CATEGORIAS C where a.IdCategoria = c.Id and m.Id=a.IdMarca and   ";

                if (brand == "Precio")
                    switch (brand)
                    {
                        case "Mayor a":
                            consulta += "price > " + filter;
                            break;
                        case "Menor A":
                            consulta += "price < " + filter;
                            break;
                        case "Descripcion":
                            consulta += "price = " + filter;
                            break;
                    }
                else if (category == "Nombre")
                {
                    switch (category)
                    {
                        case "Comienza con":
                            consulta += "name like '" + filter + "%'";

                            break;
                        case "Termina con":
                            consulta += "name like '%'" + filter + "'";
                            break;
                        case "Contiene":
                            consulta += "name like '%" + filter + "%'";
                            break;
                    }
                }
                else if (category == "Descripcion")
                    switch (category)
                    {
                        case "Que comience con ":
                            consulta += "A.Descripcion like '" + filter + "%' ";
                            break;
                        case "Que contenga ":
                            consulta += "A.Descripcion like '%" + filter + "%'";
                            break;
                        case "Que termine con ":
                            consulta += "A.Descripcion like '%" + filter + "'";
                            break;
                    }

                data.setQuery(consulta);
                data.execute();
                while (data.sqlReader.Read())
                {
                    Article aux = new Article();
                    aux.ArticleId = (int)data.sqlReader["artId"];
                    aux.Price = (int)data.sqlReader["price"];
                    aux.ArticleCode = (string)data.sqlReader["cod"];
                    aux.Name = (string)data.sqlReader["name"];
                    aux.Description = (string)data.sqlReader["descrip"];

                    aux.ArticleBrand = new Brand();
                    aux.ArticleBrand.Description = (string)data.sqlReader["brand"];
                    aux.ArticleBrand.Id = (int)data.sqlReader["brandId"];

                    aux.ArticleCategory = new Category();
                    aux.ArticleCategory.Id = (int)data.sqlReader["categoryId"];
                    aux.ArticleCategory.Description = (string)data.sqlReader["category"];


                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }


}

