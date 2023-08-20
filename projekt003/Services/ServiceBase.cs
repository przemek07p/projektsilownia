using projekt003.Buisness;
using System;
using System.Collections.Generic;
using System.Text;

namespace projekt003.Services
{
    public class ServiceBase
    {
        private readonly Database _database;
        public ServiceBase(Database database)
        {
            _database = database;
        }

        protected Database Database { get => _database; }
    }
}
