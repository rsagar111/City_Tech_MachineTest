using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MachineTest.Models;
using System.Collections;

namespace MachineTest.Controllers
{
    public class VendorController : Controller
    {
        BusinessLayer objBus = new BusinessLayer();
        // GET: Vendor
        public ActionResult VendorList()
        {
            VendorModel vm = new VendorModel();
           vm=vm.GetInitialData();
            return View(vm);
        }
        [HttpGet]
        public ActionResult AddVendor(string mode, int? vendorid)
        {
            VendorModel obj = new VendorModel();
            if (mode=="U")
            {
               
                obj = obj.UpdateVendordetails(vendorid);
                DataTable dtCountry = new DataTable();
                DataTable dtPayTerms = new DataTable();
                dtCountry = objBus.GetAllCountry();
                dtPayTerms = objBus.GetPaymentTermsDay();
                ViewBag.Country = BusinessLayer.CreateDropdownList(dtCountry);
                ViewBag.PaymentTermsDay = BusinessLayer.CreateDropdownListPaymentTerms(dtPayTerms);
            }
            else
            {
               
                DataTable dtCountry = new DataTable();
                DataTable dtPayTerms = new DataTable();
                dtCountry = objBus.GetAllCountry();
                dtPayTerms = objBus.GetPaymentTermsDay();
                ViewBag.Country = BusinessLayer.CreateDropdownList(dtCountry);
                ViewBag.PaymentTermsDay = BusinessLayer.CreateDropdownListPaymentTerms(dtPayTerms);
            }
           
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddVendor(VendorModel obj)
        {
            DataTable dtCountry = new DataTable();
            DataTable dtPayTerms = new DataTable();
            dtCountry = objBus.GetAllCountry();
            dtPayTerms = objBus.GetPaymentTermsDay();
            ViewBag.Country = BusinessLayer.CreateDropdownList(dtCountry);
            ViewBag.PaymentTermsDay = BusinessLayer.CreateDropdownListPaymentTerms(dtPayTerms);
            bool flag = objBus.SaveVendorDetails(obj);
            if (obj.Mode=="U" && flag==true)
            {
                ViewData["msg"] = "Vendor Data Updated Successfully...";
            }
            else
            {
                ViewData["msg"] = flag == true ? "Data Save Successfully..." : "Some Error Occured...";
            }
            
           
            return View(obj);
        }

        public string DeleteVendor(int vendorid)
        {
            bool flag = false;
            string result = "";
            if (vendorid!=null && vendorid > 0)
            {
              flag= objBus.DeleteVendor(vendorid);
            }
            result = flag == true ? "True" : "False";
            return result;
        }
    }
}