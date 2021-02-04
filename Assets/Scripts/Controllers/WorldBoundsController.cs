using Nodes;
using States.Game;
using States.Node;
using UnityEngine;

namespace Controllers
{
    // Used to destroy any gameobject that exceeds these bounds
    public class WorldBoundsController : MonoBehaviour
    {
        void OnTriggerExit2D(Collider2D other)
        {
            NumberNode otherNode = other.gameObject.GetComponent<NumberNode>();
            if (otherNode != null)
            {
                if (otherNode.state == NodeState.PROJECTILE)
                {
                    Destroy(other.gameObject);
                    // We are no longer inserting, as the node that has been inserted has been destroyed.
                    // Update the GameStateManager to reflect this.
                    GameStateManager.SwitchToPreInsertion();
                }
            }
        }
    }
}
