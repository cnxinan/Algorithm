/*
题目名称：
二进制中1的个数

题目描述：
输入一个整数，输出该数二进制表示中1的个数。其中负数用补码表示。

代码结构：
class Solution
{
    public int NumberOf1(int n)
    {
        // write code here
    }
}

补充：
正数的补码等于其原码
负数的补码等于其原码按位取反后（除了最高位）加1
*/
using System;
namespace NumberOf1 {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 对于本题，首先想到的是将目标数一直右移，然后将该数和1相与，计算1的个数，直到该二进制数为0为止
        /// 但是考虑负数的情况，和正数右移最高位补0不同的是，负数右移最高位补1，这样就会有无数个1，导致循环无法停止
        /// 既然将目标数右移和1与行不通，那么我们可以反过来
        /// 将1不断左移（从最低位到最高位每一位依次是1，其他位是0），然后和目标数相与来求1的个数
        /// </summary>

        public int NumberOf1(int n)
        {
            int unit = 1, count = 0;
            while(unit != 0){
                if((n & unit) != 0){
                    count ++;
                }
                unit <<= 1;
            }
            return count;
        }

        public void Test() {

            int n = 6;
            n = 1;
            n = 0;
            n = -1;
            n = -20;

            Console.WriteLine(NumberOf1(n));
        }
    }
}
