using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories.Contracts
{
    public class RaceRepository : IRepository<IRace>
    {
        private ICollection<IRace> races;
        public RaceRepository()
        {
            races = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)races;

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string name)
        {
            return Models.FirstOrDefault(n => n.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);
        }
    }
}
