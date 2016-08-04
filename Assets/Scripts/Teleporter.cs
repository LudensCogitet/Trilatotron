using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    public Transform target;
    public bool vertical = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!vertical)
        {
            float newX = target.position.x - col.bounds.extents.x;
            col.gameObject.transform.position = new Vector3(newX, col.gameObject.transform.position.y, col.gameObject.transform.position.z);

        }
        else
        {
            col.gameObject.transform.position = new Vector3(col.gameObject.transform.position.x, target.position.y, col.gameObject.transform.position.z);
        }
    }
}