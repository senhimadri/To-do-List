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

namespace DDOOCP_00165658
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public string indexs;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\New folder\DDOOCP_00165658\DDOOCP_00165658\sticky_notes.mdf;Integrated Security=True");
           void load()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM notes where user_Id =" + userinfo.MyUser_ID + " ORDER bY date desc", con);
            SqlDataAdapter ADPT = new SqlDataAdapter(cmd);
            DataTable Data_Table = new DataTable();
            ADPT.Fill(Data_Table);
            dataGridView1.DataSource = Data_Table;

            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            load();
            addCat();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[0].Visible = false;
            Cataa();
        }
        private void addCat()
        {
            con.Open();


            SqlDataAdapter SDA = new SqlDataAdapter("select Catagory_Name from catagory where User_Id=" + userinfo.MyUser_ID + "", con);
            DataTable DT = new DataTable();
            SDA.Fill(DT);



            comboBox1.DataSource = DT;
            comboBox1.DisplayMember = "Catagory_Name";
            comboBox1.ValueMember = "Catagory_Name";
            con.Close();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("You Mast Write a Title");

            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM notes where user_id =" + userinfo.MyUser_ID + " and title like '" + textBox1.Text + "%' ORDER bY date", con);


                SqlDataAdapter sen = new SqlDataAdapter(cmd);
                DataTable Data_Table = new DataTable();
                sen.Fill(Data_Table);
                dataGridView1.DataSource = Data_Table;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int ss = Int32.Parse(indexs);

            if (ss>0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from notes where n_id =" + ss + " and  User_Id =" + userinfo.MyUser_ID + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted");

                int rowindex = dataGridView1.CurrentCell.RowIndex;

                dataGridView1.Rows.RemoveAt(rowindex);
            }
            else
            {
                MessageBox.Show("You Mast Select an Index");
            }
          

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
           
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            indexs = selectedRow.Cells[0].Value.ToString();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

            note.note_id = Int32.Parse(indexs);
            this.Visible = false;
            Form3 fr = new Form3();

            fr.Visible = true;

            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 ggg = new Form2();
            ggg.Visible = true;
        }
        private void Cataa()
        {
            con.Open();


            SqlDataAdapter SDA = new SqlDataAdapter("select Catagory_Name from catagory where User_Id=" + userinfo.MyUser_ID + "", con);
            DataTable DT = new DataTable();
            SDA.Fill(DT);



            comboBox1.DataSource = DT;
            comboBox1.DisplayMember = "Catagory_Name";
            comboBox1.ValueMember = "Catagory_Name";


          
            con.Close();




        }
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM notes where user_id =" + userinfo.MyUser_ID + " and date='" + dateTimePicker1.Text + "' ORDER bY date", con);


            SqlDataAdapter sen = new SqlDataAdapter(cmd);
            DataTable Data_Table = new DataTable();
            sen.Fill(Data_Table);
            dataGridView1.DataSource = Data_Table;

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM notes where user_id =" + userinfo.MyUser_ID + " and Catagory='" + comboBox1.SelectedValue.ToString() + "' ORDER bY date", con);


            SqlDataAdapter sen = new SqlDataAdapter(cmd);
            DataTable Data_Table = new DataTable();
            sen.Fill(Data_Table);
            dataGridView1.DataSource = Data_Table;

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM notes where user_Id =" + userinfo.MyUser_ID + " and Status ='" + "Completed" + "' ORDER bY date", con);
            SqlDataAdapter ADPT = new SqlDataAdapter(cmd);
            DataTable Data_Table = new DataTable();
            ADPT.Fill(Data_Table);
            dataGridView1.DataSource = Data_Table;

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM notes where user_Id =" + userinfo.MyUser_ID + " and Status ='" + "Mised" + "' ORDER bY date", con);
            SqlDataAdapter ADPT = new SqlDataAdapter(cmd);
            DataTable Data_Table = new DataTable();
            ADPT.Fill(Data_Table);
            dataGridView1.DataSource = Data_Table;

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            load();
        }
    }
}
