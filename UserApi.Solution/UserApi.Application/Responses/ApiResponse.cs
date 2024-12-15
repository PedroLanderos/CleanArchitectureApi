using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApi.Application.Responses
{
    public record ApiResponse(bool Flag = false, string message = null!);
}
