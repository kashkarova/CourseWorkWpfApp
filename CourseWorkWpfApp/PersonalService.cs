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
    
    public partial class PersonalService
    {
        public int service_id { get; set; }
        public double additional_payment { get; set; }
    
        public virtual Service Service { get; set; }
    }
}
