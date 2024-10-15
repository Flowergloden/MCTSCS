using System.Collections.Generic;
using System.Linq;

namespace MonteCarloTreeSearch
{
    public class MonteCarloTree<TData, TGame> where TGame : IGame<TData>
    {
        private readonly MonteCarloTreeNode<TData> _root;
        private readonly float _c;
        private TGame _game;
        private readonly int _maxDepth;
        private readonly int _gamePerMove;
        private readonly int _maxIteration;
        private readonly SortedSet<MonteCarloTreeNode<TData>> _allNodes;

        public MonteCarloTree(float c, TGame game, int maxDepth, int gamePerMove, int maxIteration)
        {
            _c = c;
            _game = game;
            _maxDepth = maxDepth;
            _gamePerMove = gamePerMove;
            _maxIteration = maxIteration;
            _root = new MonteCarloTreeNode<TData>(0, 0, _c, 0, game.Data, null);
            _allNodes = new SortedSet<MonteCarloTreeNode<TData>> { _root };
        }

        public TData Run()
        {
            for (int time = 0; time < _maxIteration; time++)
            {
                for (int i = 0; i < _allNodes.Count; i++)
                {
                    var node = _allNodes.ElementAt(i);
                    if (node.Layer >= _maxDepth)
                    {
                        continue;
                    }

                    foreach (var move in _game.GetPossibleMoves(node.Data))
                    {
                        var newNode =
                            new MonteCarloTreeNode<TData>(0, 0, _c, node.Layer + 1, move, _allNodes.ElementAt(i));

                        node.Nodes.Add(newNode);
                        _allNodes.Add(newNode);

                        ++newNode.N;

                        var winTime = 0;
                        for (int j = 0; j < _gamePerMove; j++)
                        {
                            if (_game.StartAGame(move))
                            {
                                ++winTime;
                            }
                        }

                        newNode.T = winTime;
                    }

                    break;
                }
            }

            return _root.Nodes.First().Data;
        }
    }
}