using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagonal
{
    public class Diag
    {
        #region Exceptions
        public class NegativeSizeException : Exception { };
        public class ReferenceToNullPartException : Exception { };
        public class DifferentSizeException : Exception { };
        #endregion

        #region Attribute
        private readonly List<double> x = new ();
        #endregion

        #region Constructors

        public Diag(int k)
        {
            if (k <= 0) throw new NegativeSizeException();
            for (int i = 0; i < k; ++i)
            {
                x.Add(0);
            }
        }
        public Diag(Diag d)
        {
            for (int i = 0; i < d.x.Count; ++i)
            {
                x.Add(d.x[i]);
            }
        }
        #endregion

        #region Properties

        public int Size // Property for getting the size of the matrix
        {
            get { return x.Count; }
        }

        public double this[int i, int j] //Property for getting and setting an element with square bracket
        {
            get
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size) throw new IndexOutOfRangeException();
                if (i == j) return x[i];
                else return 0;
            }
            set
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size) throw new IndexOutOfRangeException();
                if (i == j) x[i] = value;
                else throw new ReferenceToNullPartException();
            }
        }

        #endregion

        #region Getters and setters

        public override int GetHashCode()
        {
            return (base.GetHashCode() << 2);
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    str += "\t" + this[i, j];
                }
                str += "\n";
            }
            return str;
        }

        public override bool Equals(Object? obj)
        {
            if (obj == null || !(obj is Diag))
                return false;
            else
            {
                Diag? diag = obj as Diag;
                if (diag!.Size != this.Size) return false;
                for (int i = 0; i < x.Count; i++)
                {
                    if (x[i] != diag.x[i]) return false;
                }
                return true;
            }
        }

        public void Set(in List<double> x)
        {
            if (this.Size != x.Count) throw new DifferentSizeException();
            for (int i = 0; i < Size; i++)
            {
                this.x[i] = x[i];
            }
        }

        #endregion

        #region Operators

        public static Diag operator +(Diag a, Diag b)
        {
            if (a.Size != b.Size) throw new DifferentSizeException();
            Diag c = new(a.Size);
            for (int i = 0; i < c.Size; ++i)
            {
                c.x[i] = a.x[i] + b.x[i];
            }
            return c;
        }

        public static Diag operator *(Diag a, Diag b)
        {
            if (a.Size != b.Size) throw new DifferentSizeException();
            Diag c = new(a.Size);
            for (int i = 0; i < c.Size; ++i)
            {
                c.x[i] = a.x[i] * b.x[i];
            }
            return c;
        }

        #endregion


    }
}
