using System.Collections.Generic;

namespace MonteCarloTreeSearch
{
    public class MonteCarloTreeNode<TData> : IComparer<MonteCarloTreeNode<TData>>
    {
        private float _t;
        private float _n;
        private float _c;
        private bool _hasChanged = true;
        private float _s;

        public MonteCarloTreeNode(float t, float n, float c)
        {
            _t = t;
            _n = n;
            _c = c;
        }

        public float T
        {
            get => _t;
            set
            {
                _t = value;
                _hasChanged = true;
            }
        }

        public float N
        {
            get => _n;
            set
            {
                _n = value;
                _hasChanged = true;
            }
        }

        public float C
        {
            get => _c;
            set
            {
                _c = value;
                _hasChanged = true;
            }
        }

        public float S
        {
            get
            {
                if (_hasChanged)
                {
                    _s = Math.UCT(_t, _n, _c);
                    _hasChanged = false;
                }

                return _s;
            }
        }

        public int Compare(MonteCarloTreeNode<TData>? x, MonteCarloTreeNode<TData>? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (y is null) return 1;
            if (x is null) return -1;
            return x._s.CompareTo(y._s);
        }
    }
}