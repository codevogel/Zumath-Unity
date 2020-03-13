using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBallSpawner : MonoBehaviour
{
    private int index = 0;
    public Gutter gutter;
    public GameObject numberBall;
    public PathCreator pathCreator;

    // Start is called before the first frame update
    void Start()
    {
        print(pathCreator.path.GetPoint(0));
        print(pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1));

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 300 == 0)
        {
            GameObject newBall = Instantiate(numberBall, pathCreator.path.GetPoint(0), Quaternion.identity);
            gutter.InsertBall(index++, newBall.GetComponent<NumberBall>());
            newBall.GetComponent<PathFollower>().StartFollowing();
        }
    }
}
