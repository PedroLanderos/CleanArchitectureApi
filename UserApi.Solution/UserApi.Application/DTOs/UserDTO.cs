using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApi.Application.DTOs
{
    public record UserDTO(int id, string name, string emailAdress, string password);
}
