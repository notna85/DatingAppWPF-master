using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppWPF.Models;
using System.Data;

namespace DatingAppWPF.ViewModels
{
    public class vm_Profile
    {
        public Person P { get; set; }       

        public vm_Profile()
        {
            P = new Person();
            SetProfileValues();
        }

        public void SetProfileValues()
        {
            int theUserID = (int)App.Current.Resources["UserID"];
            DataTable table = new DataTable();
            string statement = "select username,firstname,lastname,age,gender,religion,height,weight,adress,descriptions,imagepath from v_person where userid = " + theUserID;
            table = SQL.ShowProfile(statement);
            P.UserName = table.Rows[0]["username"].ToString();
            P.FirstName = table.Rows[0]["firstname"].ToString();
            P.LastName = table.Rows[0]["lastname"].ToString();
            P.Age = Convert.ToInt32(table.Rows[0]["age"]);
            P.Gender = table.Rows[0]["gender"].ToString();
            P.Religion = table.Rows[0]["religion"].ToString();
            P.Height = Convert.ToInt32(table.Rows[0]["height"]);
            P.Weight = Convert.ToInt32(table.Rows[0]["weight"]);
            P.City = table.Rows[0]["adress"].ToString();
            P.Description = table.Rows[0]["descriptions"].ToString();
            P.ProfileImage = table.Rows[0]["imagepath"].ToString();
        }
    }
}
