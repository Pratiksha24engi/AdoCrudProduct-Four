using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AdoCrudProduct_Four.Models;

namespace AdoCrudProduct_Four.Services
{
    public class ProductServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public ProductServices()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-A6U2I67\SQLEXPRESS;Initial catalog=AdoDotNetTask;Integrated Security=True");
        }
        
        public void AddProducts(product pro)
        {
            con.Open();
            cmd = new SqlCommand("Insert into tblproduct values('" + pro.productName + "','" + pro.rate + "','" + pro.tax + "','" + pro.stockQuantity + "')",con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
       
        public void UpdateProduct(product pro)
        {
            con.Open();
            cmd = new SqlCommand("Update tblproduct set productName='"+pro.productName+"',rate='"+pro.rate+"',tax='"+pro.tax+"',stockQuantity='"+pro.stockQuantity+"'where productId="+pro.productId+"", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteProduct(int id)
        {
            con.Open();
            cmd = new SqlCommand("delete from tblproduct where productId=" + id, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<product> GetAllProduct()
        {
            List<product> lst = new List<product>();
            con.Open();
            cmd = new SqlCommand("select * from tblproduct", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int pid = Convert.ToInt32(dr["productId"].ToString());
                string proname = dr["productName"].ToString();
                float rate = (float)Convert.ToDouble(dr["rate"].ToString());
                float tax = (float)Convert.ToDouble(dr["tax"].ToString());
                int qty = Convert.ToInt32(dr["stockQuantity"].ToString());

                product tp = new product() { productId = pid, productName = proname, rate = rate, tax = tax, stockQuantity = qty };
              lst.Add(tp);
            }
            con.Close();
            return lst;
        }
        public product GetProductById(int id)
        {
            List<product> lst = new List<product>();
            con.Open();
            cmd = new SqlCommand("Select * from tblproduct where productId=" + id, con);
            dr = cmd.ExecuteReader();
            product stp = new product();
            while (dr.Read())
            {
                int pid = Convert.ToInt32(dr["productId"].ToString());
                string name = dr["productName"].ToString();
                float rate = (float)Convert.ToDouble(dr["rate"].ToString());
                float tax = (float)Convert.ToDouble(dr["tax"].ToString());
                int stq = Convert.ToInt32(dr["stockQuantity"].ToString());
                stp.productId = pid;
                stp.productName = name;
                stp.rate = rate;
                stp.tax = tax;
                stp.stockQuantity = stq;
            }
            con.Close();
            return stp;
        }
    }
}