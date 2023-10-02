namespace TicTacToe.Models;


public class BoardCreator{

    public static Board factoryMethod(int type)
    {
        if(type == 3)
        {
            return new Board3();
        }
        else if (type == 4)
        {
            return new Board4();
        }
        else
        {
            return null;
        }
    }
}