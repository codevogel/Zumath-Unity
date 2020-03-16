using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(NumberNode))]
public class NodeController : MonoBehaviour
{

    private Rigidbody2D rb;
    private NumberNode numberNode;

    private Vector3 direction;
    public float speed = 2f;

    void Awake()
    {
        speed = 2f;
        numberNode = GetComponent<NumberNode>();
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (numberNode.inGutter)
        {
            this.enabled = false;
            return;
        }
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
