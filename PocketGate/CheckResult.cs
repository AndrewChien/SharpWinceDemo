using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PocketGate
{
    public class CheckResult
    {
        public string Result;
        public string Tips;

    }

    public class TicketInfo
    {
        public string TicketNo;
        public string Name;
        public string TicketType;
        public string Price;
        public string SellTime;
        public string Number;
        public string Music;
        public string Error;
        public Bitmap ShowImg;
    }

    public class Result
    {
        public CheckResult CheckResult;
    }

    public class TicketInfo_QD : VerifyTicketResult_QD
    {
        public string Music;
        public string Error;
    }

    /// <summary>
    /// 登录信息model
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }

    public class AccountModel
    {
        /// <summary>
        /// 账号Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>  
        public string Password { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 景点id
        /// </summary>  
        public string SpotId { get; set; }
        /// <summary>
        /// 景区id
        /// </summary>
        public string ScenicId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public string IsEnable { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string Creater { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string Modifier { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiTime { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleId { get; set; }

        // <summary>
        /// 用户类型
        /// </summary>
        public string UserType { get; set; }
    }

    //public enum Usertype
    //{
    //    normal,
    //    admin
    //}

    public class AccountInfo : AccountModel
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
    }
}
