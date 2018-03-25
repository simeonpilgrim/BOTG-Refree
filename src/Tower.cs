using System;
using System.Collections.Generic;

namespace BOTG_Refree
{
    public class Tower : Unit
    {
        Unit aggroUnit;
        int aggroTimeLeft;
        double aggroTset;

        Tower(double x, double y, int health, int team, Player player):base(x, y, health, team, 0, player)
        {
        }

        override void afterRound()
        {
            base.afterRound();
            aggroTimeLeft--;
        }

        void findAction(List<Unit> allUnits)
        {
            if (aggroUnit != null && aggroTimeLeft > 0 && canAttack(aggroUnit))
            {
                aggroTimeLeft--;
                fireAttack(aggroUnit);
                return;
            }

            aggroTset = 1.0;
            aggroUnit = null;
            aggroTimeLeft = -1;
            Unit closest = findClosestOnOtherTeam("UNIT");
            if (canAttack(closest))
            {
                fireAttack(closest);
            } else
            {
                closest = findClosestOnOtherTeam("HERO");
                if (canAttack(closest))
                {
                    fireAttack(closest);
                }
            }
        }

        override public String getType()
        {
            return "TOWER";
        }
    }
}