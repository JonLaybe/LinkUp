using AutoMapper;
using LinkUp.Application.Users.Commands.CreateUser;
using LinkUp.Application.Users.Queries.Authentication;
using LinkUp.Application.Users.Queries.GetUserByName;
using LinkUp.Application.Users.Queries.GetUsers;
using LinkUp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinkUp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        [HttpGet("{id}")]
        public async Task<ActionResult<Application.Users.Queries.GetUsers.UserProfileVM>> GetById(int id)
        {
            var query = new GetUserQuery() { UserId = id };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("GetByName/{userName}")]
        public async Task<ActionResult<Application.Users.Queries.GetUserByName.UserProfileVM>> GetByName(string userName)
        {
            var query = new GetUserByNameQuery() { UserName = userName };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost("Authentication")]
        public async Task<ActionResult<Application.Users.Queries.GetUsers.UserProfileVM>> Authentication([FromBody] AuthenticationQuery query)
        {
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost("Registration")]
        public async Task<ActionResult<int>> Create([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }
    }
}
