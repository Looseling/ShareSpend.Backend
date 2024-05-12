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
        Task AddUser(User user);

        Task<User> GetUser(int id);

        Task UpdateUser(User user);

        Task DeleteUser(int id);
    }
}