using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticalExamModel
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlDataAdapter daUsers, daPosts;
        SqlCommandBuilder cbPosts;
        DataSet ds;
        BindingSource bsUsers, bsPosts;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source = DESKTOP-S6C1A6M; Initial Catalog = " +
                "MiniFacebook; Integrated Security = SSPI");
            daUsers = new SqlDataAdapter("SELECT * FROM Users", conn);
            daPosts = new SqlDataAdapter("SELECT * FROM Posts", conn);
            cbPosts = new SqlCommandBuilder(daPosts);
            daPosts.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            ds = new DataSet();
            daUsers.Fill(ds, "Users");
            daPosts.Fill(ds, "Posts");

            DataRelation dr = new DataRelation("FK_Posts_Users", ds.Tables["Users"].Columns["UserID"],
                ds.Tables["Posts"].Columns["UserID"]);
            ds.Relations.Add(dr);

            bsUsers = new BindingSource();
            bsUsers.DataSource = ds;
            bsUsers.DataMember = "Users";

            bsPosts = new BindingSource();
            bsPosts.DataSource = bsUsers;
            bsPosts.DataMember = "FK_Posts_Users";

            dgvUsers.DataSource = bsUsers;
            dgvPosts.DataSource = bsPosts;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            daPosts.Fill(ds, "Posts");
        }

        private void btnSavePosts_Click(object sender, EventArgs e)
        {
            daPosts.Update(ds, "Posts");
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
