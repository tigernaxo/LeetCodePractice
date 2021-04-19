using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice
{
    class ZigZagConversion
    {
        // 兩種情形(ZigZag寬度N、位於第幾個row)，應該出現的新位置(1base)
        // 獲得兩種間隔：
        public string Solution1(string s, int numRows)
        {
            if (numRows == 1) return s;
            StringBuilder result = new StringBuilder(s.Length);
            int k = 0, charIdx = 0, rowIdx = 0;
            bool isNode = false;
            for (int row = 1; row <= numRows; row++)
            {
                k = 0;
                isNode = row % numRows <= 1;
                Console.WriteLine($"########## row={row}; numRows={numRows}; isNode={isNode}");
                while (charIdx < s.Length)
                {
                    // 全部的 row 都必須套用第一組規則
                    rowIdx = k * (2 * numRows - 2) + row - 1;
                    if (rowIdx >= s.Length) break;
                    result.Append(s[rowIdx]);
                    Console.WriteLine($"rowIdx={rowIdx}; charIdx={charIdx}; s[rowIdx]={s[rowIdx]}");
                    charIdx++;
                    // 如果不是節點 row/numRows <= 1，才用第二組規則
                    if (!isNode)
                    {
                        rowIdx = (k + 1) * (2 * numRows - 2) - (row - 2) - 1;
                        if (rowIdx >= s.Length) break;
                        result.Append(s[rowIdx]);
                        Console.WriteLine($"rowIdx={rowIdx}; charIdx={charIdx}; s[rowIdx]={s[rowIdx]}");
                        charIdx++;
                    }
                    k++;
                }
            }
            return result.ToString();
        }
        public void test()
        {
            Solution1("1234567890123456", 4);
        }
        //public int getRow(int totalLen , int N, int target)
        //{
        //}
    }
}
