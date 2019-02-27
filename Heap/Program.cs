using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] data=new int[] { 5,4,2,1,8,5,3,6,9,10,7,6,4};
            Heap heap=new Heap(false);
            for (int i = 0; i < data.Length; i++)
            {
                heap.Push(data[i]);
            }
            for (int i = 0; i < heap.dataList.Count; i++)
            {
                Console.WriteLine(heap.dataList[i]);
            }
            Console.WriteLine("出堆");
            while (heap.dataList.Count>0)
            {
                Console.WriteLine(heap.Pop());
            }
            Console.WriteLine("泛型");
            BHeap<int> bheap = new BHeap<int>(false, delegate(int a, int b)
            {
                if (a>b)
                {
                    return 1;
                }
                if (a<b)
                {
                    return -1;
                }
                return 0;
            });
            for (int i = 0; i < data.Length; i++)
            {
                bheap.Push(data[i]);
            }
            for (int i = 0; i < bheap.dataList.Count; i++)
            {
                Console.WriteLine(bheap.dataList[i]);
            }
            Console.WriteLine("出堆");
            while (bheap.dataList.Count > 0)
            {
                Console.WriteLine(bheap.Pop());
            }
            Console.ReadKey();
        }
    }
}
