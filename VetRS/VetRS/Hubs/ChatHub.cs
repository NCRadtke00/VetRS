using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Policy;
using System.Threading.Tasks;
//using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using VetRS.Common;

namespace VetRS.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message, string userId)
        {
            await Clients.Clients(userId).SendAsync("ReceiveMessage", message, Context.ConnectionId);
            await Clients.Clients(Context.ConnectionId).SendAsync("OwnMessage", message.Trim());
        }
        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            Clients.All.SendAsync("OnlineUserList", connectionId);
            return base.OnConnectedAsync();
        }
        public async Task OnlineUsers()
        {
            var connectionId = Context.ConnectionId;
            await Clients.All.SendAsync("OnlineUserList", connectionId);
        }
        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
        //public async Task AddToGroup(string groupName)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        //    await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        //}

        //public async Task RemoveFromGroup(string groupName)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        //    await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        //}
        //public Task SendPrivateMessage(string user, string message)
        //{
        //    return Clients.User(user).SendAsync("ReceiveMessage", message);
        //}
        //    static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        //    static List<MessageDetail> CurrentMessage = new List<MessageDetail>();
        //    public void Connect(string userName)
        //    {
        //        var id = Context.ConnectionId;


        //        if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
        //        {
        //            ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName });

        //            // send to caller
        //            Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

        //            // send to all except caller client
        //            Clients.AllExcept(id).onNewUserConnected(id, userName);

        //        }

        //    }

        //    public void SendMessageToAll(string userName, string message)
        //    {
        //        // store last 100 messages in cache
        //        AddMessageinCache(userName, message);

        //        // Broad cast message
        //        Clients.All.SendAsync(userName, message);
        //    }

        //    public void SendPrivateMessage(string toUserId, string message)
        //    {

        //        string fromUserId = Context.ConnectionId;

        //        var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
        //        var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

        //        if (toUser != null && fromUser != null)
        //        {
        //            // send to 
        //            Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

        //            // send to caller user
        //            Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
        //        }

        //    }

        //    public override System.Threading.Tasks.Task OnDisconnected()
        //    {
        //        var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
        //        if (item != null)
        //        {
        //            ConnectedUsers.Remove(item);

        //            var id = Context.ConnectionId;
        //            Clients.All.onUserDisconnectedAsync(id, item.UserName);

        //        }

        //        return base.OnDisconnectedAsync();
        //    }
        //    private void AddMessageinCache(string userName, string message)
        //    {
        //        CurrentMessage.Add(new MessageDetail { UserName = userName, Message = message });

        //        if (CurrentMessage.Count > 100)
        //            CurrentMessage.RemoveAt(0);
        //    }
        //}
    }
}
