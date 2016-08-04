using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        //GetComponent<SpriteRenderer>().color = Color.green;
    }
}
