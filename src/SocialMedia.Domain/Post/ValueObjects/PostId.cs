using SocialMedia.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Post.ValueObjects
{
    public class PostId : AggregateRootId<Guid>
    {
        private PostId() { }
        private PostId(Guid value)
        {
            Value = value;
        }
        public override Guid Value { get ; protected set ; }
        public static PostId CreateUnique()=>
             new (Guid.NewGuid());
        

        public static explicit operator PostId(Guid value)=>
             new (value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
