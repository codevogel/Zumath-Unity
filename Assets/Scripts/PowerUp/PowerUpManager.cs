using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PowerUps
{
    public static class PowerUpManager
    {
        private static PowerUpList powerUpList = new PowerUpList();
        
        public static void AddPowerUps(PowerUp powerUp)
        {
            powerUpList.powerUpLinkedList.AddFirst(powerUp);
        }

        public static void RemovePowerUps(PowerUp powerUp)
        {
           powerUpList.powerUpLinkedList.Remove(powerUp);
        }

        public static bool Contains(PowerUp powerUp)
        {
            if (powerUpList.powerUpLinkedList.Contains(powerUp))
            {
                return true;
            }
            return false;
        }

        public static LinkedList<PowerUp> GetPowerUps()
        {
            if (powerUpList != null)
            {
                return powerUpList.powerUpLinkedList;
            }
            return new LinkedList<PowerUp>();
        }
    }
}