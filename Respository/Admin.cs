using Microsoft.EntityFrameworkCore;
using PGManagement.DataLayer;
using PGManagement.Models;
using PGManagement.Models.DTO;
using PGManagement.Models.Response;

namespace PGManagement.Respository
{
    public class Admin : IAdmin
    {
        private readonly DBContext _DBContext;
        public Admin(DBContext context)
        {
            _DBContext = context;
        }

        public async Task<(List<GuestDetailsResponse>, int)> GetAllData(int pagenumber = 1, int pageSize = 5)
        {
            var totalrecords = await _DBContext.Guests.CountAsync();
            var skipRecords = (pagenumber - 1) * pageSize;
            var records = await _DBContext.Guests.Include("GuestDetails").Include("Floors").Include("Rooms").Include("Beds")
                            .Select(x => new GuestDetailsResponse
                            {
                                Id = x.Id,
                                GuestId = x.GuestId,
                                Name = x.GuestDetails.Name,
                                FloorNumber = x.Floors.FloorNumber,
                                RoomNumber = x.Rooms.RoomNumber,
                                BedNumber = x.Beds.BedNumber,
                                JoiningDate = x.GuestDetails.JoiningDate.ToString("dd-MM-yyyy"),
                                IsActive = x.GuestDetails.IsActive
                            }).Skip(skipRecords).Take(pageSize).ToListAsync();
            return (records, totalrecords);

        }

        public async Task<(List<Floors>,List<Rooms>,List<Beds>)> GetMasterData()
        {
            var floors = await _DBContext.Floors.ToListAsync();
            var rooms = await _DBContext.Rooms.ToListAsync();
            var beds = await _DBContext.Beds.ToListAsync();
            return (floors,rooms,beds);

        }

        public async Task<string> CreateNew(CreateNewGuestDTO FormData)
        {
            try
            {
                if (!_DBContext.GuestDetails.Any(x=> x.AadharNumber == FormData.Aadhar))
                {
                    var JoiningDate = new DateTime();
                    var Date = DateTime.TryParse(FormData.JoiningDate, out JoiningDate);
                    if (!Date)
                    {
                        FormData.JoiningDate = Convert.ToString(DateTime.Now);
                    }
                    GuestDetails guestDetails = new GuestDetails()
                    {
                        Name = FormData.Name,
                        Address = FormData.Address,
                        contact = FormData.Contact,
                        AadharNumber = FormData.Aadhar,
                        JoiningDate = Convert.ToDateTime(FormData.JoiningDate),
                        IsActive = true
                    };
                    _DBContext.GuestDetails.Add(guestDetails);
                    await _DBContext.SaveChangesAsync();
                    var Id = _DBContext.GuestDetails.Where(x => x.AadharNumber == FormData.Aadhar).Select(x => x.GuestId).FirstOrDefault();
                    if (Id > 0)
                    {
                        Guests guests = new Guests()
                        {
                            GuestId = Id,
                            FloorId = Convert.ToInt32(FormData.Floor),
                            RoomId = Convert.ToInt32(FormData.Room),
                            BedId = Convert.ToInt32(FormData.Bed)
                        };
                        _DBContext.Guests.Add(guests);
                        await _DBContext.SaveChangesAsync();
                    }
                    return "Guest Added Successfully.";
                }
                else
                {
                    return "Aadhar Number is already exists.";
                }
                
            }
            catch (Exception)
            {
                return "Unable to add Guest. Please contact system admin.";
            }
            
        }
    }
}
