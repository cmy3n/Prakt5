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
    
    public partial class Passengers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Passengers()
        {
            this.Passenger_Tickets = new HashSet<Passenger_Tickets>();
        }
    
        public int ID_Passenger { get; set; }
        public string Passenger_Surname { get; set; }
        public string Passenger_Name { get; set; }
        public string Passenger_Middlename { get; set; }
        public string Passenger_PhoneNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passenger_Tickets> Passenger_Tickets {private get; set; }
    }
}