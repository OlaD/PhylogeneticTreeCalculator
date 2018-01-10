namespace RootedPhylogeneticTreeCalculator
{
    class Split
    {
        public Cluster Set1 { get; }
        public Cluster Set2 { get; }

        public Split(Cluster set1, Cluster set2)
        {
            Set1 = set1;
            Set2 = set2;
        }

        public override string ToString()
        {
            return "{" + Set1.ToString() + "|" + Set2.ToString() + "}";
        }
    }
}
