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
    
    public partial class Schedule
    {
        public int ID_Schedule { get; set; }
        public int Number_Route { get; set; }
        public string Departure_Time { get; set; }
        public string Arrival_Time { get; set; }
    
        public virtual Bus_Routes Bus_Routes { private get; set; }
    }
}
