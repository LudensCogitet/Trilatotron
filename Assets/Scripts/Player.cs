using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public string myVertical;
    public string myHorizontal;
    public string myAttach;
    public string myFire;

    public float mySpeed;
    public float myNodeDetectRadius = 1f;

    public Color myColor;

    public Transform raycastOrigin;

    public bool attached = false;

    // Use this for initialization
	void Awake () {
        myColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!attached)
        {
            if (Input.GetButtonDown(myAttach))
            {
                Collider2D col = Physics2D.OverlapCircle(transform.position, myNodeDetectRadius, LayerMask.GetMask("Node"));

                if (col != null)
                {
                    attached = true;
                    transform.position = col.gameObject.transform.position;
                    gameObject.transform.parent = col.gameObject.transform.parent;

                    //transform.Rotate(new Vector3(0f, 0f, Node.nodeAngles.ReturnNearestAngle(transform.eulerAngles.z)));
                }
            }
            else
            {
                Vector3 dir = new Vector3(Input.GetAxis(myHorizontal) * mySpeed, Input.GetAxis(myVertical) * mySpeed, 0f);

                transform.position += dir * Time.deltaTime;
                if (dir != Vector3.zero)
                    transform.up = dir;
            }
           
        }
        else if (attached)
        {
            if (Input.GetButtonDown(myAttach))
            {
                attached = false;
                transform.parent = null;
            }
            else if (Input.GetButtonDown(myFire))
            {
               RaycastHit2D nodeHit = Physics2D.Raycast(raycastOrigin.position, transform.up, Mathf.Infinity, LayerMask.GetMask("Node"));
               Collider2D beamhit = Physics2D.OverlapCircle(raycastOrigin.position,0.2f, LayerMask.GetMask("Beam"));

                if (nodeHit.collider != null)
                {
                    transform.position = nodeHit.collider.gameObject.transform.position;

                }
                if(beamhit != null)
                {
                    beamhit.gameObject.GetComponent<Beam>().Fire(myColor);
                }
            }
            else
            {
                Vector3 dir = new Vector3(Input.GetAxis(myHorizontal), Input.GetAxis(myVertical), 0f);
              
                if (dir != Vector3.zero)
                {
                  
                  transform.up = transform.parent.TransformDirection(dir);
                }       
            }
        }
    }
}
