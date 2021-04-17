using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice
{
    class _MedianOfTwoSortedArrays
    {
        public double Sulotion1(int[] nums1, int[] nums2)
        {
            double totalCnt = (nums1.Length + nums2.Length);
            if (totalCnt == 1) return nums1.Length == 1 ? nums1[0] : nums2[0];
            double medianIdx = (totalCnt - 1) / 2;
            Console.WriteLine($"medianIdx={medianIdx}; totalCnt={totalCnt}");
            double num1=0, num2=0;
            for (int i = 0, idx1 = 0, idx2 = 0; i < medianIdx + 1; i++)
            {
                Console.WriteLine($"i={i}, idx1={idx1}, idx2={idx2}, nums1.Length={nums1.Length} ,nums2.Length={nums2.Length}");
                // nums1 當中還有元素的情況
                if (idx1 < nums1.Length) { 
                    // 兩個都有元素
                    if(idx2 < nums2.Length)
                    {
                        // 取比較小的判斷是否命中 median index
                        Console.WriteLine($"nums1[idx1] <= nums2[idx2]={nums1[idx1] <= nums2[idx2]}; idx1 - medianIdx: {idx1 - medianIdx}");
                        if (nums1[idx1] <= nums2[idx2])
                        {
                            Console.WriteLine($"idx1{idx1} - medianIdx{medianIdx}: {idx1 - medianIdx}");
                            if (idx1+idx2 - medianIdx == 0)
                            {
                                num1 = nums1[idx1];
                                num2 = nums1[idx1];
                                break;
                            }
                            else if (idx1 + idx2 - medianIdx == 0.5)
                            {
                                num2 = nums1[idx1];
                                break;
                            }
                            else if (idx1 + idx2 - medianIdx == -0.5)
                            Console.WriteLine($"idx1 - medianIdx: {idx1 - medianIdx}");
                            {
                                num1 = nums1[idx1];
                            }
                            idx1++;
                        }
                        else
                        {
                            Console.WriteLine($"idx1+idx2{idx1 + idx2} - medianIdx{medianIdx}: {idx1 + idx2 - medianIdx}");
                            if (idx1 + idx2 - medianIdx == 0)
                            {
                                num1 = nums2[idx2];
                                num2 = nums2[idx2];
                                break;
                            }
                            else if (idx1 + idx2 - medianIdx == 0.5)
                            {
                                num2 = nums2[idx2];
                                break;
                            }
                            else if (idx1 + idx2 - medianIdx == -0.5)
                            {
                                num1 = nums2[idx2];
                            }
                            idx2++;
                        }
                    }
                    else
                        // 只有 nums1 有元素
                    {
                        Console.WriteLine($"idx1+idx2 - medianIdx: {idx1 + idx2 - medianIdx}");
                        if (idx1 + idx2 - medianIdx == 0)
                        {
                            num1 = nums1[idx1];
                            num2 = nums1[idx1];
                            break;
                        }
                        else if (idx1 + idx2 - medianIdx == 0.5)
                        {
                            num2 = nums1[idx1];
                            break;
                        }
                        else if (idx1 + idx2 - medianIdx == -0.5)
                        {
                            num1 = nums1[idx1];
                        }
                        idx1++;
                    }
                }
                else if (idx2 < nums2.Length) 
                    // 只有 nums2 有元素
                {
                    if (idx1 + idx2 - medianIdx == 0)
                    {
                        num1 = nums2[idx2];
                        num2 = nums2[idx2];
                        break;
                    }
                    else if (idx1 + idx2 - medianIdx == 0.5)
                    {
                        num2 = nums2[idx2];
                        break;
                    }
                    else if (idx1 + idx2 - medianIdx == -0.5)
                    {
                        num1 = nums2[idx2];
                    }
                    idx2++;
                }
            }
            Console.WriteLine($"num1: {num1}, num2: {num2}");
            return (num1 + num2) / 2;
        }
    }
}
