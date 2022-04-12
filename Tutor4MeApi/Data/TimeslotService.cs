using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public class TimeslotService: ITimeslotService
    {
        private DataContext _context;
        public TimeslotService (DataContext context)
        {
            _context = context;
        }

         int ITimeslotService.CreateTimeslot(Timeslot timeslot)
        {
            if (DateTime.Compare(timeslot.StartTime, timeslot.EndTime) >= 0)
            {
                return 400;
            }

            var copyTimeslot = _context.Timeslots.Where(t =>  t.TutorId == timeslot.TutorId
            && t.Date == timeslot.Date
            && ((DateTime.Compare(timeslot.StartTime, t.StartTime)==0 || DateTime.Compare(timeslot.StartTime, t.StartTime) > 0)
            && DateTime.Compare(timeslot.StartTime,t.EndTime) < 0))
            .FirstOrDefault();
            if (copyTimeslot == null )
            {
                _context.Timeslots.Add(timeslot);
                _context.SaveChanges();
                return 200;

            }
            return 409;

        }

        int ITimeslotService.BookTimeslot(int studentID, int moduleID, int timeslotID)
        {
            var timeslot = _context.Timeslots.Where(t => t.TimeslotId == timeslotID).FirstOrDefault();
            if (timeslot == null)
            {
                return 404;
            }
            if (timeslot.TutorId ==0)
            {
                return 404;
            }
            if (timeslot.StudentId != 0 || moduleID !=0)
            {
                return 409;
            }
            try
            {
                timeslot.StudentId= studentID;
                timeslot.ModuleId= moduleID;
                _context.SaveChanges();
                return 200;
            }catch (Exception ex)
            {
                ex.GetBaseException();
                return 304;
            } 

        }
    }
}
