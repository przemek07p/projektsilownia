using LiteDB;
using projekt003.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace projekt003.Buisness
{
    public class Database
    {
        private readonly string _path;
        private string dbName = "projekt003.db";
        private static Database _instance;

        private UserService userService;
        private SkladnikPosilkuService skladnikPosilkuService;


        private Database()
        {
            _path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);
            userService = new UserService(this);
            skladnikPosilkuService = new SkladnikPosilkuService(this);

        }

        public static Database GetInstance()
        {
            if (_instance == null)
                _instance = new Database();

            return _instance;
        }

        public LiteDatabase Initialize()
        {
            LiteDatabase _db = new LiteDatabase(_path);
            return _db;
        }

        public UserService Users
        {
            get => userService;
        }

        public SkladnikPosilkuService Skladnik
        {
            get => skladnikPosilkuService;
        }

    }
}
