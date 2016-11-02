using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    //public int bottles;
    public float movementSpeed;
    public float torque;
    public float flipTime;
    public float flipTimer;
    public GameObject waterBottle;
    public Vector3 waterBottleStartPosition;
    public float force;
    public float maxForce;

    public enum PlayerState
    {
        Moving,
        Rotating,
        SelectingForce,
        Flipping,
        Idle
    }
    public PlayerState state = PlayerState.Idle;
    

    // Use this for initialization
    void Start ()
    {
        waterBottleStartPosition = waterBottle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch(state)
        {
            case PlayerState.Moving:
                Moving();
                break;
            case PlayerState.Rotating:
                Rotating();
                break;
            case PlayerState.SelectingForce:
                SelectingForce();
                break;
            case PlayerState.Flipping:
                Flipping();
                break;
            case PlayerState.Idle:
                Idle();
                break;
        }
	}

    private void Idle()
    {
        //throw new NotImplementedException();
    }

    private void Flipping()
    {
        //flipTimer += Time.deltaTime;
        //if (flipTimer > flipTime)
        //{
        //    flipTimer = 0;
        //    state = PlayerState.Idle;
        //}

        Debug.Log("Flipping");
        waterBottle.GetComponent<Rigidbody>().AddForce((transform.forward *force) + new Vector3(0,force,0));

        waterBottle.GetComponent<Rigidbody>().AddTorque(transform.right * torque);


    }

    private void SelectingForce()
    {
        force += Time.deltaTime * 25;

        if (force >= maxForce)
        {
            force = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = PlayerState.Flipping;
        }

    }

    private void Rotating()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate((-transform.up) * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate((transform.up) * movementSpeed * Time.deltaTime); ;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = PlayerState.SelectingForce;
        }
}

    private void Moving()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += (-transform.right) * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = PlayerState.Rotating;
        }
    }
}
