using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinJiaYou.Models
{
     class Class2
    {
        public const int A = 1;
        public  readonly int B = 2;
        public static int C;
        public Class2(int m)
        {
            // A = m;
            B = m;
            C = m;
        }
    }
}