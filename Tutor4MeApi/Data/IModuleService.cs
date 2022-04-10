using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public interface IModuleService
    {
        int CreateModule(Module module);
        int DeleteModule(int moduleId);
        int GetAllModules();
    }
}
