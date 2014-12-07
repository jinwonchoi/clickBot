using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickBot.ValueObject
{
    class UserInfo
    {
        string userId;
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        string passwd;
        public string Passwd
        {
            get { return passwd; }
            set { passwd = value; }
        }
        string userType;
        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }
        string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        string mobile;
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        string etc;
        public string Etc
        {
            get { return etc; }
            set { etc = value; }
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
            return companyName + "(" + userId + ")";
        }
    }
}
