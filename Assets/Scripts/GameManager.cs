using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int turns = 1;

    public Player player1;
    public Player player2;

    public GameObject player1Camera;
    public GameObject player2Camera;

    public GameObject score;

    public enum GameState
    {
        Player1Turn,
        Player2Turn,
        GameOver
    }

    public GameState state = GameState.Player1Turn;

	// Use this for initialization
	void Start ()
    {
        player2Camera.SetActive(false);

	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (state)
        {
            case GameState.Player1Turn:
                break;
        }
	}

    public void SwitchPlayers()
    {
        if (state == GameState.Player1Turn)
        {
            state = GameState.Player2Turn;
            player2Camera.SetActive(true);
            player1Camera.SetActive(false);
            player2.state = Player.PlayerState.Moving;
        }
        else if (state == GameState.Player2Turn)
        {
            state = GameState.Player1Turn;
            player2Camera.SetActive(false);
            player1Camera.SetActive(true);
            player1.state = Player.PlayerState.Moving;
        }

        turns--;
    }
}
