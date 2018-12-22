using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinJiaYou.Models;

namespace LinJiaYou.Comparers
{
    public class ShopIDComparer : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            Shop shop1 = (Shop)x;
            Shop shop2=(Shop)y;
            int result = 0;
            if (shop1.ID < shop2.ID)
            {
                result = 1;
            }
            else if (shop1.ID == shop2.ID)
            {
                result = 0;
            }
            else if (shop1.ID > shop2.ID)
            {
                result = -1;
            }
            return result;
        }
    }
}