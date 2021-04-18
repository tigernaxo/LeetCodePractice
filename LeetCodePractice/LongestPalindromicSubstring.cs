using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice
{
    class LongestPalindromicSubstring
    {
        public String Solution1(string s) 
        {
            if (s.Length == 0) return "";
            var res = s.Substring(0, 1);
            bool isPalindrom = true;
            // 從每個點往後尋找回文序列
            for (int i = 0; i < s.Length; i++)
            {
                // 取得判斷區間(跳過一個的判斷)
                for (int j = i; j < s.Length; j++)
                {
                    isPalindrom = true;
                    // 從頭尾開始對，檢查是否回文序列
                    for (int left = i, right = j; right >= left; left++, right--)
                    {
                        if (s[left] != s[right])
                        {
                            isPalindrom = false;
                            break;
                        }
                    }
                    if (isPalindrom && res.Length < j - i + 1)
                    {
                        res = s.Substring(i, j - i + 1);
                    }
                }
            }
            return res;
        }
        public String Solution2(string s)
        {
            if (s.Length == 0) return "";
            int start = 0, length = 1, len1 = 0, len2 = 0, len = 0; // 變數拉出來只宣告一次會比放在 loop 裡面快
            // 從每個點往後尋找回文序列
            for (int i = 0; i < s.Length; i++)
            {
                // 判斷s[i]是否為中心點，或中心點周圍 s[i]、s[i+1]
                len1 = expandCenter(s, i, i);
                len2 = expandCenter(s, i, i + 1);
                //len = Math.Max(len1, len2);
                len = len1 >= len2 ? len1 : len2; // 簡單的兩個比大小判斷避免呼叫 Math.Max 會比較快
                //Console.WriteLine($"i={i}, len1={len1}, len2={len2}, len={len}");
                if(len > length)
                {
                    //res = s.Substring(i - (len - 1) / 2, len); // 計算出 index 最後只做一次 substring 會比每次遇到都取快
                    if(len > length)
                    {
                        start = i - (len - 1) / 2;
                        length = len;
                    }
                }
            }
            //Console.WriteLine($"start={start}, length={length}");
            return s.Substring(start, length);
        }
        public int expandCenter(string s, int left, int right)
        {
            //Console.WriteLine($"[expandCenter] s[{left}]{ s[left]} == s[{right}]{ s[right]}");
            while(left >= 0 && right < s.Length && s[left] == s[right])
            {
                //Console.WriteLine($" s[left]{ s[left]} == s[right]{ s[right]}");
                left--;
                right++;
            }
            return right - left - 1;
        }
    }
}
