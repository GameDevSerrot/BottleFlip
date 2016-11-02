using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour
{
    public GameObject player1;
    public Player player1Script;

    public GameObject player2;
    public Player player2Script;

    public GameObject movingDisplay;
    public GameObject rotatingDisplay;
    public GameObject selectingForceDisplay;
    public Image force;
	// Use this for initialization
	void Start ()
    {
        player1 = GameObject.Find("Player 1");
        player1Script = player1.GetComponent<Player>();

        player2 = GameObject.Find("Player 2");
        player2Script = player2.GetComponent<Player>();

        movingDisplay.SetActive(false);
        rotatingDisplay.SetActive(false);
        selectingForceDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Script.state == Player.PlayerState.Moving || player2Script.state == Player.PlayerState.Moving)
        {
            movingDisplay.gameObject.SetActive(true);
            rotatingDisplay.SetActive(false);
            selectingForceDisplay.SetActive(false);
        }
        else if (player1Script.state == Player.PlayerState.Rotating || player2Script.state == Player.PlayerState.Rotating)
        {
            movingDisplay.gameObject.SetActive(false);
            rotatingDisplay.SetActive(true);
            selectingForceDisplay.SetActive(false);
        }
        else if (player1Script.state == Player.PlayerState.SelectingForce)
        {
            
            movingDisplay.gameObject.SetActive(false);
            rotatingDisplay.SetActive(false);
            selectingForceDisplay.SetActive(true);

            if (player1Script.state == Player.PlayerState.SelectingForce)
            {
                force.fillAmount = player1Script.force / player1Script.maxForce;
            }

        }
        else if(player2Script.state == Player.PlayerState.SelectingForce)
        {
            movingDisplay.gameObject.SetActive(false);
            rotatingDisplay.SetActive(false);
            selectingForceDisplay.SetActive(true);
            
            if (player2Script.state == Player.PlayerState.SelectingForce)
            {
                force.fillAmount = player2Script.force / player2Script.maxForce;
            }
        }
        else if (player1Script.state == Player.PlayerState.Flipping || player2Script.state == Player.PlayerState.Flipping)
        {
            movingDisplay.SetActive(false);
            rotatingDisplay.SetActive(false);
            selectingForceDisplay.SetActive(false);
        }
    }
}
