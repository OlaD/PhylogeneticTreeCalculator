using System.Linq;
using System.Xml.Linq;

namespace RootedPhylogeneticTreeCalculator
{
    class PhyloXMLParser
    {
        // Wczytuje drzewo z pliku w formacie phyloXML
        public TreeNode LoadTree(string file)
        {
            XDocument doc = XDocument.Load(file);
            var mainClade = doc.Root.Elements().First().Elements().Where(c => c.Name.LocalName == "clade").First();     // phyloxml/phylogeny/clade

            TreeNode root = new TreeNode();

            LoadClade(mainClade, root);

            return root;
        }

        // Wczytuje rekurencyjnie węzeł oraz jego dzieci i dodaje do drzewa
        private void LoadClade(XElement clade, TreeNode node)
        {
            var children = clade.Elements().Where(c => c.Name.LocalName == "clade");
            foreach(var child in children)
            {
                TreeNode childNode = node.AddChild();
                LoadName(child, childNode);
                LoadClade(child, childNode);
            }
        }

        // Wczytuje nazwę węzła, jeśli jest zapisana w pliku
        private void LoadName(XElement clade, TreeNode node)
        {
            var name = clade.Elements().Where(c => c.Name.LocalName == "name");
            if (name.Count() != 0)
            {
                node.Label = name.First().Value;
            }
        }
    }
}
