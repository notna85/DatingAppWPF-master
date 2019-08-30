using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatingAppWPF.Models
{
    public class SQL
    {
        //connectionstring
        private static string connectionString = "Server = tcp:kifarudb.database.windows.net,1433;Initial Catalog = AzureAndreasDB; Persist Security Info=False;User ID=TEClogin; Password=TEC.12345; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        public static DataTable FillComboBox(string statement)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(statement, con);
                adapter.Fill(table);
            }
            return table;
        }
        public static DataTable ShowProfile(string statement)
        {
            
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(statement, con);
                adapter.Fill(table);
            }
            return table;
        }

        public static void sqlCommand(string SQL)
        {
            //Using sørger for at lukke forbindelsen efter brug
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.ExecuteNonQuery();
            }
        }

        public static void selectMessages(int Case)
        {
            Users u = new Users();
            string statement = "";
            if (Case == 1)
            {
                statement = "select * from v_unreadmessages where receiver = '" + u.UserName + "'";
            }
            else if (Case == 2)
            {
                statement = "select * from v_readmessages where receiver = '" + u.UserName + "'";
            }
            Console.Clear();
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(statement, con);
                adapter.Fill(table);
                bool back;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Your messages\n");
                    back = false;

                    foreach (DataRow messages in table.Rows)
                    {
                        Console.WriteLine(" ID : " + messages["messagesID"].ToString());
                        Console.WriteLine(" Full name :  " + messages["sender"].ToString());
                        Console.WriteLine(" 1 = is Read, 0 = Not read " + messages["isRead"].ToString());
                        Console.WriteLine("");
                    }
                    Console.Write("Type ID of person(press q to go back): ");

                    string choice = Console.ReadLine();

                    if (choice == "q")
                        back = true;
                    else
                    {
                        if (inputCheck(choice, "0123456789", 7))
                        {
                            int id = Convert.ToInt32(choice);
                            string statement1 = "select Content from messages where messagesID = " + id;

                            SqlCommand cmd = new SqlCommand(statement1, con);
                            Console.WriteLine(cmd.ExecuteScalar());

                            if (Case == 1)
                            {
                                string statementUpdate = "update messages set isRead = 1 where messagesID = " + id;
                                SqlCommand cmd1 = new SqlCommand(statementUpdate, con);
                                cmd1.ExecuteNonQuery();
                            }
                            //menu
                            Console.ReadKey();
                            back = true;
                        }
                    }
                }
                while (back != true);
            }
        }
        public bool loginCheck(string userName, string userPass)
        {
            bool OK;

            string statement = "select username, userpass from users where username = '" + userName + "' and userpass = '" + userPass + "'";

            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(statement, con);
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                    OK = false;
                else
                    OK = true;
            }
            return OK;           
        }
        public static int selectID(string SQL)
        {
            int ID=0;
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, con);
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    Console.WriteLine("Nothing found");                    
                }
                else
                {
                    ID = Convert.ToInt32(table.Rows[0]["userID"]);
                    App.Current.Resources["UserID"] = ID;
                }               
            }
            return ID;
        }
        public static bool inputCheck(string input, string chars, int stringLength)
        {
            bool pass = true;
            //Hvis det indtastede input er tomt(null) køres der nedenstående
            if (input == "")
            {
                //pass sættes til false og metoden starter forfra
                pass = false;
            }
            else
            {
                if (input.Length <= stringLength) //Det indtastede inputs længde må ikke være længre end vores maximalt tilladte længde
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if ((chars).IndexOf(input.Substring(i, 1)) < 0) //Checker så at hver tegn i det indtastede input er en godkendt karakter
                        {
                            pass = false;
                            break;
                        }
                    }
                }
                else
                {
                    pass = false;
                }
            }
            return pass;
        }
        public static string Search()
        {
            Users u = new Users();
            string finalStatement = "";
            int userID = selectID("select userID from users where username = '" + u.UserName + "' and userpass = '" + u.UserPass + "'");
            string statement = "select minAge, maxAge, religionID, zipcode, genderID from SearchProfile where = " + userID;
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(statement, con);
                adapter.Fill(table);
            }
            StringBuilder sqlCommandText = new StringBuilder();

            sqlCommandText.Append("Select minAge , maxAge, religionID, zipcode, genderID FROM SearchProfile WHERE minAge = " + table.Rows[0]["minAge"] + " and maxAge = " + table.Rows[0]["maxAge"]);

            if (!string.IsNullOrEmpty(table.Rows[0]["religionID"].ToString()))
            {
                sqlCommandText.Append(" AND religionID = " + table.Rows[0]["religionID"]);
            }
            if (!string.IsNullOrEmpty(table.Rows[0]["religionID"].ToString()))
            {
                sqlCommandText.Append(" AND religionID = " + table.Rows[0]["religionID"]);
            }

            finalStatement = sqlCommandText.ToString();

            return finalStatement;
        }
    }
}

