using System.Collections.Generic;
using System.Linq;

namespace RootedPhylogeneticTreeCalculator
{
    static class SplitCalculator
    {
        public static Split GetSplitForEdge(TreeNode node1, TreeNode node2, Tree tree)
        {
            if (node1.IsChildOf(node2))
                return GetSplitForEdgeTo(node1, tree);
            else
                return GetSplitForEdgeTo(node2, tree);
        }

        // wyznacza rozbicie dla krawędzi prowadzącej do węzła node z drzewa tree
        public static Split GetSplitForEdgeTo(TreeNode node, Tree tree)
        {
            HashSet<TreeNode> allLeaves = tree.Cluster.Elements;
            Cluster set1 = node.Cluster;
            var otherLeaves = allLeaves.Where(l => !set1.Contains(l.Label));
            Cluster set2 = new Cluster(new HashSet<TreeNode>(otherLeaves));
            return new Split(set1, set2);
        }
    }
}
