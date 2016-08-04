using UnityEngine;
using System.Collections;

public class Trilatotron : MonoBehaviour {

    public GameController gameController;

    public float speed;
    public bool move = false;

    public float startingZ;

    public int hits = 0;

    void Awake()
    {
        startingZ = transform.position.z;
    }

	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>();

        if (move)
        {
            GetComponent<Rigidbody>().AddForce(-Vector3.forward * speed, ForceMode.VelocityChange);
        }
    }

    void LateUpdate()
    {
        hits = 0;
    }

    public void StartMoving(float speed)
    {
        move = true;
        GetComponent<Rigidbody>().AddForce(-Vector3.forward * speed, ForceMode.VelocityChange);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject);

        if (col.gameObject.GetComponent<Contact>())
        {
            hits++;
            if (hits == 3)
            {
                gameController.pieceActive = false;
                Destroy(gameObject);
            }
            }
        else if(col.gameObject.CompareTag("Respawn Field"))
        {
            Debug.Log("hello");
            transform.position = new Vector3(transform.position.x, transform.position.y, startingZ);
        }
    }
}
