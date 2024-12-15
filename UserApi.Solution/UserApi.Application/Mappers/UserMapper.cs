using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UserApi.Application.DTOs;
using UserApi.Domain.Entities;

namespace UserApi.Application.Mappers
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(UserDTO user) => new()
        {
            Id = user.id,
            Name = user.name,
            EmailAddress = user.emailAdress,
            Password = user.password
        };

        public static (UserDTO?, IEnumerable<UserDTO>?) FromEntity(UserEntity? user, IEnumerable<UserEntity>? users)
        {
            if (users is not null)//multiple users
            {
                var multipleUsers = users!.Select(
                    x => new UserDTO(user.Id, user.Name, user.EmailAddress, user.Password)
                    );

                return (null, multipleUsers);
            }
            else if (user is not null) //one user
            {
                var singleUser = new UserDTO(user.Id, user.Name, user.EmailAddress, user.Password);
                return (singleUser, null);
            }

            return (null, null);
            
        }
    }
}
