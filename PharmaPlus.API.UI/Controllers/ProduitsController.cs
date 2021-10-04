using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaPlus.API.UI.Applications.DTOs;
using PharmaPlus.API.UI.ExtensionMethods;
using PharmaPlus.Core.Produits.Domain;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaPlus.API.UI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors(SecurityMethods.DEFAULT_POLICY)]
    public class ProduitsController : ControllerBase
    {
        #region Fields
        private readonly IProduitsRepository _repository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        #endregion

        #region Constructor
        public ProduitsController(IProduitsRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            this._repository = repository;
            this._webHostEnvironment = webHostEnvironment;
        }
        #endregion


        #region Public methods

        [HttpGet]
        //[DisableCors]
        //[EnableCors(SecurityMethods.DEFAULT_POLICY_3)]
        //public IEnumerable<Produit> Get()
        public IActionResult GetAll([FromQuery] int produitId = 0)
        {
            //return Enumerable.Range(1, 5).Select(item => new Produit()
            //{
            //    Id = item,
            //    Drug_code = 225,
            //    Class_name = "Humain",
            //    Drug_identification_number = 00000019,
            //    Brand_name = "PLACIDYL CAP 200MG",
            //    Descriptor = "",
            //    Number_of_ais = 1,
            //    Ai_group_no = 0107593001,
            //    Company_name = "ABBOTT LABORATORIES, LIMITED",
            //    Last_update_date = new DateTime(2008 - 07 - 23),
            //    Purchase_price = 20.00,
            //    Sell_price = 25.00,
            //    Ppa = 29.00,
            //    Expiry_date = new DateTime(2022 - 07 - 23)
            //}).ToArray();

            //var model =  Enumerable.Range(1, 5).Select(item => new Produit()
            //{
            //    Id = item,
            //    Drug_code = 225,
            //    Class_name = "Humain",
            //    Drug_identification_number = 00000019,
            //    Brand_name = "PLACIDYL CAP 200MG",
            //    Descriptor = "",
            //    Number_of_ais = 1,
            //    Ai_group_no = 0107593001,
            //    Company_name = "ABBOTT LABORATORIES, LIMITED",
            //    Last_update_date = new DateTime(2008 - 07 - 23),
            //    Purchase_price = 20.00,
            //    Sell_price = 25.00,
            //    Ppa = 29.00,
            //    Expiry_date = new DateTime(2022 - 07 - 23)
            //}).ToArray();

            //var model = this._context.Produits.ToList();
            var produitsList = _repository.GetAll(produitId);
            var query = produitsList;
            //var query = from produit in this._context.Produits
            //            select produit;

            return this.Ok(query);
            //return this.StatusCode(StatusCodes.Status204NoContent);
        }

        //[Route("photos")]
        //[HttpPost]
        //public async Task<IActionResult> AddPicture()
        //{
        //    using var stream = new StreamReader(this.Request.Body);

        //    var content = await stream.ReadToEndAsync();

        //    return this.Ok();
        //}

        [Route("photos")]
        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile picture)
        {
            string filePath = Path.Combine(this._webHostEnvironment.ContentRootPath, "images\\produits");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            filePath = Path.Combine(filePath, picture.FileName);

            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            await picture.CopyToAsync(stream);

            var itemFile = this._repository.AddOnePicture(filePath);
            try
            {
                this._repository.unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }

            return this.Ok(itemFile);
        }

        [HttpPost]
        public IActionResult AddOne(Produit produit)
        {
            IActionResult result = this.BadRequest();
            Produit addProduit = this._repository.AddOne(new Produit()
            {

                NomCommercial = produit.NomCommercial,
                DatePeremption = produit.DatePeremption,
                PrixAchat = produit.PrixAchat,
                PrixVente = produit.PrixVente,
                PrixPpa = produit.PrixPpa,
                MoleculeId = produit.MoleculeId,
                LotId = produit.LotId,
                LaboId = produit.LaboId,
                PictureId = produit.PictureId,
  
            });
            this._repository.unitOfWork.SaveChanges();
            if (addProduit != null)
            {
                produit.Id = addProduit.Id;
                result = this.Ok(produit);
            }
            return result;
        }

        [HttpDelete]
        public IActionResult DeleteProduit([FromQuery] int produitId)
        {
            IActionResult result = BadRequest();
            Produit DeletedProduit = this._repository.DeleteProduit(produitId);
            this._repository.unitOfWork.SaveChanges();
            if (DeletedProduit != null)
            {
                DeletedProduit.Id = produitId;
                result = this.Ok(DeletedProduit);
            }
            return result;
        }

        #endregion 



    }

}