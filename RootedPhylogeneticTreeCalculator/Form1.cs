using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RootedPhylogeneticTreeCalculator
{
    public partial class Form1 : Form
    {
        GViewer viewer;

        List<TreeNode> trees = new List<TreeNode>();
        int emptyNodeCounter = 0;

        public Form1()
        {
            InitializeComponent();
            viewer = new GViewer();

            //// przykładowe drzewo
            //TreeNode root = new TreeNode();
            //TreeNode nodeABC = root.AddChild();
            //nodeABC.AddChild("a");
            //nodeABC.AddChild("b");
            //nodeABC.AddChild("c");
            //TreeNode nodeDEF = root.AddChild();
            //nodeDEF.AddChild("d");
            //TreeNode nodeEF = nodeDEF.AddChild();
            //nodeEF.AddChild("e");
            //nodeEF.AddChild("f");

            //label1.Text = nodeABC.Cluster.ToString();
            //label2.Text = nodeDEF.Cluster.ToString();
            //label3.Text = nodeEF.Cluster.ToString();

            //// przykładowy graf
            //Graph graph = new Graph();
            //graph.AddEdge("a", "b");
            //graph.AddEdge("a", "c");
            //graph.AddEdge("c", "d");

            //// przykładowa stylizacja węzłów i krawędzi
            //Node e = new Node("e");
            //e.Attr.Shape = Shape.Plaintext;
            //e.Label.FontSize = e.Label.FontSize - 5;
            //e.Label.FontColor = Color.BlueViolet;
            //graph.AddNode(e);

            //Edge edge = graph.AddEdge("c", "e");
            //edge.Attr.Color = Color.Pink;
            //edge.Attr.ArrowheadAtTarget = ArrowStyle.None;

            //ShowGraph(graph);
        }

        public void ShowGraph(Graph graph)
        {
            viewer.Graph = graph;
            SuspendLayout();
            viewer.Dock = DockStyle.Fill;
            graphPanel.Controls.Add(viewer);
            ResumeLayout();
        }

        private void loadFileButton_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.Filter = "xml|*.xml";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    PhyloXMLParser parser = new PhyloXMLParser();
                    TreeNode tree = parser.LoadTree(file);
                    
                    // Wyswietlanie wczytanego pliku
                    Graph graph = new Graph();
                    tree.Label = "root";
                    treeToGraph(tree, tree.Label, graph);
                    ShowGraph(graph);

                    // Sprawdzenie poprawnosci drzewa. Wyswietlamy jedynie informacje, ale i tak wyswietlamy.
                    checkTree(tree);

                    // Dodanie drzewa do listy drzew.
                    trees.Add(tree);

                    // Sprawdzenie odleglosci RF miedzy drzewami.
                    checkDistance();
                }
            }
        }

        private void checkDistance()
        {
            if (trees.Count > 1)
            {
                // Pobranie dwoch ostatnich drzew
                List<String> clusterNames1 = new List<String>();
                List<String> clusterNames2 = new List<String>();

                // Tworzy liste klastrow poszczegolnych drzew
                addClusters(trees[trees.Count - 2], clusterNames1);
                addClusters(trees[trees.Count - 1], clusterNames2);

                int uniqueClustersCount = 0;

                // Sprawdzenie unikalnych klastrow
                foreach(String clusterName in clusterNames2)
                {
                    if (!clusterNames1.Contains(clusterName))
                    {
                        uniqueClustersCount++;
                    }
                }

                foreach (String clusterName in clusterNames1)
                {
                    if (!clusterNames2.Contains(clusterName))
                    {
                        uniqueClustersCount++;
                    }
                }

                float rfDistance = (float)uniqueClustersCount / 2.0f;
                rfDistanceLabel.Text = rfDistance.ToString();
            }
        }

        // Przeszukuje rekurencyjnie nody, dodaje kazdy klaster do listy
        private void addClusters(TreeNode currentNode, List<String> clusterNames)
        {
            if (!currentNode.IsLeaf)
            {
                foreach (TreeNode child in currentNode.Children)
                {
                    addClusters(child, clusterNames);
                }
            }
            clusterNames.Add(currentNode.Cluster.ToString());
        }

        // Dodaje krawedzie na podstawie rekurencyjnego przeszukania drzewa
        private void treeToGraph(TreeNode currentNode, String ancestorLabel, Graph graph)
        {
            // Dodaje spacje do pustych nodow, przy dodaniu do krawedzi nie moze byc pustych
            if (currentNode.Label == "")
            {
                for(int i=0; i<= emptyNodeCounter;i++)
                {
                    // Brzydki workaround na puste <clad> bez <name>
                    currentNode.Label += " ";
                }
                //currentNode.Label = "node" + emptyNodeCounter.ToString();
                //currentNode.Label = currentNode.Cluster.ToString();
                emptyNodeCounter++;
            }

            // Rekurencyjne przeszukiwanie
            if (!currentNode.IsLeaf)
            {
                foreach (TreeNode child in currentNode.Children)
                {
                    String ancestorString = currentNode.Label;
                    treeToGraph(child, ancestorString, graph);
                }
                if (currentNode.Label == "root")
                {
                    return;
                }
            }
            graph.AddEdge(ancestorLabel, currentNode.Label);
        }

        // Sprawdza zgodnosc drzewa (czy nie powtarzaja sie wierzcholki)
        private void checkTree(TreeNode tree)
        {
            List<String> nodesLabelsList = new List<String>();
            //leafsList.Add("owodniowce (Amniota)");
            if (allNodesLabelsToList(nodesLabelsList, tree))
            {
                treeCheckLabel.Text = "Zgodne";
            }
            else
            {
                treeCheckLabel.Text = "Niezgodne";
            }
        }

        // Funkcja zwraca false jezeli ktorys label sie powtorzyl
        private bool allNodesLabelsToList(List<string> leafsList, TreeNode currentNode)
        {
            bool status = true;

            if (!currentNode.IsLeaf)
            {
                foreach (TreeNode child in currentNode.Children)
                {
                    if (!allNodesLabelsToList(leafsList, child))
                    {
                        // Jezeli ktores z childow zwrocilo false oznacza niezgodnosc i dalej nie sprawdzamy
                        status = false;
                    }
                }
            }

            if(leafsList.Contains(currentNode.Label))
            {
                // Znaleziono taki sam label, zwracamy false
                status = false;
            }

            // Dodanie do listy w celu pozniejszych porownan
            leafsList.Add(currentNode.Label);

            return status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuildConsensusTree();
        }

        private void BuildConsensusTree()
        {
            int x = Int32.Parse(textBox1.Text);
            ConsensusTreeBuilder consensusTreeBuilder = new ConsensusTreeBuilder();
            Graph graph = consensusTreeBuilder.CreateConsensusTree(trees, x);
            ShowGraph(graph);
        }
    }
}
