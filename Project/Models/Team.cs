//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Team
    {
        public int tid { get; set; }
        public Nullable<int> sp_id { get; set; }
        public Nullable<int> t_no { get; set; }
    
        public virtual Sport_tournamentlist Sport_tournamentlist { get; set; }
    }
}
