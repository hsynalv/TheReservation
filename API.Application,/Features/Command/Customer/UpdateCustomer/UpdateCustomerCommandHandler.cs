using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Repositories.Customer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application_.Features.Command.Customer.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        readonly ICustomerWriteRepository _customerWriteRepository;

        public UpdateCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer customer =
               await  _customerWriteRepository.Table.FirstOrDefaultAsync(x => x.AppUser.UserName == request.username);

            customer.BirthDate = request.BirthDate;
            customer.Lastname = request.LastName;
            customer.Name = request.Name;
            //customer.AppUser.UserName = request.username;
            // TODO: Kullanıcı adı değiştirmesi için AppUser in içeri eklenmesi gerekiyor.

             _customerWriteRepository.Update(customer);
             var result = await _customerWriteRepository.SaveAsync();
            if (result < 1)
                throw new Exception("Güncelleme sırasında bir hata meydana geldi");

            return new() { Succeeded = true };

        }
    }
}
