using Assets.Scripts;
using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBallSpawner : MonoBehaviour
{
    private int index = 0;
    public GameObject numberBall;
    public Transform spawnUnderParent;
    public PathCreator pathCreator;

    private float ballRadius;

    // Start is called before the first frame update
    void Start()
    {
        ballRadius = numberBall.GetComponent<NumberNode>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 150 == 0)
        {
            GameObject newBall = Instantiate(numberBall, pathCreator.path.GetPoint(0), Quaternion.identity, spawnUnderParent);
            NodeManager.InsertNode(index++, newBall.GetComponent<NumberNode>());
        }
    }
}
