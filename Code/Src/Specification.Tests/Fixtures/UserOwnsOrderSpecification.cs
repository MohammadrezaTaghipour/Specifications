using System;

namespace Specification.Tests.Fixtures
{
    public class UserOwnsOrderSpecification : ISpecification<OrderContext>
    {
        public bool IsSatisfiedBy(OrderContext context)
        {
            return context.OrderIssuedBy == context.CurrentUserId;
        }
    }
}
