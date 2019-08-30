using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppWPF.Models
{
    public class Users : BaseClass
    {
        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string _userPass;
        public string UserPass
        {
            get
            {
                return _userPass;
            }
            set
            {
                _userPass = value;
                OnPropertyChanged("UserPass");
            }
        }

        private string _userMail;
        public string UserMail
        {
            get
            {
                return _userMail;
            }
            set
            {
                _userMail = value;
                OnPropertyChanged("UserMail");
            }
        }

        public int _userID;
        public int UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
                OnPropertyChanged("UserID");
            }
        }

        private int _matchID;
        public int MatchID
        {
            get { return _matchID; }
            set { _matchID = value; OnPropertyChanged("MatchID"); }
        }
    }
}
