using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Mvc;
using System.Data;

namespace MachineTest.Models
{
    public class VendorModel
    {
        public int Vendor_Id { get; set; }
        public string Vendor_Code { get; set; }
        public string Vendor_Name { get; set; }
        public string Vendor_Address { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Vendor_EmailId { get; set; }

        public string Contact_Person { get; set; }
        public string Contact_Number { get; set; }
        public string Vat_RegistrationNo { get; set; }
        public string Payment_TermsDay { get; set; }

       

        public string Payment_Terms { get; set; }
        public string Contract_StartDate { get; set; }
        public string Contract_ExpiryDate { get; set; }
        public bool IsCompaySigned { get; set; }
        public string Addedby { get; set; }
        public string Mode { get; set; }

        public List<VendorModel> lstVendorModel { get; set; }
        internal VendorModel GetInitialData()
        {
            BusinessLayer objbus = new BusinessLayer();
            VendorModel main = new VendorModel();
            main.lstVendorModel = new List<VendorModel>();
            DataTable dt = new DataTable();
            dt = objbus.GetVendorsList();
            if (BusinessLayer.CheckDataTable(dt))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VendorModel vm = new VendorModel();
                    
                    vm.Vendor_Id =Convert.ToInt32(dt.Rows[i]["Vendor_Id"].ToString());
                    vm.Vendor_Code = dt.Rows[i]["Vendor_Code"].ToString();
                    vm.Vendor_Name = dt.Rows[i]["Vendor_Name"].ToString();
                    vm.Vendor_Address = dt.Rows[i]["Vendor_Address"].ToString();
                    vm.Vendor_EmailId = dt.Rows[i]["Vendor_EmailId"].ToString();
                    vm.Vat_RegistrationNo = dt.Rows[i]["Vat_RegistrationNo"].ToString();
                    vm.Country = dt.Rows[i]["Country_Name"].ToString();
                    vm.Addedby = dt.Rows[i]["AddedBy"].ToString();
                    main.lstVendorModel.Add(vm);
                }
            }
            return main;
        }

        internal VendorModel UpdateVendordetails(int? vendorid)
        {
            BusinessLayer objbus = new BusinessLayer();
            VendorModel main = new VendorModel();
            DataTable dt = new DataTable();
            dt = objbus.UpdateVendordetails(vendorid);
            if (BusinessLayer.CheckDataTable(dt))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    main.Vendor_Id = Convert.ToInt32(dt.Rows[0]["Vendor_Id"].ToString());
                    main.Vendor_Code = dt.Rows[0]["Vendor_Code"].ToString();
                    main.Vendor_Name = dt.Rows[0]["Vendor_Name"].ToString();
                    main.Vendor_Address = dt.Rows[0]["Vendor_Address"].ToString();
                    main.Vendor_EmailId = dt.Rows[0]["Vendor_EmailId"].ToString();
                    main.Vat_RegistrationNo = dt.Rows[0]["Vat_RegistrationNo"].ToString();
                    main.Country = dt.Rows[0]["CountryId"].ToString();
                    main.Addedby = dt.Rows[0]["AddedBy"].ToString();
                    main.Mode = "U";
                }
            }
            return main;
        }
    }
}