using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DDOOCP_00165658
{
    class userinfo
    {


        public static int MyUser_ID { get; set; }
        public static string MyUser_position { get; set; }
        public static string UserName { get; set; }

        public static int getMyUserID(string UsrName)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\New folder\DDOOCP_00165658\DDOOCP_00165658\sticky_notes.mdf;Integrated Security=True");

            //This code is for login in to the Sticky note.....
            SqlCommand CMD = new SqlCommand("Select * From registration where user_name ='" + UsrName + "'", con);
            con.Open();
            SqlDataReader SDRead = CMD.ExecuteReader();
            if (SDRead.Read())
            {
                return Int32.Parse(SDRead[0].ToString());
            }
            con.Close();
            return 0;
        }

        public static string getMyUserposition(string UsrName)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\New folder\DDOOCP_00165658\DDOOCP_00165658\sticky_notes.mdf;Integrated Security=True");

            //This code is for login in to the Sticky note.....
            SqlCommand CMD = new SqlCommand("Select * From registration where user_name ='" + UsrName + "'", con);
            con.Open();
            SqlDataReader SDRead = CMD.ExecuteReader();
            if (SDRead.Read())
            {
                return SDRead[7].ToString();
            }
            con.Close();
            return "";
        }



    }

    class note
    {


        public static int note_id;

     
    }
}
