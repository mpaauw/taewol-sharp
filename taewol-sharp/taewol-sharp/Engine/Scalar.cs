using System;
using System.Collections.ObjectModel;
using taewol_sharp.Util;

namespace taewol_sharp.Engine
{
    public abstract class Scalar<T>
    {
        private Random rand = new Random();
        private Common<T> common = new Common<T>();

        public abstract T GenerateRandomScalar();

        public T ChooseRandomScalarFromArray(T[] arr)
        {
            if (arr.Length == 0)
            {
                throw new Exception(Constants.COLLECTION_EMPTY_EXCEPTION);
            }
            return arr[this.rand.Next(arr.Length)];
        }

        public T ChooseRandomScalarFromCollection(Collection<T> collection)
        {
            if (collection.Count == 0)
            {
                throw new Exception(Constants.COLLECTION_EMPTY_EXCEPTION);
            }
            int index = this.rand.Next(collection.Count);
            foreach (T item in collection)
            {
                if (--index <= 0)
                {
                    return item;
                }
            }
            throw new Exception(Constants.GENERIC_SCALAR_EXCEPTION);
        }

        public T GenerateRandomScalarNotInArray(T[] arr)
        {
            if (arr.Length == 0)
            {
                return GenerateRandomScalar();
            }
            T value = GenerateRandomScalar();
            while (common.arrayContains(arr, value))
            {
                value = GenerateRandomScalar();
            }
            return value;
        }

        public T GenerateRandomScalarNotInCollection(Collection<T> collection)
        {
            if (collection.Count == 0)
            {
                return GenerateRandomScalar();
            }
            T value = GenerateRandomScalar();
            while (collection.Contains(value))
            {
                value = GenerateRandomScalar();
            }
            return value;
        }
    }
}
