using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.MediatR.Users.CreateUser
{
    public record CreateUserCommand(
        [Required] string Username,
        [Required] string Email,
        [Required] string Pass,
        [Required] int RoleId,
        [Required] int EmployeeId
     ) : IRequest;
}
