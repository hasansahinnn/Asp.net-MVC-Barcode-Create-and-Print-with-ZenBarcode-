using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zen.Barcode;

namespace Barcode.Controllers
{
    public class HomeController : Controller
    {
        public BarcodeDraw bdraw = BarcodeDrawFactory.GetSymbology(BarcodeSymbology.Code128);
        public Image barcodeImage;
        public ActionResult Index()
        {

            return View();
        }

        public PartialViewResult Barcode(string barcodeno = "")
        {
            if (barcodeno == "")
            {
                 barcodeno = "100";
            }
            Session["BarcodeNo"] = barcodeno;
            barcodeImage = bdraw.Draw(barcodeno, 40, 2);
            MemoryStream ms = new MemoryStream();
            barcodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            byte[] byteData = ms.ToArray();
            Session["barcodeimagebyte"] = byteData;
            return PartialView();
        }


    }
}