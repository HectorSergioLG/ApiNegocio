using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Catalogs.User
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
