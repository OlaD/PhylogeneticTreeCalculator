using System.Collections.Generic;
using System.Linq;
using Microsoft.Msagl.Drawing;

namespace RootedPhylogeneticTreeCalculator
{
    class ConsensusTreeBuilder
    {
        // Dla zadanego zbioru drzew tworzy x procentowe drzewo konsensusu  
        public Graph CreateConsensusTree(List<TreeNode> trees, int x)
        {
            List<Cluster> selectedClusters = SelectClusters(trees, x);
            return BuildTreeFromClusters(selectedClusters);
        }

        // Wybór klastrów występujących w ponad x% drzew
        private static List<Cluster> SelectClusters(List<TreeNode> trees, int x)
        {
            HashSet<Cluster> all = new HashSet<Cluster>();
            List<List<Cluster>> clustersFromTrees = new List<List<Cluster>>();

            // pobranie klastrów z wszystkich drzew
            foreach (var t in trees)
            {
                List<Cluster> clusters = t.GetAllClustersFromSubtree();
                all.UnionWith(clusters);
                clustersFromTrees.Add(clusters);
            }

            // zliczenie wystąpień klastrów w poszczególnych drzewach
            Dictionary<Cluster, int> clustersOccurences = new Dictionary<Cluster, int>();
            foreach (var cluster in all)
            {
                clustersOccurences[cluster] = 0;
                foreach (var clustersFromTree in clustersFromTrees)
                {
                    if (clustersFromTree.Contains(cluster))
                        clustersOccurences[cluster]++;
                }
            }

            // wybór klastrów, które występują w x% drzew
            float threshold = (x * trees.Count) / 100.0f;

            List<Cluster> selectedClusters = new List<Cluster>();
            foreach (var clusterOccurence in clustersOccurences)
            {
                if (clusterOccurence.Value > threshold)
                    selectedClusters.Add(clusterOccurence.Key);
            }
            return selectedClusters;
        }

        // Budowa drzewa z wybranych klastrów
        private static Graph BuildTreeFromClusters(List<Cluster> selectedClusters)
        {
            Graph nGraph = new Graph();

            foreach (var cluster in selectedClusters)
            {
                // Potencjalne dzieci to klastry, które zawierają się w podanym (i nie są nim samym)
                List<Cluster> potentialChildren = selectedClusters.Where(s => s != cluster && s.IsSubsetOf(cluster)).ToList();

                // Usuwanie krawędzi przechodnich
                // Czyli w tym przypadku usunięcie tych dzieci, które już zawierają się w innych dzieciach
                List<Cluster> toRemove = new List<Cluster>();
                foreach (var child in potentialChildren)
                {
                    foreach (var otherChild in potentialChildren)
                    {
                        if (child != otherChild)
                            if (child.IsSubsetOf(otherChild))
                                toRemove.Add(child);
                    }
                }
                potentialChildren.RemoveAll(i => toRemove.Contains(i));

                // Tworzenie krawędzi z klastra do tych dzieci, które pozostały
                foreach (var child in potentialChildren)
                {
                    nGraph.AddEdge(cluster.ToString(), child.ToString());
                }
            }

            return nGraph;
        }
    }
}
