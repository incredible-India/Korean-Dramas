using Korean_Api.Database;
using Korean_Api.Interface;
using Korean_Api.Models;
using System.Numerics;

namespace Korean_Api.Implemantaion
{
    public class ActorImplementation : IActor
    {
        private readonly KoreanContext _koreanContext;
        public ActorImplementation(KoreanContext koreanContext)
        {
            _koreanContext = koreanContext;
        }

        public int DeleteActorById(int id)
        {
            LeadActors? hero = _koreanContext.ActorsTable.Where(x=>x.Id == id).FirstOrDefault();
            if (hero != null)
            {
                _koreanContext.Remove(hero);
                _koreanContext.SaveChanges();
                return 1;

            }
            else
            {
                return 0;
            }  
        }

        public LeadActors GetActorById(int id)
        {
            LeadActors? a = _koreanContext.ActorsTable.Where(x=>x.Id == id).FirstOrDefault(); 
            return a;
        }

        public List<LeadActors> GetAllActors()
        {
            List<LeadActors>? list = _koreanContext.ActorsTable.ToList();
            return list;
        }

        public LeadActors NewActor(LeadActors lActor)
        {
            _koreanContext.ActorsTable.Add(lActor);
            _koreanContext.SaveChanges();
            return lActor;
        }
    }
}
