using DatingAppWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatingAppWPF.ViewModels
{
    public class vm_EditProfile
    {
        public Person P { get; set; }

        public vm_EditProfile()
        {
            P = new Person();
            SetProfileValues();
        }

        public void SetProfileValues()
        {
            int theUserID = (int)App.Current.Resources["UserID"];
            DataTable table = new DataTable();
            string statement = "select firstname,lastname,age,gender,religion,height,weight,zipcode,descriptions from v_person where userid = " + theUserID;
            table = SQL.ShowProfile(statement);
            P.FirstName = table.Rows[0]["firstname"].ToString();
            P.LastName = table.Rows[0]["lastname"].ToString();
            P.Age = Convert.ToInt32(table.Rows[0]["age"]);
            P.Gender = table.Rows[0]["gender"].ToString();
            P.Religion = table.Rows[0]["religion"].ToString();
            P.Height = Convert.ToInt32(table.Rows[0]["height"]);
            P.Weight = Convert.ToInt32(table.Rows[0]["weight"]);
            P.Zipcode = Convert.ToInt32(table.Rows[0]["zipcode"]);
            P.Description = table.Rows[0]["descriptions"].ToString();
        }

        public bool vm_updateProfile(string firstname, string lastname, string age, string gender, string religion, string height, string weight, string zipcode, string desc)
        {
            Person p = new Person();
            p.FirstName = firstname;
            p.LastName = lastname;
            p.TestAge = age;
            p.Gender = gender;
            p.Religion = religion;
            p.TestHeight = height;
            p.TestWeight = weight;
            p.TestZip = zipcode;
            p.Description = desc;

            if (p.updateProfile())
                return true;
            else
                return false;
        }

        public List<string> vm_selectCombobox(string statement, string column)
        {
            List<string> comboList = new List<string> { };
            DataTable table = SQL.FillComboBox(statement);

            foreach (DataRow item in table.Rows)
            {
                comboList.Add(item[column].ToString());
            }
            return comboList;
        }
    }
}
