using LowerTriangle;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace LowerTriangle
{
    public class LTM
    {
        public class InvalidIndexException : Exception { };
        public class OutOfTriangleException : Exception { };
        public class DimensionMismatchException : Exception { };

        private List<double> v;
        private int n;

        private int ind(int i, int j)
        {
            return j + i * (i + 1) / 2; ///indexing from zero
        }

        private double calcSizeFromLength(int size)
        {
            return (-1 + Math.Sqrt(1 + 8 * size)) / 2; /// root of (x^2+x-2*size=0) as x*(x-1)/2=size
        }

        private bool inLowerTriangle(int i, int j)
        {
            return i >= j && j >= 0 && i < n;
        }

        public LTM()
        {
            n = 9;
            v = new List<double>();
            var upTo = n * (n + 1) / 2;
            for (int i = 0; i < upTo; i++)
            {
                v.Add(i + 1);
            }
        }

        public LTM(int size)
        {
            n = size;
            var upTo = n * (n + 1) / 2;
            v = new List<double>();
            // v = Enumerable.Repeat(0, upTo).ToList();
            //or
            for (int i = 0; i < upTo; i++)
            {
                v.Add(0);
            }
        }

        public LTM(String fileName)
        {
            try
            {
                TextFileReader f = new TextFileReader(fileName);
                v = new List<double>();
                while (f.ReadInt(out int e))
                {
                    v.Add(e);
                }
                double size = calcSizeFromLength(v.Count);
                if (size == Math.Floor(size))
                {
                    n = Convert.ToInt32(size);
                }
                else
                {
                    n = 0;
                    v.Clear();
                }
            }
            catch
            {
                n = 0;
                v.Clear();
            }
        }

        public LTM(LTM m)
        {
            n = m.n;
            v = m.v;
        }

        public int GetSize()
        {
            return n;
        }

        public double getElem(int i, int j)
        {
            if (i >= n || j >= n || j < 0 || i < 0)
                throw new InvalidIndexException();
            else if (inLowerTriangle(i,j))
                return v[ind(i, j)];
            else
                return 0;
        }

        /// Setter
        void setElem(int i, int j, double e)
        {
            if (0 <= j && j <= i && i < n) /// indices of the lower part
            {
                v[ind(i, j)] = e; /// vector indexing starts at 0
            }
            else
                throw new OutOfTriangleException();
        }

        /// Static methods

        public static LTM add(LTM a, LTM b)
        {
            if (a.n != b.n)
                throw new DimensionMismatchException();

            LTM c = new LTM(a);
            for (int i = 0; i < a.n; i++)
            {
                c.v[i] += b.v[i];
            }
            return c;
        }

        public static LTM mul(LTM a, LTM b)
        {
            if (a.n != b.n)
                throw new DimensionMismatchException();

            LTM c = new LTM(a.n);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    for (int k = j; k <= i; k++)
                    {
                        c.setElem(i, j, c.getElem(i, j) + a.getElem(i, k) * b.getElem(k, j));
                    }
                }
            }
            return c;
        }

        public override String ToString()
        {
            String str = "";
            str += n.ToString() + "x" + n.ToString() + "\n\n    ";
            for (int i=0; i < n; i++) {
                str += $"({i+1})\t";
            }
            str +="\n";
            for (int i = 0; i < n; i++)
            {
                str += $"({i+1}) ";
                for (int j = 0; j < n; j++)
                {
                    str += getElem(i, j).ToString() + "\t";
                }
                str += "\n";
            }
            return str;
        }
    }
}
