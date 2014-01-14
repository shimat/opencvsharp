using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Blob
{
    internal class ProximityMatrix
    {
        private readonly int[] close;
        private readonly int nBlobs;
        private readonly int nTtacks;

        public ProximityMatrix(int nBlobs, int nTracks)
        {
            this.nBlobs = nBlobs;
            this.nTtacks = nTracks;
            this.close = new int[(nBlobs + 2) * (nTracks + 2)]; 
            AB = new ABIndexer(this);
            AT = new ATIndexer(this);
            IB = new IBIndexer(this);
            IT = new ITIndexer(this);
        }

        public int this[int blob, int track]
        {
            get
            {
                return close[((blob) + (track) * (nBlobs + 2))];
            }
            set
            {
                close[((blob) + (track) * (nBlobs + 2))] = value;
            }
        }

        #region Indexer
        public abstract class Indexer
        {
            protected ProximityMatrix matrix;
            protected Indexer(ProximityMatrix matrix)
            {
                this.matrix = matrix;
            }
            public abstract int this[int index] { get; set; }
        }
        public class ABIndexer : Indexer
        {
            internal ABIndexer(ProximityMatrix matrix)
                : base(matrix)
            {
            }
            public override int this[int label]
            {
                get { return matrix[label, matrix.nTtacks]; }
                set { matrix[label, matrix.nTtacks] = value; }
            }
        }
        public class ATIndexer : Indexer
        {
            internal ATIndexer(ProximityMatrix matrix)
                : base(matrix)
            {
            }
            public override int this[int id]
            {
                get { return matrix[matrix.nBlobs, id]; }
                set { matrix[matrix.nBlobs, id] = value; }
            }
        }
        public class IBIndexer : Indexer
        {
            internal IBIndexer(ProximityMatrix matrix)
                : base(matrix)
            {
            }
            public override int this[int label]
            {
                get { return matrix[label, matrix.nTtacks + 1]; }
                set { matrix[label, matrix.nTtacks + 1] = value; }
            }
        }
        public class ITIndexer : Indexer
        {
            internal ITIndexer(ProximityMatrix matrix)
                : base(matrix)
            {
            }
            public override int this[int id]
            {
                get { return matrix[matrix.nBlobs + 1, id]; }
                set { matrix[matrix.nBlobs + 1, id] = value; }
            }
        }

        public ABIndexer AB { get; private set; }
        public ATIndexer AT { get; private set; }
        public IBIndexer IB { get; private set; }
        public ITIndexer IT { get; private set; }
        #endregion
    }
}
