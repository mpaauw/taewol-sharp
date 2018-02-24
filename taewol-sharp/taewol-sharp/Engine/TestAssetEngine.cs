using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taewol_sharp.Util;

namespace taewol_sharp.Engine
{
    public class TestAssetEngine<T>
    {
        private Random rand = new Random();
        private int upperBoundValue = int.MaxValue;
        private int upperBoundSize = 100000;

        public TestAssetEngine() { }

        public TestAssetEngine(int upperBoundValue, int upperBoundSize)
        {
            if (upperBoundValue == upperBoundSize)
            {
                throw new Exception("Upper bound values and size should not be equivalent.");
            }
            this.upperBoundValue = upperBoundValue;
            this.upperBoundSize = upperBoundSize;
        }

        public TestAssetEngine(TestAssetEngineBuilder builder)
        {
            if (builder.upperBoundValue == builder.upperBoundSize)
            {
                throw new Exception("Upper bound values and size should not be equivalent.");
            }
            this.upperBoundValue = builder.upperBoundValue;
            this.upperBoundSize = builder.upperBoundSize;
        }

        public int generateRandomInteger()
        {
            return GenerateSign() ? this.rand.Next(upperBoundValue) : -1 * this.rand.Next(upperBoundValue);
        }

        public int generateRandomIntegerWithBound(int bound)
        {
            return GenerateSign() ? this.rand.Next(bound) : -1 * this.rand.Next(bound);
        }

        public int generateRandomPositiveIntegerWithBound(int bound)
        {
            return this.rand.Next(bound);
        }

        public int[] generateUnorderedIntegerArray()
        {
            int arraySize = 0;
            do
            {
                arraySize = this.rand.Next(this.upperBoundSize);
            } while (arraySize <= 0);
            int[] unorderedArr = new int[arraySize];
            for (int i = 0; i < unorderedArr.Length; i++)
            {
                unorderedArr[i] = generateRandomInteger();
            }
            return unorderedArr;
        }

        public int[] generateUnorderedIntegerArrayOfSize(int size)
        {
            int[] unorderedArr = new int[size];
            for (int i = 0; i < unorderedArr.Length; i++)
            {
                unorderedArr[i] = generateRandomInteger();
            }
            return unorderedArr;
        }

        public int[] generateUnorderedUniqueIntegerArray()
        {
            int arraySize = 0;
            do
            {
                arraySize = this.rand.Next(this.upperBoundSize);
            } while (arraySize <= 0);
            int[] unorderedArr = new int[arraySize];
            for (int i = 0; i < unorderedArr.Length; i++)
            {
                int val = generateRandomInteger();
                while (ContainsInteger(unorderedArr, val))
                {
                    val = generateRandomInteger();
                }
                unorderedArr[i] = val;
            }
            return unorderedArr;
        }

        public int[] generateOrderedIntegerArray()
        {
            int arraySize = 0;
            do
            {
                arraySize = this.rand.Next(this.upperBoundSize);
            } while (arraySize <= 0);
            int[] orderedArr = new int[arraySize];
            for (int i = 0; i < orderedArr.Length; i++)
            {
                orderedArr[i] = generateRandomInteger();
            }
            Array.Sort(orderedArr);
            return orderedArr;
        }

        public ItemIndex<T> chooseRandomItemIndexFromArray(T[] arr)
        {
            int index = this.rand.Next(arr.Length);
            return new ItemIndex<T>(arr[index], index);
        }

        public int generateRandomIntegerNotInArray(int[] arr)
        {
            int value = generateRandomIntegerWithBound(upperBoundValue);
            while (arr.Contains(value))
            {
                value = generateRandomIntegerWithBound(upperBoundValue);
            }
            return value;
        }

        public bool GenerateSign()
        {
            return this.rand.Next(2) == 0 ? true : false;
        }

        private bool ContainsInteger(int[] arr, int val)
        {
            foreach (int item in arr)
            {
                if (item == val)
                {
                    return true;
                }
            }
            return false;
        }

        public class TestAssetEngineBuilder
        {
            public int upperBoundValue = int.MaxValue;
            public int upperBoundSize = 100000;

            public TestAssetEngineBuilder UpperBoundValue(int upperBoundValue)
            {
                this.upperBoundValue = upperBoundValue;
                return this;
            }

            public TestAssetEngineBuilder UpperBoundSize(int upperBoundSize)
            {
                this.upperBoundSize = upperBoundSize;
                return this;
            }
        }
    }
}
