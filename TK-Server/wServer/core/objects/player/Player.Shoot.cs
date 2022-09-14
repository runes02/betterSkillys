﻿using System;
using System.Collections.Generic;

namespace wServer.core.objects
{
    partial class Player
    {
        private int LastShootTime;

        public bool IsValidShoot(int time, double rateOfFire)
        {
            var attackPeriod = (int)(1 / Stats.GetAttackFrequency() * 1 / rateOfFire);
            if (time < LastShootTime + attackPeriod)
                return false;
            LastShootTime = time;
            return true;
        }
    }
}