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
    
    public partial class Post
    {
        public Post()
        {
            this.Coach = new HashSet<Coach>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
    
        public virtual ICollection<Coach> Coach { get; set; }
    }
}
