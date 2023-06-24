using AutoMapper;
using EmployeesTracker.Services;
using Microsoft.AspNetCore.Mvc;
using ProjectsTracker.Api.Dto.Projects;
using ProjectsTracker.Domain.Projects;
using ProjectsTracker.Services;

namespace ProjectsTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        #region Fields
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ProjectController(IProjectService projectService,                                
                                 IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;

        }
        #endregion

        #region Methods
        // GET: api/projects
        [HttpGet]
        public IActionResult GetProjects(Filter.Filter filter)
        {
            try
            {
                var projects = _projectService.GetProjects(filter);
                return Ok(projects);
            }
            catch
            {
                return StatusCode(500, "Произошла ошибка при получении списка проектов.");
            }
        }

        // GET: api/projects/{id}
        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            try
            {
                var project = _projectService.GetProject(id);
                if (project == null)
                    return NotFound();

                return Ok(project);
            }
            catch
            {
                return StatusCode(500, "Произошла ошибка при получении проекта.");
            }
        }

        // POST: api/projects
        [HttpPost]
        public IActionResult CreateProject(ProjectDto projectDto)
        {
            try
            {
                var project = _mapper.Map<Project>(projectDto);
                projectDto = _mapper.Map<ProjectDto>(_projectService.CreateProject(project));

                return Ok(projectDto);
            }
            catch
            {
                return StatusCode(500, "Произошла ошибка при создании проекта.");
            }
        }

        // PUT: api/projects/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, ProjectDto updatedProjectDto)
        {
            try
            {
                var updatedProject = _mapper.Map<Project>(updatedProjectDto);
                updatedProjectDto = _mapper.Map<ProjectDto>(_projectService.UpdateProject(id, updatedProject));
                return Ok(updatedProjectDto);
            }
            catch
            {
                return StatusCode(500, "Произошла ошибка при обновлении проекта.");
            }
        }

        // DELETE: api/projects/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                var project = _projectService.GetProject(id);
                if (project == null)
                {
                    return NotFound();
                }

                _projectService.DeleteProject(project);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Произошла ошибка при удалении проекта.");
            }
        }

        //DELETE: api/projects/{employeeId/projectId}
        [HttpDelete("{employeeId/projectId}")]
        public IActionResult DeleteEmployeeFromProject(int employeeId, int projectId)
        {
            try
            {
                _projectService.DeleteEmployeeFromProject(employeeId, projectId);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Произошла ошибка при удалении сотрудника из проекта.");
            }
        }

        #endregion
    }
}
