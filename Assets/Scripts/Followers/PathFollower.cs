using UnityEngine;
using PathCreation;
using References;
using Nodes;
using Follower;

// Moves along a path at constant speed.
// Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
namespace Following
{
    [RequireComponent(typeof(NumberNode))]
    [RequireComponent(typeof(PathCreator))]
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float distanceTravelled;

        void Awake()
        {
            pathCreator = GameObject.FindGameObjectWithTag(Tags.GUTTER).GetComponent<PathCreator>();
        }

        public void Follow(MoveType moveType)
        {
            float speed = NodeManager.GetSpeed();
            // Adjust distance travelled
            if (moveType == MoveType.FORWARD)
            {
                distanceTravelled += speed * Time.deltaTime;
            }
            else
            {
                distanceTravelled -= speed * Time.deltaTime;
            }
            // Update position accordingly
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        }

        public void SetDistanceTravelled(float distanceTravelled)
        {
            this.distanceTravelled = distanceTravelled;
        }
    }
}
