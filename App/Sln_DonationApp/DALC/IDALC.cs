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

        public partial class Address
        {
            public Int32? ADDRESS_ID { get; set; }
            public string COUNTRY { get; set; }
            public string CITY { get; set; }
            public string STREET { get; set; }
            public decimal LATIDUTE { get; set; }
            public decimal LANGITUDE { get; set; }

        }

        public partial class Category
        {
            public Int32? CATAGORY_ID { get; set; }
            public string NAME { get; set; }
            public string DESCRIPTION { get; set; }
            public DateTime ENTRY_DATE { get; set; }
            public UploadFile? UPLOAD_FILE { get; set; }
        }

        public partial class Donation
        {
            public long? DONATION_ID { get; set; }
            public string COLOR { get; set; }
            public string SIZE { get; set; }
            public int QUANTITY { get; set; }
            public bool? IS_SHIPPED { get; set; }
            public DateTime SHIP_DATE { get; set; }
            public DateTime ENTRY_DATE { get; set; }
            public Address ADDRESS { get; set; }
            public User USER { get; set; }
            public Item ITEM { get; set; }
            public List<UploadFile>? UPLOADED_FILES { get; set; }

        }

        public partial class Item
        {
            public Int32? ITEM_ID { get; set; }
            public string NAME { get; set; }
            public string DESCRIPTION { get; set; }
            public bool? IS_ACTIVE { get; set; }
            public Category CATAGORY { get; set; }
            public DateTime ENTRY_DATE { get; set; }
            public UploadFile? UPLOAD_FILE { get; set; }
<<<<<<< HEAD
=======
            public Int32? TIME_NUMBER { get; set; }

>>>>>>> origin/temp004

        }

        public partial class UploadFile
        {
            public Int32? UPLOADED_FILE_ID { get; set; }
            public string FILE_NAME { get; set; }
            public Int32? CATEGORY_ID { get; set; }
            public Int32? ITEM_ID { get; set; }
            public Int32? DONATION_ID { get; set; }
            public DateTime ENTRY_DATE { get; set; }

        }
        #endregion

    }
}
