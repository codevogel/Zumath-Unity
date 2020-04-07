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
        private float timeStamp = 0;
        private const float COOLDOWN = 1; // in seconds
        private bool locked = true;

        private void Awake()
        {
            gameObject.tag = Tags.CANON;
        }

        void Start()
        {
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
            if (locked)
            {
                return;
            }
            if (timeStamp < Time.time)
            {
                newNode = Instantiate(node, transform.position, Quaternion.identity, parentTransform).GetComponent<NumberNode>();
                newNode.SetValue(2);
                newNode.SetState(NodeState.PROJECTILE);

                Vector3 heading = mousePos - transform.position;
                float distance = heading.magnitude;
                newNode.nodeController.SetDirection(heading / distance);

                timeStamp = Time.time + COOLDOWN;
                //fired = true;

            }
        }

        public void Lock()
        {
            locked = true;
        }

        public void Unlock()
        {
            locked = true;
        }
    }
}


