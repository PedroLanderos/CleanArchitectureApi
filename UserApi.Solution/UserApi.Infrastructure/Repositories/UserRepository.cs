using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Application.Interfaces;
using UserApi.Domain.Entities;
using UserApi.Infrastructure.Data;

namespace UserApi.Infrastructure.Repositories
{
    //this class implements all the operations from the interface
    internal class UserRepository : UserInterface
    {
        //the repository is using a readonly context that contains all the dbset from the database
        private readonly UserDbContext context;
        public UserRepository(UserDbContext _context)
        {
            if (_context is null)
                throw new ArgumentNullException(nameof(_context)); 
            
            context = _context;
        }
        public async Task AddUser(UserEntity user)
        {
            try
            {
                //as there is no need to make no validations, it only adds a new user to the database
                var newUser = context.Users.Add(user).Entity;
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new ApplicationException("error while adding the user");
            }
        }

        public async Task DeleteUser(int userId)
        {
            try
            {
                //valide if the user exists
                var userToDelete = await GetUserById(userId);
                if(userToDelete is null)
                    throw new ApplicationException("the user does not exist");
                else if(userToDelete is not null)
                {
                    //delete the user 
                    context.Users.Remove(userToDelete);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw new ApplicationException("The user was not deleted");
            }
        }

        public Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(int userId, UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
