using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice
{
    class _LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring1(string s)
        {
            HashSet<char> set = new HashSet<char>();
            int len = 0, maxLen = 0;
            if (s.Length == 1) return 1;
            for (int idx = 0; idx < s.Length; idx++)
            {
                if (!set.Contains(s[idx]))
                {
                    len++;
                    if (idx == s.Length - 1)
                    {
                        maxLen = len > maxLen ? len : maxLen;
                    }
                }
                else
                {
                    //Console.WriteLine($"位置{idx}檢查到重覆字元{s[idx]}, len={len}, maxLen={maxLen}, set.Count={set.Count}");
                    maxLen = len > maxLen ? len : maxLen;
                    // 從最近分析字串的開頭去找出重複字元，如果還沒遇到沒重複就除
                    // 表示重複的在後面，長度要從重複的後面一個字元重新開始算
                    while (s[idx - len] != s[idx])
                    {
                        set.Remove(s[idx - len]);
                        len--;
                    }
                    set.Remove(s[idx - len]);
                    //Console.WriteLine($"位置{idx}處裡完重覆字元{s[idx]}, len={len}, maxLen={maxLen}, set.Count={set.Count}");
                }
                set.Add(s[idx]);
            }
            return maxLen;
        }
        public int LengthOfLongestSubstring2(string s) {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int ans = 0, left = 0;
            for (var idx = 0; idx < s.Length; idx++)
            {
                if (map.ContainsKey(s[idx]))
                {
                    left = Math.Max(map[s[idx]] + 1, left);
                }
                map[s[idx]] = idx;
                ans = Math.Max(ans, idx - left + 1);
                Console.WriteLine($"char={s[idx]}; left={left}; idx={idx}; ans={ans}");
            }
            return ans;
        }
    }
}
