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
            _context.Module.Add(module);
            _context.SaveChanges();
            return 1;
        }

        // Check if a module with the same moduleId exists, is so, that module gets deleleted, and 1 gets returned, if not, 0 gets returned
        public int DeleteModule(int moduleId)
        {
            var deleteObject = _context.Module.Where(m => m.Id == moduleId).SingleOrDefault();
            if (deleteObject == null) 
            {
                return 0;
            }

            _context.Module.Remove(deleteObject);
            _context.SaveChanges();
            return 1;
        } 

        // Returns all modules in the DB
        public List<Module> GetAllModules()
        {
            var  result =  _context.Module.ToList();
            var objectList = new List<Module>();
            result.ForEach(t => objectList.Add(t));
            return objectList;      
        } 

    }
}
