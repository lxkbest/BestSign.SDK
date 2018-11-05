using BestSignSDK.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK.API
{
    public class StorageServiceAPI
    {
        private IHttpService httpService;

        public StorageServiceAPI()
        {
            httpService = new HttpService();
        }

        /// <summary>
        /// 上传合同文件
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        /// <param name="fdata">文件数据，base64编码</param>
        /// <param name="fmd5">文件md5值</param>
        /// <param name="ftype">文件类型</param>
        /// <param name="fname">文件名</param>
        /// <param name="fpages">文件页数</param>
        /// <returns></returns>
        public BaseResult<StorageUploadResult> Upload(string account, string fdata, string fmd5, string ftype, string fname, int fpages)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);
            requestParams.Add("fdata", fdata);
            requestParams.Add("fmd5", fmd5);
            requestParams.Add("ftype", ftype);
            requestParams.Add("fname", fname);
            requestParams.Add("fpages", fpages);

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Storage_Upload, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Storage_Upload;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<StorageUploadResult> result = httpService.HttpPost<BaseResult<StorageUploadResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 转换文件格式
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        /// <param name="fid">源文件编号</param>
        /// <param name="ftype">文件类型</param>
        /// <returns></returns>
        public BaseResult<StorageUploadResult> Convert(string account, string fid, string ftype = "")
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);
            requestParams.Add("fid", fid);
            if (string.IsNullOrWhiteSpace(ftype))
                requestParams.Add("ftype", ftype);
 

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Storage_Convert, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Storage_Convert;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<StorageUploadResult> result = httpService.HttpPost<BaseResult<StorageUploadResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 为PDF文件添加元素
        /// </summary>
        /// <param name="account">用户唯一标识</param>
        /// <param name="fid">源文件编号</param>
        /// <param name="elements">要添加的元素集合</param>
        /// <returns></returns>
        public BaseResult<StorageUploadResult> AddPDFElements(string account, string fid, object elements)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("account", account);
            requestParams.Add("fid", fid);
            requestParams.Add("elements", elements);


            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Storage_AddPDFElements, SignUtils.GenerateMD5(requestParams), keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Storage_AddPDFElements;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<StorageUploadResult> result = httpService.HttpPost<BaseResult<StorageUploadResult>>(requestUrl, requestParams);
            return result;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fid">文件编号</param>
        /// <returns></returns>
        public BaseResult<StorageUploadResult> Download(string fid)
        {
            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("fid", fid);
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Storage_Download, "", keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Storage_Download;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<StorageUploadResult> result = httpService.HttpGet<BaseResult<StorageUploadResult>>(requestUrl);
            return result;
        }

        /// <summary>
        /// PDF文件验签
        /// </summary>
        /// <param name="pdfData">PDF文件</param>
        /// <returns></returns>
        public BaseResult<PDFVerifySignaturesResult> VerifySignatures(string pdfData)
        {
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestParams.Add("pdfData", pdfData);
 

            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            keyValues.Add("developerId", Constants.DeveloperID);
            keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            keyValues.Add("signType", Constants.SignType);

            var signResult = SignUtils.GenerateSign(Constants.Path + Constants.Pdf_VerifySignatures, "", keyValues);
            var signEncryResult = RSAEncryption.SignData(signResult, Constants.PrivateKey);
            var signEncodeResult = SignUtils.SignUrlEncode(signEncryResult);

            keyValues.Add("sign", signEncodeResult);
            var originalUrl = Constants.Host + Constants.Path + Constants.Pdf_VerifySignatures;
            var requestUrl = SignUtils.GenerateUrl(originalUrl, keyValues);

            BaseResult<PDFVerifySignaturesResult> result = httpService.HttpPost<BaseResult<PDFVerifySignaturesResult>>(requestUrl, requestParams);
            return result;
        }
    }
}
