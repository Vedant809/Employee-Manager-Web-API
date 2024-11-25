using MigrationProject.DTO;
using MigrationProject.Model;

namespace MigrationProject.Interface
{
    public interface IManager
    {
        public Task<int> createManager(ManagerDTO manager);

        public ManagerResponseDTO getManagerDetails(int managerId);
        public List<ManagerResponseDTO> getAll();
    }
}
