using UnityEngine;
using PathCreation;

// Moves along a path at constant speed.
// Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
public class PathFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    private NumberNode attachedNode;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 2f;
    public bool following;
    public bool forwards;
    public float distanceTravelled;

    void Awake()
    {
        pathCreator = GameObject.FindGameObjectWithTag("Gutter").GetComponent<PathCreator>();
        attachedNode = GetComponent<NumberNode>();
    }

    public void Follow()
    {
        switch (attachedNode.state)
        {
            case NodeState.FORWARD:
                distanceTravelled += speed * Time.deltaTime;
                break;
            case NodeState.BACKWARD:
                distanceTravelled -= speed * Time.deltaTime;
                break;
            case NodeState.STANDSTILL:
                return;
        }
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
    }

    public void SetDistanceTravelled(float distanceTravelled)
    {
        this.distanceTravelled = distanceTravelled;
    }

    public void AddDistanceTravelled(float add)
    {
        distanceTravelled += add;
    }
}