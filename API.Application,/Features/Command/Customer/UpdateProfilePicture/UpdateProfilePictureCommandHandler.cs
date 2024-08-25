using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Exceptions;
using API.Application_.Repositories.Customer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Command.Customer.UpdateProfilePicture
{
    public class UpdateProfilePictureCommandHandler : IRequestHandler<UpdateProfilePictureCommandRequest, ResultDto>
    {
        private ICustomerWriteRepository _repository;

        public UpdateProfilePictureCommandHandler(ICustomerWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> Handle(UpdateProfilePictureCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer customer =
                await _repository.Table.FirstOrDefaultAsync(x => x.AppUser.UserName == request.username);
            customer.ProfilePicture = request.url;

            customer.UpdatedDate = DateTime.UtcNow.ToLocalTime();

            _repository.Update(customer);
            var result =await _repository.SaveAsync();
            if (result < 1)
                throw new UpdateException();
            return new()
            {
                Succeeded = true
            };
        }
    }
}
