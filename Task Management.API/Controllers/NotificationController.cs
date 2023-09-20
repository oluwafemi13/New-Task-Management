using Management.Application.Models;
using Management.Core.Entities;
using Management.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Management.Application.DTO;

namespace Task_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [HttpPost("CreateNotification")]
        public async Task<ActionResult> CreateNotification(NotificationDTO notification)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var create = await _service.CreateNotification(notification);
                return Ok(create);
            }
           
        }
        [HttpPut("UpdateNotification")]
        public async Task<ActionResult> UpdateNotification(int Id, NotificationDTO notification)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var update = await _service.Update(notification, Id);
            return Ok(update);
        }

        [HttpDelete("DeleteNotification")]
        public async Task<ActionResult> DeleteNotification([FromQuery] int Id)
        {
            var delete = await _service.DeleteNotification(Id);
            return Ok(delete);
        }

        [HttpGet("GetAllNotifications")]
        public async Task<ActionResult> GetNotifications([FromQuery] RequestParameters parameters)
        {
            var fetchAll = await _service.GetAll(parameters);
            return Ok(fetchAll);
        }

        [HttpPut("ReadNotification")]
        public async Task<ActionResult> MarkNotificationAsRead(int Id)
        {
            var fetchAll = await _service.MarkAsRead(Id);
            return Ok(fetchAll);
        }
    }
}
