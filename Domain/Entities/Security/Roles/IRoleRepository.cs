namespace Domain.Entities.Security.Roles
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAll();
        Task<Role?> GetById(RoleId id);
        Task<bool> Exists(RoleId id);
        void Add(Role role);
        void Delete(Role role);
        void Update(Role role);


    }
}
