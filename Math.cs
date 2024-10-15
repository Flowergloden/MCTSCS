using System;

namespace MonteCarloTreeSearch
{
    public static class Math
    {
        public static float UCT(float t, float n, float N, float c)
        {
            // TODO: use quick natural log & sqrt
            if (n == 0)
            {
                return float.MaxValue;
            }

            return t + c * MathF.Sqrt(MathF.Log(N) / n);
        }
    }
}