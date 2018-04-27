namespace Graphs
{
    /// <summary>
    /// Quick union algorithm
    /// Trees can get too tall
    /// Find can be expensive
    /// </summary>
    class QuickUnionUF
    {
        private int[] array;

        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="N"></param>
        public QuickUnionUF(int N)
        {
            array = new int[N];
            for (int i = 0; i < N; i++)
            {
                array[i] = i;
            }
        }
        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int root(int num)
        {
            while (num != array[num])
            {
                num = array[num];
            }

            return num;
        }
        
        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool Connected(int p, int q)
        {
            return root(p) == root(q);            
        }

        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void Union(int p, int q)
        {
            int pid = root(p);
            int qid = root(q);            
            array[pid] = qid;
        }
    }
}
