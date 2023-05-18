using SocialMedia.Domain.Common.Models;
using SocialMedia.Domain.Post.Exceptions;
using SocialMedia.Domain.Post.ValueObjects;
using SocialMedia.Domain.User.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.User
{
    public class User : AggregateRoot<UserId, Guid>
    {
        private User() { }
        private User(UserId id,Email email, string firstName, string lastName,string password) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
        }
        public Email Email { get; private set; }
        public List<PostId> PostId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }

        public static User Register(Email email, string firstName, string lastName, string password) =>
            new(UserId.CreateUnique(), email,firstName,lastName,password);

    }
}
