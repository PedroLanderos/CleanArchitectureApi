﻿using Microsoft.EntityFrameworkCore;
using UserApi.Application.Interfaces;
using UserApi.Application.Responses;
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
        public async Task<ApiResponse> AddUser(UserEntity user)
        {
            try
            {
                //as there is no need to make no validations, it only adds a new user to the database
                var newUser = context.Users.Add(user).Entity;
                await context.SaveChangesAsync();

                if (newUser is not null) return new ApiResponse(true, "user created");
                else return new ApiResponse(false, "errr while adding the user");
            }
            catch (Exception)
            {
                throw new ApplicationException("error while adding the user");
            }
        }

        public async Task<ApiResponse> DeleteUser(int userId)
        {
            try
            {
                //valide if the user exists
                var userToDelete = await GetUserById(userId);
                if (userToDelete is null)
                    return new ApiResponse(false, "user not found");

                context.Users.Remove(userToDelete);
                await context.SaveChangesAsync();

                return new ApiResponse(true, "user deleted");
            }
            catch (Exception)
            {
                throw new ApplicationException("The user was not deleted");
            }
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            try
            {
                return await context.Users.ToListAsync();
            }
            catch (Exception)
            {
                throw new ApplicationException("an error happened while getting the users");
            }
        }

        public async Task<UserEntity> GetUserById(int userId)
        {
            try
            {        
                var user = await context.Users.FindAsync(userId);
                return user ?? throw new ApplicationException("User not found");
            }
            catch (Exception)
            {
                throw new ApplicationException("error while getting the user");
            }
        }

        public async Task<ApiResponse> UpdateUser(int userId, UserEntity user)
        {
            try
            {
                var userToUpdate = GetUserById(userId);
                if (userToUpdate is null) return new ApiResponse(false, "user not found");

                //get the main properties of an user
                var properties = typeof(UserEntity).GetProperties();
                foreach (var property in properties)
                {
                    if(property.CanWrite)
                    {
                        var newvalue = property.GetValue(user);
                        property.SetValue(userToUpdate, newvalue);
                    }
                }
                await context.SaveChangesAsync();

                return new ApiResponse(true, "user updated");
            }
            catch (Exception)
            {
                throw new ApplicationException("error while updating the user");
            }
        }
    }
}