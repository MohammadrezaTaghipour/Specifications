using System;

namespace Specification.Tests.Fixtures
{
    public class Order
    {
        public OrderState State { get; private set; }

        public void Cancel(OrderContext context)
        {
            if (GuardAgainstOrderCantBeCanceled(context))
                throw new OrderCantBeCanceledByCurrentUser();
            State = OrderState.Canceled;
        }

        bool GuardAgainstOrderCantBeCanceled(OrderContext context)
        {
            var condition = new UserHasAdministrationPermission()
                .And(new UserOwnsOrderSpecification());
            return condition.IsSatisfiedBy(context);
        }
    }
}
