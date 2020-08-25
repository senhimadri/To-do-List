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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\New folder\DDOOCP_00165658\DDOOCP_00165658\sticky_notes.mdf;Integrated Security=True");
        public int nid;
        public string catagory;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" && richTextBox1.Text=="")
            {
                MessageBox.Show("Some Fields Are Empty");

            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure This Data is Correct?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {


                    con.Open();
                    SqlCommand mycmd = new SqlCommand("insert into notes(title,content,date,catagory,user_id,Status) values('" + textBox1.Text + "','" + richTextBox1.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.SelectedValue + "','" + userinfo.MyUser_ID + "','" + "Sticked" + "')", con);
                    mycmd.ExecuteNonQuery();
                    MessageBox.Show("succsess..!");
                    con.Close();


                    con.Close();

                    Form2 re = new Form2();
                    this.Visible = false;
                    re.Visible = true;

                }
            }


            
        }

        public void updatenote()
        {


        
           
        

        }
        public void cata()
        {


            con.Open();
            SqlCommand cmd = new SqlCommand("update catagory set Catagory_Name='" + textBox3.Text + "'  where Catagory_Name='" + catagory + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data updated..");
            con.Close();



        }
       

        private void Form3_Load(object sender, EventArgs e)
        {
       
            
                addCat();

            nid = note.note_id;
            if (nid > 0)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select * from notes where n_id='" + nid + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    textBox1.Text = dr[1].ToString();

                    dateTimePicker1.Text = dr[3].ToString();

                    comboBox1.SelectedValue = dr[4].ToString();

                    richTextBox1.Text = dr[2].ToString();
                    button1.Visible = false;

                }

                con.Close();

            }
            else { button4.Visible = false; }


            //comboBox1.Items.Add("Home");
            //comboBox1.Items.Add("Work");
            //comboBox1.Items.Add("Personal");
            //comboBox1.Items.Add("Shoping");
            //comboBox1.Items.Add("Favoutite");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 ggg = new Form2();
            ggg.Visible = true;
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


            comboBox2.DataSource = DT;
            comboBox2.DisplayMember = "Catagory_Name";
            comboBox2.ValueMember = "Catagory_Name";
            con.Close();




        }





        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
            {
                MessageBox.Show("Fild Are empty");
            }
            else
            {
                con.Open();
                SqlCommand mycmd = new SqlCommand("insert into catagory (Catagory_Name,user_id)values('" + textBox2.Text + "'," + userinfo.MyUser_ID + ")", con);
                mycmd.ExecuteNonQuery();
                MessageBox.Show("succsess..!");
                con.Close();
                addCat();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            con.Open();
            SqlCommand cmd = new SqlCommand("update notes set title='" + textBox1.Text + "', content='" + richTextBox1.Text + "' , date='" + dateTimePicker1.Text + "' , catagory='" + comboBox1.SelectedValue + "' where n_id='"+ note.note_id +"'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated");
            con.Close();

            Form4 re = new Form4();
            this.Visible = false;
            re.Visible = true;
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            cata();
            addCat();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            catagory = comboBox2.SelectedValue.ToString();
            textBox3.Text = catagory;

        }
    }
}
