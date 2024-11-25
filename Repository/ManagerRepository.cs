using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MigrationProject.DTO;
using MigrationProject.Interface;
using MigrationProject.Model;
using Microsoft.Extensions.Logging;
using MigrationProject.DTO;

namespace MigrationProject.Repository
{
    //Inherit the Interface and implement it
    public class ManagerRepository:IManager
    {
        //Declare the AppDbContext object
        private readonly AppDbContext _context;
        private readonly ILogger<ManagerRepository> _logger;
        public ManagerRepository(AppDbContext context,ILogger<ManagerRepository> logger)
        {
            //Initialize the DbContext object
            _context = context;
            _logger = logger;
        }

        public async Task<int> createManager(ManagerDTO manager)
        {
            try
            {
                //Map the Request DTO objects to the Model Entity objects to pass to insert the manager related data

                Manager managerModel = new Manager()
                {
                    ManagerName = manager.ManagerName
                };
                
                //Insert the data to the manager table
                _context.Manager.Add(managerModel);

                await _context.SaveChangesAsync();

                var addedManager = _context.Manager.Single(m=>m.ManagerName == manager.ManagerName);

                return addedManager.ManagerId;

            }
            catch
            {
                throw;
            }
        }

        public ManagerResponseDTO getManagerDetails(int managerId)
        {
            try
            {
                var managerDetails = _context.Manager.FirstOrDefault(x => x.ManagerId == managerId);
                //Map the response with the Manager Response DTO
                ManagerResponseDTO managerResponseDTO = new ManagerResponseDTO()
                {
                    ManagerId = managerDetails.ManagerId,
                    ManagerName = managerDetails.ManagerName
                };
                return managerResponseDTO;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ManagerResponseDTO> getAll()
        {
            try
            {
                var list = _context.Manager.ToList();
                //Initialize a list of the response DTO
                List<ManagerResponseDTO> li = new List<ManagerResponseDTO>();

                //Iterate over the list of objects using foreach loop and add the list object to the response dto list
                foreach (var item in list)
                {
                    var listItem = new ManagerResponseDTO()
                    {
                        ManagerId = item.ManagerId,
                        ManagerName = item.ManagerName,
                    };
                    li.Add(listItem);
                }
                return li;
            }

            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
