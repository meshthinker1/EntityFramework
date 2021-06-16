using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Table
{
    public class Institution
    {
        public Guid Id { get; set; }
        public String SalesForceId { get; set; }
        public String SapCustomerId { get; set; }
        public String DisplayName { get; set; }
        public String Location { get; set; }
        public DateTime CreatedUtc { get; set; }
        public String CreatedBy { get; set; }
        public DateTime LastModifiedUtc { get; set; }
        public String LastModifiedBy { get; set; }
        public Boolean Deleted { get; set; }
        public String GlobalDisplayName { get; set; }
        public String IdpId { get; set; }
        public String Scopes { get; set; }
        public String IdpMatchingRegEx { get; set; }
    }
}
