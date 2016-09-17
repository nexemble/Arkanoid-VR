using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrickContainer : MonoBehaviour {

    public GameManager gameManager;
    public Brick brick;

    // List bricks
    List<Brick> listBricks;

	// Use this for initialization
	void Start () {
        listBricks = new List<Brick>();

        Reset();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Reset()
    {

        // Destroy the bricks
        foreach(Brick currentBrick in listBricks)
        {
            if (currentBrick != null)
            {
                Destroy(currentBrick.gameObject);
                Destroy(currentBrick);
            }
        }
        listBricks.Clear();

        // Creates the brick wall
        float delta = gameManager.delta;

        // Gets the size of the bricks
        float width = 1.0f / (float)gameManager.nbColumns - delta;
        float height = 1.0f / (float)gameManager.nbRows - delta;
        float depth = 1.0f / (float)gameManager.nbDepths - delta;


        for (int x = 0; x < gameManager.nbColumns; x++)
        {
            for (int y = 0; y< gameManager.nbRows; y++)
            {
                for (int z=0; z < gameManager.nbDepths; z++)
                {
                    Brick newBrick = (Brick)GameObject.Instantiate(brick);
                    newBrick.brickContainer = this;
                    newBrick.transform.parent = this.transform;

                    newBrick.transform.localPosition = new Vector3(x * (width + delta) - 0.5f, y * (height + delta) - 0.5f, z * (depth + delta) - 0.5f);
                    newBrick.transform.localScale = new Vector3(width, height, depth);

                    listBricks.Add(newBrick);
                }
            }
        }
    }

    public void RemoveBrick()
    {

    }
}
