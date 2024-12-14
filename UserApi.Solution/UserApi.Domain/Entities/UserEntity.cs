using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApi.Domain.Entities
{
    public class UserEntity
    {
        public int Id { get;set; }
        public string Name { get;set; }
        
        [EmailAddress]
        public string EmailAddress { get;set; }
        public string Password { get;set; }
    }
}
