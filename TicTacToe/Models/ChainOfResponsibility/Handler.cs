using TicTacToe.GameObjects;
using TicTacToe.Interfaces;


public abstract class Handler
{
    private Handler successor {get; set;}

    public abstract string handleRequest(string[] info);
}
