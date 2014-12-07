using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickBot.ValueObject
{
    public class Product
    {
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
        int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
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
            return productName + "(" + productId + ")";
        }
    }
}
