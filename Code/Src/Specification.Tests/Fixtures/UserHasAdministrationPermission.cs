namespace Specification.Tests.Fixtures
{
    public class UserHasAdministrationPermission : ISpecification<OrderContext>
    {
        public bool IsSatisfiedBy(OrderContext context)
        {
            return context.IsAdminUser;
        }
    }
}