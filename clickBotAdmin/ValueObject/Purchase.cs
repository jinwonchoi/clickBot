using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickBot.ValueObject
{
    public class Purchase
    {
        int purchaseId;
        public int PurchaseId
        {
            get { return purchaseId; }
            set { purchaseId = value; }
        }
        string userId;
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        string productId;
        public string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        string deviceType;
        public string DeviceType
        {
            get { return deviceType; }
            set { deviceType = value; }
        }
        string siteType;
        public string SiteType
        {
            get { return siteType; }
            set { siteType = value; }
        }
        string taskType;
        public string TaskType
        {
            get { return taskType; }
            set { taskType = value; }
        }
        string purchaseDate;
        public string PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }
        int purchaseAmount;
        public int PurchaseAmount
        {
            get { return purchaseAmount; }
            set { purchaseAmount = value; }
        }        
        string purchaseType;
        public string PurchaseType
        {
            get { return purchaseType; }
            set { purchaseType = value; }
        }
        string usedFlag;
        public string UsedFlag
        {
            get { return usedFlag; }
            set { usedFlag = value; }
        }
        string createDate;
        public string CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        string updateDate;
        public string UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }

        public override string ToString()
        {
            return productName+"/" + companyName + "(" + purchaseId + ")";
        }
    }
}
