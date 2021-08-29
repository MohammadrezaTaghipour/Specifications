using FluentAssertions;
using Specification.Tests.Fixtures;
using System;
using Xunit;
using static Specification.Tests.TestData.UserPermission;
using static Specification.Tests.TestData.UsersTestData;

namespace Specification.Tests
{
    public class OrderCancellationSpecificationTests
    {
        [Fact]
        public void order_gets_canceled_properly_by_its_issuer()
        {
            var orderContext = new OrderContext
            {
                OrderIssuedBy = Jack.UserId,
                CurrentUserId = Jack.UserId,
                CurrentUserPermission = ModificationPermission
            };

            var order = new Order();
            order.Cancel(orderContext);

            order.State.Should().BeEquivalentTo(OrderState.Canceled);
        }

        [Fact]
        public void order_gets_canceled_properly_by_admin_user()
        {
            var orderContext = new OrderContext
            {
                OrderIssuedBy = Ferry.UserId,
                CurrentUserId = Jack.UserId,
                CurrentUserPermission = AdministrationPermissions
            };

            var order = new Order();
            order.Cancel(orderContext);

            order.State.Should().BeEquivalentTo(OrderState.Canceled);
        }

        [Fact]
        public void order_is_not_allowed_to_get_canceled_by_a_user_who_is_not_the_issuer() 
        { 
            var orderContext = new OrderContext
            {
                OrderIssuedBy = Ferry.UserId,
                CurrentUserId = Jack.UserId,
                CurrentUserPermission = ReadOnlyPermission
            };

            var order = new Order();

            try
            {
                order.Cancel(orderContext);
            } 
            catch (Exception e)
            {
                e.Should().BeOfType<OrderCantBeCanceledByCurrentUser>();
            }
        }

        [Fact]
        public void order_is_not_allowed_to_get_canceled_by_a_user_who_is_not_admin()
        {
            var orderContext = new OrderContext
            {
                OrderIssuedBy = Ferry.UserId,
                CurrentUserId = Jack.UserId,
                CurrentUserPermission = ModificationPermission
            };

            var order = new Order();

            try
            {
                order.Cancel(orderContext);
            }
            catch (Exception e)
            {
                e.Should().BeOfType<OrderCantBeCanceledByCurrentUser>();
            }
        }
    }
}
