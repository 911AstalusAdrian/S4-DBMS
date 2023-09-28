using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PracticalExamSolution
{
    public partial class Form1 : Form{

        SqlConnection conn;
        SqlDataAdapter daParent, daChild;
        SqlCommandBuilder cb;
        DataSet ds;
        BindingSource bsParent, bsChild;

        private void btnSave_Click(object sender, EventArgs e)
        {
            daChild.Update(ds, "Students"); 
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ds.Tables["Students"].Clear();
            daChild.Fill(ds, "Students");
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){

            conn = new SqlConnection("Data Source = DESKTOP-K1CIPD3; Initial Catalog = PracticalExam ; Integrated Security = SSPI");

            daParent = new SqlDataAdapter("SELECT * FROM Groups", conn);
            daChild = new SqlDataAdapter("SELECT * FROM Students", conn);

            cb = new SqlCommandBuilder(daChild);

            ds = new DataSet();
            daParent.Fill(ds, "Groups");
            daChild.Fill(ds, "Students");

            DataRelation dr = new DataRelation("FK_Students_Groups", ds.Tables["Groups"].Columns["groupId"],
                ds.Tables["Students"].Columns["groupId"]);
            ds.Relations.Add(dr);

            bsParent = new BindingSource();
            bsParent.DataSource = ds;
            bsParent.DataMember = "Groups";

            bsChild = new BindingSource();
            bsChild.DataSource = bsParent;
            bsChild.DataMember = "FK_Students_Groups";


            dgvGroups.DataSource = bsParent;
            dgvStudents.DataSource = bsChild;


        }
    }
}
