using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Domain.Entities;

namespace UserApi.Infrastructure.Data
{
    //get the ef frameworks things to be able to do all the basic operations
    internal class UserDbContext : DbContext //<- inherating the ef 
    {
        //get a "DbcontextOptions<UserDbContext" as a parameter to get the same options but also being able to acces to a reference of the data by an external point 
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) //<- defines the database provider and defines the string connection 
        {
        }
        //DbSet works as a simulation of a real table with all the operations to create, update, etc etc etc
        public DbSet<UserEntity> Users { get; set; }
    }
}
