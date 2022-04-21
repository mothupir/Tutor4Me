﻿using Tutor4MeApi.Models;

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
            if (timeslot.TutorId == 0 ||DateTime.Compare(timeslot.StartTime, timeslot.EndTime) >= 0)
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
            if (timeslot == null || DateTime.Compare(DateTime.Now, timeslot.Date) >0)
            {
                return 404;
            }
            if (timeslot.TutorId == 0)
            {
                return 404;
            }
            if (timeslot.StudentId != 0 || timeslot.ModuleId != 0)
            {
                return 409;
            }
            if (studentID == 0 || moduleID == 0)
            {
                return 400;
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
                return 500;
            } 

        }
        int ITimeslotService.CancelBooking (int timeslotID)
        {
            var timeslot = _context.Timeslots.Where(t => t.TimeslotId == timeslotID).FirstOrDefault();
            if (timeslot == null)
            {
                return 404;
            }
            try
            {
                timeslot.StudentId = 0;
                timeslot.ModuleId = 0;
                _context.SaveChanges();
                return 200;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return 500;
            }

        }
        dynamic ITimeslotService.getTimeslots(int tutorID)
        {
            dynamic timeslots = _context.Timeslots.Where(t=> t.TutorId == tutorID).ToList();
            return timeslots;

        }
        int ITimeslotService.deleteTimeslot(int timeslotID)
        {
            var timeslot = _context.Timeslots.Where(t => t.TimeslotId == timeslotID).FirstOrDefault();
            if (timeslot == null)
            {
                return 404;
            }
            try
            {
                _context.Timeslots.Remove(timeslot);
                _context.SaveChanges();
                return 200;
            }catch (Exception ex)
            {
                ex.GetBaseException();
                return 500;
            }

        }
        dynamic ITimeslotService.GetBookedTimeslotsTutor(int tutorID)
        {
            dynamic bookedTimeslots = _context.Timeslots.Where(t => t.TutorId == tutorID && t.StudentId != 0 && t.ModuleId != 0).ToList();
            return bookedTimeslots;
        }
        dynamic ITimeslotService.getBookingsStudent(int studentID)
        {
            dynamic bookedTimeslots = _context.Timeslots.Where(t =>  t.StudentId == studentID).ToList();
            return bookedTimeslots;

        }

        dynamic ITimeslotService.GetTutorAvailableTimeslots(int tutorID)
        {
            dynamic bookedTimeslots = _context.Timeslots.Where(t => t.TutorId == tutorID && t.StudentId == 0 && t.ModuleId == 0).ToList();
            return bookedTimeslots;
        }
    }
}
