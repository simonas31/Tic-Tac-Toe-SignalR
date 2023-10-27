using TicTacToe.GameObjects;

public interface ICreator
{
    public Board FactoryMethod(int type);
}