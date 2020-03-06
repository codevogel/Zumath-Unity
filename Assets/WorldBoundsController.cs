using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBoundsController : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
