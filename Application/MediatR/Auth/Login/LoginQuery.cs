using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.MediatR.Auth.Login
{
    public record LoginQuery(
        [Required] string UserName,
        [Required] string PassWord
     ) : IRequest<TokenDto>;
}
