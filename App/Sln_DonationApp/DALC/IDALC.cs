using System;
using System.Collections.Generic;
using System.Text;

namespace DALC
{
    public class IDALC
    {
        #region Entities
        public partial class User
        {
            public long? USER_ID { get; set; }
            public string FIRST_NAME { get; set; }
            public string LAST_NAME { get; set; }
            public string EMAIL { get; set; }
            public string PHONE { get; set; }
            public string? PASSWORD { get; set; }
            public string USER_TYPE_CODE { get; set; }
            public bool? IS_ACTIVE { get; set; }
            public DateTime ENTRY_DATE { get; set; }
        }

        public partial class Category
        {
            public Int32? CATEGORY_ID { get; set; }
            public string NAME { get; set; }
            public string DESCRIPTION { get; set; }
            public DateTime ENTRY_DATE { get; set; }
        }

        #endregion

    }
}
