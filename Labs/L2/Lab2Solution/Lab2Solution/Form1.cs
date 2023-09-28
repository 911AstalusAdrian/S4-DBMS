using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Lab2Solution
{
    public partial class Form1 : Form
    {
        SqlConnection myConn;
        DataSet myDataSet = new DataSet();
        SqlDataAdapter parentDA, childDA;
        BindingSource firstBS = new BindingSource();
        BindingSource secondBS = new BindingSource();
        DataRelation drParentChild;
        SqlCommandBuilder parentCB, childCB;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeDB() 
        {
            // Get the Connection String from the config file
            String connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // use the Connection String to create the SQL Connection to the DB
            myConn = new SqlConnection(connStr);

            // setting the Data Adapters for the Parent and Child tables
            parentDA = new SqlDataAdapter(ConfigurationManager.AppSettings["SelectParent"], myConn);
            childDA = new SqlDataAdapter(ConfigurationManager.AppSettings["SelectChild"], myConn);

            // initialize Command builders
            childCB = new SqlCommandBuilder(childDA);


            // fill the data
            parentDA.Fill(myDataSet, ConfigurationManager.AppSettings["ParentTable"]);
            childDA.Fill(myDataSet, ConfigurationManager.AppSettings["ChildTable"]);

            // create the data relation
            DataColumn parentCol = myDataSet.Tables[ConfigurationManager.AppSettings["ParentTable"]].Columns[ConfigurationManager.AppSettings["ParentKey"]];
            DataColumn childCol = myDataSet.Tables[ConfigurationManager.AppSettings["ChildTable"]].Columns[ConfigurationManager.AppSettings["ChildFK"]];
            drParentChild = new DataRelation(ConfigurationManager.AppSettings["ForeignKey"], parentCol, childCol);
            myDataSet.Relations.Add(drParentChild);
        }

        private void InitializeUI() 
        { 
            firstBS.DataSource = myDataSet;
            firstBS.DataMember = ConfigurationManager.AppSettings["ParentTable"];

            secondBS.DataSource = firstBS;
            secondBS.DataMember = ConfigurationManager.AppSettings["ForeignKey"];

            dgvParent.DataSource = firstBS;
            dgvChild.DataSource = secondBS;
        }

        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            childDA.Update(myDataSet, ConfigurationManager.AppSettings["ChildTable"]);
            Console.WriteLine("The Database has been updated.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvChild.CurrentCell.RowIndex;
            dgvChild.Rows.RemoveAt(rowIndex);
            Console.WriteLine("The entry has been removed from the GridView! Press 'Update DB' to make the changes in the DB as well.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDB();
            InitializeUI();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            myDataSet.Tables[ConfigurationManager.AppSettings["ChildTable"]].Clear();
            myDataSet.Tables[ConfigurationManager.AppSettings["ParentTable"]].Clear();
            parentDA.Fill(myDataSet, ConfigurationManager.AppSettings["ParentTable"]);
            childDA.Fill(myDataSet, ConfigurationManager.AppSettings["ChildTable"]);
            Console.WriteLine("Tables have been refreshed.");
        }
    }
}
