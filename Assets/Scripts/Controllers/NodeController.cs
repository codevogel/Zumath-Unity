using Nodes;
using States.Game;
using States.Node;
using UnityEngine;


namespace Controllers
{
    [RequireComponent(typeof(NumberNode))]
    public class NodeController : MonoBehaviour
    {

        private NumberNode numberNode;

        private Vector3 direction;
        public float speed = 2f;

        void Awake()
        {
            numberNode = GetComponent<NumberNode>();
        }

        public void SetDirection(Vector3 direction)
        {
            this.direction = direction;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameStateManager.GetGameState() != GameState.PAUSED)
            {
                if (numberNode.state != NodeState.PROJECTILE)
                {
                    this.enabled = false;
                    return;
                }
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
    }
}

