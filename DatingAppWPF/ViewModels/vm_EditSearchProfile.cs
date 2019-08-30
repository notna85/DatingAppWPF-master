using DatingAppWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatingAppWPF.ViewModels
{
    class vm_EditSearchProfile
    {
        public Person P { get; set; }

        public vm_EditSearchProfile()
        {
            P = new Person();
            SetProfileValues();
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
        public bool vm_updateSearchProfile(string minage, string maxage, string gender, string religion, string zipcode)
        {
            Person p = new Person();
            p.MinAge = minage;
            p.MaxAge = maxage;
            p.GenderSearch = gender;
            p.ReligionSearch = religion;
            p.ZipcodeSearch = zipcode;

            if (p.updateSearchProfile())
                return true;
            else
                return false;
        }

        public void SetProfileValues()
        {
            int theUserID = (int)App.Current.Resources["UserID"];
            DataTable table = new DataTable();
            string statement = "select minage,maxage,gender,religion,zipcode from v_searchprofile where userid = " + theUserID;
            table = SQL.ShowProfile(statement);
            P.MinAge = table.Rows[0]["minage"].ToString();
            P.MaxAge = table.Rows[0]["maxage"].ToString();
            P.GenderSearch = table.Rows[0]["gender"].ToString();
            P.ReligionSearch = table.Rows[0]["religion"].ToString();
            P.ZipcodeSearch = table.Rows[0]["zipcode"].ToString();
        }
    }
}
