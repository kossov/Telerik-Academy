using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Infestation.Supplements;

namespace Infestation
{
    public class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            base.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, int.MaxValue, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }
            return optimalAttackableUnit;
        }
    }
}
