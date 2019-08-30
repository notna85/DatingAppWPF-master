using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppWPF.Models;
using System.Data;

namespace DatingAppWPF.ViewModels
{
    public class vm_ReadMessage
    {
        public Person M { get; set; }

        public vm_ReadMessage(int messageID)
        {
            M = new Person();
            SetMessageValues(messageID);
        }

        public void SendMessage()
        {
            string message = "";
            SQL.sqlCommand(message);
        }

        public void SetMessageValues(int messageID)
        {
            int matchID = (int)App.Current.Resources["MatchID"];
            int userID = (int)App.Current.Resources["UserID"];
            DataTable table = new DataTable();
            string statement = "select content from messages where messagesid=" + messageID + " and receiver=" + userID;
            table = SQL.ShowProfile(statement);
            M.Message = table.Rows[0]["content"].ToString();
            string statement2 = "select username from v_person where userid=" + matchID;
            table = SQL.ShowProfile(statement2);
            M.UserName = table.Rows[0]["username"].ToString();
        }
    }
}
