using System;
using System.Collections.Generic;
using System.Text;

namespace projekt003.Buisness
{
    public class Session
    {
        private static Session _instance;

        public bool IsAppBusy { get; set; }

        private Session()
        {
            IsAppBusy = false;
        }

        public static Session GetInstance()
        {
            if (_instance == null)
                _instance = new Session();

            return _instance;
        }

        public Database Database
        {
            get { return Database.GetInstance(); }
        }



    }
}
