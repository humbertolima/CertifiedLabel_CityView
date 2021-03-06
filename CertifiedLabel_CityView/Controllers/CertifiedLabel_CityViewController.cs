﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Http;
using System.Web.Http;
using CertifiedLabel_CityView.Models;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace CertifiedLabel_CityView.Controllers
{
    public class CertifiedLabel_CityViewController : Controller
    {
        private CityViewEntities db = new CityViewEntities();
        private CertifiedLabelEntities db1 = new CertifiedLabelEntities();
        private string label_CityView = System.Configuration.ConfigurationManager.AppSettings["label_CityView"];
        private string label_Parameters = System.Configuration.ConfigurationManager.AppSettings["label_Parameters"];
        private string signatures_Range = System.Configuration.ConfigurationManager.AppSettings["signatures_Range"];
        private string signature_CertifiedNumber = System.Configuration.ConfigurationManager.AppSettings["signature_CertifiedNumber"];
        private string disk = System.Configuration.ConfigurationManager.AppSettings["disk"];

        //HttpClient client = new HttpClient();
       

        //GET: CertifiedLabel_CityView/CreateLabel_By_RecordID
        public ActionResult Create_Label_By_RecordID()
        {
            return View();
        }

        // POST: CertifiedLabel_CityView/Get_CreateLabel_By_RecordID
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]    
        public ActionResult Get_Create_Label_By_RecordID(int RecordID)
        {
            HttpClient client = new HttpClient();
            string url = label_CityView + RecordID;

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                string errorMsg = response.ReasonPhrase;
                //Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception(errorMsg));
                ViewBag.ErrorMessage = errorMsg;
                return View("Error");
            }
            else
            {
                string myFileName = response.ReasonPhrase + "_Label.pdf";  //Certified Number generated by Certified Label Service            
                string myFullPath = disk + @"\" + myFileName; //Path where labels are going to be stored

                FileStream stream = new FileStream(myFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                response.Content.CopyToAsync(stream).ContinueWith(
                  (copyTask) =>
                  {
                      stream.Close();
                  });

                var fileStream = new FileStream(myFullPath,
                                     FileMode.Open,
                                     FileAccess.ReadWrite,
                                     FileShare.ReadWrite
                                     );
                var fsResult = new FileStreamResult(fileStream, "application/pdf");
                return fsResult;
            }
        }

        // GET: CertifiedLabel_CityView/Get_Signature_Certified_Number
        public ActionResult Signature_Certified_Number()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult Get_Signature_Certified_Number(string CertifiedNumber)
        {           
            HttpClient client = new HttpClient();
            string url = signature_CertifiedNumber + CertifiedNumber;

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                string errorMsg = response.ReasonPhrase;
                //Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception(errorMsg));
                ViewBag.ErrorMessage = errorMsg;
                return View("Error");
            }
            else
            { 
                string myFileName = CertifiedNumber + "_Signature.pdf";
                string myFullPath = disk + @"\" + myFileName; //Path where labels are going to be stored

                FileStream stream = new FileStream(myFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                response.Content.CopyToAsync(stream).ContinueWith(
                  (copyTask) =>
                  {
                      stream.Close();
                  });

                var fileStream = new FileStream(myFullPath,
                                     FileMode.Open,
                                     FileAccess.ReadWrite,
                                     FileShare.ReadWrite
                                     );
                var fsResult = new FileStreamResult(fileStream, "application/pdf");
                return fsResult;
            }
            
        }

        public ActionResult Reprint_Certified_Number()
        {
            return View();
        }
        public ActionResult Get_Reprint_Certified_Number(string CertifiedNumber)
        {
            try
            { 
               string myFileName = CertifiedNumber + "_Label.pdf";
               string myFullPath = disk + @"\" + myFileName; //Path where labels are stored

               var fileStream = new FileStream(myFullPath,
                                    FileMode.Open,
                                    FileAccess.ReadWrite,
                                    FileShare.ReadWrite
                                    );

               var fsResult = new FileStreamResult(fileStream, "application/pdf");
               return fsResult;
            }
            catch (Exception ex)
            {
                string errorMsg = "Label doesn't exist in this path";
                //Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception(errorMsg));
                ViewBag.ErrorMessage = errorMsg;
                return View("Error");
                //Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex);
            }
        }
        
        public ActionResult Error(string error)
        {

            return View();
        }


    }
}