using System;

namespace taewol_sharp.Util
{
    public class Common<T>
    {
        public bool arrayContains(T[] arr, T value)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(Constants.COLLECTION_NULL_EXCEPTION, nameof(arr));
            }
            foreach (T item in arr)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
