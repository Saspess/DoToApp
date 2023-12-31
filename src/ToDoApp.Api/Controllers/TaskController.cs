﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Business.DTOs.Task;
using ToDoApp.Business.Services.Contracts;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _taskService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var result = await _taskService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("UsersTesks/{appUserId:int}")]
        public async Task<IActionResult> GetByAppUserIdAsync([FromRoute] int appUserId)
        {
            var result = await _taskService.GetByAppUserIdAsync(appUserId);

            return Ok(result);
        }

        [HttpGet("UsersCompletedTesks/{appUserId:int}")]
        public async Task<IActionResult> GetAppUserCompletedTasksAsync([FromRoute] int appUserId)
        {
            var result = await _taskService.GetAppUserCompletedTasksAsync(appUserId);

            return Ok(result);
        }

        [HttpGet("UsersUncompletedTesks/{appUserId:int}")]
        public async Task<IActionResult> GetAppUserUncompletedTasksAsync([FromRoute] int appUserId)
        {
            var result = await _taskService.GetAppUserUncompletedTasksAsync(appUserId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TaskCreateDto taskCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _taskService.CreateAsync(taskCreateDto);

            return StatusCode(201, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TaskUpdateDto taskUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _taskService.UpdateAsync(taskUpdateDto);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _taskService.DeleteAsync(id);

            return Ok();
        }
    }
}
