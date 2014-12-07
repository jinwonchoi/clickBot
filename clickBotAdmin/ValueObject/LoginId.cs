using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickBot.ValueObject
{
    public class LoginIdInfo
    {
        string loginId;
        public string LoginId
        {
            get { return loginId; }
            set { loginId = value; }
        }
        string passwd;
        public string Passwd
        {
            get { return passwd; }
            set { passwd = value; }
        }
        string idType;
        public string IdType
        {
            get { return idType; }
            set { idType = value; }
        }
        string userId;
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
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
            return "LoginId("+loginId + ":" + passwd + ":"+idType+":"+idType+")";
        }
    }
}
