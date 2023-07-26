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

        public LeadActors GetActorById(int id)
        {
           
            LeadActors? a = _koreanContext.ActorsTable.Where(x=>x.Id == id).FirstOrDefault();
            return a;
        }

        public LeadActors NewActor(LeadActors lActor)
        {
            _koreanContext.ActorsTable.Add(lActor);
            _koreanContext.SaveChanges();
            return lActor;
        }
    }
}
