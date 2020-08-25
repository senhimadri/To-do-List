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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\New folder\DDOOCP_00165658\DDOOCP_00165658\sticky_notes.mdf;Integrated Security=True");
        public void userinformatiom()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from registration where user_id='" + userinfo.MyUser_ID + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                label1.Text = dr[0].ToString();
                label2.Text = dr[1].ToString();
                label3.Text = dr[2].ToString();
                label4.Text = dr[3].ToString();
                label5.Text = dr[4].ToString();
                label6.Text = dr[5].ToString();
                label7.Text = dr[6].ToString();
                label8.Text = dr[7].ToString();

                
            }
         
            con.Close();
        }
        public void updateuserinformatiom()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from registration where user_id='" + userinfo.MyUser_ID + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string gender= dr[4].ToString();

                if (gender == "Male") { radioButton1.Checked = true; }
                else { radioButton2.Checked = true; }
                label17.Text = "You Are Not Allow To Change This";
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[3].ToString();
               
            
                dateTimePicker1 .Text = dr[5].ToString();
                textBox4.Text = dr[6].ToString();
                label8.Text = dr[7].ToString();
                textBox3.Text= dr[2].ToString();
                label18.Text = "You Are Not Allow To Change This";

            }

            con.Close();
        }

        public void update()
        {
            string gender;
            if (radioButton1.Checked == true) { gender = "Male"; }
            else if (radioButton2.Checked == true) { gender = "Femail"; }
            else { gender = ""; }
            con.Open();
            SqlCommand cmd = new SqlCommand("update registration set name='" + textBox1.Text + "', user_name='" + textBox3.Text + "' , email='" + textBox2.Text + "' , gender='" + gender + "' , birth_date='" + dateTimePicker1.Text + "' , password='" + textBox4.Text + "' where user_id='" + userinfo.MyUser_ID + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data updated..");
            con.Close();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = true;
            button2.Visible = false;
            button1.Visible = true;
            userinformatiom();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            button2.Visible = true;
            button1.Visible = false;
            updateuserinformatiom();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
            userinformatiom();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = true;
            button2.Visible = false;
            button1.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 ggg = new Form2();
            ggg.Visible = true;
        }
    }
}
