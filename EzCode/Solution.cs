using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzCode
{
    public class Solution
    {
        public bool IsPowerOfFour(int n)
        {
            return n > 0 && (n & (n - 1)) == 0 && (n & 0x55555555) != 0;
        }
    }
}
