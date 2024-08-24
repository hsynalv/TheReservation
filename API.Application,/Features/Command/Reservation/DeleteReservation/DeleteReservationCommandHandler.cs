using API.Application_.DTOs;
using API.Application_.Exceptions;
using API.Application_.Repositories.Reservation;
using MediatR;

namespace API.Application_.Features.Command.Reservation.DeleteReservation;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommandRequest, ResultDto>
{
    private readonly IReservationWriteRepository _reservationWriteRepository;

    public DeleteReservationCommandHandler(IReservationWriteRepository reservationWriteRepository)
    {
        _reservationWriteRepository = reservationWriteRepository;
    }

    public async Task<ResultDto> Handle(DeleteReservationCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Reservation? reservation =  _reservationWriteRepository.Table.Find(request.ReservationId);

        if (reservation is null)
            throw new NotFoundException("Rezervasyon bulunamadı");
        await _reservationWriteRepository.RemoveAsync(request.ReservationId);
        var result = await _reservationWriteRepository.SaveAsync();

        if (result < 1)
            throw new Exception("Rezervasyon silinirken bir hata meydana geldi");
        return new() { Succeeded = true };
    }
}