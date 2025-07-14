using Application.MediatR.Users;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace Application.MediatR.Auth.Login
{
    class LoginHandler : IRequestHandler<LoginQuery, TokenDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<TokenDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            TokenDto response = new TokenDto();
            var users = await _unitOfWork.Repository<User>().GetAsync(x => x.Username == request.UserName);
            if (users.Count > 0)
            {
                User logedUser = users.Where(x => MatchPasswordHash(request.PassWord, x.Password, x.PasswordKey)).FirstOrDefault();
                if (logedUser != null)
                {
                    var roleModules = await _unitOfWork.Repository<RoleModule>().GetAsync(x => x.RoleId == logedUser.RoleId, includeString: "Module");
                    var modules = roleModules.Select(rm => new
                    {
                        rm.Module.Id,
                        rm.Module.Name
                    }).ToList();
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,request.UserName),
                        new Claim("modules",JsonConvert.SerializeObject(modules)),
                        new Claim("employeeId",logedUser.EmployeeId.ToString())
                    };

                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var Sectoken = new JwtSecurityToken(
                      issuer: _configuration.GetSection("Jwt:Issuer").Value!,
                      audience: _configuration.GetSection("Jwt:Issuer").Value!,
                      claims: claims,
                      expires: DateTime.Now.AddMinutes(Int32.Parse(_configuration.GetSection("Jwt:ExpireTokenInMinutes").Value!)),
                      signingCredentials: credentials);
                    response.token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
                }
            }


            return response;
        }

        private bool MatchPasswordHash(string password, byte[] passwordDb, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < passwordDb.Length; i++)
                {
                    if (passwordDb[i] != passwordHash[i])
                        return false;
                }

                return true;
            }
        }
    }
}
