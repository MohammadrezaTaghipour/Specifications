namespace Specification
{
    public class OrSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left,
            ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public bool IsSatisfiedBy(T context)
        {
            return _left.IsSatisfiedBy(context) ||
                   _right.IsSatisfiedBy(context);
        }
    }
}