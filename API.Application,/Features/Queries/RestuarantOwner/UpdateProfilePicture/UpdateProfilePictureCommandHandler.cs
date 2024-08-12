using API.Application_.DTOs;
using API.Application_.Exceptions;
using API.Application_.Repositories.Customer;
using API.Application_.Repositories.RestaurantOwner;
using API.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Queries.RestuarantOwner.UpdateProfilePicture
{
    public class UpdateRestaurantOwnerProfilePictureCommandHandler : IRequestHandler<UpdateRestaurantOwnerProfilePictureCommandRequest, ResultDto>
    {
        private IRestaurantOwnerWriteRepository _repository;

        public UpdateRestaurantOwnerProfilePictureCommandHandler(IRestaurantOwnerWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> Handle(UpdateRestaurantOwnerProfilePictureCommandRequest request, CancellationToken cancellationToken)
        {

            RestaurantOwner entity =
                await _repository.Table.FirstOrDefaultAsync(x => x.AppUser.UserName == request.username);
            entity.ProfilePicture = request.url;

            entity.UpdatedDate = DateTime.UtcNow.ToLocalTime();

            _repository.Update(entity);
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
