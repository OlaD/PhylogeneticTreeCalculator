using System;
using System.Collections.Generic;
using System.Linq;

namespace RootedPhylogeneticTreeCalculator
{
    public class Cluster : IEquatable<Cluster>
    {
        public HashSet<TreeNode> Elements { get; }

        public List<string> ElementsNames
        {
            get { return Elements.Select(e => e.Label).ToList(); }
        }

        public Cluster(HashSet<TreeNode> elements)
        {
            Elements = elements;
        }

        public override string ToString()
        {
            return "{" + string.Join(",", Elements.Select(e => e.Label)) + "}";
        }

        public bool Contains(string nodeName)
        {
            foreach (var e in Elements)
            {
                if (e.Label == nodeName)
                    return true;
            }
            return false;
        }

        // czy klaster zawiera się w podanym klastrze
        public bool IsSubsetOf(Cluster other)
        {
            return ElementsNames.All(other.ElementsNames.Contains);
        }

        public bool IsDisjointFrom(Cluster other)
        {
            foreach (string el in ElementsNames)
            {
                if (other.ElementsNames.Contains(el))
                    return false;
            }
            return true;
        }

        public bool Equals(Cluster other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ElementsNames.SequenceEqual(other.ElementsNames);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cluster)obj);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            if (Elements != null)
            {
                foreach (var element in Elements)
                {
                    hash += element.Label.GetHashCode();
                }
            }
            return hash;
        }
    }
}
