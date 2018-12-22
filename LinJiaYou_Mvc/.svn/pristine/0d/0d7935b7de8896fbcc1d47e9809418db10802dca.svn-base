using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinJiaYou.Models;

namespace LinJiaYou.Collections
{
    internal partial class Shops : CollectionBase
    {
        public Shops()
        {
            A();
        }
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
        
         partial void A();

        //internal IEnumerator GetEnumerator()
        //{

        //}
    }
    internal partial class Shops
    {
         partial void A()
        {
            this.Add(new Shop { });
            int a = this.Count;
            int b = a;
            List<Shop> shops = new List<Shop> { new Shop {ID=5 }, new Shop { ID=1 },new Shop { ID=2 } };
            System.Comparison<Shop> comparison = new Comparison<Shop>(Fun.ShopComparer);
            shops.Sort(comparison);

            shops.S(new Fun.C<Shop>(Fun.ShopComparer));
            Shop findedShop= shops.F(new Fun.D<Shop>(Fun.ShopFinder));
        }
        
    }
}