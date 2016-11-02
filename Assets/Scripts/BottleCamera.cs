using UnityEngine;
using System.Collections;

public class BottleCamera : MonoBehaviour
{

    public GameObject target;
    public Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);

        // transform.position = target.transform.position - (rotation * offset);
        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform);
    }
}
