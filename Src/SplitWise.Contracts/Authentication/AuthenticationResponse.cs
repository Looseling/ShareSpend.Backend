using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid id,
        string FirstName,
        string LastName,
        string Email,
        string Token);
}
