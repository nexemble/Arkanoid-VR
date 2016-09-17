using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    Rigidbody rigid ;
    bool isStillInObject;
    Vector3 defaultPosition;

    public Racket racket;
    public Brick brick;

    // Use this for initialization
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        this.defaultPosition = this.transform.position;
        this.Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other == racket)
        {
            Debug.Log("TOUCH BALL !!");
            if (this.isStillInObject == false)
            {
                rigid.velocity = Vector3.Reflect(rigid.velocity, other.transform.up);
                this.isStillInObject = true;
            }
        } else
        {
            if (other == brick)
                Debug.Log("TOUCH2 BRICK !!");
            rigid.velocity = Vector3.Reflect(rigid.velocity, other.transform.up);
        }
    }

    void OnTriggerExit(Collider other)
    {
        this.isStillInObject = false;
    }

    public void Reset()
    {
        rigid.velocity = Vector3.zero;
        rigid.AddForce(new Vector3(0.5f, 0.3f, -0.8f) * 4, ForceMode.Impulse);
        this.transform.position = defaultPosition;
        this.isStillInObject = false;

    }
}
   
