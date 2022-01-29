using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace MachineTest.Models
{
    public class DataLayer
    {
        public static string Constr = "";
        public DataLayer()
        {
            Constr = ConfigurationManager.AppSettings.Get("con");
        }
        internal DataTable GetAllCountry()
        {
            DataTable dt = new DataTable();
            string sql = "";
            using (SqlConnection con = new SqlConnection(Constr))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    sql = "select Country_Id,Country_Name from tbl_CountryMaster";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(dt);
                }
                catch (Exception ex)
                {
                    dt = null;
                    con.Close();
                }
            }
            return dt;
        }

        internal DataTable GetPaymentTermsDay()
        {
            DataTable dt = new DataTable();
            string sql = "";
            using (SqlConnection con = new SqlConnection(Constr))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    sql = "select PayTerms_Id,PayTermsDay from tbl_PaymentTermsMaster";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(dt);
                }
                catch (Exception ex)
                {
                    dt = null;
                    con.Close();
                }
            }
            return dt;
        }

      

        internal DataTable GetVendorsList()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Constr))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllVendors", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(dt);
                }
                catch (Exception ex)
                {
                    dt = null;
                    con.Close();
                }
            }
            return dt;
        }

        internal bool SaveVendorDetails(VendorModel obj)
        {
            bool flag = false;
            using (SqlConnection con = new SqlConnection(Constr))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_VendorDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] sp = new SqlParameter[16];
                    sp[0] = new SqlParameter("@Vendor_Id  ", obj.Vendor_Id);
                    sp[1] = new SqlParameter("@Vendor_Code  ", obj.Vendor_Code);
                    sp[2] = new SqlParameter("@Vendor_Name  ", obj.Vendor_Name);
                    sp[3] = new SqlParameter("@Vendor_Address  ", obj.Vendor_Address);
                    sp[4] = new SqlParameter("@PostalCode  ", obj.PostalCode);
                    sp[5] = new SqlParameter("@CountryId  ", obj.Country);
                    sp[6] = new SqlParameter("@Vendor_EmailId  ", obj.Vendor_EmailId);
                    sp[7] = new SqlParameter("@Contact_Person  ", obj.Contact_Person);
                    sp[8] = new SqlParameter("@Contact_Number  ", obj.Contact_Number);

                    sp[9] = new SqlParameter("@Vat_RegistrationNo   ", obj.Vat_RegistrationNo);
                    sp[10] = new SqlParameter("@Payment_TermsDay   ", obj.Payment_TermsDay);
                    sp[11] = new SqlParameter("@Payment_Terms   ", obj.Payment_Terms);
                    sp[12] = new SqlParameter("@Contract_StartDate   ", obj.Contract_StartDate);

                    sp[13] = new SqlParameter("@Contract_ExpiryDate    ", obj.Contract_ExpiryDate);
                    sp[14] = new SqlParameter("@IsCompaySigned    ", obj.IsCompaySigned);
                    sp[15] = new SqlParameter("@AddedBy    ", "Ranjeet");

                    cmd.Parameters.AddRange(sp);
                    int affectedrow = cmd.ExecuteNonQuery();
                    flag = affectedrow > 0 ? flag = true : flag = false;

                }
                catch (Exception ex)
                {
                    flag = false;
                    con.Close();
                }
            }
            return flag;
        }

        internal bool DeleteVendor(int vendorid)
        {
            bool flag = false;
            string sql = "";
            using (SqlConnection con = new SqlConnection(Constr))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    sql = "update tbl_VendorDetails set IsActive=0 where Vendor_Id='"+ vendorid + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    flag = true;
                }
                catch (Exception ex)
                {
                    flag = false;
                    con.Close();
                }
            }
            return flag;
        }


        internal DataTable UpdateVendordetails(int? vendorid)
        {
            DataTable dt = new DataTable();
            string sql = "";
            using (SqlConnection con = new SqlConnection(Constr))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    sql = "select *from tbl_VendorDetails where Vendor_Id='"+vendorid+ "' and IsActive=1";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(dt);
                }
                catch (Exception ex)
                {
                    dt = null;
                    con.Close();
                }
            }
            return dt;
        }
    }
}