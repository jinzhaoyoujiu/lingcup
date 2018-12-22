using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using LinJiaYou.Models;

namespace LinJiaYou.Collections
{
    internal class Shops:CollectionBase
    {
        public Shops() { }
        internal void Add(Shop shop)
        {
            List.Add(shop);
        }
        internal void Remove(Shop shop)
        {
            List.Remove(shop);
        }
        internal Shop this[int shopIndex]
        {
            get { return (Shop)List[shopIndex]; }
            set { List[shopIndex] = value; }
        }
    }
}