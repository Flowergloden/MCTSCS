namespace MonteCarloTreeSearch
{
    public class MonteCarloTree<T, TGame> where TGame : IGame<T>
    {
        private MonteCarloTreeNode _root;
        private readonly float _c;
        private TGame _game;

        public MonteCarloTree(float c, TGame game)
        {
            _c = c;
            _game = game;
            _root = new MonteCarloTreeNode(0, 0, _c);
        }
    }
}