using Assets.Scripts;
using Assets.Scripts.Particles;
using MathLists;
using Nodes;
using References;
using States.Game;
using States.Node;
using UnityEngine;

namespace Controllers
{
    // Used to provide functionality to the canon gameobject
    public class CanonController : MonoBehaviour
    {
        // Start is called before the first frame update

        public GameObject nodePrefab;
        public Transform parentTransform;
        private NumberNode newNode;
        public NodeInTransitParticles particles;

        private void Awake()
        {
            gameObject.tag = Tags.CANON;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameStateManager.GetGameState() != GameState.PAUSED && GameStateManager.GetGameState() != GameState.CHECKPOINT)
            {
                // Rotate transform towards mouse position
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10f;

                Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
                mousePos.x = mousePos.x - objectPos.x;
                mousePos.y = mousePos.y - objectPos.y;

                float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

                // If left mouse clicked
                if (Input.GetMouseButtonDown(0))
                {   
                    Shoot(mousePos);
                }
            }
        }

        // Instantiates a new node and fires it towards the mouse position.
        private void Shoot(Vector3 mousePos)
        {
            // Only accept shooting when we're in Pre-insertion
            if (GameStateManager.GetGameState() == GameState.PREINSERTION)
            {
                // Create a new node
                newNode = Instantiate(nodePrefab, transform.position, Quaternion.identity, parentTransform).GetComponent<NumberNode>();

                // Get the directional vector towards the mouse position
                Vector3 heading = mousePos - transform.position;
                newNode.nodeMotor.SetDirection(heading.normalized);

                // Set the node state
                newNode.SetState(NodeState.PROJECTILE);
                // Set it's value and it's corresponding color
                int ballValue = NodeManager.GetNextBallValue();
                newNode.SetValue(ballValue);
                newNode.SetColorToValue();
                
                particles.setNode(newNode);
                // Let the gamestate manager know we're shooting now
                GameStateManager.SwitchToShooting();
            }
        }
    }
}


