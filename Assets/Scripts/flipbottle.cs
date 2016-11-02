using UnityEngine;
using System.Collections;

public class flipbottle : MonoBehaviour
{
    public float magnitudeNumber;
    //public AudioSource music;

    public bool hitTarget = false;
    public bool flipping;

    public float flipTimer;
    public float flipTime;

    public float rotationSpeed;

    public float torque;
    public float xForce;
    public float yForce;
    public float zForce;
    public float resetThreshold;

    public Vector3 startPosition;

    public Rigidbody rb;

	// Use this for initialization
	void Start () {

        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Vector3 V3Force = new Vector3( xForce, yForce, * transform.forward *

        if (hitTarget)
        {
            if (rb.velocity.magnitude <= magnitudeNumber)
            {
                transform.localRotation = Quaternion.identity;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            flipping = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if (flipping)
        {
            //rb.AddRelativeForce(Vector3.forward * zForce);
            rb.AddForce(new Vector3(xForce, yForce, zForce));
            //rb.AddForce(Vector3.forward);//+//);
            
            rb.AddTorque(transform.right * torque);// * turn)

            flipTimer += Time.deltaTime;

            if (flipTimer > flipTime)
            {
                flipping = !flipping;
                flipTimer = 0.0f;
            }
        }
        ResetBottle();
    }

    private void ResetBottle()
    {
        if (transform.position.y < resetThreshold || Input.GetKey(KeyCode.R))
        {
            
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = startPosition;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "target")
        {
            hitTarget = true;
        }
    }
}
