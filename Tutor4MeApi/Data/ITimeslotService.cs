using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public interface ITimeslotService
    {
        int CreateTimeslot(Timeslot timeslot);
        int BookTimeslot(int studentID, int moduleID, int timeslotID);
        int CancelBooking(int timeslotID);
        dynamic getTimeslots(int TutorID);
        int deleteTimeslot(int timeslotID);
        dynamic GetBookedTimeslotsTutor(int TutorID);
        dynamic getBookingsStudent(int studentID);
        dynamic GetTutorAvailableTimeslots(int tutorID);
    }

}