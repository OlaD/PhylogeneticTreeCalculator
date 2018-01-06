namespace RootedPhylogeneticTreeCalculator
{
    class Tree : TreeNode
    {
        public bool Rooted { get; }

        public Tree(bool rooted, string label = "") : base(label)
        {
            Rooted = rooted;
        }
    }
}
