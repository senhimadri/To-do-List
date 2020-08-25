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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            timer1.Start();

          
        }

        public string indexs;
        public string gg;






        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\New folder\DDOOCP_00165658\DDOOCP_00165658\sticky_notes.mdf;Integrated Security=True");
     
      
       public void Gridviev()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM notes where user_Id =" + userinfo.MyUser_ID + " and Status ='" + "Sticked" + "' ORDER bY date desc", con);
            SqlDataAdapter ADPT = new SqlDataAdapter(cmd);
            DataTable Data_Table = new DataTable();
            ADPT.Fill(Data_Table);
            dataGridView1.DataSource = Data_Table;

            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Gridviev1()
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM notes where user_Id =" + userinfo.MyUser_ID + " and date >= ' "+ gg + " ' and Status ='" + "Sticked" + "' ORDER bY date", con);
            SqlDataAdapter ADPT = new SqlDataAdapter(cmd);
            DataTable Data_Table = new DataTable();
            ADPT.Fill(Data_Table);
            dataGridView1.DataSource = Data_Table;

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void Gridviev5()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM notes where user_Id =" + userinfo.MyUser_ID + " and Status ='" + "Sticked" + "' ORDER bY date", con);
            SqlDataAdapter ADPT = new SqlDataAdapter(cmd);
            DataTable Data_Table = new DataTable();
            ADPT.Fill(Data_Table);
            dataGridView1.DataSource = Data_Table;

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void Gridviev3()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM notes where user_Id =" + userinfo.MyUser_ID + " and date < ' " + gg + " ' and Status ='" + "Sticked" + "' ORDER bY date desc", con);
            SqlDataAdapter ADPT = new SqlDataAdapter(cmd);
            DataTable Data_Table = new DataTable();
            ADPT.Fill(Data_Table);
            dataGridView1.DataSource = Data_Table;

            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Gridviev2()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM notes where user_Id =" + userinfo.MyUser_ID + " and date = ' "+ gg + " 'and Status ='" + "Sticked" + "' ORDER bY date desc", con);
            SqlDataAdapter ADPT = new SqlDataAdapter(cmd);
            DataTable Data_Table = new DataTable();
            ADPT.Fill(Data_Table);
            dataGridView1.DataSource = Data_Table;

            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        if (userinfo.MyUser_position=="admin")
            {
                menuStrip1.Items[3].Visible = true;
            }
        else
            {
                menuStrip1.Items[3].Visible = false;
            }
            Gridviev5();
            label1.Text = "All Sticked Notes";
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[2].HeaderText = "Content";
            dataGridView1.Columns[3].HeaderText = "Date";
            dataGridView1.Columns[4].HeaderText = "Category";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 70;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
        }

        public void update()
            {

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            int ss= Int32.Parse(indexs);

            con.Open();
            SqlCommand cmd = new SqlCommand("update notes set Status='" + "Completed" + "' where n_id='" + ss + "'", con);
            cmd.ExecuteNonQuery();
           
            con.Close();
            int rowindex = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows.RemoveAt(rowindex);





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            indexs = selectedRow.Cells[0].Value.ToString();
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
           gg = DateTime.Now.ToShortDateString();
        
        }

        
        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            Form3 from3 = new Form3();
            from3.Visible = true;
        }

        private void allNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form4 gg = new Form4();
            gg.Visible = true;
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 FRM = new Form1();
                DialogResult result = MessageBox.Show("Are You Sure You Want to Log Out?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.Visible = false;
                    FRM.Visible = true;
                    userinfo.MyUser_ID =0;
                    userinfo.UserName = "";
                }
                else
                {
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem Deleting File");
            }
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Visible = false;

            form5.Visible = true;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Gridviev2();
            label1.Text = "Task of Today";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gridviev1();
            label1.Text = "Weating List";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Gridviev3();
            label1.Text = "Passed Task";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ss = Int32.Parse(indexs);

            con.Open();
            SqlCommand cmd = new SqlCommand("update notes set Status='" + "Mised" + "' where n_id='" + ss + "'", con);
            cmd.ExecuteNonQuery();

            con.Close();
            int rowindex = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows.RemoveAt(rowindex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Gridviev5();
            label1.Text = "All Sticked Notes";
        }
    }
}
