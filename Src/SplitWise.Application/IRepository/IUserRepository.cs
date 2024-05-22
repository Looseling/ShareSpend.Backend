using ShareSpend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Application.IRepository
{
    public interface IUserRepository
    {
        //Cruds
        Task AddUser(User user);

        Task<User> GetUserByIdAsync(string publicId);

        Task UpdateUser(User user);

        Task DeleteUser(string publicId);

        //Queries
        Task<bool> IsUserExists(string publicId);
    }
}