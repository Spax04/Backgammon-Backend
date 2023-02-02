using Chat_DAL.Repositories;
using Chat_Services;
using Chat_Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;

namespace Backgammon_ChatServer.Hubs
{
    public class ChatHub : Hub
    {
        private IChatService _chatService;
        private IMessageService _messageService;
        public ChatHub(IChatService chatService, IMessageService messageService)
        {
            _chatService = chatService;
            _messageService = messageService;
        }


      /*  public  async Task OnConnectedAsync(string token)
        {
            if (token == string.Empty || token == null)
                throw new ArgumentException("User input error");

            //var testToken = Request.Cookies["jwt"];

            var tokenCheck = new JwtSecurityToken(token);
            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;
            string name = tokenCheck.Claims.First(x => x.Type == "name").Value;
            Guid chaterId = Guid.Parse(id);


            // Add user to connected list, 
            var chatter = await _chatService.GetOrAddChatterAsync(chaterId, name);

            var isFirstConnect = await _chatService.ConnectChatterAsync(chatter.Id, Context.ConnectionId);

          //  var chattersWithoutCaller = await chatService.GetChattersAsync(chaterId);

            if (isFirstConnect)
            {
                var chatterIds = chattersWithoutCaller.Select(c => c.Id.ToString()).ToList();

                await Clients.Users(chatterIds).SendAsync("ChatterConnected", chatter);
            }

            await Clients.Caller.SendAsync("SetChatters", chattersWithoutCaller);
       */ //}



        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
