using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private ICollection<IDelicacy> delicacies;
        public DelicacyRepository()
        {
            delicacies = new List<IDelicacy>();
        }
        public IReadOnlyCollection<IDelicacy> Models => (IReadOnlyCollection<IDelicacy>)delicacies;

        public void AddModel(IDelicacy model)
        {
            delicacies.Add(model);
        }
    }
}
