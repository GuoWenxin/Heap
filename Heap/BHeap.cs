using System.Collections.Generic;

namespace Heap
{
    public class BHeap<T>
    {
        /// <summary>数据存储数组 </summary>
        public List<T> dataList;
        /// <summary> 是否是最小堆 </summary>
        private bool issmall;
        /// <summary>数组长度 </summary>

        public delegate int Compore<T>(T t1,T t2);
        
        private Compore<T> compore;
        public int length
        {
            get { return dataList.Count; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="issmall_">是否是最小堆，反之则为最大堆</param>
        public BHeap(bool issmall_,Compore<T> compore )
        {
            dataList = new List<T>();
            issmall = issmall_;
            this.compore = compore;
        }
        /// <summary>
        /// 添加一个数据
        /// </summary>
        /// <param name="data_"></param>
        public void Push(T data_)
        {
            dataList.Add(data_);
            BalanceHeap(length - 1);
        }
        /// <summary>
        /// 获取根数据
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (dataList == null || dataList.Count == 0)
            {
                return default(T);
            }
            T data = dataList[0];
            dataList[0] = dataList[length - 1];
            dataList.RemoveAt(length - 1);
            BalanceDown(0);
            return data;
        }
        /// <summary>
        /// 平衡堆结构
        /// </summary>
        /// <param name="pos_"></param>
        private void BalanceHeap(int pos_)
        {
            if (pos_ >= length)
            {
                return;
            }
            BalanceUp(pos_);
        }

        private void BalanceUp(int pos_)
        {
            if (pos_ <= 0)
            {
                return;
            }
            int parPos = GetParentPos(pos_);
            if (issmall)
            {
                //if (dataList[parPos] > dataList[pos_])
                if (compore(dataList[parPos],dataList[pos_])==1)
                {
                    SwitchData(parPos, pos_);
                    BalanceDown(parPos);
                }
            }
            else
            {
                if (compore(dataList[parPos], dataList[pos_]) == -1)
                {
                    SwitchData(parPos, pos_);
                    BalanceDown(parPos);
                }
            }
            BalanceUp(parPos);
        }

        private void BalanceDown(int pos_)
        {
            BalanceDownLeft(pos_);
            BalanceDownRight(pos_);
        }

        private void BalanceDownLeft(int pos_)
        {
            int leftChildPos = GetLeftChildPos(pos_);
            if (pos_ >= leftChildPos)
            {
                return;
            }
            if (issmall)
            {
                //if (dataList[leftChildPos] < dataList[pos_])
                if (compore(dataList[leftChildPos],dataList[pos_])==-1)
                {
                    SwitchData(leftChildPos, pos_);
                    BalanceUp(leftChildPos);
                }
            }
            else
            {
                if (compore(dataList[leftChildPos], dataList[pos_]) == 1)
                {
                    SwitchData(leftChildPos, pos_);
                    BalanceUp(leftChildPos);
                }
            }
            BalanceDown(leftChildPos);
        }
        private void BalanceDownRight(int pos_)
        {
            int rightChildPos = GetRightChildPos(pos_);
            if (pos_ >= rightChildPos)
            {
                return;
            }
            if (issmall)
            {
                if (compore(dataList[rightChildPos], dataList[pos_]) == -1)
                {
                    SwitchData(rightChildPos, pos_);
                    BalanceUp(rightChildPos);
                }
            }
            else
            {
                if (compore(dataList[rightChildPos], dataList[pos_]) == 1)
                {
                    SwitchData(rightChildPos, pos_);
                    BalanceUp(rightChildPos);
                }
            }
            BalanceDown(rightChildPos);
        }
        /// <summary>
        /// 获取父节点的位置
        /// </summary>
        /// <param name="curPos_"></param>
        /// <returns></returns>
        private int GetParentPos(int curPos_)
        {
            if (curPos_ <= 0)
            {
                return 0;
            }
            return (curPos_ - 1) / 2;
        }
        /// <summary>
        /// 获取左子树的位置
        /// </summary>
        /// <param name="curPos"></param>
        /// <returns></returns>
        private int GetLeftChildPos(int curPos)
        {
            int pos = curPos * 2 + 1;
            if (pos < length)
            {
                return pos;
            }
            return curPos;
        }
        /// <summary>
        /// 获取右子树的位置
        /// </summary>
        /// <param name="curPos"></param>
        /// <returns></returns>
        private int GetRightChildPos(int curPos)
        {
            int pos = curPos * 2 + 2;
            if (pos < length)
            {
                return pos;
            }
            return curPos;
        }
        /// <summary>
        /// 交换两个位置的数据
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        private void SwitchData(int pos1, int pos2)
        {
            T temp = dataList[pos1];
            dataList[pos1] = dataList[pos2];
            dataList[pos2] = temp;
        }

        //public abstract int Compore<T>(T t1, T t2);
    }
}
