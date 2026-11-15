
using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace PlacementDashboard
{
    public partial class Default : System.Web.UI.Page
    {
        string cs = ConfigurationManager
            .ConnectionStrings["PlacementDB"]
            .ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSummary();
                LoadStudents();
            }
        }

        // Load placement summary
        private void LoadSummary()
        {
            using (MySqlConnection con =
                new MySqlConnection(cs))
            {
                con.Open();

                // Total students
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM Students", con);

                lblTotal.Text =
                    cmd.ExecuteScalar().ToString();

                // Placed students
                cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM Students WHERE IsPlaced=1",
                    con);

                lblPlaced.Text =
                    cmd.ExecuteScalar().ToString();

                // Not placed students
                cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM Students WHERE IsPlaced=0",
                    con);

                lblNotPlaced.Text =
                    cmd.ExecuteScalar().ToString();

                // Placement percentage
                int total = Convert.ToInt32(lblTotal.Text);
                int placed = Convert.ToInt32(lblPlaced.Text);

                double percentage = total > 0
                    ? (placed * 100.0) / total
                    : 0;

                lblPercentage.Text =
                    percentage.ToString("F2") + "%";

                // Highest package
                cmd = new MySqlCommand(
                    "SELECT IFNULL(MAX(PackageLPA),0) FROM Placements",
                    con);

                decimal highest =
                    Convert.ToDecimal(cmd.ExecuteScalar());

                lblHighestPackage.Text =
                    highest.ToString("F2") + " LPA";
            }
        }

        // Load student records
        private void LoadStudents()
        {
            string query = @"
                SELECT
                    S.EnrollmentNo,
                    S.StudentName,
                    S.Department,
                    P.CompanyName,
                    P.PackageLPA

                FROM Students S

                LEFT JOIN Placements P
                ON S.StudentId = P.StudentId

                ORDER BY S.EnrollmentNo";

            using (MySqlConnection con =
                new MySqlConnection(cs))
            using (MySqlDataAdapter da =
                new MySqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();

                da.Fill(dt);

                gvPlacements.DataSource = dt;

                gvPlacements.DataBind();
            }
        }
    }
}
