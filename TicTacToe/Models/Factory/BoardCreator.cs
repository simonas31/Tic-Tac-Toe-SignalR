using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

namespace TicTacToe.Models;
public class BoardCreator : ICreator
{
    /// <summary>
    /// create specific board
    /// </summary>
    /// <param name="type">dimensions for the board</param>
    /// <returns></returns>
    public Board FactoryMethod(int type)
    {
        if(type == 3)
        {
            return new Board3();
        }
        else if (type == 4)
        {
            return new Board4();
        }
        else if(type == 5)
        {
            return new Board5();
        }
        else if (type == 6)
        {
            return new Board6();
        }
        else
        {
            return null; // wanted type is not implemented
        }
    }
}