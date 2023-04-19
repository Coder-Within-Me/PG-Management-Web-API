using PGManagement.DataLayer;
using PGManagement.Models;
using PGManagement.Models.DTO;
using PGManagement.Models.Response;

namespace PGManagement.Respository
{
    public interface IAdmin
    {
        Task<(List<GuestDetailsResponse>, int)> GetAllData(int pagenumber = 1, int pageSize = 5);
        Task<(List<Floors>, List<Rooms>, List<Beds>)> GetMasterData();
        Task<string> CreateNew(CreateNewGuestDTO FormData);
    }
}
