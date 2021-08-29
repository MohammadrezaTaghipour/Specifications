namespace Specification
{
    public class NotSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _spec;

        public NotSpecification(ISpecification<T> spec)
        {
            _spec = spec;
        }

        public bool IsSatisfiedBy(T context)
        {
            return !_spec.IsSatisfiedBy(context);
        }
    }
}