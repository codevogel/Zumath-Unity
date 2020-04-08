using Nodes;
using States.Game;
using States.Node;
using UnityEngine;

namespace Controllers
{
    public class WorldBoundsController : MonoBehaviour
    {
        void OnTriggerExit2D(Collider2D other)
        {
            NumberNode otherNode = other.gameObject.GetComponent<NumberNode>();
            if (otherNode.state == NodeState.PROJECTILE)
            {
                Destroy(other.gameObject);
                GameStateManager.SetGameState(GameState.PREINSERTION);
            }
        }
    }
}
