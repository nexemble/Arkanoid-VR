using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    Rigidbody rigid ;

    // Use this for initialization
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        rigid.AddForce(new Vector3(0.5f, 0.3f ,-0.8f)*5, ForceMode.Impulse);
        Debug.Log("FORCE !!");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TOUCH BALL !!");
    }
}
   
