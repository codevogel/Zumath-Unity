using Nodes;
using States.Game;
using States.Node;
using UnityEngine;


namespace Motors
{
    // Responsible for moving a node as a projectile
    public class NodeMotor : MonoBehaviour
    {
        private Vector3 direction;
        public float speed = 2f;

        public void SetDirection(Vector3 direction)
        {
            this.direction = direction;
        }

        // Update is called once per frame
        void Update()
        {
            // Confirm that the gamestate is shooting, (and not paused)
            if (GameStateManager.GetGameState() == GameState.SHOOTING)
            {
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
    }
}

