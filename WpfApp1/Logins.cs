//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Logins
    {
        public int ID_Login { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role_ID { get; set; }
    
        public virtual Roles Roles { private get; set; }
    }
}