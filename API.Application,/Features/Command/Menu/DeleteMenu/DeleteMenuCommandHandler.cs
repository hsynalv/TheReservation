using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.DTOs;
using API.Application_.Repositories.Menu;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Command.Menu.DeleteMenu
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommandRequest, ResultDto>
    {
        readonly IMenuWriteRepository _repository;

        public DeleteMenuCommandHandler(IMenuWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> Handle(DeleteMenuCommandRequest request, CancellationToken cancellationToken)
        {
            var menu =await _repository.Table.SingleOrDefaultAsync(x => x.Id == request.MenuId);
            if (menu is null)
                return new() { Message = "Menu Bulunamadı. ", Succeeded = false };

            _repository.Remove(menu);
            var result = await _repository.SaveAsync();
            if (result < 1)
                throw new Exception("Menü silinirken bir hata meydana geldi");

            return new() { Succeeded = true };
        }
    }
}
