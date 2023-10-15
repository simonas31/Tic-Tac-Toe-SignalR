namespace TicTacToe.Models
{
    public interface IBoardBuilder
    {
        IBoardBuilder SetDimensions(int dimensions);
        IBoardBuilder WithCustomConfigurations();
        Board Build();
    }
}
