using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    Rigidbody rigid;
    bool isStillInObject;
    Vector3 defaultPosition;

    public GameManager gameManager;

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
       if (other.gameObject.name.StartsWith(typeof(Racket) + ""))
        {
            Debug.Log("TOUCH RACKET !!");
            if (this.isStillInObject == false)
            {
                // On doit repousser la balle sur le pourtour de la raquette
                rigid.velocity = Vector3.Reflect(rigid.velocity, other.transform.up);
                this.isStillInObject = true;

                // Attention : on veut toujours une vitesse de sortie minimum de ???
                
            }
        }
        else if (other.gameObject.name.StartsWith(typeof(Brick)+"("))
        {


            Debug.Log("TOUCH BRICK !!");
            if (!this.isStillInObject)
            {
                Vector3 vecOut = new Vector3(0, 0, 1);
                RaycastHit hit;

                float x = other.transform.position.x;
                float y = other.transform.position.y;
                float z = other.transform.position.z;
                float w = other.transform.localScale.x;
                float h = other.transform.localScale.y;
                float d = other.transform.localScale.z;

                // On calcule la distance entre le centre de la balle et la brique sur les 3 axes
                // La plus grande nous donne quel est le vecteur sortant
                float xdis = this.transform.position.x - other.transform.position.x;
                // en fonction du signe, on sait si il est devant ou derrière
                float ydis = this.transform.position.y - other.transform.position.y;
                float zdis = this.transform.position.z - other.transform.position.z;

                float xNorm = Mathf.Abs(xdis) - w / 2.0f;
                float yNorm = Mathf.Abs(ydis) - h / 2.0f;
                float zNorm = Mathf.Abs(zdis) - d / 2.0f;
                // Le plus petit des 3 est le vainqueur
                if (xNorm < yNorm && xNorm < zNorm)
                    vecOut = new Vector3(1, 0, 0) * xdis / Mathf.Abs(xdis);
                if (yNorm < xNorm && yNorm < zNorm)
                    vecOut = new Vector3(0, 1, 0) * ydis / Mathf.Abs(ydis);
                if (zNorm < yNorm && zNorm < xNorm)
                    vecOut = new Vector3(0, 0, 1) * zdis / Mathf.Abs(zdis);


                // On cherche ou a tapé la brique pour savoir quel est son vecteur sortant
               /* if (Physics.Raycast(transform.position, rigid.velocity.normalized, out hit))
                {
                    Debug.Log("Point of contact: " + hit.point);

                    if (x + w / 2 == hit.point.x)
                        vecOut = new Vector3(1, 0, 0);
                    else if (x - w / 2 == hit.point.x)
                        vecOut = new Vector3(-1, 0, 0);
                    else if (y + h / 2 == hit.point.y)
                        vecOut = new Vector3(0, 1, 0);
                    else if (y - h / 2 == hit.point.y)
                        vecOut = new Vector3(0, -1, 0);
                    else if (z + d / 2 == hit.point.z)
                        vecOut = new Vector3(0, 0, 1);
                    else if (z - d / 2 == hit.point.z)
                        vecOut = new Vector3(0, 0, 1);


                }*/
                rigid.velocity = Vector3.Reflect(rigid.velocity, vecOut);
                this.isStillInObject = true;
            }

        }
        else
            rigid.velocity = Vector3.Reflect(rigid.velocity, other.transform.up);
        //gameManager.Rumble();

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

