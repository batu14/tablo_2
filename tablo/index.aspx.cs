using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.Data.Sql;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Data.SqlTypes;
using System.Drawing;

namespace tablo
{
    
    public partial class index : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=BATUHAN;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected void Page_Load(object sender, EventArgs e)
        {
            table.CssClass = "table";
            dropLoad();
        }
        
        protected void dropLoad()
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("use test select * from sys.tables", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
                {
                    DropDownList1.Items.Add(dr["name"].ToString());
                }
            dr.Close();
            baglanti.Close();
            
                
        }

        protected void tablo_Click(object sender, EventArgs e)
        {
            string colSelect = "EXEC  sp_columns " + DropDownList1.SelectedItem.ToString() + "";
            var colNames = new List<string>();
            var rowNames = new List<string>();
            baglanti.Open();
            SqlCommand komut = new SqlCommand(colSelect, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            TableHeaderRow rows = new TableHeaderRow();
            rows.CssClass = "tableHead";
            while (dr.Read())
            {
               
                colNames.Add(dr["COLUMN_NAME"].ToString());
               

            }
           
            
            for (int i = 0; i < colNames.Count; i++)
            {
                
                TableCell cell = new TableCell();
                cell.Text = colNames[i];
                rows.Cells.Add(cell);
                table.Rows.Add(rows);
            }
            dr.Close();
           
            string row = "select * from " + DropDownList1.SelectedItem.ToString() + "";
            SqlCommand komut2 = new SqlCommand(row, baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                for (int i = 0; i < colNames.Count; i++)
                {
                    rowNames.Add(dr2[colNames[i].ToString()].ToString());
                }
            }
            for (int i = 0; i < rowNames.Count; i++)
            {
                TableRow tableRow = new TableRow();
                tableRow.CssClass = "tableBody";
                for (int j = 0; j < colNames.Count; j++)
                {
                    TableCell cell = new TableCell();
                    cell.Text = rowNames[j];
                    tableRow.Cells.Add(cell);
                  
                }
                table.Rows.Add(tableRow);



            }
            dr2.Close();
            baglanti.Close();





        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write(DropDownList1.SelectedItem.ToString());
        }
    }
    }
    