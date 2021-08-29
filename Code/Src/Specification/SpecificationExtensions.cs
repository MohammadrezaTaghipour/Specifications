﻿using System;

namespace Specification
{
    public static class SpecificationExtensions
    {
        public static ISpecification<T> And<T>(
            this ISpecification<T> left, ISpecification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        public static ISpecification<T> Or<T>(
            this ISpecification<T> left, ISpecification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }

        public static ISpecification<T> AndNot<T>(
            this ISpecification<T> left, ISpecification<T> right)
        {
            return left.And(new NotSpecification<T>(right));
        }

        public static ISpecification<T> OrNot<T>(
            this ISpecification<T> left, ISpecification<T> right)
        {
            return left.Or(new NotSpecification<T>(right));
        }
    }
}
