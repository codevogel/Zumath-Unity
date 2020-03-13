using UnityEngine;

namespace PathCreation
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public bool following;
        private bool goingForwards = true;
        float distanceTravelled;

        void Start() {
            pathCreator = GameObject.FindGameObjectWithTag("PathCreator").GetComponent<PathCreator>();
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null && following)
            {
                if (goingForwards)
                {
                    distanceTravelled += speed * Time.deltaTime;
                }
                else
                {
                    distanceTravelled -= speed * Time.deltaTime;
                }
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        public void Reverse()
        {
            goingForwards = !goingForwards;
        }

        public void StartFollowing()
        {
            following = true;
        }

        public void StopFollowing()
        {
            following = false;
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}