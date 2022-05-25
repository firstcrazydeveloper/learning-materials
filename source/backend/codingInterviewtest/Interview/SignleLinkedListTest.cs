using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingInterview.Helper.SignleLinkedList;
using CodingInterview.Interview;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewTest.Interview
{
    [TestClass]
    public class SignleLinkedListTest
    {
        private SignleLinkedList<int> linkedList;
        public SignleLinkedListTest()
        {
            linkedList = new SignleLinkedList<int>();
        }

        [TestMethod]
        public void AddTest()
        {
            linkedList.Add(5);
            linkedList.Add(7);
            linkedList.Add(18);
            linkedList.Add(25);
            Node node = this.linkedList.Head;

            Assert.AreEqual(25, node.Data);
            Assert.AreEqual(18, node.Next.Data);
            Assert.AreEqual(7, node.Next.Next.Data);
            Assert.AreEqual(5, node.Next.Next.Next.Data);
        }

        [TestMethod]
        public void AppendTest()
        {
            linkedList.Append(5);
            linkedList.Append(7);
            linkedList.Append(18);
            linkedList.Append(25);
            Node node = this.linkedList.Head;

            Assert.AreEqual(5, node.Data);
            Assert.AreEqual(7, node.Next.Data);
            Assert.AreEqual(18, node.Next.Next.Data);
            Assert.AreEqual(25, node.Next.Next.Next.Data);
        }

        [TestMethod]
        public void CopyTest()
        {
            linkedList.Add(5);
            linkedList.Add(7);
            linkedList.Add(18);
            linkedList.Add(25);
            Node node = this.linkedList.Head;

            Assert.AreEqual(25, node.Data);
            Assert.AreEqual(18, node.Next.Data);
            Assert.AreEqual(7, node.Next.Next.Data);
            Assert.AreEqual(5, node.Next.Next.Next.Data);

            var copyData = linkedList.CopyLinkedList();
            Node copyNode = copyData.Head;

            Assert.AreEqual(25, copyNode.Data);
            Assert.AreEqual(18, copyNode.Next.Data);
            Assert.AreEqual(7, copyNode.Next.Next.Data);
            Assert.AreEqual(5, copyNode.Next.Next.Next.Data);
        }

        [TestMethod]
        public void CopyCircularLinkedListTest()
        {
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            Node node = this.linkedList.Head;
            this.linkedList.Head.Random = this.linkedList.Head.Next.Next;
            this.linkedList.Head.Next.Random = this.linkedList.Head.Next.Next.Next;
            this.linkedList.Head.Next.Next.Random = this.linkedList.Head.Next;
            this.linkedList.Head.Next.Next.Next.Random = this.linkedList.Head.Next.Next.Next.Next;
            this.linkedList.Head.Next.Next.Next.Next.Random = this.linkedList.Head.Next.Next;



            var copyData = linkedList.CopyCircularLinkedList();
            Node copyNode = copyData.Head;

            Assert.AreEqual(5, copyNode.Data);
            Assert.AreEqual(4, copyNode.Next.Data);
            Assert.AreEqual(3, copyNode.Next.Next.Data);
            Assert.AreEqual(2, copyNode.Next.Next.Next.Data);
            Assert.AreEqual(1, copyNode.Next.Next.Next.Next.Data);

            Assert.AreEqual(3, copyNode.Random.Data);
            Assert.AreEqual(2, copyNode.Next.Random.Data);
            Assert.AreEqual(4, copyNode.Next.Next.Random.Data);
            Assert.AreEqual(1, copyNode.Next.Next.Next.Random.Data);
            Assert.AreEqual(3, copyNode.Next.Next.Next.Next.Random.Data);
        }

        [TestMethod]
        public void GetMidNodeTest()
        {
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            Node node = this.linkedList.GetMidNode();
            Assert.AreEqual(3, node.Data);


        }

        [TestMethod]
        public void DetectLoopTest()
        {
            linkedList.Add(50);
            linkedList.Add(20);
            linkedList.Add(15);
            linkedList.Add(4);
            linkedList.Add(10);
            var isLooping = this.linkedList.DetectLoop(this.linkedList.Head);
            Assert.AreEqual(false, isLooping);
            this.linkedList.Head.Next.Next.Next = this.linkedList.Head.Next.Next;
            isLooping = this.linkedList.DetectLoop(this.linkedList.Head);
            this.linkedList.RemoveLoop(this.linkedList.Head);
            Assert.AreEqual(true, isLooping);


        }

        [TestMethod]
        public void MergeTwoListTest()
        {
            linkedList.Add(5);
            linkedList.Add(4);
            linkedList.Add(3);
            linkedList.Add(2);
            linkedList.Add(1);

            Node node = this.linkedList.Head;

           SignleLinkedList<int> tempList=new SignleLinkedList<int>();
            tempList.Add(10);
            tempList.Add(9);
            tempList.Add(8);
            tempList.Add(7);
            tempList.Add(6);

            Node node2 = tempList.Head;

            this.linkedList.MergeTwoList(node, node2);


        }
    }
}
