using DatingAppWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppWPF.ViewModels
{
    public class vm_signUp
    {
        public bool vm_createProfile(string username, string password, string firstname, string lastname, string age, string gender, string religion, string height, string weight, string zipcode, string desc)
        {
            Person p = new Person();
            p.UserName = username;
            p.UserPass = password;
            p.FirstName = firstname;
            p.LastName = lastname;
            p.TestAge = age;
            p.Gender = gender;
            p.Religion = religion;
            p.TestHeight = height;
            p.TestWeight = weight;
            p.TestZip = zipcode;
            p.Description = desc;

            if (p.createProfile())
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
