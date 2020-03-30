using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject node;
    public Transform parentTransform;
    private NumberNode newNode;
    private float timeStamp = 0;
    private const float COOLDOWN = 1; // in seconds
    private bool fired = true;

    void Start()
    {
        newNode = new NumberNode();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameStateManager.IsPaused())
        {
            //rotation
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

            Shoot(mousePos);
        }
    }


    private void Shoot(Vector3 mousePos)
    { 
        if (fired)
        {
            Vector3 ballInCannon = transform.position;
            ballInCannon.y -= 1;
            newNode = Instantiate(node, ballInCannon, Quaternion.identity, parentTransform).GetComponent<NumberNode>();
            //newNode.SetValue(Random.Range(NumberList.BOUND_LOW, NumberList.BOUND_HIGH));
            newNode.SetValue(2);
            newNode.SetState(NodeState.STANDSTILL);
            
            fired = false;
        }
        
        if (Input.GetMouseButtonDown(0) && timeStamp < Time.time)
        {
            newNode = Instantiate(node, transform.position, Quaternion.identity, parentTransform).GetComponent<NumberNode>();
            newNode.SetValue(2);
            newNode.SetState(NodeState.PROJECTILE);

            Vector3 heading = mousePos - transform.position;
            float distance = heading.magnitude;
            newNode.nodeController.SetDirection(heading / distance);

            timeStamp = Time.time + COOLDOWN;
            //fired = true;
           
        }
    }
}

