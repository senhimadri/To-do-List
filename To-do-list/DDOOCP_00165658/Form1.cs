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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\New folder\DDOOCP_00165658\DDOOCP_00165658\sticky_notes.mdf;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            String value;

            if (radioButton1.Checked)
                value = "Male";
            else if (radioButton2.Checked)
                value = "Female";
            else
                value = "";

            //name,username,email,gender,password,cpassword;
            string rname = textBoxname.Text;
            string rusername = textBoxusername.Text;
            string remail = textBoxemail.Text;
            string rgender = value;
            string rdate = dateTimePicker1.Text;
            string rpassword = textBoxpassword.Text;
            string rcpassword = textBoxcpassword.Text;

        

            if (rname == "" || rusername == "" || remail == "" || rgender == "" || rdate == "" || rpassword == "" || rcpassword == "" || rpassword != rcpassword)
            {
                if (rname == "")
                {
                    labela.Text = "Enter Your Name";
                }
                else
                {
                    labela.Text = "";
                }

                if (rusername == "")
                {
                    labelb.Text = "Choice an User Name";
                }
                else
                {
                    labelb.Text = "";
                }
                if (remail == "")
                {
                    labelc.Text = "Enter Your Email/Phone";

                }
                else
                {
                    labelc.Text = "";
                }
                if (rgender == "")
                {
                    labeld.Text = "Select Your Gender";
                }
                else
                {
                    labeld.Text = "";
                }
                if (rdate == "")
                {
                    labele.Text = "Select Your Date of Birth";
                }
                else
                {
                    labele.Text = "";
                }
                if (rpassword == "")
                {
                    labelf.Text = "Enter Your Password";
                }
                else
                {
                    labelf.Text = "";
                }
                if (rcpassword == "")
                {
                    labelg.Text = "Conferm Your Password";
                }
                else
                {
                    labelg.Text = "";
                }
                if (rpassword != rcpassword)
                {
                    labelh.Text = "Password Doesn't Match";
                }
                else
                {
                    labelh.Text = "";
                }
            }


            else
            {
                DialogResult result = MessageBox.Show("Are You Sure This Data is Correct?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    

                    con.Open();
                    string cmd = "insert into registration(Name,User_Name,Email,Gender,Birth_Date,password,Position) values('" + rname + "','" + rusername + "','" + remail + "','" + rgender + "','" + rdate + "','" + rpassword + "','" + "user" + "')";
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd, con);
                    SDA.SelectCommand.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Register Successfully");

                    textBoxname.Text = "";
                    textBoxusername.Text = "";
                    textBoxemail.Text = "";


                    textBoxpassword.Text = "";
                    textBoxcpassword.Text = "";

                    labela.Text = "";
                    labelb.Text = "";
                    labelc.Text = "";
                    labeld.Text = "";
                    labele.Text = "";
                    labelf.Text = "";
                    labelg.Text = "";
                    labelh.Text = "";


                }
                else
                {
                    this.Visible = true;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userinfo.MyUser_ID = userinfo.getMyUserID(textBoxluname.Text);
            userinfo.MyUser_position = userinfo.getMyUserposition(textBoxluname.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from registration where user_name='" + textBoxluname.Text + "'and password='" + textBoxlpassword.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("");

      

                Form2 fr = new Form2();
                fr.Show();
                this.Hide();

               
            }
            else
            {
                MessageBox.Show("Login failed..");
            }
            con.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
