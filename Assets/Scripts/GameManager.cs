using UnityEngine;
using System.Collections;
using Valve.VR;

public class GameManager : MonoBehaviour {

    public enum GameState
    {
        Menu,
        Playing,
        GameOver
    }

    // Les objets
    public Ball ball;
    public BrickContainer brickContainer;
    public SteamVR_Controller controller;

    // Variables
    public int nbColumns = 7;
    public int nbRows = 5;
    public int nbDepths = 2;
    public float delta = 0.04f;

    private GameState _gameState;
    public GameState gameState
    {
        get { return _gameState; }
    }

	// Use this for initialization
	void Start () {
        _gameState = GameState.Playing;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeToGameOver()
    {
        _gameState = GameState.GameOver;

        // Reset the ball
        this.ball.Reset();
        this.brickContainer.Reset();
    }

    public void Rumble(ushort duration)
    {
        SteamVR_Controller.Input(1).TriggerHapticPulse(duration);
    }
}
