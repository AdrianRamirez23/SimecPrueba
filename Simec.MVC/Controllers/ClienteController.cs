using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Simec.MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Simec.MVC.Controllers
{
    public class ClienteController : Controller
    {
        string url = "https://localhost:44302/api/cliente";
        [HttpGet]
        public ActionResult Index()
        {
           
            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);
            List<Cliente> cliente = new List<Cliente>();
            foreach(var i in m)
            {
                Cliente cli = new Cliente
                {
                    IdCliente = i.idCliente,
                    NombreCompleto = i.nombreCompleto,
                    Estado= i.estado
                };
                cliente.Add(cli);
            }

            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                string Result = null;
                var objson = JsonConvert.SerializeObject(cliente);

                WebRequest request = WebRequest.Create(url);
                request.Method = "post";
                request.ContentType = "application/json;charset=UTF-8";

                using (var oSW = new StreamWriter(request.GetRequestStream()))
                {
                    oSW.Write(objson);
                    oSW.Flush();
                    oSW.Close();
                }
                WebResponse respon = request.GetResponse();

                using (var oSR = new StreamReader(respon.GetResponseStream()))
                {
                    Result = oSR.ReadToEnd();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public ActionResult Edit(string IdCliente)
        {
            var json = new WebClient().DownloadString(url+"/"+IdCliente);
            
            Cliente cliente = new Cliente();
            cliente = JsonConvert.DeserializeObject<Cliente>(json);

            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                string Result = null;
                var objson = JsonConvert.SerializeObject(cliente);

                WebRequest request = WebRequest.Create(url+"/"+cliente.IdCliente);
                request.Method = "put";
                request.ContentType = "application/json;charset=UTF-8";

                using (var oSW = new StreamWriter(request.GetRequestStream()))
                {
                    oSW.Write(objson);
                    oSW.Flush();
                    oSW.Close();
                }
                WebResponse respon = request.GetResponse();

                using (var oSR = new StreamReader(respon.GetResponseStream()))
                {
                    Result = oSR.ReadToEnd();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw(ex);
            }
           
        }
        public ActionResult Delete(string IdCliente)
        {
            try
            {
                string Result = null;
                WebRequest request = WebRequest.Create(url + "/" + IdCliente);
                request.Method = "delete";
                request.ContentType = "application/json;charset=UTF-8";
                WebResponse respon = request.GetResponse();
                using (var oSR = new StreamReader(respon.GetResponseStream()))
                {
                    Result = oSR.ReadToEnd();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }


    }
}
