using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Domain.Entities;

namespace UserApi.Application.Interfaces
{
    public interface UserInterface
    {
        //create a new user
        Task AddUser(UserEntity user);
        //delete an user
        Task DeleteUser(int userId);
        //update an user
        Task UpdateUser(int userId, UserEntity user);
        //find user by id
        Task<UserEntity> GetUserById(int userId);
        //get all the users
        Task<IEnumerable<UserEntity>> GetAllUsers();
    }
}
