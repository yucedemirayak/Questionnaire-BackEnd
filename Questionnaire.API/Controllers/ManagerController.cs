using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Questionnaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "ManagerPolicy")]
    public class ManagerController : Controller
    {
        private readonly Core.IServiceProvider serviceProvider;
        private readonly IMapper mapper;

        public ManagerController(Core.IServiceProvider _serviceProvider, IMapper _mapper)
        {
            serviceProvider = _serviceProvider;
            mapper = _mapper;
        }


    }
}
