using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    public class ModuleService : IModuleService
    {
        private DataContext _context;

        public ModuleService(DataContext context)
        {
            _context = context;
        }

        // Adds a new module to the DB
        public int CreateModule(Module module)
        {
            _context.Modules.Add(module);
            _context.SaveChanges();
            return 1;
        }
        public List<Module> GetOfferedModulesByTutor(int tutorId)
        {
            List<Module> modules = new List<Module>();
            List<TutoredModule> tutoredModules = _context.TutoredModules.Where(tm => tm.TutorId == tutorId).ToList();
            foreach (TutoredModule tm in tutoredModules)
            {
                Module module = _context.Modules.Find(tm.ModuleId);
                modules.Add(module);
            }
            return modules;
        }

        // Check if a module with the same moduleId exists, is so, that module gets deleleted, and 1 gets returned, if not, 0 gets returned
        public int DeleteModule(int moduleId)
        {
            var deleteObject = _context.Modules.Where(m => m.ModuleId == moduleId).SingleOrDefault();
            if (deleteObject == null)
            {
                return 0;
            }

            _context.Modules.Remove(deleteObject);
            _context.SaveChanges();
            return 1;
        }


        public Module GetModule(int moduleId)
        {
            return _context.Modules.Where(m => m.ModuleId == moduleId).SingleOrDefault();
        }

        // Returns all modules in the DB
        public List<Module> GetAllModules()
        {
            var result = _context.Modules.ToList();
            var objectList = new List<Module>();
            result.ForEach(t => objectList.Add(t));
            return objectList;
        }

        public List<Module> GetModuleByNameSubstring(String searchTerm)
        {
            var objectList = GetAllModules();
            var result = new List<Module>();

            foreach (var Module in objectList)
            {
                if (Module.Name.ToLower().Contains(searchTerm.ToLower()))
                {
                    result.Add(Module);
                }
            }
            return result;
        }

        public List<Module> GetModuleByKeywordDesc(String searchTerm)
        {
            var objectList = GetAllModules();
            var result = new List<Module>();

            foreach (var Module in objectList)
            {
                if (Module.Description.ToLower().Contains(searchTerm.ToLower()))
                {
                    result.Add(Module);
                }
            }
            return result;
        }
    }
}
