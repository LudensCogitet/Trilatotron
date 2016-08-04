using UnityEngine;
using System.Collections;

public class NodeGroup : MonoBehaviour {

    public float speed;
    public float maxTravel;
    public float currentTravel = 0;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    public bool rotate;

    Vector3 horizontal;
    Vector3 vertical;

    // Use this for initialization
    void Start() {
        SetTravel();
    }

    // Update is called once per frame
    void Update() {
        if (speed > 0)
        {
            if (rotate)
            {
                if (left)
                    transform.Rotate(Vector3.forward, -speed * Time.deltaTime);
                else if (right)
                    transform.Rotate(Vector3.forward, speed * Time.deltaTime);
            }
            else
            {

                transform.position += horizontal * speed * Time.deltaTime;
                transform.position += vertical * speed * Time.deltaTime;

                currentTravel += speed * Time.deltaTime;
                if (currentTravel >= maxTravel)
                {
                    currentTravel = 0;
                    if (up)
                    {
                        up = false;
                        down = true;
                    }
                    else if (down)
                    {
                        up = true;
                        down = false;
                    }

                    if (left)
                    {
                        left = false;
                        right = true;
                    }
                    else if (right)
                    {
                        right = false;
                        left = true;
                    }

                    SetTravel();
                }
            }
        }
    }

    public void SetTravel()
    {
        Debug.Log("SetTravel");

        vertical = Vector3.zero;
        horizontal = Vector3.zero;

        if (down)
            vertical = Vector3.down;
        else if (up)
            vertical = Vector3.up;

        if (left)
            horizontal = Vector3.right;
        else if (right)
            horizontal = Vector3.left;
    }
}
