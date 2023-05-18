using SocialMedia.Domain.Common.Models;
using SocialMedia.Domain.Post.Exceptions;
using SocialMedia.Domain.Post.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Post.Entities
{
    public class PostTags : Entity<PostTagsId>
    {
        private PostTags() { }
        private PostTags(PostTagsId id, string name) :base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public static PostTags Create(string name) =>
            new (PostTagsId.CreateUnique(), name);

        public void IsValidTagNameLength()
        {
            if (string.IsNullOrEmpty(Name) && Name.Length > 20)
                throw new InvalidTagNameLengthException();
        }



    }
}
