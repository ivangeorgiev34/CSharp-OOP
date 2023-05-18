using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private ICollection<ICocktail> cocktails;
        public CocktailRepository()
        {
            cocktails = new List<ICocktail>();
        }
        public IReadOnlyCollection<ICocktail> Models => (IReadOnlyCollection<ICocktail>)cocktails;

        public void AddModel(ICocktail model)
        {
            cocktails.Add(model);
        }
    }
}
