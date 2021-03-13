using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Model
{
    public interface IRuleEngine
    {
        decimal CalculatePrice(ICollection<Product> products);
    }
}
