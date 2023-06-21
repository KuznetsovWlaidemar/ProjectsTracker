﻿using Microsoft.AspNetCore.Mvc;
using ProjectsTracker.Domain;
using ProjectsTracker.Services;

namespace ProjectsTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        #region Fields
        private readonly IProjectService? _projectService;
        #endregion

        #region Constructors
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        #endregion

        #region Methods
        // GET: api/projects
        [HttpGet]
        public IActionResult GetProjects()
        {
            try
            {
                var projects = _projectService.GetProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                // Обработка ошибки и возврат кода состояния HTTP 500 (Внутренняя ошибка сервера)
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
            catch (Exception ex)
            {
                // Обработка ошибки и возврат кода состояния HTTP 500 (Внутренняя ошибка сервера)
                return StatusCode(500, "Произошла ошибка при получении проекта.");
            }
        }
        // POST: api/projects
        [HttpPost]
        public IActionResult CreateProject(Employee project)
        {
            try
            {
                _projectService.CreateProject(project);
                return Ok(project);
            }
            catch (Exception ex)
            {
                // Обработка ошибки и возврат кода состояния HTTP 500 (Внутренняя ошибка сервера)
                return StatusCode(500, "Произошла ошибка при создании проекта.");
            }
        }
        // PUT: api/projects/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, Employee updatedProject)
        {
            try
            {
                var project = _projectService.UpdateProject(id, updatedProject);
                return Ok(project);
            }
            catch (Exception ex)
            {
                // Обработка ошибки и возврат кода состояния HTTP 500 (Внутренняя ошибка сервера)
                return StatusCode(500, "Произошла ошибка при обновлении проекта.");
            }
        }
        // DELETE: api/projects/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                _projectService.DeleteProject(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Обработка ошибки и возврат кода состояния HTTP 500 (Внутренняя ошибка сервера)
                return StatusCode(500, "Произошла ошибка при удалении проекта.");
            }
        }
        #endregion
    }
}