using SocialMedia.Domain.Common.Models;
using SocialMedia.Domain.Post.Entities;
using SocialMedia.Domain.Post.ValueObjects;
using SocialMedia.Domain.User.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Post
{
    public class Post : AggregateRoot<PostId,Guid> 
    {
        private Post() { }
        private Post(PostId id, List<PostTags> postTags, string title, string text, string imageUrl):base(id)
        {
            if (postTags.Count > 0)
                postTags.ForEach(tag => tag.IsValidTagNameLength());

            Title=title;
            Text=text;
            ImageUrl=imageUrl;
        }

        private readonly List<PostTags> _postTags = new();
        public IReadOnlyList<PostTags> PostTags => _postTags.AsReadOnly();
        public UserId UserId { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string? ImageUrl { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public static Post Publish(List<PostTags> postTags, string title, string text, string imageUrl) =>
            new(PostId.CreateUnique(), postTags, title, text, imageUrl);

    }
}
