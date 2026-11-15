
using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace PlacementDashboard
{
    public partial class Companies : System.Web.UI.Page
    {
        string cs = ConfigurationManager
            .ConnectionStrings["PlacementDB"]
            .ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCompanies();
            }
        }

        private void LoadCompanies()
        {
            string query = @"
                SELECT
                    P.CompanyName,
                    S.StudentName,
                    S.EnrollmentNo,
                    P.JobRole,
                    P.PackageLPA

                FROM Placements P

                INNER JOIN Students S
                ON P.StudentId = S.StudentId

                ORDER BY P.CompanyName";

            using (MySqlConnection con =
                new MySqlConnection(cs))
            using (MySqlDataAdapter da =
                new MySqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();

                da.Fill(dt);

                gvCompanies.DataSource = dt;

                gvCompanies.DataBind();
            }
        }
    }
}
