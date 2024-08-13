using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Exceptions;
using API.Application_.Repositories.Menu;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Command.Menu.UpdateMenu
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommandRequest, ResultDto>
    {
        readonly IMenuWriteRepository _repository;

        public UpdateMenuCommandHandler(IMenuWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> Handle(UpdateMenuCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Menu menu = await _repository.Table.SingleOrDefaultAsync(x => x.Id == request.MenuId);
            if (menu is null)
                return new() { Succeeded = false, Message = "Menu bulunamadı" };

            menu.Name = request.Name;

            _repository.Update(menu);
            var result = await _repository.SaveAsync();

            if (result < 1)
                throw new UpdateException();

            return new ResultDto() { Succeeded = true };

        }
    }
}
