namespace RootedPhylogeneticTreeCalculator
{
    class Tree : TreeNode
    {
        public bool Rooted { get; }

        public Tree(bool rooted, string label = "root") : base(label)
        {
            Rooted = rooted;
        }
    }
}
