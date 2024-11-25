using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MigrationProject.DTO;
using MigrationProject.Repository;
using MigrationProject.Interface;
using MigrationProject.Model;
using Microsoft.Extensions.Logging;

namespace MigrationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManager _manager;
        private readonly ILogger<ManagerController> _logger;

        public ManagerController(IManager manager,ILogger<ManagerController> logger)
        {
            _manager = manager;
            _logger = logger;

        }

        [HttpPost]
        [Route("AddManager")]
        public async Task<IActionResult> CreateManager(ManagerDTO manager)
        {
            try
            {
                var newManager =await _manager.createManager(manager);
                _logger.LogInformation($"Added Manager Details to the table with manager Id {newManager}");
                return Ok(newManager);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetManagerInfo")]

        public IActionResult getManagerInfo(int managerId)
        {
            try
            {
                var managerInfo = _manager.getManagerDetails(managerId);
                _logger.LogInformation($"");
                return Ok(managerInfo);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetAllManagers")]

        public IActionResult getAllManagers()
        {
            try
            {
                var listOfManagers = _manager.getAll();
                return Ok(listOfManagers);
            }

            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

    }
}
