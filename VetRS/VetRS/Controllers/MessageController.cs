using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PusherServer;
using VetRS.Data;
using VetRS.Models;

namespace VetRS.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private int memberId;
        public MessageController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            memberId = 0;
        }

        [HttpGet("{group_id}")]
        public IEnumerable<Message> GetById(int group_id)
        {
            memberId = group_id;
            return _context.Message.Where(gb => gb.GroupId == group_id);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] MessageViewModel message)
        {
            //messages breaking here
            Message newMessage = new Message { SentBy = _userManager.GetUserName(User), message = message.message, GroupId = message.GroupId };
            
            _context.Message.Add(newMessage);
            _context.SaveChanges();
            var options = new PusherOptions
            {
                Cluster = "us3",
                Encrypted = true
            };
            var pusher = new Pusher(
                "1088226",
                "a8e8c58dc5d53b967a82",
                "a320be2396ef5924f1ed",
                options
            );
            var result = await pusher.TriggerAsync(
                "private-" + message.GroupId,
                "new_message",
            new { newMessage },
            new TriggerOptions() { SocketId = message.SocketId });

            return new ObjectResult(new { status = "success", data = newMessage });
        }

    }
}