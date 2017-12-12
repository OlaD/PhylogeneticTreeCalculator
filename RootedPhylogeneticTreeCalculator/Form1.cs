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
                    trees.Add(tree);
                }
            }
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
