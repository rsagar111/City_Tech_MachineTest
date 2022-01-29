using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MachineTest.Models;
using System.Collections;
using System.Web.Mvc;

namespace MachineTest.Models
{
    public class BusinessLayer
    {
        DataLayer objdl = new DataLayer();

        internal DataTable GetAllCountry()
        {
            return objdl.GetAllCountry();
        }
        internal DataTable GetPaymentTermsDay()
        {
            return objdl.GetPaymentTermsDay();
        }

        public static List<SelectListItem> CreateDropdownList(DataTable dt)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "--All Countries--", Value = "0" });
            if (CheckDataTable(dt))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(new SelectListItem { Text = dt.Rows[i][1].ToString(),Value=dt.Rows[i][0].ToString() });
                }
            }
            else
            {
                list.Add(new SelectListItem { Text = "--None--", Value = "-1" });
            }
            return list;
        }

        public static List<SelectListItem> CreateDropdownListPaymentTerms(DataTable dt)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "--Select Payment Terms Day--", Value = "0" });
            if (CheckDataTable(dt))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(new SelectListItem { Text = dt.Rows[i][1].ToString(), Value = dt.Rows[i][0].ToString() });
                }
            }
            else
            {
                list.Add(new SelectListItem { Text = "--None--", Value = "-1" });
            }
            return list;
        }

        public static bool CheckDataTable(DataTable dt)
        {
            bool flag = false;
            if (dt!=null && dt.Rows.Count>0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;

        }

        internal DataTable GetVendorsList()
        {
            return objdl.GetVendorsList();
        }

        internal bool SaveVendorDetails(VendorModel obj)
        {
            return objdl.SaveVendorDetails(obj);
        }

        internal bool DeleteVendor(int vendorid)
        {
            return objdl.DeleteVendor(vendorid);
        }

        internal DataTable UpdateVendordetails(int? vendorid)
        {
            return objdl.UpdateVendordetails(vendorid);
        }
    }
}