using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice
{
    public class _AddTwoNumbers
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return helper(l1, l2);
        }
        public ListNode? helper(ListNode l1 = null, ListNode l2 = null, int carry = 0)
        {
            if (l1 == null && l2 == null)
            {
                return carry == 0 ? null : new ListNode(1);
            }
            carry += l1 == null ? 0 : l1.val;
            carry += l2 == null ? 0 : l2.val;
            var node = new ListNode(carry % 10);
            node.next = helper(l1?.next ?? null, l2?.next ?? null, carry > 9 ? 1 : 0);
            return node;
        }
    }
}
