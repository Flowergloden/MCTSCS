namespace MonteCarloTreeSearch
{
    public class MonteCarloTreeNode
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
    }
}