using BreakfastWebAPI.Models;

namespace BreakfastWebAPI.Services.Breakfast
{
    public class BreakfastService : IBreakfastService
    {
        private readonly Dictionary<Guid, BreakfastModel> _breakfast = new();
        public void CreateBreakFast(BreakfastModel breakfast)
        {
            _breakfast.Add(breakfast.Id, breakfast);
        }

        public void DeleteBreakfast(Guid id)
        {
            _breakfast.Remove(id);
        }

        public BreakfastModel GetBreakfast(Guid id)
        {
            return _breakfast[id];
        }

        public List<BreakfastModel> GetBreakfasts()
        {
            return _breakfast.Values.ToList();
        }

        public void UpsertBreakfast(BreakfastModel breakfast)
        {
            _breakfast[breakfast.Id] = breakfast;
        }
    }
}
