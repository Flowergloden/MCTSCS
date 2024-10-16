using System;
using System.Collections.Generic;

namespace MonteCarloTreeSearch
{
# nullable enable
    public class MonteCarloTreeNode<TData> : IComparable<MonteCarloTreeNode<TData>>
    {
        private float _t;
        private float _n;
        private float _c;
        private bool _hasChanged = true;
        private float _s;
        private TData _data;
        private readonly MonteCarloTreeNode<TData>? _parent;

        public MonteCarloTreeNode(float t, float n, float c, int layer, TData data, MonteCarloTreeNode<TData>? parent)
        {
            _t = t;
            _n = n;
            _c = c;
            _data = data;
            _parent = parent;
            Layer = layer;
            Nodes = new List<MonteCarloTreeNode<TData>>();
        }

        public readonly List<MonteCarloTreeNode<TData>> Nodes;
        public readonly int Layer;

        public TData Data
        {
            get => _data;
            set
            {
                _data = value;
                _hasChanged = true;
            }
        }

        public float T
        {
            get => _t;
            set
            {
                var delta = value - _t;
                if (_parent != null) _parent.T += delta;
                _t += delta;
                _hasChanged = true;
            }
        }

        public float N
        {
            get => _n;
            set
            {
                var delta = value - _n;
                if (_parent != null) _parent.N += delta;
                _n += delta;
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
                    _s = Math.UCT(_t, _n, _parent?.N ?? 1, _c);
                    _hasChanged = false;
                }

                return _s;
            }
        }

        public int CompareTo(MonteCarloTreeNode<TData>? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;
            return S.CompareTo(other.S);
        }
    }
}