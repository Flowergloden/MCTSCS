namespace MonteCarloTreeSearch
{
    public interface IGame<T>
    {
        public bool StartAGame(T data);
        public T Data { get; }

        public T[] GetPossibleMoves(T data);

        public bool IsEnd(T data);
    }
}