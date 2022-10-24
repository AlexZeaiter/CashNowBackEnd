using CashNow.DbContexts;
using CashNow.Models;
using CashNow.Services.CompanyServices;
using CashNow.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Controllers
{
    [Route("api/ap-request")]
    [ApiController]

    public class APRequestController : Controller
    {
        private AccountPayableRequestsServices _accountPayableRequestsServices;
        private CompanyInformationService _companyInformationService;
        public APRequestController(AccountPayablesRequestsDbContext context, CompanyDbContext companyDbContext)
        {
            _companyInformationService = new CompanyInformationService(companyDbContext);
            _accountPayableRequestsServices = new AccountPayableRequestsServices(context, _companyInformationService);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddNewAP_Request(AP_RequestData ap_RequestData)
        {
            await _accountPayableRequestsServices.AddAP_RequestData(ap_RequestData);

            return Ok();
        }


        //[HttpPost("po")]
        //public async Task<IActionResult> AddPOFile([FromForm] IFormFile pOFile)
        //{
        //    var a = productSpecificationDocumentsFile.Name;
        //    var b = productSpecificationDocumentsFile.FileName;
        //    var c = productSpecificationDocumentsFile.ContentDisposition;
        //    var d = productSpecificationDocumentsFile.ContentType;
        //    var x = productSpecificationDocumentsFile.Length;

        //    if (productSpecificationDocumentsFile != null)

        //    {
        //        if (productSpecificationDocumentsFile.Length > 0)

        //        //Convert Image to byte and save to database

        //        {

        //            byte[] filebytes = null;
        //            using (var fs1 = productSpecificationDocumentsFile.OpenReadStream())
        //            using (var ms1 = new MemoryStream())
        //            {
        //                fs1.CopyTo(ms1);
        //                filebytes = ms1.ToArray();
        //            }
        //            Blog.Img = p1;

        //        }
        //    }

        //    _context.Add(client);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}
        //[HttpPost("invoice")]
        //public async Task<IActionResult> AddInvoiceFile([FromForm] IFormFile invoiceFile)
        //{
        //    var a = productSpecificationDocumentsFile.Name;
        //    var b = productSpecificationDocumentsFile.FileName;
        //    var c = productSpecificationDocumentsFile.ContentDisposition;
        //    var d = productSpecificationDocumentsFile.ContentType;
        //    var x = productSpecificationDocumentsFile.Length;

        //    if (productSpecificationDocumentsFile != null)

        //    {
        //        if (productSpecificationDocumentsFile.Length > 0)

        //        //Convert Image to byte and save to database

        //        {

        //            byte[] filebytes = null;
        //            using (var fs1 = productSpecificationDocumentsFile.OpenReadStream())
        //            using (var ms1 = new MemoryStream())
        //            {
        //                fs1.CopyTo(ms1);
        //                filebytes = ms1.ToArray();
        //            }
        //            Blog.Img = p1;

        //        }
        //    }

        //    _context.Add(client);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}
        //[HttpPost("email-confirmation")]
        //public async Task<IActionResult> AddEmailConfirmation([FromForm] IFormFile emailConfirmationFile)
        //{ 
        //    var a = productSpecificationDocumentsFile.Name;
        //    var b = productSpecificationDocumentsFile.FileName;
        //    var c = productSpecificationDocumentsFile.ContentDisposition;
        //    var d = productSpecificationDocumentsFile.ContentType;
        //    var x = productSpecificationDocumentsFile.Length;

        //    if (productSpecificationDocumentsFile != null)

        //    {
        //        if (productSpecificationDocumentsFile.Length > 0)

        //        //Convert Image to byte and save to database

        //        {

        //            byte[] filebytes = null;
        //            using (var fs1 = productSpecificationDocumentsFile.OpenReadStream())
        //            using (var ms1 = new MemoryStream())
        //            {
        //                fs1.CopyTo(ms1);
        //                filebytes = ms1.ToArray();
        //            }
        //            Blog.Img = p1;

        //        }
        //    }

        //    _context.Add(client);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}
        //[HttpPost("product-specification")]
        //public async Task<IActionResult> AddProductSpecificationDocument([FromForm] IFormFile productSpecificationDocumentsFile)
        //{
        //    var a = productSpecificationDocumentsFile.Name;
        //    var b = productSpecificationDocumentsFile.FileName;
        //    var c = productSpecificationDocumentsFile.ContentDisposition;
        //    var d = productSpecificationDocumentsFile.ContentType;
        //    var x = productSpecificationDocumentsFile.Length;

        //    if (productSpecificationDocumentsFile != null)

        //    {
        //        if (productSpecificationDocumentsFile.Length > 0)

        //        //Convert Image to byte and save to database

        //        {

        //            byte[] filebytes = null;
        //            using (var fs1 = productSpecificationDocumentsFile.OpenReadStream())
        //            using (var ms1 = new MemoryStream())
        //            {
        //                fs1.CopyTo(ms1);
        //                filebytes = ms1.ToArray();
        //            }
        //            Blog.Img = p1;

        //        }
        //    }

        //    _context.Add(client);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}

        //[HttpPost("other-documents")]
        //public async Task<IActionResult> AddOtherDocument([FromForm] IFormFile otherDocumentsFile)
        //{
        //    if (productSpecificationDocumentsFile != null)

        //    {
        //        if (productSpecificationDocumentsFile.Length > 0)

        //        //Convert Image to byte and save to database

        //        {

        //            byte[] filebytes = null;
        //            using (var fs1 = productSpecificationDocumentsFile.OpenReadStream())
        //            using (var ms1 = new MemoryStream())
        //            {
        //                fs1.CopyTo(ms1);
        //                filebytes = ms1.ToArray();
        //            }
        //            Blog.Img = filebytes;

        //        }
        //    }

        //    _context.Add(client);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}


        public class Filethingy
        {
            public IFormFile file { get; set; }
            public string FileType { get; set; }
        }
    }
}
