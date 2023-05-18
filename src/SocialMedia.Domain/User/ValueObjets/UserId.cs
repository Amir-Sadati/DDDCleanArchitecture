using SocialMedia.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.User.ValueObjets
{
    public class UserId : AggregateRootId<Guid>
    {
        private UserId() { }
        private UserId(Guid value)
        {
            Value = value;
        }
        public override Guid Value { get; protected set; }
        public static UserId CreateUnique() =>
             new(Guid.NewGuid());


        public static explicit operator UserId(Guid value) =>
             new(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
