using API.Application_.DTOs;
using API.Application_.Exceptions;
using API.Application_.Repositories.Customer;
using API.Application_.Repositories.Reservation;
using API.Application_.Repositories.Restaurant;
using MediatR;

namespace API.Application_.Features.Command.Reservation.CreateReservation;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommandRequest, ResultDto>
{
    private readonly IRestaurantReadRepository _restaurantReadRepository;
    private readonly ICustomerReadRepository _customerReadRepository;
    private readonly IReservationWriteRepository _reservationWriteRepository;

    public CreateReservationCommandHandler(IRestaurantReadRepository restaurantReadRepository, ICustomerReadRepository customerReadRepository, IReservationWriteRepository reservationWriteRepository)
    {
        _restaurantReadRepository = restaurantReadRepository;
        _customerReadRepository = customerReadRepository;
        _reservationWriteRepository = reservationWriteRepository;
    }

    public async Task<ResultDto> Handle(CreateReservationCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Restaurant restaurant = await _restaurantReadRepository.GetByIdAsync(request.RestaurantId, false);

        Domain.Entities.Customer customer = await _customerReadRepository.GetByIdAsync(request.UserId, false);

        if ((restaurant is null) || (customer is null))
            throw new NotFoundException("Restoran veya Müşteri Bulunamadı. ");

        Domain.Entities.Reservation reservation = new()
        {
            CreatedDate = DateTime.UtcNow.ToLocalTime(),
            Id = Guid.NewGuid().ToString(),
            RestaurantId = request.RestaurantId,
            UserId = request.UserId,
            GuestCount = request.GuestCount,
            ReservationTime = request.ReservationTime,
            SpecialRequest = request.SpecialRequest
        };

        _reservationWriteRepository.AddAsync(reservation);
        int result = await _reservationWriteRepository.SaveAsync();

        if (result < 1)
            throw new Exception("Reservasyon yapılırken bir hata meydana geldi");

        return new() { Succeeded = true };
    }
}