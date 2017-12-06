using System.Collections.Generic;
using System.Linq;

namespace RootedPhylogeneticTreeCalculator
{
    public class Cluster
    {
        public HashSet<TreeNode> Elements { get; }

        public Cluster(HashSet<TreeNode> elements)
        {
            Elements = elements;
        }

        public override string ToString()
        {
            return "{" + string.Join(",", Elements.Select(e => e.Label)) + "}";
        }
    }
}
