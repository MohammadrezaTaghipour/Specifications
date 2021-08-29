using System;

namespace Specification
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T context);
    }
}
