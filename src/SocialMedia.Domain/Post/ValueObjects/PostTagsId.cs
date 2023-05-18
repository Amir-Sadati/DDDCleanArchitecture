using SocialMedia.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Post.ValueObjects
{
    public sealed class PostTagsId : ValueObject
    {
        private PostTagsId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static PostTagsId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static explicit operator PostTagsId(Guid value) =>
           new PostTagsId(value);
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
