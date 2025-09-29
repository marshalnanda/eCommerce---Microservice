using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Entities.DTO
{
    public record AuthenticationResponse
    (
        Guid UserID,
        string? Email,
        string? PersonName,
        string? Gender,
        string? Token,
        bool success
        )
    {
        public AuthenticationResponse() : this(default, default, default, default, default, default) { }
    }
}
