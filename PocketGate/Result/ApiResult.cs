using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace PocketGate
{
    /// <summary>
    /// api返回结果类
    /// </summary>
    public class ApiResult<T>
    {
        public ApiResult()
        {
            code = (int)HttpStatusCode.OK;
        }

        /// <summary>
        /// 成功或者失败标志
        /// </summary>
        public bool flag { get; set; }

        /// <summary>
        /// 返回结果编码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public T oData { get; set; }
    }

    public class ApiPageResult<T> : ApiResult<T>
    {
        /// <summary>
        /// 页号
        /// </summary>
        public int pageIndex { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int pageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public long total { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount
        {
            get
            {
                if (pageSize <= 0) return 0;

                return (int)Math.Ceiling((double)total / pageSize);
            }
        }
    }

    /// <summary>
    /// Api返回结果助手
    /// </summary>
    public class ApiResultHelper<T>
    {
        /*
        public static ApiResult<T> getSuccessApiResult(string msg, T oData)
        {
            return new ApiResult<T> { flag = true, msg = msg, oData = oData };
        }
        */

        public static ApiResult<T> getFailApiResult(string msg, T oData)
        {
            return new ApiResult<T> { flag = false, msg = msg, oData = oData };
        }
    }

    /// <summary>
    /// api返回结果类（青岛）
    /// </summary>
    public class ApiResult_QD<T>
    {
        public ApiResult_QD()
        {

        }

        /// <summary>
        /// 成功或者失败标志
        /// </summary>
        public bool isSuc { get; set; }

        /// <summary>
        /// 是否验证错误
        /// </summary>
        public bool isValidFail { get; set; }

        /// <summary>
        /// 返回类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
    }

   /// <summary>
   /// （青岛项目用）
   /// </summary>
   /// <typeparam name="T"></typeparam>
    public class ApiPageResult_QD<T> : ApiResult_QD<T>
    {
        /// <summary>
        /// 页号
        /// </summary>
        public int pageIndex { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int pageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public long total { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount
        {
            get
            {
                if (pageSize <= 0) return 0;

                return (int)Math.Ceiling((double)total / pageSize);
            }
        }
    }

    /// <summary>
    /// Api返回结果助手（_青岛）
    /// </summary>
    public class ApiResultHelper_QD<T>
    {
        /*
        public static ApiResult<T> getSuccessApiResult(string msg, T oData)
        {
            return new ApiResult<T> { flag = true, msg = msg, oData = oData };
        }
        */

        public static ApiResult_QD<T> getFailApiResult(string msg, T oData)
        {
            return new ApiResult_QD<T> { isSuc = false, msg = msg, Data = oData };
        }
    }

    public class ServerToken
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string grant_type { get; set; }
        public string scope { get; set; }
    }

    public class TokenStyle
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
    }
}
