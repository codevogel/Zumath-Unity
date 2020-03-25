using UnityEngine;

public static class GameStateManager
{
    private static GameState currentGameState;

    public static void Start()
    {
        currentGameState = GameState.PLAYING;
    }

    public static void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !IsPaused()){
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.U) && IsPaused())
        {
            Unpause();
        }
    }

    public static void Pause()
    {
            currentGameState = GameState.PAUSED;
    }

    public static void Unpause()
    {
        currentGameState = GameState.PLAYING;
    }

    public static GameState GetGameState()
    {
        return currentGameState;
    }

    public static bool IsPaused()
    {
        return currentGameState == GameState.PAUSED;
    }

 
}