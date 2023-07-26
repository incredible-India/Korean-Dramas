using Korean_Api.Models;

namespace Korean_Api.Interface
{
    public interface IActor
    {
        public LeadActors NewActor(LeadActors lActor);
        public LeadActors GetActorById(int id);
    }
}
