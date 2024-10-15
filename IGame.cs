namespace MonteCarloTreeSearch
{
    public interface IGame<T>
    {
        public bool StartAGame(T data);

        public T[] GetPossibleMoves();
    }
}