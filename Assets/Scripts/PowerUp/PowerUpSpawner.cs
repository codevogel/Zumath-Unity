using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerUps
{
    // Spawns the PowerUps
    public class PowerUpSpawner : MonoBehaviour
    {
        public GameObject powerUpBall;
        public Transform parentTransform;

        private const int POWERUPS_TO_SPAWN = 1;

        private void Awake()
        {
            for (int i = POWERUPS_TO_SPAWN; i > 0; i--)
            {
                SpawnPowerUps();
            }
        }

        public void SpawnPowerUps()
        {
            Vector3 startingLocation = new Vector3(0, 0, 0);
            PowerUp powerUp = Instantiate(powerUpBall, startingLocation, Quaternion.identity, parentTransform).GetComponent<PowerUp>();

            PowerUpManager.AddPowerUps(powerUp);
        }
    }
}
