using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modele;
using Thymio_V2;
using ThymioApplication.Models;

namespace ThymioApplication.Controllers
{
    public class HomeController : Controller
    {
        ThymioV2 thymio;
        string fileEmplacement;
        List<string> list;

        public HomeController()
        {
            list = new List<string>();
            
            fileEmplacement = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            Debug.WriteLine("------------------------------");
            Debug.WriteLine(fileEmplacement);
            thymio = new ThymioV2();
            
        }
        
        public IActionResult Index()
        {
            
            return View();
            
        }


        public IActionResult AjouterInstruction()
        {
           
            list.Add("instruction 2");
            list.Add("instruction 2");

            thymio.ForwardAtDistanceToSpeed(0,50);
            
            thymio.Fin();
            
            //return RedirectToPage("Index1");
            return View("Index1",list);
        }

        public IActionResult Transformer()
        {
            string []dataFile = System.IO.File.ReadAllLines(@"D:\bilel\Desktop\thymio II\thymio2018\Thymio2018\foo.aesl");
            //System.IO.File.Copy(@"~/../wwwroot/FichierAseba/base.aesl", @"~/../wwwroot/FichierAseba/base.txt", true);
            ViewData["isDataFile"] = "true";
            return View("Index1",dataFile);
        }


        public IActionResult Transfert()
        {
            //Transfert t = new Transfert("~/../wwwroot/FichierAseba/base.aesl");
            Transfert t = new Transfert(@"D:\bilel\Desktop\thymio II\thymio2018\Thymio2018\foo.aesl");
            //Boolean ok = t.transfertFileToThymio();
            //Debug.WriteLine(ok);
            //if (ok)
            //{
            //    ViewData["Transfert"] = "Transfert Ok";
            //}
            //else
            //{
            //    ViewData["Transfert"] = "Echec de transfert";
            //}
            return View("Index1");
        }


        public IActionResult Test()
        {
            //Console.Write("frgelqglnqe");
            

            return View("Index1");
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
              
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        
        
        // 
        // GET: /HelloWorld/Welcome/
        public IActionResult Index1()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
