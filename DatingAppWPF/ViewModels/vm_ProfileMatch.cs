using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppWPF.Models;
using System.Data;

namespace DatingAppWPF.ViewModels
{
    public class vm_ProfileMatch
    {
        public Person PM { get; set; }

        public vm_ProfileMatch()
        {
            PM = new Person();
            SetProfileMatchValues();
        }

        public int vm_LikeProcess()
        {
            return PM.likeProcess();
        }

        public void SetProfileMatchValues()
        {
            int matchID = (int)App.Current.Resources["MatchID"];
            DataTable table = new DataTable();
            string statement = "select username,firstname,lastname,age,gender,religion,height,weight,adress,descriptions,imagepath from v_person where userid = " + matchID;
            table = SQL.ShowProfile(statement);
            PM.UserName = table.Rows[0]["username"].ToString();
            PM.FirstName = table.Rows[0]["firstname"].ToString();
            PM.LastName = table.Rows[0]["lastname"].ToString();
            PM.Age = Convert.ToInt32(table.Rows[0]["age"]);
            PM.Gender = table.Rows[0]["gender"].ToString();
            PM.Religion = table.Rows[0]["religion"].ToString();
            PM.Height = Convert.ToInt32(table.Rows[0]["height"]);
            PM.Weight = Convert.ToInt32(table.Rows[0]["weight"]);
            PM.City = table.Rows[0]["adress"].ToString();
            PM.Description = table.Rows[0]["descriptions"].ToString();
            PM.ProfileImage = table.Rows[0]["imagepath"].ToString();
        }
    }
}
