using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour
{
    public bool isFlipping = false;
    public float flipTime;
    public float flipTimer;

    public float torque;

    public float xForce;
    public float yForce;
    public float zForce;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isFlipping)
        {
            Flip();
        }
	}

    public void Flip()
    {
        rb.AddForce(new Vector3(xForce, yForce, zForce));

        rb.AddTorque(transform.right * torque);

        flipTimer += Time.deltaTime;

        if (flipTimer > flipTime)
        {
            isFlipping = !isFlipping;
            flipTimer = 0.0f;
        }
    } 
}
