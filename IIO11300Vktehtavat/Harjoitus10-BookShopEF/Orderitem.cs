//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Harjoitus10_BookShopEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orderitem
    {
        public int id { get; set; }
        public int orderid { get; set; }
        public int bookid { get; set; }
        public int count { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
