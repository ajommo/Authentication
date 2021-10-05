using System;
using System.Runtime.Serialization;

using Game.Database.Models;

namespace Game.Authentication.Models
{
    [DataContract]
    public class Credentials
    {
        private int id;
        private string username;
        private string password;
        private Guid? token;

        public Credentials()
        {
        }

        public Credentials(AccountEntity account)
        {
            id = account.Id;
            username = account.Username;
            token = account.Token;
        }

        [DataMember(Name = "id")]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [DataMember(Name = "username")]
        public string Username
        {
            get => username;
            set => username = value;
        }

        [DataMember(Name = "password")]
        public string Password
        {
            get => password;
            set => password = value;
        }

        [DataMember(Name = "token")]
        public Guid? Token
        {
            get => token;
            set => token = value;
        }
    }
}
