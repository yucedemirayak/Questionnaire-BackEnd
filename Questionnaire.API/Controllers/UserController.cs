using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Questionnaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "UserPolicy")]
    public class UserController : Controller
    {
        private readonly Core.IServiceProvider serviceProvider;
        private readonly IMapper mapper;

        public UserController(Core.IServiceProvider _serviceProvider, IMapper _mapper)
        {
            serviceProvider = _serviceProvider;
            mapper = _mapper;
        }


    }
}
