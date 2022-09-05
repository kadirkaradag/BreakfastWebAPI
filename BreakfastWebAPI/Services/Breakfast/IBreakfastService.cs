using Breakfast.Breakfast;
using BreakfastWebAPI.Models;

namespace BreakfastWebAPI.Services.Breakfast
{
    public interface IBreakfastService
    {
        void CreateBreakFast(BreakfastModel breakfast);
        BreakfastModel GetBreakfast(Guid id);
        void UpsertBreakfast(BreakfastModel breakfast);
        void DeleteBreakfast(Guid id);
        List<BreakfastModel> GetBreakfasts();
    }
}
