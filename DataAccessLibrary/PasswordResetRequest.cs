//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class PasswordResetRequest
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public System.DateTime RequestDateTime { get; set; }
        public string ResetToken { get; set; }
        public System.DateTime ResetTokenExpiry { get; set; }
    }
}
