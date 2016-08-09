using UnityEngine;
using System.Collections;

public class Beam : MonoBehaviour {

    public SpriteRenderer myRenderer;
    public BoxCollider2D myCollider;

    public GameObject[] contacts;
    public float upTime;

    void Awake() {
        myRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    void Start () {
        myRenderer.enabled = false;
    }
	
    public void Fire(Color newColor)
    {
        if (!myRenderer.enabled)
        {
            int oldLayer = gameObject.layer;
            gameObject.layer = Physics2D.IgnoreRaycastLayer;
            Collider2D beamOverlap = Physics2D.OverlapCircle(transform.position, 0.3f, LayerMask.GetMask("Beam"));
            gameObject.layer = oldLayer;

            if (beamOverlap)
            {
                if (beamOverlap.GetComponent<Beam>().myRenderer.enabled == true)
                    return;
            }

            myRenderer.enabled = true;
            contacts[0].SetActive(true);
            contacts[1].SetActive(true);
        }

        myRenderer.color = newColor;

        if (IsInvoking("Shutdown"))
            CancelInvoke("Shutdown");

        Invoke("Shutdown", upTime);
    }

    public void Shutdown()
    {
        myRenderer.enabled = false;
        contacts[0].SetActive(false);
        contacts[1].SetActive(false);
    }

}
