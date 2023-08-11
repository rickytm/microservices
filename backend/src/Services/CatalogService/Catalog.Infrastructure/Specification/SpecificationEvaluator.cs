﻿using Common.Specifications;
using Microsoft.EntityFrameworkCore;
namespace Catalog.Infrastructure.Specification;

public class SpecificationEvaluator<T> where T : class
{

    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
    {
        if (spec.Criteria != null)
        {
            inputQuery = inputQuery.Where(spec.Criteria);
        }

        if (spec.OrderBy != null)
        {
            inputQuery = inputQuery.OrderBy(spec.OrderBy);
        }

        if (spec.OrderByDescending != null)
        {
            inputQuery = inputQuery.OrderByDescending(spec.OrderByDescending);
        }

        if (spec.IsPagingEnable)
        {
            inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);
        }

        if (spec.IncludeStrings.Any())
        {
            inputQuery = spec.IncludeStrings!.Aggregate(inputQuery, (current, include) => current.Include(include)).AsSingleQuery().AsNoTracking();
        }

        inputQuery = spec.Includes!.Aggregate(inputQuery,
                        (current, include) => current.Include(include)).AsSplitQuery().AsNoTracking();

        return inputQuery;
    }

}
