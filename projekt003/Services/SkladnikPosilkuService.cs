using LiteDB;
using projekt003.Buisness;
using projekt003.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projekt003.Services
{
    public class SkladnikPosilkuService : ServiceBase
    {
        public SkladnikPosilkuService(Database database) : base(database)
        {

        }

        public int DeleteSkladnikPosilku()
        {
            using (LiteDatabase db = Database.Initialize())
            {
                return db.GetCollection<SkladnikPosilkuDTO>().DeleteAll();
            }
        }

        public void InsertSkladnik(SkladnikPosilkuDTO skladnik)
        {
            using (LiteDatabase db = Database.Initialize())
            {
                var col = db.GetCollection<SkladnikPosilkuDTO>().Insert(skladnik);
            }
        }

        public SkladnikPosilkuDTO GetSkladnikById(string id)
        {
            using (LiteDatabase db = Database.Initialize())
            {
                var skladnik = db.GetCollection<SkladnikPosilkuDTO>().FindById(id);
                return skladnik;
            }
        }

        public SkladnikPosilkuDTO GetSkladnikByName(string Name)
        {
            using (var db = Database.Initialize())
            {
                var skladnik = db.GetCollection<SkladnikPosilkuDTO>().FindOne(Query.EQ("Nazwa", Name));
                return skladnik;
            }
        }

        public List<SkladnikPosilkuDTO> GetAllSkladnik()
        {
            var skladnik = new List<SkladnikPosilkuDTO>();
            using (LiteDatabase db = Database.Initialize())
            {
                var col = db.GetCollection<SkladnikPosilkuDTO>().FindAll();
                
                foreach (var item in col)
                {
                    
                    skladnik.Add(item);
                    
                }                
            }
            return skladnik;
        }
    }
}

