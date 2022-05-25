using System.Collections.Generic;
using CodingInterview.Interview;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewTest.Interview
{
    [TestClass]
    public class ArrayTest
    {
        private Array arrObj;
        public ArrayTest()
        {
            arrObj = new Array();
        }
        [TestMethod]
        public void RevereArrayTest()
        {

            int[] temp = new int[] { 2, 1, 3, 5, 4, 0, 9, 8, 7 };
            int[] expectedResult = new int[] { 7, 8, 9, 0, 4, 5, 3, 1, 2 };
            var result = arrObj.RevereArray(temp);
            CollectionAssert.AreEqual(expectedResult, result);

        }


        [TestMethod]
        public void MissingNumberTest()
        {
            int num = 50;
            int[] arr = new int[num];
            for (int i = 1; i <= num; i++)
            {
                if (i != 35)
                    arr[i - 1] = i;
            }
            int[] temp = new int[] { 2, 1, 3, 5, 4, 0, 9, 8, 7 };
            long result = arrObj.MissingNumber(temp);
            Assert.AreEqual(6, result);

        }

        [TestMethod]
        public void MissingNumberEfficientTest()
        {
            int num = 50;
            int[] arr = new int[num];
            for (int i = 1; i <= num; i++)
            {
                if (i != 35)
                    arr[i - 1] = i;
            }

            int[] temp = new int[] { 2, 1, 3, 5, 4, 0, 9, 8, 7 };
            long result = arrObj.MissingNumberEfficient(temp);
            Assert.AreEqual(6, result);

        }

        [TestMethod]
        public void MissingMultipleMissingNumberInArrayTest()
        {
            int[] temp = new int[] { 1, 3, 4, 5, 6, 7, 10 };
            int[] res = new int[] { 2, 8, 9 };
            var result = arrObj.MissingMultipleMissingNumberInArray(temp);
            for (int i = 0; i < res.Length; i++)
            {
                if (!result.Contains(res[i]))
                    Assert.Fail(res[i] + "is not missing");
            }
            Assert.AreEqual(3, result.Count);

        }

        [TestMethod]
        public void SumTwoMinimumValueInArrayTest()
        {
            int[] temp = new int[] { 1, 3, 4, 5, 2, 1, 8, 10 };
            int[] res = new int[] { 2, 9 };
            var result = arrObj.SumTwoMinimumValueInArray(temp);
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void SumTwoMinimumValueInArrayTestFailed()
        {
            int[] temp = new int[] { 1, 3, 4, 5, 2, 1, 8, 10 };
            int[] res = new int[] { 2, 9 };
            var result = arrObj.SumTwoMinimumValueInArray(temp);
            Assert.AreNotEqual(6, result);

        }

        [TestMethod]
        public void BinarySearchLinearTest()
        {
            int[] temp = new int[] { 1, 3, 4, 5, 6, 7, 8, 10 };
            var result = arrObj.BinarySearchLinear(temp, 5);
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void BinarySearchRecursiveTest()
        {
            int[] temp = new int[] { 1, 3, 4, 5, 6, 7, 8, 10 };
            var result = arrObj.BinarySearchRecursive(temp, 0, temp.Length - 1, 6);
            Assert.AreEqual(4, result);

        }


        [TestMethod]
        public void QuickSortRecursiveTest()
        {
            int[] temp = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = arrObj.QuickSortRecursive(temp, 0, temp.Length - 1);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, result);

        }

        [TestMethod]
        public void MergeSortRecursiveTest()
        {
            // int[] temp = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] temp = new int[] { 5, 4, 3, 1, 6, 2 };
            List<int> lst = new List<int>(new int[] { 1, 2, 8, 9, 5, 6, 7, 3, 4 });
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = arrObj.MergeSort(temp, 0, temp.Length - 1);
            //  var result = arrObj.mergeSort(lst, 0, temp.Length - 1);
            CollectionAssert.AreEqual(expectedResult, temp);

        }

        [TestMethod]
        public void GetDuplicateNumberTest()
        {
            int[] temp = new int[] { 1, 3, 4, 5, 3, 6, 7, 5 };
            List<int> expectedResult = new List<int>();
            expectedResult.Add(3);
            expectedResult.Add(5);
            var result = arrObj.GetDuplicateNumber(temp);
            CollectionAssert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void WorldTourTest()
        {
            List<WorldTour> rangeList = new List<WorldTour>();
            rangeList.Add(new WorldTour() { StartRange = 0, EndRange = 1 });
            rangeList.Add(new WorldTour() { StartRange = 1, EndRange = 2 });
            rangeList.Add(new WorldTour() { StartRange = 2, EndRange = 0 });
            // rangeList.Add(new WorldTour() { StartRange = 5, EndRange = 5 });
            rangeList.Add(new WorldTour() { StartRange = 0, EndRange = 0 });
            rangeList.Add(new WorldTour() { StartRange = 1, EndRange = 2 });
            rangeList.Add(new WorldTour() { StartRange = 2, EndRange = 3 });
            // rangeList.Add(new WorldTour() { StartRange = 4, EndRange = 4 });
            rangeList.Add(new WorldTour() { StartRange = 4, EndRange = 0 });
            arrObj.WorldTour(4, 3, rangeList);

        }
    }
}
