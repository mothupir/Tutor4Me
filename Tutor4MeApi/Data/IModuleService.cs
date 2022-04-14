using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public interface IModuleService
    {
        int CreateModule(Module module);
        int DeleteModule(int moduleId);
        Module GetModule(int moduleId);
        List<Module> GetAllModules();
    }
}
