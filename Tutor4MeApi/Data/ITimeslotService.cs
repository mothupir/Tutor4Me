using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public interface ITimeslotService
    {
        int CreateTimeslot(Timeslot timeslot);
        int BookTimeslot (int studentID, int moduleID, int timeslotID);
    }
}
