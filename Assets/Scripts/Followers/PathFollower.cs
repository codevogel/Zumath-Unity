using UnityEngine;
using PathCreation;
using References;
using Nodes;
using Follower;
using States.Game;

// Moves along a path at constant speed.
// Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
namespace Following
{
    [RequireComponent(typeof(NumberNode))]
    [RequireComponent(typeof(PathCreator))]
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        private NumberNode attachedNode;
        public EndOfPathInstruction endOfPathInstruction;
        public bool following;
        public bool forwards;
        public float distanceTravelled;

        void Awake()
        {
            pathCreator = GameObject.FindGameObjectWithTag(Tags.GUTTER).GetComponent<PathCreator>();
            attachedNode = GetComponent<NumberNode>();
        }

        public void Follow(MoveType moveType)
        {
            float speed = NodeManager.GetSpeed();
            switch (moveType)
            {
                case MoveType.FORWARD:
                    distanceTravelled += speed * Time.deltaTime;
                    break;
                case MoveType.BACKWARD:
                    distanceTravelled -= speed * Time.deltaTime;
                    break;
            }
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        }

        public void SetDistanceTravelled(float distanceTravelled)
        {
            this.distanceTravelled = distanceTravelled;
        }
    }
}
