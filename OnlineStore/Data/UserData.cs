using System;
using System.Collections.Generic;
using System.Data.Common;
using OnlineStore.Models;

namespace OnlineStore.Data;

public class UserData
{
    private readonly List<User> users = [
        new(){
            UserId="ccn106",
            UserName="MasterCCNSamma",
            UserEmail="ccn106@gmail.com",
            UserPassword="ccnSamma@106",
            DateTime=new DateTime(),
            DidUserLogIn=false
        }
    ];
    public IEnumerable<User> GetUsers() => users;
    public User? AuthenticateUser(string username, string password)
    {
        return users.FirstOrDefault(user =>
            user.UserName == username && user.UserPassword == password);
    }

}
