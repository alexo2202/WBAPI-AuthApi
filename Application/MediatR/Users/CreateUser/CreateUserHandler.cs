using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace Application.MediatR.Users.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            byte[] passwordHash, passwordKey;
            using (var hmac = new HMACSHA512())
            {
                user.PasswordKey = hmac.Key;
                user.Password =  hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Pass));
            }
            var data = await _unitOfWork.Repository<User>().AddAsync(user);
        }
    }
}
