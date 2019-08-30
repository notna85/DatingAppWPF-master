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
    public class Person : Users
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged("Age"); }
        }
        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged("Gender"); }
        }
        private int _height;
        public int Height
        {
            get { return _height; }
            set { _height = value; OnPropertyChanged("LastName"); }
        }
        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; OnPropertyChanged("Weight"); }
        }
        private string _religion;
        public string Religion
        {
            get { return _religion; }
            set { _religion = value; OnPropertyChanged("Religion"); }
        }
        private int _zipcode;
        public int Zipcode
        {
            get { return _zipcode; }
            set { _zipcode = value; OnPropertyChanged("Zipcode"); }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("Description"); }
        }
        private string _testAge;
        public string TestAge
        {
            get { return _testAge; }
            set { _testAge = value; OnPropertyChanged("TestAge"); }
        }
        private string _testHeight;
        public string TestHeight
        {
            get { return _testHeight; }
            set { _testHeight = value; OnPropertyChanged("TestHeight"); }
        }
        private string _testWeight;
        public string TestWeight
        {
            get { return _testWeight; }
            set { _testWeight = value; OnPropertyChanged("TestHeight"); }
        }
        private string _testZip;
        public string TestZip
        {
            get { return _testZip; }
            set { _testZip = value; OnPropertyChanged("TestZip"); }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged("City"); }
        }

        private string _minAge;
        public string MinAge
        {
            get { return _minAge; }
            set { _minAge = value; OnPropertyChanged("MinAge"); }
        }

        private string _maxAge;
        public string MaxAge
        {
            get { return _maxAge; }
            set { _maxAge = value; OnPropertyChanged("MaxAge"); }
        }

        private string _genderSearch;
        public string GenderSearch
        {
            get { return _genderSearch; }
            set { _genderSearch = value; OnPropertyChanged("GenderSearch"); }
        }

        private string _religionSearch;
        public string ReligionSearch
        {
            get { return _religionSearch; }
            set { _religionSearch = value; OnPropertyChanged("ReligionSearch"); }
        }

        private string _zipcodeSearch;
        public string ZipcodeSearch
        {
            get { return _zipcodeSearch; }
            set { _zipcodeSearch = value; OnPropertyChanged("ZipcodeSearch"); }
        }

        private string _profileImage;

        public string ProfileImage
        {
            get { return _profileImage; }
            set { _profileImage = value; OnPropertyChanged("ProfileImage"); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged("Message"); }
        }

        public bool createProfile()
        {
            if (!SQL.inputCheck(UserName, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMqwertyuiopåasdfghjklæøzxcvbnm0123456789@.,", 50) || UserName == "")
                return false;

            if (!SQL.inputCheck(UserPass, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMqwertyuiopåasdfghjklæøzxcvbnm0123456789!#$%&'()*+,-./:;<=>?@[]/^_`{|}~", 50) || UserPass == "")
                return false;

            if (!SQL.inputCheck(FirstName, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMqwertyuiopåasdfghjklæøzxcvbnm", 50) || FirstName == "")
                return false;

            if (!SQL.inputCheck(LastName, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMqwertyuiopåasdfghjklæøzxcvbnm", 50) || LastName == "")
                return false;

            if (!SQL.inputCheck(TestAge, "0123456789", 3) || TestAge == "")
                return false;
            else
                Age = Int32.Parse(TestAge);            

            if (!SQL.inputCheck(TestHeight, "0123456789", 3) || TestHeight == "")
                return false;
            else
                Height = Int32.Parse(TestHeight);

            if (!SQL.inputCheck(TestWeight, "0123456789", 3) || TestWeight == "")
                return false;
            else
                Weight = Int32.Parse(TestWeight);            

            if (!SQL.inputCheck(TestZip, "0123456789", 4) || TestZip == "")
                return false;
            else
                Zipcode = Int32.Parse(TestZip);

            if (!SQL.inputCheck(Description, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMqwertyuiopåasdfghjklæøzxcvbnm0123456789!#$%&'()*+,-./:;<=>?@[]/^_`{|}~ ", 200) || Description == "")
                return false;

            //call stored procedure
            string statement = "exec createuser @username='" + UserName + "', @userpass='" + UserPass + "', @firstname='" + FirstName + "', @lastname='" + LastName + "', @age=" + Age + ", " +
                "@gender='" + Gender + "', @height=" + Height + ", @weight=" + Weight + ", @description='" + Description + "', @religion='" + Religion + "', @zipcode=" + Zipcode + ", @imagepath='https://i.imgur.com/LXQp0a6.png'";
            SQL.sqlCommand(statement);

            return true;
        }

        public bool updateProfile()
        {
            if (!SQL.inputCheck(FirstName, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMqwertyuiopåasdfghjklæøzxcvbnm", 50) || FirstName == "")
                return false;

            if (!SQL.inputCheck(LastName, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMqwertyuiopåasdfghjklæøzxcvbnm", 50) || LastName == "")
                return false;

            if (!SQL.inputCheck(TestAge, "0123456789", 3) || TestAge == "")
                return false;
            else
                Age = Int32.Parse(TestAge);

            if (!SQL.inputCheck(TestHeight, "0123456789", 3) || TestHeight == "")
                return false;
            else
                Height = Int32.Parse(TestHeight);

            if (!SQL.inputCheck(TestWeight, "0123456789", 3) || TestWeight == "")
                return false;
            else
                Weight = Int32.Parse(TestWeight);

            if (!SQL.inputCheck(TestZip, "0123456789", 4) || TestZip == "")
                return false;
            else
                Zipcode = Int32.Parse(TestZip);

            if (!SQL.inputCheck(Description, "QWERTYUIOPÅASDFGHJKLÆØZXCVBNMqwertyuiopåasdfghjklæøzxcvbnm0123456789!#$%&'()*+,-./:;<=>?@[]/^_`{|}~ ", 200) || Description == "")
                return false;

            //call stored procedure
            string statement = "exec updateperson @userid=" + App.Current.Resources["UserID"] + ", @firstname='" + FirstName + "', @lastname='" + LastName + "', @age=" + Age + ", " +
                "@gender='" + Gender + "', @height=" + Height + ", @weight=" + Weight + ", @description='" + Description + "', @religion='" + Religion + "', @zipcode=" + Zipcode;
            SQL.sqlCommand(statement);

            return true;
        }
        
        public bool updateSearchProfile()
        {
            if (MinAge != "")
            {
                if (!SQL.inputCheck(MinAge, "0123456789", 3))
                    return false;
                else
                    Convert.ToInt32(MinAge);
            }
            else
                MinAge = "null";

            if (MaxAge != "")
            {
                if (!SQL.inputCheck(MaxAge, "0123456789", 3))
                    return false;
                else
                    Convert.ToInt32(MaxAge);
            }
            else
                MaxAge = "null";

            if (GenderSearch == "")
                GenderSearch = "null";
            else
                GenderSearch = "'" + GenderSearch + "'";

            if (ReligionSearch == "")
                ReligionSearch = "null";
            else
                ReligionSearch = "'" + ReligionSearch + "'";

            if(ZipcodeSearch != "")
            {
                if (!SQL.inputCheck(ZipcodeSearch, "0123456789", 4))
                    return false;
                else
                    Convert.ToInt32(ZipcodeSearch);
            }
            else
                ZipcodeSearch = "null";

            //call stored procedure
            string statement = "exec updatesearchprofile @userid=" + App.Current.Resources["UserID"] + ", @minage=" + MinAge + ", @maxage=" + MaxAge + 
                ", @gender=" + GenderSearch + ", @religion=" + ReligionSearch + ", @zipcode=" + ZipcodeSearch;
            SQL.sqlCommand(statement);

            return true;
        }
        public void changePassword(string user, string currentPass)
        {
            bool tjek = false;
            string oldPass;
            do
            {
                Console.Clear();
                do
                {
                    Console.Clear();
                    Console.Write("Enter old password... : ");
                    oldPass = Console.ReadLine();
                    if (oldPass != currentPass)
                    {
                        Console.WriteLine("Wrong password!");
                        Thread.Sleep(1500);
                    }

                }
                while (oldPass != currentPass);

                Console.Write("Enter a new password... : ");
                string pass1 = Console.ReadLine();
                Console.Write("Confirm the new password... : ");
                string pass2 = Console.ReadLine();
                if (pass1 == pass2)
                {
                    string updateStatement = "update users set userpass = '" + pass2 + "' where username = '" + user + "'";
                    SQL.sqlCommand(updateStatement);
                    tjek = true;
                    Console.WriteLine("Password changed...");
                    Thread.Sleep(1500);
                }
                else if (pass1 != pass2)
                {
                    Console.WriteLine("Passwords doesn't match...");
                    Thread.Sleep(1500);
                }
            }
            while (tjek != true);
        }
        public int likeProcess()
        {
            string statement2 = "select liking, liked, match from matches where (liking = " + App.Current.Resources["UserID"] + " or liking = " + App.Current.Resources["MatchID"] + ") and (liked = " + App.Current.Resources["UserID"] + " or liked = " + App.Current.Resources["MatchID"] + ")";
            DataTable table = SQL.ShowProfile(statement2);

            if (table.Rows.Count == 0)
            {
                string statement3 = "insert into matches values (" + App.Current.Resources["UserID"] + ", " + App.Current.Resources["MatchID"] + ", 0)";
                SQL.sqlCommand(statement3);
                return 1;
            }
            else
            {
                int likedID = Convert.ToInt32(table.Rows[0]["liked"]);
                int likingID = Convert.ToInt32(table.Rows[0]["liking"]);
                int matchID = Convert.ToInt32(table.Rows[0]["match"]);
                if (likedID == (int)App.Current.Resources["UserID"] && matchID == 0)
                {
                    string statement3 = "update matches set match = 1 where liking = " + likingID + " and liked = " + likedID;
                    SQL.sqlCommand(statement3);
                    return 2;
                }
                else if (likingID == (int)App.Current.Resources["UserID"] || matchID == 1)
                {
                    return 3;
                }
            }
            return 4;
        }
    }
}

