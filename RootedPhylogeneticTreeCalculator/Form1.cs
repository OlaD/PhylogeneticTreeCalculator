using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System.Windows.Forms;

namespace RootedPhylogeneticTreeCalculator
{
    public partial class Form1 : Form
    {
        GViewer viewer;

        public Form1()
        {
            InitializeComponent();
            viewer = new GViewer();

            // przykładowe drzewo
            TreeNode root = new TreeNode();
            TreeNode nodeABC = root.AddChild();
            nodeABC.AddChild("a");
            nodeABC.AddChild("b");
            nodeABC.AddChild("c");
            TreeNode nodeDEF = root.AddChild();
            nodeDEF.AddChild("d");
            TreeNode nodeEF = nodeDEF.AddChild();
            nodeEF.AddChild("e");
            nodeEF.AddChild("f");

            label1.Text = nodeABC.Cluster.ToString();
            label2.Text = nodeDEF.Cluster.ToString();
            label3.Text = nodeEF.Cluster.ToString();

            // przykładowy graf
            Graph graph = new Graph();
            graph.AddEdge("a", "b");
            graph.AddEdge("a", "c");
            graph.AddEdge("c", "d");

            // przykładowa stylizacja węzłów i krawędzi
            Node e = new Node("e");
            e.Attr.Shape = Shape.Plaintext;
            e.Label.FontSize = e.Label.FontSize - 5;
            e.Label.FontColor = Color.BlueViolet;
            graph.AddNode(e);

            Edge edge = graph.AddEdge("c", "e");
            edge.Attr.Color = Color.Pink;
            edge.Attr.ArrowheadAtTarget = ArrowStyle.None;

            ShowGraph(graph);
        }

        public void ShowGraph(Graph graph)
        {
            viewer.Graph = graph;
            SuspendLayout();
            viewer.Dock = DockStyle.Fill;
            graphPanel.Controls.Add(viewer);
            ResumeLayout();
        }
    }
}
