using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketGate.Helper
{
    /// <summary>
    /// 检票帮助类
    /// </summary>
    public class VerifyTicketHelper
    {
        /// <summary>
        /// 青岛检票API请求
        /// </summary>
        /// <param name="verify"></param>
        /// <returns></returns>
        public static ApiResult_QD<VerifyTicketResult_QD> VerifyTicket_QD(VerifyTicket_QD verify, string webUrl, TokenStyle token)
        {
            if (verify == null)
                return ApiResultHelper_QD<VerifyTicketResult_QD>.getFailApiResult("检票参数不正确", null);
            if (string.IsNullOrEmpty(webUrl))
                return ApiResultHelper_QD<VerifyTicketResult_QD>.getFailApiResult("没有找到管理后台地址，请检查配置文件", null);
            var result = ApiHelper.SendDataToApiService_QD<VerifyTicketResult_QD>(
                string.Format("{0}/api/v1/VerifyTicket", webUrl), "POST", JsonConvert.SerializeObject(verify), token);
            return result;
        }

        /// <summary>
        /// 青岛登录API请求
        /// </summary>
        /// <param name="verify"></param>
        /// <returns></returns>
        public static ApiResult_QD<AccountInfo> Login_QD(LoginInfo verify, string webUrl, TokenStyle token)
        {
            if (verify == null)
                return ApiResultHelper_QD<AccountInfo>.getFailApiResult("参数不正确", null);
            if (string.IsNullOrEmpty(webUrl))
                return ApiResultHelper_QD<AccountInfo>.getFailApiResult("没有找到管理后台地址，请检查配置文件", null);
            var result = ApiHelper.SendDataToApiService_QD<AccountInfo>(
                string.Format("{0}/api/v1/Accounts/login", webUrl), "POST", JsonConvert.SerializeObject(verify),token);
            return result;
        }

        /// <summary>
        /// 获取服务器登录令牌
        /// </summary>
        /// <returns></returns>
        public static TokenStyle GetToken(string webUrl)
        {
            return ApiHelper.GetTokenString(string.Format("{0}/connect/token", webUrl));
        }

        /// <summary>
        /// 大容山检票
        /// </summary>
        /// <param name="verify"></param>
        /// <returns></returns>
        public static ApiResult<selled_ticket> VerifyTicket(VerifyTicket verify, string webUrl)
        {
            if (verify == null)
                return ApiResultHelper<selled_ticket>.getFailApiResult("检票参数不正确", null);
            if (string.IsNullOrEmpty(webUrl))
                return ApiResultHelper<selled_ticket>.getFailApiResult("没有找到管理后台地址，请检查配置文件", null);

            var gateUrl = ApiHelper.GetTicketGateWayUrl(webUrl);
            if (string.IsNullOrEmpty(gateUrl))
                return ApiResultHelper<selled_ticket>.getFailApiResult("没有找到前置网关地址", null);

            var result = ApiHelper.SendDataToApiService<selled_ticket>(
                string.Format("{0}verifyticket/api/verifyticket/verifyticket", gateUrl)
                , "POST", JsonConvert.SerializeObject(verify));

            return result;
        }

        /// <summary>
        /// 获取市民卡持卡人的个人信息
        /// </summary>
        /// <param name="verify"></param>
        /// <returns></returns>
        public static ApiResult<CitizenCardPerson> GetCitizenCardPerson(string cardNo, string webUrl)
        {
            if (string.IsNullOrEmpty(cardNo))
                return ApiResultHelper<CitizenCardPerson>.getFailApiResult("市民卡号码不能为空", null);
            if (string.IsNullOrEmpty(webUrl))
                return ApiResultHelper<CitizenCardPerson>.getFailApiResult("没有找到管理后台地址，请检查配置文件", null);

            var gateUrl = ApiHelper.GetTicketGateWayUrl(webUrl);
            if (string.IsNullOrEmpty(gateUrl))
                return ApiResultHelper<CitizenCardPerson>.getFailApiResult("没有找到前置网关地址", null);

            var result = ApiHelper.SendDataToApiService<CitizenCardPerson>(
                string.Format("{0}citizencard/api/citizencard/getcitizencardperson?cardNo={1}"
                , gateUrl, System.Uri.EscapeUriString(cardNo))
                , "GET", string.Empty);

            return result;
        }
    }
}
