using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    internal class Garden : IEquatable<Garden>
    {
        private Tree[] _trees;
        private double _enclosureLength;

        public Tree[] Trees { get { return _trees; } set { _trees = value; } }
        public double EnclosureLength { get { return _enclosureLength; } set { _enclosureLength = value; } }

        public Garden(Tree[] trees)
        {
            _trees = trees;
            _enclosureLength = CalculatePerimeter(trees);
        }
        
        private double DistanceBetweenTwoTrees(Tree firstTree, Tree secondTree)
        {
            double distanceX = firstTree.X - secondTree.X;
            double distanceY = firstTree.Y - secondTree.Y;
            return Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        }
        private Tree GetStartTree()
        {
            Tree startTree = Trees[0];
            foreach (Tree tree in Trees)
            {
                if (tree.Y < startTree.Y || (tree.Y == startTree.Y && tree.X < startTree.X))
                {
                    startTree = tree;
                }
            }
            return startTree;
        }
        private static double DirectionToFormEcnlosure(Tree first, Tree second, Tree third)
        {
            return (second.X - first.X) * (third.Y - first.Y) - (second.Y - first.Y) * (third.X - first.X);
        }
        public double CalculatePerimeter(Tree[] enclosure)
        {
            enclosure = EnclosureCreation();
            double perimeter = 0;
            if (enclosure.Length < 2)
            {
                return perimeter;
            }
            else if (enclosure.Length == 2)
            {
                double distance = DistanceBetweenTwoTrees(enclosure[0], enclosure[1]);
                return distance;
            }

            Tree firstTree = enclosure[0];
            for (int i = 1; i < enclosure.Length; i++)
            {
                perimeter += DistanceBetweenTwoTrees(firstTree, enclosure[i]);
                firstTree = enclosure[i];
            }

            perimeter += DistanceBetweenTwoTrees(firstTree, enclosure[0]);

            return perimeter;
        }
        private Tree[] EnclosureCreation()
        { 
            List<Tree> enclosure = new List<Tree>();

            if (Trees.Length < 3)
            {
                return enclosure.ToArray();
            }
            Tree startTree = GetStartTree();
            enclosure.Add(startTree);
            Tree firstTree = startTree;
            Tree nextTree;
            do
            {
                nextTree = Trees[0];
                foreach (Tree firstTempTree in Trees)
                {
                    if (firstTempTree == firstTree)
                    {
                        continue;
                    }

                    double direction = DirectionToFormEcnlosure(firstTree, nextTree, firstTempTree);
                    if (direction > 0)
                    {
                        nextTree = firstTempTree;
                    }
                    else if (direction == 0 && DistanceBetweenTwoTrees(firstTree, firstTempTree) > DistanceBetweenTwoTrees(firstTree, nextTree))
                    {
                        nextTree = firstTempTree;
                    }
                }

                enclosure.Add(nextTree);
                firstTree = nextTree;

            } 
            while (firstTree != startTree);

            enclosure.RemoveAt(enclosure.Count - 1);

            return enclosure.ToArray();

        }
        #region operator overloading
        public static bool operator == (Garden firstGarden, Garden secondGarden)
        {
            if (firstGarden.EnclosureLength == secondGarden.EnclosureLength) 
            {
                return true; 
            }
            else 
            {
                return false; 
            }
        }
        public static bool operator != (Garden firstGarden, Garden secondGarden)
        {
            if (firstGarden.EnclosureLength == secondGarden.EnclosureLength) 
            {
                return false; 
            }
            else 
            {
                return true; 
            }
        }
        public bool Equals(Garden garden)
        {
            if (EnclosureLength == garden.EnclosureLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Garden);
        }
        public override int GetHashCode()
        {
            Random random = new Random();
            int hashCode = random.Next(1, 100);
            hashCode = hashCode * 31 + EnclosureLength.GetHashCode();
            hashCode = hashCode * 31 + Trees.GetHashCode();

            return hashCode;
        }
        #endregion
        public override string? ToString()
        {
            return $"Enclosure length for the garden is {EnclosureLength} and it contains {Trees.Length} trees";
        }
    }
}
