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
    
    public partial class Drivers
    {
        public int ID_Driver { get; set; }
        public string Driver_Surname { get; set; }
        public string Driver_Name { get; set; }
        public string Driver_Middlename { get; set; }
        public string Driver_Email { get; set; }
        public int Number_Route { get; set; }
    
        public virtual Bus_Routes Bus_Routes { private get; set; }
    }
}