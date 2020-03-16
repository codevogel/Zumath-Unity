using UnityEngine;
using PathCreation;

// Moves along a path at constant speed.
// Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
public class PathFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    public bool following;
    public bool forwards;
    public float distanceTravelled;

    void Awake()
    {
        pathCreator = GameObject.FindGameObjectWithTag("Gutter").GetComponent<PathCreator>();
    }

    public void Follow()
    {
        if (pathCreator != null && following)
        {
            if (forwards)
            {
                distanceTravelled += speed * Time.deltaTime;
            }
            else
            {
                distanceTravelled -= speed * Time.deltaTime;
            }
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        }
    }

    public void StartFollowing()
    {
        following = true;
    }

    public void StopFollowing()
    {
        following = false;
    }

    public void FollowForwards()
    {
        forwards = true;
    }

    public void FollowBackwards()
    {
        forwards = false;
    }

    public void SetDistanceTravelled(float distanceTravelled)
    {
        this.distanceTravelled = distanceTravelled;
    }
}