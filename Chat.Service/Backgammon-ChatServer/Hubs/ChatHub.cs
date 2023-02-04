using Chat_DAL.Repositories;
using Chat_Services;
using Chat_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;

namespace Backgammon_ChatServer.Hubs
{
    //[Authorize]
    public class ChatHub : Hub
    {
        private IChatService _chatService;
        private IMessageService _messageService;
        public ChatHub(IChatService chatService, IMessageService messageService)
        {
            _chatService = chatService;
            _messageService = messageService;
        }


        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            // var token = Context.GetHttpContext().Request.Headers["Authorization"].ToString();
              string token = Context.GetHttpContext().Request.Query["token"].ToString();

            //var token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI3MDRmZWU5Yi1mMGMxLTQxMTAtODMwNS1jMzI2YjRmMzFkNGYiLCJ1c2VySWQiOiJlMzgxZWZkOS1mMTNjLTRiNmItOTk3ZS0zYTExYmU1NTBiOGUiLCJuYW1lIjoic3RyaW5nIiwiZW1haWwiOiJzdHJpbmciLCJleHAiOjE3MDY5NTg0NjV9._m7yCY59dQV4xQ3X0FpD6AQZ21QlnPf20dJuaHCOL7OSxed4iVnF4lVa2qZiOFAb6MiXswBr2lkZje_mXBrA9A";


            //var testToken = Request.Cookies["jwt"];

            var tokenCheck = new JwtSecurityToken(token);
            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;
            string name = tokenCheck.Claims.First(x => x.Type == "name").Value;
            Guid chaterId = Guid.Parse(id);


            // Add user to connected list, 
            var chatter = await _chatService.GetOrAddChatterAsync(chaterId, name);

            var isFirstConnect = await _chatService.ConnectChatterAsync(chatter.Id, Context.ConnectionId);

            var chattersWithoutCaller = await _chatService.GetChattersAsync(chaterId);

            if (isFirstConnect)
            {
                var chatterIds = chattersWithoutCaller.Select(c => c.Id.ToString()).ToList();

                // Who is online - automatacly get new user that conected
                await Clients.Users(chatterIds).SendAsync("ChatterConnected", chatter);
            }
            // Caller gets list of users online
            await Clients.Caller.SendAsync("SetChatters", chattersWithoutCaller);
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            await base.OnDisconnectedAsync(exception);
            string token = Context.GetHttpContext().Request.Query["token"].ToString();

            var tokenCheck = new JwtSecurityToken(token);
            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;
            Guid chatterId = Guid.Parse(id);

            var chatter = await _chatService.GetChatterAsync(chatterId);

            if (chatter == null)
                return;

            if (await _chatService.DisconnectChatterAsync(chatter.Id, Context.ConnectionId))
            {
                var lastSeen = await _chatService.GetLastSeenAsync(chatterId);
                chatter.LastSeen = lastSeen;
                await Clients.Others.SendAsync("ChatterDisconnect", chatter);
            }

        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
