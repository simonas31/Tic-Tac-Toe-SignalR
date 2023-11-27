using TicTacToe.GameObjects;
using TicTacToe.Interfaces;


public class ObstaclesHandler: Handler
{
    private Handler successor {get; set;}

    public ObstaclesHandler()
    {

    }

    public override string handleRequest(string[] info)
    {
        if(info.Length != 0)
        {
            string textDecoration;
            if(bool.Parse(info[0]))
                textDecoration = "line-through";
            else
                textDecoration = "underline";
            return textDecoration;
        }
        else
        {
            return "";
        }
    }
}