using TicTacToe.GameObjects;
using TicTacToe.Interfaces;


public class RowHandler: Handler
{
    private Handler successor {get; set;}

    public RowHandler()
    {
        successor = new ObstaclesHandler();
    }

    public override string handleRequest(string[] info)
    {
        if(info.Length != 0)
        {
            string fontSize;
            if(info[0] == "0")
                fontSize = "5px";
            else if(info[0] == "2")
                fontSize = "10px";
            else
                fontSize = "15px";
            return fontSize + ":" + successor.handleRequest(info.Skip(1).ToArray());
        }
        else
        {
            return "";
        }
    }
}