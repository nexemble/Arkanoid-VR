using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {

    public GameManager gameManager;
    bool isStillInObject;

    // Use this for initialization
    void Start () {
        isStillInObject = false;

    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        gameManager.Rumble(2000);

        /*if (other.gameObject.name.StartsWith(typeof(Ball) + ""))
        {
            Debug.Log("TOUCH RACKET !!");
            if (this.isStillInObject == false)
            {
                Rigidbody rigid = other.GetComponent<Rigidbody>();

                // On doit repousser la balle sur le pourtour de la raquette
                rigid.velocity = Vector3.Reflect(rigid.velocity, -this.transform.up);
                this.isStillInObject = true;

                // Attention : on veut toujours une vitesse de sortie minimum de ???

            }
        }*/

    }

    void OnTriggerExit(Collider other)
    {
        this.isStillInObject = false;
    }

}
