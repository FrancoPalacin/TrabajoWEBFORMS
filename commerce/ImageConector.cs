using domain;
using System;
using System.Collections.Generic;

namespace commerce
{
    public class ImageConector
    {
        private List<ImagenArticulo> _images;
        private int _imageIndex;
        public void FindImageById(int ArticleId)
        {
            this._imageIndex = 0;
            this._images = this.FetchImageById(ArticleId);
        }

        public string GetCurremtImg()
        {
            if (this._images != null && this._imageIndex < this._images.Count)
            {
                return this._images[this._imageIndex].ImageUrl;
            }
            return "";
        }

        public void Next()
        {
            if (_imageIndex < (this._images.Count - 1)) { this._imageIndex++; } else { this._imageIndex = 0; }
        }

        public void Previous()
        {
            if (_imageIndex > 0) { this._imageIndex--; }
        }

        private List<ImagenArticulo> FetchImageById(int idArticle)
        {
            List<ImagenArticulo> imageList = new List<ImagenArticulo>();
            DataAccess db = new DataAccess();

            try
            {
                db.setQuery("select Id, IdArticulo, ImagenUrl from IMAGENES where IdArticulo  = " + idArticle);
                db.execute();

                while (db.sqlReader.Read())
                {
                    ImagenArticulo aux = new ImagenArticulo(
                        (!(db.sqlReader["Id"] is DBNull)) ? (int)db.sqlReader["Id"] : 0,
                        (!(db.sqlReader["IdArticulo"] is DBNull)) ? (int)db.sqlReader["IdArticulo"] : 0,
                        (!(db.sqlReader["ImagenUrl"] is DBNull)) ? (string)db.sqlReader["ImagenUrl"] : ""
                        );
                    imageList.Add(aux);
                }
                return imageList;
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
