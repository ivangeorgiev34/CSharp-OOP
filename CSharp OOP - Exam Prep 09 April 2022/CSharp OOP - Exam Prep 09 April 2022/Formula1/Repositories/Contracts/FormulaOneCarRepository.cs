using Formula1.Models;
using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories.Contracts
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private ICollection<IFormulaOneCar> formulaOneCars;
        public FormulaOneCarRepository()
        {
            formulaOneCars = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)formulaOneCars;

        public void Add(IFormulaOneCar model)
        {
            formulaOneCars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return Models.FirstOrDefault(m => m.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return formulaOneCars.Remove(model);
        }
    }
}
