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


namespace Lab1Solution
{
    public partial class Form1 : Form
    {
        SqlConnection myConn = new SqlConnection("Data Source = DESKTOP-K1CIPD3; Initial Catalog = CinemaDB; Integrated Security = True");
        DataSet myDataSet = new DataSet();
        SqlDataAdapter parentDataAdapter = new SqlDataAdapter();
        SqlDataAdapter childrenDataAdapter = new SqlDataAdapter();
        BindingSource bindingSource = new BindingSource();

        DataRelation drCinemaRoom;
        private void btnDisplayChildren_Click(object sender, EventArgs e)
        {
            string sid = tbParentID.Text;
            childrenDataAdapter.SelectCommand = new SqlCommand("Select * from MovieRoom MR WHERE MR.CID = " + sid, myConn);
            if (myDataSet.Tables["MovieRoom"] != null)
                myDataSet.Tables["MovieRoom"].Clear();
            childrenDataAdapter.Fill(myDataSet, "MovieRoom");
            dgvChildrenTable.DataSource = myDataSet.Tables["MovieRoom"];
        }
        private void btnAddChildren_Click(object sender, EventArgs e)
        {
            childrenDataAdapter.InsertCommand = new SqlCommand("INSERT INTO MovieRoom VALUES (@RoomID, @RoomCapacity, @RoomType, @CID)", myConn);
            childrenDataAdapter.InsertCommand.Parameters.Add("@RoomID", SqlDbType.VarChar).Value = tbRoomID.Text;
            childrenDataAdapter.InsertCommand.Parameters.Add("@RoomCapacity", SqlDbType.Int).Value = tbRoomCap.Text;
            childrenDataAdapter.InsertCommand.Parameters.Add("@RoomType", SqlDbType.VarChar).Value = tbRoomType.Text;
            childrenDataAdapter.InsertCommand.Parameters.Add("@CID", SqlDbType.Int).Value = tbParentID.Text;

            myConn.Open();
            childrenDataAdapter.InsertCommand.ExecuteNonQuery();
            myConn.Close();

            myDataSet.Tables["MovieRoom"].Clear();
            childrenDataAdapter.Fill(myDataSet, "MovieRoom");
        }
        private void btnUpdateChildren_Click(object sender, EventArgs e)
        {
            childrenDataAdapter.UpdateCommand = new SqlCommand("UPDATE MovieRoom SET RoomCapacity = @RoomCapacity, RoomType = @RoomType WHERE RoomID = @RoomID", myConn);
            childrenDataAdapter.UpdateCommand.Parameters.Add("@RoomCapacity", SqlDbType.Int).Value = Int32.Parse(tbRoomCap.Text);
            childrenDataAdapter.UpdateCommand.Parameters.Add("@RoomType", SqlDbType.VarChar).Value = tbRoomType.Text;
            childrenDataAdapter.UpdateCommand.Parameters.Add("@RoomID", SqlDbType.VarChar).Value = tbRoomID.Text;

            myConn.Open();
            childrenDataAdapter.UpdateCommand.ExecuteNonQuery();
            myConn.Close();

            myDataSet.Tables["MovieRoom"].Clear();
            childrenDataAdapter.Fill(myDataSet, "MovieRoom");

        }
        private void btnRemoveChildren_Click(object sender, EventArgs e)
        {
            childrenDataAdapter.DeleteCommand = new SqlCommand("DELETE FROM MovieRoom WHERE RoomID = @RoomID", myConn);
            childrenDataAdapter.DeleteCommand.Parameters.Add("@RoomID", SqlDbType.VarChar).Value = tbRoomID.Text;

            myConn.Open();
            childrenDataAdapter.DeleteCommand.ExecuteNonQuery();
            myConn.Close();

            myDataSet.Tables["MovieRoom"].Clear();
            childrenDataAdapter.Fill(myDataSet, "MovieRoom");
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            parentDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Cinema", myConn);
            parentDataAdapter.Fill(myDataSet, "Cinema");
            dgvParentTable.DataSource = myDataSet.Tables["Cinema"];
        }

    }
}
