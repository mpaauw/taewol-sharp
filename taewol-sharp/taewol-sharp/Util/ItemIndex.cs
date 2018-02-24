using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taewol_sharp.Util
{
    public class ItemIndex<T>
    {
        private T value;
        private int index;

        public ItemIndex() { }

        public ItemIndex(T value, int index)
        {
            this.value = value;
            this.index = index;
        }

        public T GetValue()
        {
            return value;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }

        public int GetIndex()
        {
            return index;
        }

        public void SetIndex(int index)
        {
            this.index = index;
        }
    }
}
