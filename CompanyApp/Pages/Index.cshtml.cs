using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Data.SqlClient;

namespace CompanyApp.Pages
{
    public class IndexModel : PageModel
    {
        public string companyName;
        public string website;
        


        public void OnGet()
        {
            string connectionString = "Data Source=tcp:myb2csqlserver.database.windows.net,1433;Initial Catalog=mydb;Persist Security Info=False;User ID=myb2cuser;Password=MyB2C123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string sqlQuery = "select CompanyName, website from COMPANY where CompanyId=1";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader(); //to reterieve data from db
            if (dr.Read())
            {
                companyName = dr["CompanyName"].ToString();
                website = dr["website"].ToString();

            }
            System.Console.WriteLine("Company Name", companyName);
            System.Console.WriteLine("Website", website);
            con.Close();
        }
    }
}
