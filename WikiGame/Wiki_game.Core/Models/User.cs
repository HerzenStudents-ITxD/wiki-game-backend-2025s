using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WikiGame.Core.Models;

public class User
{
    public User(string email,  string password_salt, string password_hash, string nickname, string stats, string achievements, bool isAdmin)
    {
        UserEmail = email;
        UserPasswordSalt = password_salt;
        UserPasswordHash = password_hash;
        UserNickname = nickname;
        UserStats = stats;
        UserAchievements = achievements;
        IsAdmin = isAdmin;
    }

    public Guid UserId { get; set; }
    public string UserEmail { get; set; }
    public string UserPasswordSalt { get; set; }
    public string UserPasswordHash { get; set; }
    public string UserNickname { get; set; }
    public string UserStats { get; set; }
    public string UserAchievements { get; set; }
    public bool IsAdmin { get; set; }
}
