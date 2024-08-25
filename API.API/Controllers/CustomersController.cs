﻿using API.Application_.Features.Command.Customer.UpdateCustomer;
using API.Application_.Features.Command.Customer.UpdateProfilePicture;
using API.Application_.Features.Queries.Customer.GetAllCustomer;
using API.Application_.Features.Queries.Customer.GetCustomerByUserId;
using API.Application_.Features.Queries.Customer.GetCustomerByUserName;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerByUserName(string username)
        {
            var request = new GetCustomerByUserNameQueriesRequest()
            {
                UserName = username
            };

            var result = await  _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerByUserId(string Id)
        {
            var request = new GetCustomerByUserIdQueriesRequest()
            {
                Id = Id
            };

            var result = await  _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePhoto(UpdateProfilePictureCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _mediator.Send(new GetAllCustomerQueriesRequest());
            return Ok(list);
        }
    }
}
