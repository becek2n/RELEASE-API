using RELEASE.API.Models;
using RELEASE.API.Models.dbentities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RELEASE.API.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet, Route("Api/Product/GetDataProductCategory")]
        public ResultModel<List<ModelAPICategory>> GetDataProductCategory()
        {
            ResultModel<List<ModelAPICategory>> oResult = new ResultModel<List<ModelAPICategory>>();
            try
            {
                using (var db = new RELEASECOMEntities())
                {
                    var data = db.MstCategory.Select(x => new ModelAPICategory { ID = x.ID, Categori = x.Categori }).ToList();
                    oResult.ResponseCode = "500";
                    oResult.ResponseMessage = "Success";
                    oResult.ResponseData = data;
                }
            }
            catch (Exception ex)
            {
                oResult.ResponseCode = "400";
                oResult.ResponseMessage = ex.Message;
            }
            return oResult;
        }

        [HttpGet, Route("Api/Product/GetDataProductAll")]
        public ResultModel<List<ModelAPIProduct>> GetDataProductAll()
        {
            ResultModel<List<ModelAPIProduct>> oResult = new ResultModel<List<ModelAPIProduct>>();
            try
            {
                using (var db = new RELEASECOMEntities())
                {
                    var data = db.Product
                                .Join(db.MstCategory, x => x.CategoriID, y => y.ID,
                                (x, y) => new ModelAPIProduct
                                {
                                    ID = x.ID,
                                    CategoriID = x.CategoriID,
                                    Categori = y.Categori,
                                    Title = x.Title,
                                    Description = x.Description,
                                    Price = x.Price,
                                    Photo1 = x.Photo1,
                                    Photo2 = x.Photo2,
                                    Photo3 = x.Photo3
                                }).ToList();
                    oResult.ResponseCode = "500";
                    oResult.ResponseMessage = "Success";
                    oResult.ResponseData = data;
                }
            }
            catch (Exception ex)
            {
                oResult.ResponseCode = "400";
                oResult.ResponseMessage = ex.Message;
            }
            return oResult;
        }

        [HttpGet, Route("Api/Product/GetDataProductByID/{id:int}")]
        public ResultModel<List<ModelAPIProduct>> GetDataProductByID(int id)
        {
            ResultModel<List<ModelAPIProduct>> oResult = new ResultModel<List<ModelAPIProduct>>();
            try
            {
                using (var db = new RELEASECOMEntities())
                {
                    var data = db.Product
                                .Join(db.MstCategory, x => x.CategoriID, y => y.ID,
                                (x, y) => new ModelAPIProduct 
                                            { 
                                                ID = x.ID, CategoriID = x.CategoriID, Categori =y.Categori,
                                                Title = x.Title,
                                                Description = x.Description,
                                                Price = x.Price,
                                                Photo1 = x.Photo1,
                                                Photo2 = x.Photo2,
                                                Photo3 = x.Photo3
                                            })
                                .Where(x => x.CategoriID == id)
                                .ToList();
                    oResult.ResponseCode = "500";
                    oResult.ResponseMessage = "Success";
                    oResult.ResponseData = data;
                }
            }
            catch (Exception ex)
            {
                oResult.ResponseCode = "400";
                oResult.ResponseMessage = ex.Message;
            }
            return oResult;
        }
        
	}

    public class ResultModel<T>
    {
        public ResultModel()
        {

        }
        public ResultModel(bool IsSuccess)
        {
            this.ResponseCode = (IsSuccess) ? "200" : "500";
            this.ResponseMessage = (IsSuccess) ? "success" : "failed";
        }

        public ResultModel<T> SetSuccess(string message, T value = default(T))
        {
            this.ResponseCode = "200";
            this.ResponseMessage = message != null ? message : "success";
            this.ResponseData = value;
            return this;
        }

        public ResultModel<T> SetFailed(string message, string statusCode = "500", T value = default(T), Exception Ex = null)
        {
            this.ResponseCode = statusCode;
            this.ResponseMessage = message != null ? message : "failed";
            this.ResponseData = value;
            this.ValException = Ex;
            return this;
        }

        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public T ResponseData { get; set; }
        public Exception ValException { get; set; }
    }
}