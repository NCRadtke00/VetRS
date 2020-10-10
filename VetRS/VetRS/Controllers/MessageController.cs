using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using VetRS.Models;
using VetRS.Data;

namespace VetRS.Controllers
{
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext db;
        public MessageController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult ShowChatRoom(string userName)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    List<ChatRoom> chatRooms = new List<ChatRoom>();
                    ChatRoom chat = null;
                    var currentUser = db.Users.FirstOrDefault(x => x.UserName == HttpContext.Session.GetString("UserName"));
                    var user = db.Users.FirstOrDefault(x => x.UserName == userName);
                    ViewBag.UserId = user.Id;
                    var myChatRoom = db.ChatRoomUsers.Where(x => x.UserId == currentUser.Id).ToList();
                    if (myChatRoom.Count != 0)
                    {
                        foreach (var item in myChatRoom)
                        {
                            chatRooms.AddRange(db.ChatRooms.Where(x => x.Id == item.ChatRoomId));
                        }

                        foreach (var chatroom in chatRooms)
                        {
                            if (db.ChatRoomUsers.Any(x => x.ChatRoomId == chatroom.Id && x.UserId == user.Id))
                            {
                                var chatroomuser = myChatRoom.Where(x => x.ChatRoomId == chatroom.Id).FirstOrDefault();
                                chat = db.ChatRooms.FirstOrDefault(x => x.Id == chatroomuser.ChatRoomId);
                            }
                            else
                            {
                                chat = new ChatRoom();
                                db.ChatRooms.Add(chat);
                                db.SaveChanges();
                                ChatRoomUser chatRoomUser = new ChatRoomUser();
                                chatRoomUser.ChatRoomId = chat.Id;
                                chatRoomUser.UserId = user.Id;
                                db.ChatRoomUsers.Add(chatRoomUser);
                                db.SaveChanges();
                                ChatRoomUser chatRoomUser2 = new ChatRoomUser();
                                chatRoomUser2.UserId = currentUser.Id;
                                chatRoomUser2.ChatRoomId = chat.Id;
                                db.ChatRoomUsers.Add(chatRoomUser2);
                                db.SaveChanges();
                                transaction.Commit();

                            }
                        }

                    }
                    else
                    {
                        chat = new ChatRoom();
                        db.ChatRooms.Add(chat);
                        db.SaveChanges();
                        ChatRoomUser chatRoomUser = new ChatRoomUser();
                        chatRoomUser.ChatRoomId = chat.Id;
                        chatRoomUser.UserId = user.Id;
                        db.ChatRoomUsers.Add(chatRoomUser);
                        db.SaveChanges();
                        ChatRoomUser chatRoomUser2 = new ChatRoomUser();
                        chatRoomUser2.UserId = currentUser.Id;
                        chatRoomUser2.ChatRoomId = chat.Id;
                        db.ChatRoomUsers.Add(chatRoomUser2);
                        db.SaveChanges();
                        transaction.Commit();

                    }
                    return View(chat);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
         }
    }
}