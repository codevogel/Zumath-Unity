using Nodes;
using States.Game;
using States.Node;
using UnityEngine;


namespace Motors
{
    [RequireComponent(typeof(NumberNode))]
    public class NodeMotor : MonoBehaviour
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
            if (GameStateManager.GetGameState() == GameState.SHOOTING)
            {
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
    }
}

