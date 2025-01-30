using System;
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
    public User[] GetUsers() => [.. users];

}
