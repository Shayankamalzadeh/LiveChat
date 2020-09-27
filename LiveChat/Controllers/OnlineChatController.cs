
using System.Threading.Tasks;

using LiveChat.Application;
using LiveChat.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace LiveChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineChatController : ControllerBase
    {
        private readonly ChatHub _chatService;

        public OnlineChatController(ChatHub chatService)
        {
            _chatService = chatService;
        }

        /// <summary>
        /// Send Private Message for somebody
        /// </summary>
        /// <param name="message">
        ///
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("OnlineChat/SendMessage")]
        public async Task<IActionResult> SendMessage(SendRequestModel message)
        {

            await _chatService.SendMessage(message);
            return Ok();
        }
        /// <summary>
        /// History of message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("OnlineChat/HistoryMessage")]
        public async Task<IActionResult> SendMessage(RequestForHistoryMessages message)
        {

            var result = await _chatService.GetHistoryMessage(message);

            return Ok(result);

        }

        /// <summary>
        /// Contact List for one user
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("OnlineChat/ContactList")]
        public async Task<IActionResult> ContactList(RequestForHistoryMessages message)
        {

            var result = await _chatService.GetHistoryMessage(message);

            return Ok(result);

        }


    }
}
