using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinJiaYou.Models;

namespace LinJiaYou.Dictionarys
{
   internal partial  class Shops:System.Collections.DictionaryBase
    {
        public Shops()
        {
            A();
        }
        internal void Add(string id, Shop shop)
        {
            Dictionary.Add(id, shop);
        }
        internal void Remove(string id)
        {
            Dictionary.Remove(id);
        }
        internal Shop this[string id]
        {
            get { return (Shop)Dictionary[id]; }
            set { Dictionary[id] = value; }
        }
        partial void A();
        public new System.Collections.IEnumerator GetEnumerator()
        {
            foreach (object item in Dictionary.Values)
            yield return (Shop)item;
        }
    }
    internal partial class Shops
    {
        partial void A()
        {
            string id = "a";
            this.Add(id,new Shop { });
            int a = this.Count;
            //this.Remove(id);
            //int b = this.Count;
        }
    }
}