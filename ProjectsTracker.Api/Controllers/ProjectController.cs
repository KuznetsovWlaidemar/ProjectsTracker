using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectsTracker.Api.Contracts.Project;
using ProjectsTracker.Application.Services;
using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService,
                                 IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjectsAsync()
        {
            var result = await _projectService.GetAllProjectsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
           var result = await _projectService.GetProjectAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectRequest request)
        {
            var project = _mapper.Map<Project>(request);
            await _projectService.CreateAsync(project);
            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, UpdateProjectRequest request)
        {
            var existingProject = await _projectService.GetProjectAsync(id);
            if (existingProject == null)
            {
                return NotFound($"Проект с {id} не найден.");
            }

            _mapper.Map(request, existingProject);

            await _projectService.UpdateAsync(id, existingProject);

            return Ok(existingProject);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{employeeId}/{projectId}")]
        public IActionResult DeleteEmployeeFromProject(int employeeId, int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
