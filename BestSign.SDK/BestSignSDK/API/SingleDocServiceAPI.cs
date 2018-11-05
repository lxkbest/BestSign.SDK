using BestSignSDK.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK.API
{
    public class SingleDocServiceAPI
    {
        private IHttpService httpService;

        public SingleDocServiceAPI()
        {
            httpService = new HttpService();
        }

        /// <summary>
        /// 上传并创建合同
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        /// <param name="fmd5">文件md5值</param>
        /// <param name="ftype">文件类型</param>
        /// <param name="fname">文件名</param>
        /// <param name="fpages">文件页数</param>
        /// <param name="fdata">文件数据，base64编码</param>
        /// <param name="title">合同标题</param>
        /// <param name="expireTime">合同能够签署的截止时间</param>
        /// <param name="description">合同描述</param>
        /// <param name="hotStoragePeriod">热存周期</param>
        /// <returns></returns>
        public BaseResult<StorageContractUploadResult> Upload(string account, string fmd5, string ftype, string fname, string fpages, string  fdata, string title, string expireTime, string description = "", string hotStoragePeriod = "")
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);
            requestParams.Add("fmd5", fmd5);
            requestParams.Add("ftype", ftype);
            requestParams.Add("fname", fname);
            requestParams.Add("fpages", fpages);
            requestParams.Add("fdata", fdata);
            requestParams.Add("title", title);
            requestParams.Add("expireTime", expireTime);
            if (!string.IsNullOrWhiteSpace(description))
                requestParams.Add("description", description);
            if (!string.IsNullOrWhiteSpace(hotStoragePeriod))
                requestParams.Add("hotStoragePeriod", hotStoragePeriod);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Storage_Contract_Upload, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Storage_Contract_Upload;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<StorageContractUploadResult> result = httpService.HttpPost<BaseResult<StorageContractUploadResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 签署合同（即自动签）
        /// </summary>
        /// <param name="contractId">合同编号</param>
        /// <param name="signer">签署者</param>
        /// <param name="signaturePositions">指定的签署位置，json array格式</param>
        /// <param name="signatureImageName">签名图片名称</param>
        /// <param name="signatureImageData">签名图片</param>
        /// <param name="signatureImageWidth">签名图片显示宽度</param>
        /// <param name="signatureImageHeight">签名图片显示高度</param>
        /// <returns></returns>
        public BaseResult<CommonResult> SignCert(string contractId, string signer, object signaturePositions, string signatureImageName = "",
            string signatureImageData = "", string signatureImageWidth = "", string signatureImageHeight = "")
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("contractId", contractId);
            requestParams.Add("signer", signer);
            requestParams.Add("signaturePositions", signaturePositions);
            if (!string.IsNullOrWhiteSpace(signatureImageName))
                requestParams.Add("signatureImageName", signatureImageName);
            if (!string.IsNullOrWhiteSpace(signatureImageData))
                requestParams.Add("signatureImageData", signatureImageData);
            if (!string.IsNullOrWhiteSpace(signatureImageWidth))
                requestParams.Add("signatureImageWidth", signatureImageWidth);
            if (!string.IsNullOrWhiteSpace(signatureImageHeight))
                requestParams.Add("signatureImageHeight", signatureImageHeight);
 

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Storage_Contract_Sign_Cert, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Storage_Contract_Sign_Cert;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<CommonResult> result = httpService.HttpPost<BaseResult<CommonResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 发送合同（即手动签，指定图片大小）
        /// </summary>
        /// <param name="contractId">合同编号</param>
        /// <param name="signer">指定给哪个用户看</param>
        /// <param name="dpi">预览图片清晰度，枚举值：96-低清（默认），120-普清，160-高清，240-超清</param>
        /// <param name="signaturePositions">json array格式</param>
        /// <param name="isAllowChangeSignaturePosition">在有指定signaturePOSTion参数的情况下，是否允许拖动签名位置。取值1/0。（0：不允许，1：允许）</param>
        /// <param name="expireTime">签署链接的到期时间，unix时间戳格式（秒数）</param>
        /// <param name="returnUrl">签署页面指定回跳的页面地址</param>
        /// <param name="vcodeMobile">手动签署时指定接收手机验证码的手机号</param>
        /// <param name="isDrawSignatureImage">手动签署时是否手绘签名</param>
        /// <param name="signatureImageName">签名/印章图片</param>
        /// <param name="sid">开发者自定义的签署流水号</param>
        /// <param name="pushUrl">异步推送地址</param>
        /// <param name="version">手动签的版本</param>
        /// <param name="readAll">无需拖动到页面底部即可确认签署</param>
        /// <param name="app">人脸比对签署</param>
        /// <param name="signatureImageWidth">本次签署使用的签名/印章图片在合同PDF上显示的宽度</param>
        /// <param name="signatureImageHeight">本次签署使用的签名/印章图片在合同PDF上显示的高度</param>
        /// <param name="isShowHandwrittenTime">不显示该时间</param>
        /// <param name="isFaceAuth">是否使用刷脸签</param>
        /// <returns></returns>
        public BaseResult<CommonResult> Send(string contractId, string signer, string dpi, object signaturePositions,
            int isAllowChangeSignaturePosition = 0, long expireTime = 0, string returnUrl = "", string vcodeMobile = "", int isDrawSignatureImage = 1, string signatureImageName = "",
            string sid = "", string pushUrl = "", string version = "", int readAll = 0 , string app = "", string signatureImageWidth = "", string signatureImageHeight = "", int isShowHandwrittenTime = 0,
            int isFaceAuth = 0)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("contractId", contractId);
            requestParams.Add("signer", signer);
            requestParams.Add("signaturePositions", signaturePositions);
            if (isAllowChangeSignaturePosition != 0)
                requestParams.Add("isAllowChangeSignaturePosition", isAllowChangeSignaturePosition);
            if (expireTime != 0)
                requestParams.Add("expireTime", expireTime);
            if (!string.IsNullOrWhiteSpace(returnUrl))
                requestParams.Add("returnUrl", returnUrl);
            if (!string.IsNullOrWhiteSpace(vcodeMobile))
                requestParams.Add("vcodeMobile", vcodeMobile);
            if (isDrawSignatureImage != 1)
                requestParams.Add("isDrawSignatureImage", isDrawSignatureImage);
            if (!string.IsNullOrWhiteSpace(signatureImageName))
                requestParams.Add("signatureImageName", signatureImageName);
            if (string.IsNullOrWhiteSpace(sid))
                requestParams.Add("sid", sid);
            if (!string.IsNullOrWhiteSpace(pushUrl))
                requestParams.Add("pushUrl", pushUrl);
            if (!string.IsNullOrWhiteSpace(version))
                requestParams.Add("version", version);
            if (readAll != 0)
                requestParams.Add("readAll", readAll);
            if (!string.IsNullOrWhiteSpace(app))
                requestParams.Add("app", app);
            if (!string.IsNullOrWhiteSpace(signatureImageWidth))
                requestParams.Add("signatureImageWidth", signatureImageWidth);
            if (!string.IsNullOrWhiteSpace(signatureImageHeight))
                requestParams.Add("signatureImageHeight", signatureImageHeight);
            if (isShowHandwrittenTime != 0)
                requestParams.Add("isShowHandwrittenTime", isShowHandwrittenTime);
            if (isFaceAuth != 0)
                requestParams.Add("isFaceAuth", isFaceAuth);


            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Contract_Send, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Contract_Send;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<CommonResult> result = httpService.HttpPost<BaseResult<CommonResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 撤销合同
        /// </summary>
        /// <param name="contractId">合同编号</param>
        /// <returns></returns>
        public BaseResult<CommonResult> Cancel(string contractId)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("contractId", contractId);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Contract_Cancel, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Contract_Cancel;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<CommonResult> result = httpService.HttpPost<BaseResult<CommonResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 锁定并结束合同
        /// </summary>
        /// <param name="contractId">合同编号</param>
        /// <returns></returns>
        public BaseResult<CommonResult> Lock(string contractId)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("contractId", contractId);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Storage_Contract_Lock, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);

            keyValues.Add("sign", signEncryResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Storage_Contract_Lock;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<CommonResult> result = httpService.HttpPost<BaseResult<CommonResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 查询合同信息
        /// </summary>
        /// <param name="contractId">合同编号</param>
        /// <returns></returns>
        public BaseResult<GetInfoResult> GetInfo(string contractId)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("contractId", contractId);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Contract_GetInfo, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Contract_GetInfo;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<GetInfoResult> result = httpService.HttpPost<BaseResult<GetInfoResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 获取合同签署参数
        /// </summary>
        /// <param name="contractId">合同编号</param>
        /// <param name="account">签署者</param>
        /// <returns></returns>
        public BaseResult<GetSignerConfigResult> GetSignerConfig(string contractId, string account)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("contractId", contractId);
            requestParams.Add("account", account);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Contract_GetSignerConfig, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Contract_GetSignerConfig;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<GetSignerConfigResult> result = httpService.HttpPost<BaseResult<GetSignerConfigResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 查询合同签署者状态
        /// </summary>
        /// <param name="contractId">合同编号</param>
        /// <returns></returns>
        public BaseResult<GetSignerStatusResult> GetSignerStatus(string contractId)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("contractId", contractId);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Contract_GetSignerStatus, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Contract_GetSignerStatus;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<GetSignerStatusResult> result = httpService.HttpPost<BaseResult<GetSignerStatusResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 下载合同文件
        /// </summary>
        /// <param name="contractId">合同编号</param>
        /// <returns></returns>
        public bool Download(string contractId, string path)
        {
            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("contractId", contractId);
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Contract_Download, "", keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Contract_Download;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            var result = httpService.HttpDownload(requestUrl, path);
            return result;
        }

        /// <summary>
        /// 获取预览页URL
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        public BaseResult<GetPreviewURLResult> GetPreviewURL(string contractId, string expireTime, string dpi = "", string account = "")
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("contractId", contractId);
            requestParams.Add("expireTime", expireTime);
            if (string.IsNullOrWhiteSpace(dpi))
                requestParams.Add("dpi", dpi);
            if (string.IsNullOrWhiteSpace(account))
                requestParams.Add("account", account);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Contract_GetPreviewURL, "", keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Contract_GetPreviewURL;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<GetPreviewURLResult> result = httpService.HttpPost<BaseResult<GetPreviewURLResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 创建合同
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        /// <param name="fid">文件编号</param>
        /// <param name="expireTime">合同能够签署的截止时间</param>
        /// <param name="title">合同标题</param>
        /// <param name="description">合同描述</param>
        /// <param name="hotStoragePeriod">热存周期</param>
        /// <returns></returns>
        public BaseResult<CreateResult> Create(string account, string fid, string expireTime, string title, string description = "", string hotStoragePeriod = "")
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);
            requestParams.Add("fid", fid);
            requestParams.Add("expireTime", expireTime);
            requestParams.Add("title", title);

            if (string.IsNullOrWhiteSpace(description))
                requestParams.Add("description", description);
            if (string.IsNullOrWhiteSpace(hotStoragePeriod))
                requestParams.Add("hotStoragePeriod", hotStoragePeriod);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Contract_Create, "", keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Contract_Create;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<CreateResult> result = httpService.HttpPost<BaseResult<CreateResult>>(requestUrl, requestParams);
            return result;
        }
    }
}
