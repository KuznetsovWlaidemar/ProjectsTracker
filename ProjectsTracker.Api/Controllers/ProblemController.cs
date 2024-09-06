using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectsTracker.Application.Services;

namespace ProjectsTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProblemController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly IMapper _mapper;

        public ProblemController(IProblemService problemService,
                                 IMapper mapper)
        {
            _problemService = problemService;
            _mapper = mapper;
        }
    }
}
