using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppWPF.Models;
using System.Data;

namespace DatingAppWPF.ViewModels
{
    class vm_SearchProfile
    {
        public Person P { get; set; }

        public vm_SearchProfile()
        {
            P = new Person();
            SetSearchProfileValues();
        }

        public void SetSearchProfileValues()
        {
            int theUserID = (int)App.Current.Resources["UserID"];
            DataTable table = new DataTable();
            string statement = "select MinAge, MaxAge, Gender, Religion, City from v_searchprofile where UserID = " + theUserID;
            table = SQL.ShowProfile(statement);
            P.MinAge = table.Rows[0]["MinAge"].ToString();
            P.MaxAge = table.Rows[0]["MaxAge"].ToString();
            P.GenderSearch = table.Rows[0]["Gender"].ToString();
            P.ReligionSearch = table.Rows[0]["Religion"].ToString();
            P.City = table.Rows[0]["City"].ToString();
        }
    }
}
