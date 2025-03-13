using System;
using System.Collections.Generic;
using System.Data.Common;
using OnlineStore.Models;

namespace OnlineStore.Data;

public class UserData
{
    public static List<User> users = [
        new(){
            UserId="ccn106",
            UserName="MasterCCNSamma",
            UserEmail="ccn106@gmail.com",
            UserPassword="ccnSamma@106",
            DateTime=new DateTime(),
            DidUserLogIn=false
        }
    ];

    public void AddUser(string userId, string username, string email, string password)
    {
        users.Add(new User()
        {
            UserId = userId + "A76Z" ,
            UserName = username,
            UserEmail = email,
            UserPassword = password,
            DateTime = DateTime.Now,
            DidUserLogIn = false
        });

        Console.WriteLine($"User: {username} of ID: {userId}, is added on {DateTime.Now}");
    }


    // public IEnumerable<User> GetUsers() => users;
    public User? AuthenticateUser(string username, string password)
    {
        return users.FirstOrDefault(user =>
            user.UserName == username && user.UserPassword == password);
    }
}
