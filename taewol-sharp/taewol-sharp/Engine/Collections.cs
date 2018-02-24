using System;
using taewol_sharp.Util;

namespace taewol_sharp.Engine
{
    public class Collections<T>
    {
        private long upperBoundSize = Constants.UPPER_BOUND_SIZE;
        private Random rand = new Random();

        public Collections(long upperBoundSize)
        {
            this.upperBoundSize = upperBoundSize;
        }
    }
}
