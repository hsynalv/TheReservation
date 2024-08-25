﻿using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.Customer.CreateCustomer;

public class CreateCustomerCommandRequest : IRequest<ResultDto>
{
    public string Id  { get; set; }
    public string? Name { get; set; }

    public string? LastName { get; set; }
}