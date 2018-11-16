using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PocketGate
{
    /// <summary>
    /// 检票参数对象
    /// </summary>
    public class VerifyTicket
    {
        /// <summary>
        /// 票号
        /// </summary>
        public string ticketNo { set; get; }
        
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDCard { set; get; }

        /// <summary>
        /// 市民卡号码
        /// </summary>
        public string citizenCard { set; get; }

        /// <summary>
        /// 指纹信息
        /// </summary>
        public string fingerprint { set; get; }

        /// <summary>
        /// 闸机设备编号
        /// </summary>
        public string gateId { set; get; }

        /// <summary>
        /// 是否支持指纹检票（1表示支持，其他表示不支持）
        /// </summary>
        public string isfingerprint { get; set; }
    }

    /// <summary>
    /// 检票返回结果信息
    /// </summary>
    public class selled_ticket
    {
        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 主票Id
        /// </summary>
        public string MainTicketId { get; set; }

        /// <summary>
        /// 子票Id
        /// </summary>
        public string SubTicketId { get; set; }

        /// <summary>
        /// 票编号
        /// </summary>
        public string TicketNo { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string TicketOrderNo { get; set; }

        /// <summary>
        /// 门票名称
        /// </summary>
        public string TicketName { get; set; }

        /// <summary>
        /// 类型Id
        /// </summary>
        public string TicketTypeId { get; set; }

        /// <summary>
        /// 门票分类Id
        /// </summary>
        public string TicketCategoryId { get; set; }

        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal TicketPrice { get; set; }

        /// <summary>
        /// 实际支付金额
        /// </summary>
        public decimal TicketPayPrice { get; set; }

        /// <summary>
        /// 使用人数
        /// </summary>
        public int TicketLimitPerson { get; set; }

        /// <summary>
        /// 可玩景点数
        /// </summary>
        public int OptionalSpots { get; set; }

        /// <summary>
        /// 已玩景点数
        /// </summary>
        public int UsedTimes { get; set; }

        /// <summary>
        /// 票的状态
        /// </summary>
        public string TicketStatus { get; set; }

        /// <summary>
        /// 有效期开始时间
        /// </summary>
        public DateTime TicketStartTime { get; set; }

        /// <summary>
        /// 有效期结束时间
        /// </summary>
        public DateTime TicketEndTime { get; set; }

        /// <summary>
        /// 售票员编号
        /// </summary>
        public string TicketSellUserId { get; set; }

        /// <summary>
        /// 售票时间
        /// </summary>
        public DateTime TicketSellTime { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// 售票方式：窗口(window)、网络(network)
        /// </summary>
        public string SellTicketType { get; set; }

        /// <summary>
        /// 日结时间
        /// </summary>
        public DateTime? DayEndTime { get; set; }

    }

    /// <summary>
    /// 市民卡二维码信息
    /// </summary>
    public class CityCardQCode
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string card_no { get; set; }

        /// <summary>
        /// 有效时间开始
        /// </summary>
        public DateTime start_time { get; set; }

        /// <summary>
        /// 有效时间结束
        /// </summary>
        public DateTime end_time { get; set; }
    }

    /// <summary>
    /// 市民卡持卡人个人信息
    /// </summary>
    public class CitizenCardPerson
    {
        /// <summary>
        /// 出生年月
        /// </summary>
        public string birthday { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string cert_type { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>
        public string cert_no { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile_no { get; set; }

        /// <summary>
        /// 国籍（国家标准编码）
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 民族（国家标准编码）
        /// </summary>
        public string nation { get; set; }

        /// <summary>
        /// 乡镇编号
        /// </summary>
        public string town_id { get; set; }

        /// <summary>
        /// 社区编号
        /// </summary>
        public string comm_id { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string letter_addr { get; set; }

        /// <summary>
        /// 居住地址
        /// </summary>
        public string reside_addr { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string company { get; set; }

        /// <summary>
        /// 客户照片字节流
        /// </summary>
        public string photo { get; set; }
    }

    /// <summary>
    /// 检票服务接收参数对象
    /// </summary>
    public class VerifyTicket_QD
    {
        /// <summary>
        /// 票号
        /// </summary>
        public string ticketNo { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string idCard { get; set; }

        /// <summary>
        /// ic卡号码
        /// </summary>
        public string icCard { get; set; }

        /// <summary>
        /// 指纹信息
        /// </summary>
        public string fingerprint { set; get; }

        /// <summary>
        /// 人脸信息
        /// </summary>
        public string face { set; get; }

        /// <summary>
        /// 检票设备编码
        /// </summary>
        public string deviceCode { get; set; }

        /// <summary>
        /// 检票设备IP地址
        /// </summary>
        public string deviceIP { get; set; }

        /// <summary>
        /// 检票设备mac地址
        /// </summary>
        public string deviceMAC { get; set; }
    }
    
    /// <summary>
    /// 检票返回结果对象
    /// </summary>
    public class VerifyTicketResult_QD
    {
        /// <summary>
        /// 票号
        /// </summary>
        public string TicketNo { get; set; }

        /// <summary>
        /// 票种名称
        /// </summary>
        public string TicketTypeName { get; set; }

        /// <summary>
        /// 票型名称
        /// </summary>
        public string TicketMouldName { get; set; }

        /// <summary>
        /// 票价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 可通过人数
        /// </summary>
        public int PeopleNum { get; set; }

        /// <summary>
        /// 有效期开始时间
        /// </summary>
        public DateTime TicketStartTime { get; set; }

        /// <summary>
        /// 有效期结束时间
        /// </summary>
        public DateTime TicketEndTime { get; set; }

        /// <summary>
        /// 有效期剩余天数
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// 游客姓名
        /// </summary>
        public string VisitorName { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// ic卡名称
        /// </summary>
        public string IcCardName { get; set; }

        /// <summary>
        /// ic卡号码
        /// </summary>
        public string IcCardNo { get; set; }

        /// <summary>
        /// 音频文件索引
        /// </summary>
        public int SoundIndex { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// 门票类型（团队/散客）
        /// </summary>
        public string TicketMode { get; set; }
    }
}
