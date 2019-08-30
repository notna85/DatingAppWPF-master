using DatingAppWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppWPF.ViewModels
{
    public class vm_ReplayMessage
    {
        public Person RM { get; set; }

        public vm_ReplayMessage()
        {
            RM = new Person();
            SetUsername();
        }

        public void SetUsername()
        {
            DataTable dt = new DataTable();
            dt = SQL.ShowProfile("Select username from users where userid =" + App.Current.Resources["MatchID"]);
            RM.UserName = dt.Rows[0]["username"].ToString();
        }

        //public int ReturnMessageID()
        //{
        //    int matchID = (int)App.Current.Resources["MatchID"];
        //    int userID = (int)App.Current.Resources["UserID"];
        //    DataTable table = new DataTable();
        //    string statement = "select messagesid from messages where sender=" + matchID + " and receiver=" + userID;
        //    table = SQL.ShowProfile(statement);
        //    int MessageID = Convert.ToInt32(table.Rows[0]["messagesid"]);

        //    return MessageID;
        //}
    }
}
