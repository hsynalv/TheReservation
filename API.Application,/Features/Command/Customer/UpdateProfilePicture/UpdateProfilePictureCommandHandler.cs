using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Features.Queries.Customer.GetCustomer;
using API.Application_.Repositories.Customer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Command.Customer.UpdateProfilePicture
{
    public class UpdateProfilePictureCommandHandler : IRequestHandler<UpdateProfilePictureCommandRequest, UpdateProfilePictureCommandResponse>
    {
        private ICustomerWriteRepository _repository;

        public UpdateProfilePictureCommandHandler(ICustomerWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateProfilePictureCommandResponse> Handle(UpdateProfilePictureCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer customer =
                await _repository.Table.FirstOrDefaultAsync(x => x.AppUser.UserName == request.username);
            customer.ProfilePicture = request.url;
            _repository.Table.Update(customer);
            var result =await _repository.SaveAsync();
            if (result < 1)
                throw new Exception("Fotoğraf Yüklenirken bir hata oluştu");
            return new()
            {
                Succeeded = true
            };
        }
    }
}
