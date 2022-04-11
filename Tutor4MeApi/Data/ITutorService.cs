namespace Tutor4MeApi.Data
{
    public interface ITutorService
    {
        int AddTutoredModule(int tutorId, int moduleId);
        int RemoveTutoredModule(int tutorId, int moduleId);
    }
}
