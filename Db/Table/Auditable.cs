using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Table
{
    public class Auditable
    {
        public Guid Id { get; set; }                    /*Log id*/
        public DateTime EventTimeUtc { get; set; }  /*Log time*/
        public string EventType { get; set; }           /*Create, Update or Delete*/
        public string UserName { get; set; }           /*Log User*/
        public string TableName { get; set; }           /*Table where rows been created/updated/deleted*/
        public string KeyValue { get; set; }           /*Pk and it's values*/
        public string OldValue { get; set; }           /*Changed column name and old value*/
        public string NewValue { get; set; }           /*Changed column name and current value*/
        public string ChangedColumns { get; set; }      /*Changed column names*/
    }
}
