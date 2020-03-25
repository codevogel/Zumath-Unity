using UnityEngine;
using PathCreation;
using Assets.Scripts;

// Moves along a path at constant speed.
// Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
public class PathFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    private NumberNode attachedNode;
    public EndOfPathInstruction endOfPathInstruction;
    public bool following;
    public bool forwards;
    public float distanceTravelled;
    private static int nextCheckpoint = 1;
    private static int amountOfCheckpoints = 3;

    void Awake()
    {
        pathCreator = GameObject.FindGameObjectWithTag("Gutter").GetComponent<PathCreator>();
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
        Check();
    }

    public void SetDistanceTravelled(float distanceTravelled)
    {
        this.distanceTravelled = distanceTravelled;
    }

    public void AddDistanceTravelled(float add)
    {
        distanceTravelled += add;
    }


    private void Check()
    {
        CheckCheckpoint();
        CheckEnd();

    }

    private void CheckEnd()
    {
        if (distanceTravelled >= pathCreator.path.length)
        {
            attachedNode.Kill();
        }
    }

    private void CheckCheckpoint()
    {
        if (distanceTravelled >= pathCreator.path.length / (amountOfCheckpoints + 1) * nextCheckpoint && nextCheckpoint!= (amountOfCheckpoints + 1))
        {
            GameStateManager.Pause();
            print(nextCheckpoint++);
        }
    }
}