
namespace States.Game
{
    // **** Important ****
    // Remember to update the GameStateDisplayer when adding a gamestate.
    // *******************
    public enum GameState
    {
        // Balls are all moving forward, player can shoot a new ball for insertion
        PREINSERTION,
        // Balls are all moving forward, except the ball that the player shot for insertion.
        SHOOTING,
        // Insertion has happened and balls are being dispersed to accomodate new ball.
        DISPERSING,
        // Balls are moving forward untill the gap (that has been created by removing combo-ed balls) has been filled.
        RESETTING,
        // TODO: Balls have stopped moving. Player must answer a question before being able to proceed.
        CHECKPOINT,
        // TODO: Game is in pause menu
        PAUSED,
        WON
    }
}
