using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public bool pieceActive = false;
    public GameObject[] trilats;

    public float minTrilatSpeed;
    public float maxTrilatSpeed;


	// Use this for initialization
	void Start () {
        StartMove();
	}
	
	// Update is called once per frame
	void Update () {
        if (pieceActive == false)
            StartMove();
	}
    
    void StartMove()
    {
        pieceActive = true;
        GameObject rand = trilats[Random.Range(0, 15)];
        GameObject newTrilat = Instantiate(rand, rand.transform.position, rand.transform.rotation) as GameObject;
        Debug.Log(newTrilat);
        newTrilat.GetComponent<SpriteRenderer>().enabled = true;
        newTrilat.GetComponent<Trilatotron>().StartMoving(Random.Range(minTrilatSpeed, maxTrilatSpeed));
    }
}
