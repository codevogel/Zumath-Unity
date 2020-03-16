using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject node;
    public Transform parentTransform;

    // Update is called once per frame
    void Update()
    {
        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        if (Input.GetMouseButtonDown(0))
        {
            NumberNode newNode = Instantiate(node, transform.position, Quaternion.identity, parentTransform).GetComponent<NumberNode>();
            Vector3 heading = mousePos - transform.position;
            float distance = heading.magnitude;
            newNode.nodeController.SetDirection(heading / distance);
        }
    }
}

