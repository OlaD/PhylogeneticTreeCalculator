using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RootedPhylogeneticTreeCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

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
        }
    }
}
