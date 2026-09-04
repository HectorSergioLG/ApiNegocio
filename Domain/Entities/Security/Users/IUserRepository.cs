namespace Domain.Entities.Security.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(UserId id);
        Task<bool> Exists(UserId id);
        void Add(User usuario);
        void Delete(User usuario);
        void Update(User usuario);




        
    }
}
