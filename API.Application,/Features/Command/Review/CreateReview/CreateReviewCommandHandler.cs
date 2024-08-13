using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Exceptions;
using API.Application_.Repositories.Customer;
using API.Application_.Repositories.Restaurant;
using API.Application_.Repositories.Review;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Command.Review.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, ResultDto>
    {
        readonly IReviewWriteRepository _reviewWriteRepository;
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly IRestaurantReadRepository _restaurantReadRepository;
        private readonly IRestaurantWriteRepository _restaurantWriteRepository;
        private readonly IReviewReadRepository _reviewReadRepository;

        public CreateReviewCommandHandler(IReviewWriteRepository repository, ICustomerReadRepository customerReadRepository, IRestaurantReadRepository restaurantReadRepository, IRestaurantWriteRepository repository1, IReviewReadRepository reviewReadRepository)
        {
            _reviewWriteRepository = repository;
            _customerReadRepository = customerReadRepository;
            _restaurantReadRepository = restaurantReadRepository;
            _restaurantWriteRepository = repository1;
            _reviewReadRepository = reviewReadRepository;
        }

        public async Task<ResultDto> Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerReadRepository.GetByIdAsync(request.UserId);
            if (customer is null)
                return new() { Succeeded = false, Message = "Customer not found." };
            var restaurant = await _restaurantReadRepository.GetByIdAsync(request.RestaurantId);
            if(restaurant is null)
                return new() { Succeeded = false, Message = "Restaurant not found." };

            Domain.Entities.Review review = new()
            {
                Id = Guid.NewGuid().ToString(),
                Customer = customer,
                Restaurant = restaurant,
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                Comment = request.Comment,
                RestaurantId = request.RestaurantId,
                UserId = request.UserId,
                Rating = request.Rating
            };
            _reviewWriteRepository.AddAsync(review);
            var result = await _reviewWriteRepository.SaveAsync();

            if (result < 1)
                throw new ReviewCreateFailedException();
            

            restaurant.AverageScore = await CalculateAverageScore(request.RestaurantId);
            var reviewResult = _restaurantWriteRepository.Update(restaurant);
            _restaurantWriteRepository.SaveAsync();

            return new() { Succeeded = true };
        }

        private async Task<double> CalculateAverageScore(string restaurantId)
        {
            var average =  await _reviewReadRepository.GetWhere(x => x.RestaurantId == restaurantId).AverageAsync(s => s.Rating);
            return average;
        }
    }
}
