using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using static DALC.IDALC;
<<<<<<< HEAD
using MailKit.Net.Smtp;
using MimeKit;
=======
>>>>>>> origin/temp004

namespace BLC
{
    public class BLC
    {
        public string ConnectionString = "";

        public IConfiguration _config;
        public BLC(IConfiguration config)
        {
            _config = config;
        }

        #region Get_Users
        public List<User> Get_Users()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            List<User> oUsers = new List<User>();
            oUsers = oDalc.Get_Users();
            
            if(oUsers.Count == 0) { throw new Exception("There are no Users"); }
            return oUsers;
        }
        #endregion

        #region GET_USER_BY_USER_ID
        public User GET_USER_BY_USER_ID(long USER_ID)
        {
            if (USER_ID == null || USER_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            User oUser = new User();
            oUser = oDalc.GET_USER_BY_USER_ID(USER_ID);

            if (oUser.USER_ID == null) { throw new Exception("User doesn't exist"); }

            return oUser;
        }
        #endregion

        #region EDIT_USER
        public Int32 EDIT_USER(User i_User)
        {
            if (i_User.USER_ID == null || i_User.USER_ID  == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
		if(i_User.USER_ID == -1){
		  i_User.ENTRY_DATE = DateTime.Today;
		}
           

            if (!string.IsNullOrEmpty(i_User.PASSWORD))
            {
                var encrypted = EncryptString(i_User.PASSWORD, _config["Key"]);
               // Console.WriteLine(encrypted);
                i_User.PASSWORD = encrypted;
            }


            int RETURNED_USER_ID = oDalc.EDIT_USER(i_User);

            return RETURNED_USER_ID;
        }
        #endregion

        #region DELETE_USER_BY_USER_ID
        public void DELETE_USER_BY_USER_ID(long USER_ID)
        {
            if (USER_ID == null || USER_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.DELETE_USER_BY_USER_ID(USER_ID);
        }
        #endregion

        #region DECATIVATE_USER_BY_USER_ID
        public void DECATIVATE_USER_BY_USER_ID(long USER_ID, int Is_Active)
        {
            if (USER_ID == null || USER_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.DECATIVATE_USER_BY_USER_ID(USER_ID, Is_Active);
        }
        #endregion

        #region GET_USER_BY_EMAIL_AND_PASSWORD
        public User GET_USER_BY_EMAIL_AND_PASSWORD(string EMAIL, string PASSWORD)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            User oUSER = new User();
            oUSER = oDalc.GET_USER_BY_EMAIL_AND_PASSWORD(EMAIL);

            if(oUSER.USER_ID == null) { throw new Exception("Email is incorrect"); }

            var decrypted = DecryptString(oUSER.PASSWORD, _config["Key"]);

            if (decrypted != PASSWORD) { throw new Exception("Password is incorrect"); }

            oUSER.PASSWORD = null;

           // Console.WriteLine(decrypted);

            return oUSER;
        }
        #endregion

        #region GET_ADDRESS
        public List<Address> GET_ADDRESS()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Address> oADDRESSES = new List<Address>();
            oADDRESSES = oDalc.GET_ADDRESS();

            if (oADDRESSES.Count == 0) { throw new Exception("There are no Addresses"); }
            
            return oADDRESSES;
        }
        #endregion

        #region GET_ADDRESS_BY_ADDRESS_ID
        public Address GET_ADDRESS_BY_ADDRESS_ID(Int32 ADDRESS_ID)
        {
            if (ADDRESS_ID == null || ADDRESS_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            Address oADDRESS = new Address();
            oADDRESS = oDalc.GET_ADDRESS_BY_ADDRESS_ID(ADDRESS_ID);

            if (oADDRESS.ADDRESS_ID == null) { throw new Exception("Address doesn't exist"); }

            return oADDRESS;
        }
        #endregion

        #region EDIT_ADDRESS
        public Int32 EDIT_ADDRESS(Address i_Address)
        {
            if(i_Address.ADDRESS_ID == null || i_Address.ADDRESS_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            int RETURNED_ADDRESS_ID = oDalc.EDIT_ADDRESS(i_Address);

            return RETURNED_ADDRESS_ID;
        }
        #endregion

        #region DELETE_ADDRESS
        public void DELETE_ADDRESS(Int32 ADDRESS_ID)
        {
            if (ADDRESS_ID == null || ADDRESS_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.DELETE_ADDRESS(ADDRESS_ID);
        }
        #endregion

        #region GET_ADDRESS_BY_COUNTRY
        public List<Address> GET_ADDRESS_BY_COUNTRY(string COUNTRY)
        {
            if (COUNTRY == null) { throw new Exception("Country can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Address> oADDRESSES = new List<Address>();
            oADDRESSES = oDalc.GET_ADDRESS_BY_COUNTRY(COUNTRY);

            if (oADDRESSES.Count == 0) { throw new Exception("There are no Addresses"); }

            return oADDRESSES;
        }
        #endregion

        #region GET_DONATIONS
        public List<Donation> GET_DONATIONS()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            List<Donation> oDonations = new List<Donation>(); ;
            oDonations = oDalc.GET_DONATIONS();

            if (oDonations.Count == 0) { throw new Exception("There are no Donations"); }
            
            return oDonations;
        }
        #endregion

        #region GET_DONATION_BY_DONATION_ID
        public Donation GET_DONATION_BY_DONATION_ID(Int32 DONATION_ID)
        {
            if (DONATION_ID == null || DONATION_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            Donation oDonation = new Donation(); ;
            oDonation = oDalc.GET_DONATION_BY_DONATION_ID(DONATION_ID);

            if (oDonation.DONATION_ID == null) { throw new Exception("Donation doesn't exist"); }

            return oDonation;
        }
        #endregion

        #region GET_DONATION_BY_USER_ID
        public List<Donation> GET_DONATION_BY_USER_ID(Int32 USER_ID)
        {
            if (USER_ID == null || USER_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Donation> oDonations = new List<Donation>(); ;
            oDonations = oDalc.GET_DONATION_BY_USER_ID(USER_ID);

            if (oDonations.Count == 0) { throw new Exception("There are no Donations"); }

            return oDonations;
        }
        #endregion

        #region GET_DONATION_BY_ITEM_ID
        public List<Donation> GET_DONATION_BY_ITEM_ID(Int32 ITEM_ID)
        {
            if (ITEM_ID == null || ITEM_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Donation> oDonations = new List<Donation>(); ;
            oDonations = oDalc.GET_DONATION_BY_ITEM_ID(ITEM_ID);

            if (oDonations.Count == 0) { throw new Exception("There are no Donations"); }

            return oDonations;
        }
        #endregion

        #region GET_DONATION_BY_ADDRESS_ID
        public List<Donation> GET_DONATION_BY_ADDRESS_ID(Int32 ADDRESS_ID)
        {
            if (ADDRESS_ID == null || ADDRESS_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Donation> oDonations = new List<Donation>();
            oDonations = oDalc.GET_DONATION_BY_ADDRESS_ID(ADDRESS_ID);

            if (oDonations.Count == 0) { throw new Exception("There are no Donations"); }

            return oDonations;
        }
        #endregion

        #region GET_DONATION_BY_IS_SHIPPED
        public List<Donation> GET_DONATION_BY_IS_SHIPPED()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Donation> oDonations = new List<Donation>(); ;
            oDonations = oDalc.GET_DONATION_BY_IS_SHIPPED();

            if (oDonations.Count == 0) { throw new Exception("There are no Donations"); }

            return oDonations;
        }
        #endregion

        #region GET_DONATION_BY_IS_NOT_SHIPPED
        public List<Donation> GET_DONATION_BY_IS_NOT_SHIPPED()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Donation> oDonations = new List<Donation>(); ;
            oDonations = oDalc.GET_DONATION_BY_IS_NOT_SHIPPED();

            if (oDonations.Count == 0) { throw new Exception("There are no Donations"); }

            return oDonations;
        }
        #endregion

        #region EDIT_DONATION
        public Int32 EDIT_DONATION(Donation i_Donation)
        {
            if (i_Donation.DONATION_ID == null || i_Donation.DONATION_ID == 0) { throw new Exception("Primary key can't be null or empty"); }
            if (i_Donation.USER.USER_ID == null || i_Donation.USER.USER_ID == 0) { throw new Exception("Foreign key USER_ID can't be null or empty"); }
            if (i_Donation.ITEM.ITEM_ID == null || i_Donation.ITEM.ITEM_ID == 0) { throw new Exception("Foreign key ITEM_ID can't be null or empty"); }
            if (i_Donation.ADDRESS.ADDRESS_ID == null || i_Donation.ITEM.ITEM_ID == 0) { throw new Exception("Foreign key ADDRESS_ID can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            i_Donation.ENTRY_DATE = DateTime.Today;
            int RETURNED_DONATION_ID = oDalc.EDIT_DONATION(i_Donation);

            return RETURNED_DONATION_ID;
        }
        #endregion

        #region DELETE_DONATION
        public void DELETE_DONATION(Int32 DONATION_ID)
        {
            if (DONATION_ID == null || DONATION_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.DELETE_DONATION(DONATION_ID);
        }
        #endregion

        #region SHIP_DONATION
<<<<<<< HEAD
        public void SHIP_DONATION(Int32 DONATION_ID, int IS_SHIPPED, string EMAIL)
        {
            if (DONATION_ID == null || DONATION_ID == 0) { throw new Exception("Primary key can't be null or empty"); }
           
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.SHIP_DONATION(DONATION_ID, IS_SHIPPED);
            
           
            if(IS_SHIPPED == 1)
            {
                Console.WriteLine(EMAIL);
                Console.WriteLine(IS_SHIPPED);
                MimeMessage message = new MimeMessage();

                MailboxAddress from = new MailboxAddress("Admin",
                "mohammedmansour1232000@gmail.com");
                message.From.Add(from);

                MailboxAddress to = new MailboxAddress("Donor",
                EMAIL);
                message.To.Add(to);

                message.Subject = "Your Donation has been shipped!";

                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<h2>Thank you for the donation!</h2>";
                bodyBuilder.HtmlBody += $"<h4>Your donation has been shipped at {DateTime.Now}</h4>";
                //bodyBuilder.TextBody = "You made a family happy";

                message.Body = bodyBuilder.ToMessageBody();

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.CheckCertificateRevocation = false;
                    smtpClient.Connect("smtp.gmail.com", 465, true);
                    smtpClient.Authenticate("mohammedmansour1232000@gmail.com", "mohammed/hamzi123123");
                    smtpClient.Send(message);
                    smtpClient.Disconnect(true);
                }
            }
                
            
=======
        public void SHIP_DONATION(Int32 DONATION_ID, int IS_SHIPPED)
        {
            if (DONATION_ID == null || DONATION_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.SHIP_DONATION(DONATION_ID, IS_SHIPPED);
>>>>>>> origin/temp004
        }
        #endregion

        #region Get_ITEMS
        public List<Item> Get_ITEMS()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            List<Item> oItems = new List<Item>();
            oItems = oDalc.GET_ITEMS();

            if (oItems.Count == 0) { throw new Exception("There are no items"); }

            return oItems;
        }

        #endregion

        #region GET_ITEM_BY_ID
        public Item GET_ITEM_BY_ID(Int32 iId)
        {
            if (iId == null || iId == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            Item oItem = new Item();
            oItem = oDalc.GET_ITEM_BY_ID(iId);

            if (oItem.ITEM_ID == null) { throw new Exception("Item doesn't exist"); }

            return oItem;
        }

        #endregion

        #region GET_ITEM_BY_CATEGORY_ID
        public List<Item> GET_ITEM_BY_CATEGORY_ID(Int32 iId)
        {
            if (iId == null || iId == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            List<Item> oItems = new List<Item>();
            oItems = oDalc.GET_ITEM_BY_CATEGORY_ID(iId);

            if (oItems.Count == 0) { throw new Exception("Item doesn't exist"); }

            return oItems;
        }

        #endregion

        #region GET_ITEM_BY_NAME
        public List<Item> GET_ITEM_BY_NAME(string name)
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            List<Item> oItem = new List<Item>();
            oItem = oDalc.GET_ITEM_BY_Name(name);

            if (oItem.Count == 0) { throw new Exception("Item doesn't exist"); }

            return oItem;
        }

        #endregion

        #region EDIT_ITEM
        public Int32 EDIT_ITEM(Item item)
        {
            if (item.ITEM_ID == null || item.ITEM_ID == 0) { throw new Exception("Primary key can't be null or empty"); }
            if (item.CATAGORY.CATAGORY_ID == null || item.CATAGORY.CATAGORY_ID == 0) { throw new Exception("Foreign key CATEGORY_ID can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            item.ENTRY_DATE = DateTime.Today;
            int RETURNED_ITEM_ID = oDalc.EDIT_ITEM(item);

            return RETURNED_ITEM_ID;
        }

        #endregion

        #region DELETE_ITEM
        public void DELETE_ITEM(Int32 iId)
        {
            if (iId == null || iId == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.DELETE_Item(iId);

        }

        #endregion



        #region Get_UPLOADED_FILE
        public List<UploadFile> Get_UPLOADED_FILE()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            List<UploadFile> oUploadedFiles = new List<UploadFile>();
            oUploadedFiles = oDalc.GET_UPLOADED_FILE();

            if (oUploadedFiles.Count == 0) { throw new Exception("There are no Uploaded Files"); }

            return oUploadedFiles;
        }

        #endregion


        #region Get UPLOADED_FILE_BY_ID

        public UploadFile GET_UPLOADED_FILE_BY_ID(int uId)
        {
            if (uId == null || uId == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            UploadFile oUploadedFiles = new UploadFile();
            oUploadedFiles = oDalc.GET_UPLOADED_FILE_BY_ID(uId);

            if (oUploadedFiles.UPLOADED_FILE_ID == null) { throw new Exception("File doesn't exist"); }

            return oUploadedFiles;
        }

        #endregion

        #region Get UPLOADED_FILE_BY_CATEGORY_ID

        public UploadFile GET_UPLOADED_FILE_BY_CATEGORY_ID(int uId)
        {
            if (uId == null || uId == 0) { throw new Exception("value can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            UploadFile oUploadedFiles = new UploadFile();
            oUploadedFiles = oDalc.GET_UPLOADED_FILE_BY_CATEGORY_ID(uId);

            if (oUploadedFiles.UPLOADED_FILE_ID == null) { throw new Exception("File doesn't exist"); }

            return oUploadedFiles;
        }

        #endregion


        #region Get GET_UPLOADED_FILE_BY_ITEM_ID
        public UploadFile GET_UPLOADED_FILE_BY_ITEM_ID(int uId)
        {
            if (uId == null || uId == 0) { throw new Exception("value can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            UploadFile oUploadedFiles = new UploadFile();
            oUploadedFiles = oDalc.GET_UPLOADED_FILE_BY_ITEM_ID(uId);

            if (oUploadedFiles.UPLOADED_FILE_ID == null) { throw new Exception("File doesn't exist"); }

            return oUploadedFiles;
        }

        #endregion

        #region GET_UPLOADED_FILE_BY_DONATION_ID
        public List<UploadFile> GET_UPLOADED_FILE_BY_DONATION_ID(int uId)
        {
            if (uId == null || uId == 0) { throw new Exception("value can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            List<UploadFile> oUploadedFiles = new List<UploadFile>();
            oUploadedFiles = oDalc.GET_UPLOADED_FILE_BY_DONATION_ID(uId);

            if (oUploadedFiles.Count == 0) { throw new Exception("File doesn't exist"); }

            return oUploadedFiles;
        }

        #endregion

        #region DELETE_UPLOADED_FILE
        public void DELETE_UPLOADED_FILE(Int32 iId)
        {
            if (iId == null || iId == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.DELETE_UPLOADED_FILE(iId);

        }

        #endregion


        #region EDIT_UPLOADED_FILE
        public Int32 EDIT_UPLOADED_FILE(UploadFile uploadFile)
        {
            if (uploadFile.UPLOADED_FILE_ID == null || uploadFile.UPLOADED_FILE_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;

            uploadFile.ENTRY_DATE = DateTime.Today;
            int RETURNED_UPLOADED_FILE_ID = oDalc.EDIT_UPLOADED_FILE(uploadFile);

            return RETURNED_UPLOADED_FILE_ID;
        }
        #endregion


        #region Get_Category
        public List<Category> Get_Category()
        {
            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            List<Category> oCategory = new List<Category>();
            oCategory = oDalc.Get_Category();

            if (oCategory.Count == 0) { throw new Exception("There are no Categories"); }

            return oCategory;
        }

        #endregion

        #region GET_CATEGORY_BY_ID

        public Category GET_CATEGORY_BY_ID(int uId)
        {
            if (uId == null || uId == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            Category oCategory = new Category();
            oCategory = oDalc.GET_CATEGORY_BY_ID(uId);

            if (oCategory.CATAGORY_ID == null) { throw new Exception("Category doesn't exist"); }

            return oCategory;
        }

        #endregion

        #region DELETE_CATEGORY
        public void DELETE_CATEGORY(Int32 iId)
        {
            if (iId == null || iId == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            oDalc.DELETE_CATEGORY(iId);

        }

        #endregion

        #region EDIT_CATEGORY
        public Int32 EDIT_CATEGORY(Category category)
        {
            if (category.CATAGORY_ID == null || category.CATAGORY_ID == 0) { throw new Exception("Primary key can't be null or empty"); }

            DALC.DALC oDalc = new DALC.DALC();
            oDalc.ConnectionString = this.ConnectionString;
            category.ENTRY_DATE = DateTime.Today;

            int RETURNED_UPLOADED_FILE_ID = oDalc.EDIT_CATEGORY(category);

            return RETURNED_UPLOADED_FILE_ID;
        }
        #endregion

        #region EncryptString
        public static string EncryptString(string text, string keyString)
        {
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = System.Security.Cryptography.Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }
        #endregion

        #region DecryptString
        public static string DecryptString(string cipherText, string keyString)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = System.Security.Cryptography.Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }
        #endregion


    }
}
