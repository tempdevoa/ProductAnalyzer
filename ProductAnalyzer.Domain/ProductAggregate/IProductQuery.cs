﻿using ProductAnalyzer.Domain.ProductAggregate.Filtering;

namespace ProductAnalyzer.Domain.ProductAggregate
{
    public interface IProductQuery
    {
        Task<IEnumerable<Product>> QueryWithAsync(IProductFilter productFilter);
    }
}
