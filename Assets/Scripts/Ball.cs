using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    Rigidbody rigid ;
    bool isStillInObject;

    // Use this for initialization
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        rigid.AddForce(new Vector3(0.5f, 0.3f ,-0.8f)*2, ForceMode.Impulse);

        this.isStillInObject = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TOUCH BALL !!");
        if (this.isStillInObject == false)
        {
            rigid.velocity = Vector3.Reflect(rigid.velocity, other.transform.up);
            this.isStillInObject = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        this.isStillInObject = false;
    }
}
   
