//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pays_last
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pay
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int user_id { get; set; }
        public int count { get; set; }
        public decimal sum { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
