using BestSignSDK.Result;
using System;
using System.Collections.Generic;

namespace BestSignSDK.API
{
    public class UserSerivceAPI
    {
        private IHttpService httpService;

        public UserSerivceAPI()
        {
            httpService = new HttpService();
        }

        /// <summary>
        /// 注册个人用户并申请证书 | 注册企业用户并申请证书
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        /// <param name="name">用户名称</param>
        /// <param name="userType">用户类型</param>
        /// <param name="credential">用户证件信息对象</param>
        /// <param name="applyCert"></param>
        /// <param name="mail">用户邮箱</param>
        /// <param name="mobile">用户手机号</param>
        /// <returns></returns>
        public BaseResult<RegResult> Reg(string account, string name, string userType, object credential, string applyCert, string mail = "", string mobile = "")
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);
            requestParams.Add("name", name);
            requestParams.Add("userType", userType);
            requestParams.Add("mail", mail);
            requestParams.Add("mobile", mobile);
            requestParams.Add("credential", credential);
            requestParams.Add("applyCert", applyCert);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.User_Reg, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.User_Reg;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<RegResult> result =  httpService.HttpPost<BaseResult<RegResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 查询证书编号
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        public BaseResult<GetCertResult> GetCert(string account)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.User_GetCert, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.User_GetCert;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<GetCertResult> result = httpService.HttpPost<BaseResult<GetCertResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 查询个人用户证件信息
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        public BaseResult<GetPersonalCredentialResult> GetPersonalCredential(string account)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.User_GetPersonalCredential, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.User_GetPersonalCredential;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<GetPersonalCredentialResult> result = httpService.HttpPost<BaseResult<GetPersonalCredentialResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 查询企业用户证件信息
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        public BaseResult<GetEnterpriseCredentialResult> GetEnterpriseCredential(string account)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.User_GetEnterpriseCredential, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.User_GetEnterpriseCredential;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<GetEnterpriseCredentialResult> result = httpService.HttpPost<BaseResult<GetEnterpriseCredentialResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 异步申请状态查询
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        /// <param name="taskId">任务单号</param>
        /// <returns></returns>
        public BaseResult<AsyncApplyCertStatusResult> AsyncApplyCertStatus(string account, string taskId)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);
            requestParams.Add("taskId", taskId);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);


            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.User_Async_ApplyCert_Status, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.User_Async_ApplyCert_Status;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<AsyncApplyCertStatusResult> result = httpService.HttpPost<BaseResult<AsyncApplyCertStatusResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 获取证书详细信息
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        /// <param name="certId">证书编号</param>
        /// <returns></returns>
        public BaseResult<CertInfoResult> CertInfo(string account, string certId)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);
            requestParams.Add("certId", certId);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);


            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.User_Cert_Info, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.User_Cert_Info;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<CertInfoResult> result = httpService.HttpPost<BaseResult<CertInfoResult>>(requestUrl, requestParams);
            return result;
        }
    }
}
