﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinJiaYou.Models
{
    public class BaseModel
    {
        public int ID { get; set; }
        internal void ChangeID<T>(T obj) where T : BaseModel, new()
        {
            obj.ID = 0;
        }
    }
    public interface IHaveNameModel
    {
         String Name { get; set; }
    }
}