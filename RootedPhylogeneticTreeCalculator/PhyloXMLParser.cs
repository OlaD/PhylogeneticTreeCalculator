using System;
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
            var xmlTree = doc.Root.Elements().First(); // phyloxml/phylogeny
            bool rooted = Convert.ToBoolean(xmlTree.Attribute("rooted").Value);

            Tree tree = new Tree(rooted);
            if (rooted)
            {
                var mainClade = xmlTree.Elements().Where(c => c.Name.LocalName == "clade").First();
                LoadClade(mainClade, tree);
            }
            else
            {
                LoadClade(xmlTree, tree);
            }
            return tree;
        }

        // Wczytuje rekurencyjnie węzeł oraz jego dzieci i dodaje do drzewa
        private void LoadClade(XElement clade, TreeNode node)
        {
            var children = clade.Elements().Where(c => c.Name.LocalName == "clade");
            foreach (var child in children)
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