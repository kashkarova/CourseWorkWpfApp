//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWorkWpfApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Abonement
    {
        public Abonement()
        {
            this.ServicePosition = new HashSet<ServicePosition>();
        }
    
        public int id { get; set; }
        public int client_id { get; set; }
        public System.DateTime date_begin { get; set; }
    
        public virtual ICollection<ServicePosition> ServicePosition { get; set; }
        public virtual Client Client { get; set; }
    }
}
