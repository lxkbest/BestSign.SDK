using BestSignSDK.Result;
using System;
using System.Collections.Generic;

namespace BestSignSDK.API
{
    public class SignatureServiceAPI
    {
        private IHttpService httpService;

        public SignatureServiceAPI()
        {
            httpService = new HttpService();
        }

        /// <summary>
        /// 生成用户签名/印章图片
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        /// <param name="text">签名/印章图片上生成的文本</param>
        /// <param name="fontName">字体名称（仅针对个人类型账号有效）</param>
        /// <param name="fontSize">字号（仅针对个人类型账号有效）</param>
        /// <param name="fontColor">字体颜色（仅针对个人类型账号有效）</param>
        /// <returns></returns>
        public BaseResult<CommonResult> UserCreate(string account, string text = "", string fontName = "", int fontSize = 0, string fontColor = "")
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);
            if (string.IsNullOrWhiteSpace(text))
                requestParams.Add("text", text);
            if (string.IsNullOrWhiteSpace(fontName))
                requestParams.Add("fontName", fontName);
            if (fontSize > 0)
                requestParams.Add("fontSize", fontSize);
            if (string.IsNullOrWhiteSpace(fontColor))
                requestParams.Add("fontColor", fontColor);


            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.SignatureImage_User_Create, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.SignatureImage_User_Create;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<CommonResult> result = httpService.HttpPost<BaseResult<CommonResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 上传用户签名/印章图片
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        /// <param name="imageData">图片文件内容</param>
        /// <param name="imageName">签名/印章图片名称</param>
        /// <returns></returns>
        public BaseResult<CommonResult> UserUpload(string account, string imageData, string imageName = "")
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);
            requestParams.Add("imageData", imageData);
            if (string.IsNullOrWhiteSpace(imageName))
                requestParams.Add("imageName", imageName);


            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.SignatureImage_User_Upload, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.SignatureImage_User_Upload;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<CommonResult> result = httpService.HttpPost<BaseResult<CommonResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 下载用户签名/印章图片
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        /// <param name="imageName">签名/印章图片名称</param>
        /// <returns></returns>
        public BaseResult<CommonResult> UserDownload(string account, string imageName = "default")
        {
            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("account", account);
            keyValues.Add("imageName", imageName);
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.SignatureImage_User_Download, "", keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.SignatureImage_User_Download;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<CommonResult> result = httpService.HttpGet<BaseResult<CommonResult>>(requestUrl);
            return result;
        }
    }
}
