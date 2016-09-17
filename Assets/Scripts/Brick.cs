using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public BrickContainer brickContainer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

    void OnTriggerEnter(Collider other)
    {

        // On la comptabilise pour le score
        // ...
        brickContainer.RemoveBrick();

        // La brique disparait
        Destroy(this.gameObject);


    }
}
