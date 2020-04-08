using Assets.Scripts;
using MathLists;
using Nodes;
using References;
using States.Game;
using States.Node;
using UnityEngine;

namespace Controllers
{
    public class CanonController : MonoBehaviour
    {
        // Start is called before the first frame update

        public GameObject node;
        public Transform parentTransform;
        private NumberNode newNode;

        private void Awake()
        {
            gameObject.tag = Tags.CANON;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameStateManager.GetGameState() != GameState.PAUSED)
            {
                //rotation
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10f;

                Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
                mousePos.x = mousePos.x - objectPos.x;
                mousePos.y = mousePos.y - objectPos.y;

                float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

                if (Input.GetMouseButtonDown(0))
                {
                    Shoot(mousePos);
                }
            }
        }

        private void Shoot(Vector3 mousePos)
        {
            if (GameStateManager.GetGameState() == GameState.PREINSERTION)
            {
                newNode = Instantiate(node, transform.position, Quaternion.identity, parentTransform).GetComponent<NumberNode>();

                Vector3 heading = mousePos - transform.position;
                float distance = heading.magnitude;
                newNode.nodeMotor.SetDirection(heading / distance);

                newNode.SetState(NodeState.PROJECTILE);
                int ballValue = NodeManager.GetNextBallValue();
                newNode.SetValue(ballValue);
                GameStateManager.SwitchToShooting();
            }
        }
    }
}


