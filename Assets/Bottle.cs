using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour
{
    public Player player;
    public GameObject bottlePrefab;

    public GameObject gameManagerObject;
    private GameManager gameManager;

    public bool hitTarget = false;
    void Start()
    {
        gameManagerObject = GameObject.Find("Game Manager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    void Update()
    {
        if (hitTarget)
        {
            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude < .01)
            {
                Instantiate(bottlePrefab, transform.position, Quaternion.identity);
                transform.position = player.transform.position;
                hitTarget = false;
                gameManager.SwitchPlayers();
            }
        }

        if (transform.position.y <= -10)
        {
            transform.position = player.transform.position;
            gameManager.SwitchPlayers();
            
        }
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.collider.CompareTag("target"))
        {
            hitTarget = true;
        }
    }
}
