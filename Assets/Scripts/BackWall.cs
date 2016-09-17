using UnityEngine;
using System.Collections;

public class BackWall : MonoBehaviour {

    public GameManager gameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TOUCH BACK WALL !!");
        // You lose...
        gameManager.ChangeToGameOver();
    }

}
