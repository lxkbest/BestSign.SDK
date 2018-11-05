


using BestSign.Common;
using BestSignSDK;
using BestSignSDK.API;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using Xceed.Words.NET;
        

namespace BestSign.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 测试RSA

            //string pkcs8_private_key = "MIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQDTQrBbEVcXRVlKhzfEIwC8oxZ0X7XJov+P28jLWL4MP/SEaLamgYtK9vuZ3IGBb3BZWc8nZl8IlCHiXGOOeOyFot6BTHQ/3q4tBfwpW2/ylHY1+2ZcqsfYeitjCSqRll5IfGrNklp3SMNieUChDIt+WEiHFAzTZa6mNhpsuFnAsZQusjtd8xqATg4ymiromQQbAL9Z083O2PcV6Wy/mDjfjG0NX/jsLld+WppUOs7VxKh8OC8GPVZyj80ZZUGqcXojuqbFsvJDao1pezcwGS/tJzAtFgfATBBBHaOzab4gZzjfHwRB5Al+EaEdr+PYBI3qrg1QShcFLJ978cjUX7i3AgMBAAECggEBAJcyS3Vh26rT/yvPyqGdS5G2RwPS3BALkEwtSHAAe0PZIe8B4ncYj9B/I2Li5ez1DLtmA1R3d9xz6CxRYw88jEq4Xfa7+RcdEBs5BVe0EVLT3iaUXpZDw/OyvAqNLOI1dBT8tpOaAxUMBoobrZ2VlOA/3uiN+P/y7iQW5KKa7eFx6WuHdqkd69/oMgryfj7shmGNd1N6TadFaYYhZKsHMupd+msXnmhcc8UZeG/vMcCx6VWsP24k5jeSVIP9DOepO69hj6KLEMjkWqOXQMQGueBuqsvQWZm/G74cJosCdP7AOSq+B9fB8qqHfAg/KMS3m5Xm5+YEDLfB7A1XgaV6zEECgYEA64ObhjHkYEnF5NVbZyAEzH0itEFx5O/Wi0tVXM6LZqwZWv46T9pyseRZ8wb0ZNpvIuSuNxb2FN43jQIY67HxrTDvdGaERhChByywk4gQ67ZZiCqjZEUT1BOmhYyW0uEmLUc4o+80V7Xud6E+YxjWWDnR9wnl6vWG3g41zZk/MaMCgYEA5aMBkALbkexeaJJySAhxm0+wPEFfrTfN+gc2FTNl0Z/y5EAKDoswjjupE+K83UEh205UBBqRrcwZqHTRMw7HIPQ0vLgyoLymIzVm7m8vW1xDh9DfVOAULr6PabzvICks6rLNFLWpeyJVsFIo10+Hzk8VTGQazWCmptdssZY6ld0CgYEAx7x1AOl9UwAeGkWsYBhymW6jKRa73jpdzQLV4YC2Dxxz4IztrV2Jmj8c3hSO3p22VXR2H/iUOPyBRlB6DCJ84bI30pNDKRzfRHNtSaHDH/Ull2r56YcAGwOTXX3vR+d09j+J1NaAoMaF+OVCQM8GsgpPfODjIlKaz+ZjUPvf8VsCgYEAi1SAGjThrIRSM/jHRlV5ONb9A1JXDu6RF2dQtURePvZhlYQVlgV2DJa+W8Zy+XwPYtT/vQ2x3lW8K63VULlisOf7J5ZLgaN02mAIeBsWDMTKZJmjKAhdto8AzRNJs6XIDw81x58BmiiW/UicZydmKxNoxNToPjyqYQjMdmPEYDECgYAfp7kLEV5576H3C9Qd+m7mvblZ1jNDkg3nw3tt1o8vIAeC2yNO0b27iiVCY2ZEm0X+hAbkp27KGCO0tg5pEzZAH5X242pzZ+NucAHs+OPd2+ZOyJdKC+zNygNwcElCvsKFjABSv4uiRLElpsG+AfpN7enjP5HwD7/VcTuB3dB7JA==";
            //string pkcs8_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA00KwWxFXF0VZSoc3xCMAvKMWdF+1yaL/j9vIy1i+DD/0hGi2poGLSvb7mdyBgW9wWVnPJ2ZfCJQh4lxjjnjshaLegUx0P96uLQX8KVtv8pR2NftmXKrH2HorYwkqkZZeSHxqzZJad0jDYnlAoQyLflhIhxQM02WupjYabLhZwLGULrI7XfMagE4OMpoq6JkEGwC/WdPNztj3Felsv5g434xtDV/47C5XflqaVDrO1cSofDgvBj1Wco/NGWVBqnF6I7qmxbLyQ2qNaXs3MBkv7ScwLRYHwEwQQR2js2m+IGc43x8EQeQJfhGhHa/j2ASN6q4NUEoXBSyfe/HI1F+4twIDAQAB";

            //string source = "developerId=2089515089324409441rtick=15380227585730signType=rsa/openapi/v2/user/reg32597BD6BE197BD2529EF784A3A81AFF";//"sign_type=RSA2&t=1024";
            //var pkcs1_privateKey =
            //    "MIIEpQIBAAKCAQEA00KwWxFXF0VZSoc3xCMAvKMWdF+1yaL/j9vIy1i+DD/0hGi2poGLSvb7mdyBgW9wWVnPJ2ZfCJQh4lxjjnjshaLegUx0P96uLQX8KVtv8pR2NftmXKrH2HorYwkqkZZeSHxqzZJad0jDYnlAoQyLflhIhxQM02WupjYabLhZwLGULrI7XfMagE4OMpoq6JkEGwC/WdPNztj3Felsv5g434xtDV/47C5XflqaVDrO1cSofDgvBj1Wco/NGWVBqnF6I7qmxbLyQ2qNaXs3MBkv7ScwLRYHwEwQQR2js2m+IGc43x8EQeQJfhGhHa/j2ASN6q4NUEoXBSyfe/HI1F+4twIDAQABAoIBAQCXMkt1Yduq0/8rz8qhnUuRtkcD0twQC5BMLUhwAHtD2SHvAeJ3GI/QfyNi4uXs9Qy7ZgNUd3fcc+gsUWMPPIxKuF32u/kXHRAbOQVXtBFS094mlF6WQ8PzsrwKjSziNXQU/LaTmgMVDAaKG62dlZTgP97ojfj/8u4kFuSimu3hcelrh3apHevf6DIK8n4+7IZhjXdTek2nRWmGIWSrBzLqXfprF55oXHPFGXhv7zHAselVrD9uJOY3klSD/QznqTuvYY+iixDI5Fqjl0DEBrngbqrL0FmZvxu+HCaLAnT+wDkqvgfXwfKqh3wIPyjEt5uV5ufmBAy3wewNV4GlesxBAoGBAOuDm4Yx5GBJxeTVW2cgBMx9IrRBceTv1otLVVzOi2asGVr+Ok/acrHkWfMG9GTabyLkrjcW9hTeN40CGOux8a0w73RmhEYQoQcssJOIEOu2WYgqo2RFE9QTpoWMltLhJi1HOKPvNFe17nehPmMY1lg50fcJ5er1ht4ONc2ZPzGjAoGBAOWjAZAC25HsXmiSckgIcZtPsDxBX603zfoHNhUzZdGf8uRACg6LMI47qRPivN1BIdtOVAQaka3MGah00TMOxyD0NLy4MqC8piM1Zu5vL1tcQ4fQ31TgFC6+j2m87yApLOqyzRS1qXsiVbBSKNdPh85PFUxkGs1gpqbXbLGWOpXdAoGBAMe8dQDpfVMAHhpFrGAYcpluoykWu946Xc0C1eGAtg8cc+CM7a1diZo/HN4Ujt6dtlV0dh/4lDj8gUZQegwifOGyN9KTQykc30RzbUmhwx/1JZdq+emHABsDk11970fndPY/idTWgKDGhfjlQkDPBrIKT3zg4yJSms/mY1D73/FbAoGBAItUgBo04ayEUjP4x0ZVeTjW/QNSVw7ukRdnULVEXj72YZWEFZYFdgyWvlvGcvl8D2LU/70Nsd5VvCut1VC5YrDn+yeWS4GjdNpgCHgbFgzEymSZoygIXbaPAM0TSbOlyA8PNcefAZoolv1InGcnZisTaMTU6D48qmEIzHZjxGAxAoGAH6e5CxFeee+h9wvUHfpu5r25WdYzQ5IN58N7bdaPLyAHgtsjTtG9u4olQmNmRJtF/oQG5KduyhgjtLYOaRM2QB+V9uNqc2fjbnAB7Pjj3dvmTsiXSgvszcoDcHBJQr7ChYwAUr+LokSxJabBvgH6Te3p4z+R8A+/1XE7gd3QeyQ=";
            //var pkcs1_publicKey =
            //    "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA00KwWxFXF0VZSoc3xCMAvKMWdF+1yaL/j9vIy1i+DD/0hGi2poGLSvb7mdyBgW9wWVnPJ2ZfCJQh4lxjjnjshaLegUx0P96uLQX8KVtv8pR2NftmXKrH2HorYwkqkZZeSHxqzZJad0jDYnlAoQyLflhIhxQM02WupjYabLhZwLGULrI7XfMagE4OMpoq6JkEGwC/WdPNztj3Felsv5g434xtDV/47C5XflqaVDrO1cSofDgvBj1Wco/NGWVBqnF6I7qmxbLyQ2qNaXs3MBkv7ScwLRYHwEwQQR2js2m+IGc43x8EQeQJfhGhHa/j2ASN6q4NUEoXBSyfe/HI1F+4twIDAQAB";

            //var signResult = RSAEncryption.SignData(source, pkcs1_privateKey);
            //var verifyData = RSAEncryption.VerifyData(source, signResult, pkcs1_publicKey);
            //;

            //System.Console.WriteLine("签名:\n" + signResult);
            //System.Console.WriteLine("验签:\n" + verifyData);
            //System.Console.Read();
            #endregion

            #region 测试上上签签名

            //var pkcs1_privateKey =
            //     "MIIEpQIBAAKCAQEA00KwWxFXF0VZSoc3xCMAvKMWdF+1yaL/j9vIy1i+DD/0hGi2poGLSvb7mdyBgW9wWVnPJ2ZfCJQh4lxjjnjshaLegUx0P96uLQX8KVtv8pR2NftmXKrH2HorYwkqkZZeSHxqzZJad0jDYnlAoQyLflhIhxQM02WupjYabLhZwLGULrI7XfMagE4OMpoq6JkEGwC/WdPNztj3Felsv5g434xtDV/47C5XflqaVDrO1cSofDgvBj1Wco/NGWVBqnF6I7qmxbLyQ2qNaXs3MBkv7ScwLRYHwEwQQR2js2m+IGc43x8EQeQJfhGhHa/j2ASN6q4NUEoXBSyfe/HI1F+4twIDAQABAoIBAQCXMkt1Yduq0/8rz8qhnUuRtkcD0twQC5BMLUhwAHtD2SHvAeJ3GI/QfyNi4uXs9Qy7ZgNUd3fcc+gsUWMPPIxKuF32u/kXHRAbOQVXtBFS094mlF6WQ8PzsrwKjSziNXQU/LaTmgMVDAaKG62dlZTgP97ojfj/8u4kFuSimu3hcelrh3apHevf6DIK8n4+7IZhjXdTek2nRWmGIWSrBzLqXfprF55oXHPFGXhv7zHAselVrD9uJOY3klSD/QznqTuvYY+iixDI5Fqjl0DEBrngbqrL0FmZvxu+HCaLAnT+wDkqvgfXwfKqh3wIPyjEt5uV5ufmBAy3wewNV4GlesxBAoGBAOuDm4Yx5GBJxeTVW2cgBMx9IrRBceTv1otLVVzOi2asGVr+Ok/acrHkWfMG9GTabyLkrjcW9hTeN40CGOux8a0w73RmhEYQoQcssJOIEOu2WYgqo2RFE9QTpoWMltLhJi1HOKPvNFe17nehPmMY1lg50fcJ5er1ht4ONc2ZPzGjAoGBAOWjAZAC25HsXmiSckgIcZtPsDxBX603zfoHNhUzZdGf8uRACg6LMI47qRPivN1BIdtOVAQaka3MGah00TMOxyD0NLy4MqC8piM1Zu5vL1tcQ4fQ31TgFC6+j2m87yApLOqyzRS1qXsiVbBSKNdPh85PFUxkGs1gpqbXbLGWOpXdAoGBAMe8dQDpfVMAHhpFrGAYcpluoykWu946Xc0C1eGAtg8cc+CM7a1diZo/HN4Ujt6dtlV0dh/4lDj8gUZQegwifOGyN9KTQykc30RzbUmhwx/1JZdq+emHABsDk11970fndPY/idTWgKDGhfjlQkDPBrIKT3zg4yJSms/mY1D73/FbAoGBAItUgBo04ayEUjP4x0ZVeTjW/QNSVw7ukRdnULVEXj72YZWEFZYFdgyWvlvGcvl8D2LU/70Nsd5VvCut1VC5YrDn+yeWS4GjdNpgCHgbFgzEymSZoygIXbaPAM0TSbOlyA8PNcefAZoolv1InGcnZisTaMTU6D48qmEIzHZjxGAxAoGAH6e5CxFeee+h9wvUHfpu5r25WdYzQ5IN58N7bdaPLyAHgtsjTtG9u4olQmNmRJtF/oQG5KduyhgjtLYOaRM2QB+V9uNqc2fjbnAB7Pjj3dvmTsiXSgvszcoDcHBJQr7ChYwAUr+LokSxJabBvgH6Te3p4z+R8A+/1XE7gd3QeyQ=";
            //var pkcs1_publicKey =
            //    "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA00KwWxFXF0VZSoc3xCMAvKMWdF+1yaL/j9vIy1i+DD/0hGi2poGLSvb7mdyBgW9wWVnPJ2ZfCJQh4lxjjnjshaLegUx0P96uLQX8KVtv8pR2NftmXKrH2HorYwkqkZZeSHxqzZJad0jDYnlAoQyLflhIhxQM02WupjYabLhZwLGULrI7XfMagE4OMpoq6JkEGwC/WdPNztj3Felsv5g434xtDV/47C5XflqaVDrO1cSofDgvBj1Wco/NGWVBqnF6I7qmxbLyQ2qNaXs3MBkv7ScwLRYHwEwQQR2js2m+IGc43x8EQeQJfhGhHa/j2ASN6q4NUEoXBSyfe/HI1F+4twIDAQAB";

            //Dictionary<string, object> requestParams = new Dictionary<string, object>();
            //requestParams.Add("account", "18276195055");
            //requestParams.Add("name", "薛凯");
            //requestParams.Add("userType", 1);
            //requestParams.Add("mail", "xuekaikai@qq.com");
            //requestParams.Add("mobile", "13888888888");
            //requestParams.Add("credential", new object());
            //requestParams.Add("applyCert", 1);

            //string jsonParams = JsonConvert.SerializeObject(requestParams);
            //string host = "https://openapi.bestsign.info";
            //string path = "/openapi/v2/user/reg";

            //SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>();
            //keyValues.Add("developerId", Constants.DeveloperID);
            //keyValues.Add("rtick", SignUtils.ToUnixEpochDate(DateTime.Now).ToString() + SignUtils.ToRandom(1000, 9999));
            //keyValues.Add("signType", Constants.SignType);

            //var signResult = SignUtils.GenerateSign(path, SignUtils.GenerateMD5(requestParams), keyValues);
            //var signEncryResult = RSAEncryption.SignData(signResult, pkcs1_privateKey);
            //var verifyResult = RSAEncryption.VerifyData(signResult, signEncryResult, pkcs1_publicKey);

            //System.Console.WriteLine("原始签名:\n" + signResult);
            //System.Console.WriteLine("加密签名:\n" + signEncryResult);
            //System.Console.WriteLine("验签:\n" + verifyResult);
            //System.Console.Read();
            #endregion

            #region 测试上上签_Reg接口
            //Dictionary<string, object> credential = new Dictionary<string, object>
            //{
            //    { "identity", "450881198603110017" },
            //    { "identityType", "0"},
            //    { "contactMail", "18697993314@qq.com"},
            //    { "contactMobile", "18697993314"},
            //    { "province", "广西省"},
            //    { "city", "南宁市"},
            //    { "address", "白云路38号荣和山水美地7栋3单元3201房"},
            //};
            //UserSerivceAPI userSerivce = new UserSerivceAPI();
            //var result = userSerivce.Reg("450881198603110017", "刘君", RegUserType.Person.ToValue(), credential, RegApplyCert.YES.ToValue());
            //if (result.errno != 0 || !string.IsNullOrEmpty(result.errmsg))
            //{
            //    //日志记录，提示用户
            //    System.Console.WriteLine("请求数据cost:\n" + result.cost);
            //    System.Console.WriteLine("请求数据errmsg:\n" + result.errmsg);
            //    System.Console.WriteLine("请求数据errno:\n" + result.errno);
            //    System.Console.Read();
            //}
            //else
            //{
            //    System.Console.WriteLine("请求数据taskId:\n" + result.data.taskId);
            //    System.Console.Read();
            //}
            #endregion

            #region 测试上上签_GetCert接口
            //UserSerivceAPI userSerivce = new UserSerivceAPI();
            //var result = userSerivce.GetCert("450881198603110017");
            //if (result.errno != 0 || !string.IsNullOrEmpty(result.errmsg))
            //{
            //    //日志记录，提示用户
            //    System.Console.WriteLine("请求数据cost:\n" + result.cost);
            //    System.Console.WriteLine("请求数据errmsg:\n" + result.errmsg);
            //    System.Console.WriteLine("请求数据errno:\n" + result.errno);
            //    System.Console.Read();
            //}
            //else
            //{
            //    System.Console.WriteLine("请求数据account:\n" + result.data.account);
            //    System.Console.WriteLine("请求数据cert:\n" + result.data.cert);
            //    System.Console.WriteLine("请求数据certId:\n" + result.data.certId);
            //    System.Console.Read();
            //}
            #endregion

            #region 测试上上签_GetPersonalCredential接口
            //UserSerivceAPI userSerivce = new UserSerivceAPI();
            //var result = userSerivce.GetPersonalCredential("450881198603110017");
            //if (result.errno != 0 || !string.IsNullOrEmpty(result.errmsg))
            //{
            //    //日志记录，提示用户
            //    System.Console.WriteLine("请求数据cost:\n" + result.cost);
            //    System.Console.WriteLine("请求数据errmsg:\n" + result.errmsg);
            //    System.Console.WriteLine("请求数据errno:\n" + result.errno);
            //    System.Console.Read();
            //}
            //else
            //{
            //    System.Console.WriteLine("请求数据account:\n" + result.data.account);
            //    System.Console.WriteLine("请求数据address:\n" + result.data.address);
            //    System.Console.WriteLine("请求数据city:\n" + result.data.city);
            //    System.Console.WriteLine("请求数据contactMail:\n" + result.data.contactMail);
            //    System.Console.WriteLine("请求数据contactMobile:\n" + result.data.contactMobile);
            //    System.Console.WriteLine("请求数据identity:\n" + result.data.identity);
            //    System.Console.WriteLine("请求数据identityType:\n" + result.data.identityType);
            //    System.Console.WriteLine("请求数据name:\n" + result.data.name);
            //    System.Console.WriteLine("请求数据province:\n" + result.data.province);
            //    System.Console.Read();
            //}
            #endregion

            #region 测试上上签_AsyncApplyCertStatus接口
            //UserSerivceAPI userSerivce = new UserSerivceAPI();
            //var result = userSerivce.AsyncApplyCertStatus("450881198603110017", "153820518001000001");
            //if (result.errno != 0 || !string.IsNullOrEmpty(result.errmsg))
            //{
            //    //日志记录，提示用户
            //    System.Console.WriteLine("请求数据cost:\n" + result.cost);
            //    System.Console.WriteLine("请求数据errmsg:\n" + result.errmsg);
            //    System.Console.WriteLine("请求数据errno:\n" + result.errno);
            //    System.Console.Read();
            //}
            //else
            //{
            //    System.Console.WriteLine("请求数据message:\n" + result.data.message);
            //    System.Console.WriteLine("请求数据status:\n" + result.data.status);
            //    System.Console.Read();
            //}
            #endregion

            #region 测试上上签_CertInfo接口
            //UserSerivceAPI userSerivce = new UserSerivceAPI();
            //var result = userSerivce.CertInfo("450881198603110017", "CFCA-33-20180929110056753-41826");
            //if (result.errno != 0 || !string.IsNullOrEmpty(result.errmsg))
            //{
            //    //日志记录，提示用户
            //    System.Console.WriteLine("请求数据cost:\n" + result.cost);
            //    System.Console.WriteLine("请求数据errmsg:\n" + result.errmsg);
            //    System.Console.WriteLine("请求数据errno:\n" + result.errno);
            //    System.Console.Read();
            //}
            //else
            //{
            //    System.Console.WriteLine("请求数据message:\n" + result.data.certId);
            //    System.Console.WriteLine("请求数据issuerDN:\n" + result.data.issuerDN);
            //    System.Console.WriteLine("请求数据revokedReason:\n" + result.data.revokedReason);
            //    System.Console.WriteLine("请求数据revokedTime:\n" + result.data.revokedTime);
            //    System.Console.WriteLine("请求数据serialNumber:\n" + result.data.serialNumber);
            //    System.Console.WriteLine("请求数据startTime:\n" + result.data.startTime);
            //    System.Console.WriteLine("请求数据status:\n" + result.data.status);
            //    System.Console.WriteLine("请求数据statusMsg:\n" + result.data.statusMsg);
            //    System.Console.WriteLine("请求数据stopTime:\n" + result.data.stopTime);
            //    System.Console.WriteLine("请求数据subjectDN:\n" + result.data.subjectDN);
            //    System.Console.Read();
            //}
            #endregion

            #region 测试上上签_UserCreate接口
            //SignatureServiceAPI signatureService = new SignatureServiceAPI();
            //var result = signatureService.UserCreate("450881198603110017");
            //if (result.errno != 0 || !string.IsNullOrEmpty(result.errmsg))
            //{
            //    //日志记录，提示用户
            //    System.Console.WriteLine("请求数据cost:\n" + result.cost);
            //    System.Console.WriteLine("请求数据errmsg:\n" + result.errmsg);
            //    System.Console.WriteLine("请求数据errno:\n" + result.errno);
            //    System.Console.Read();
            //}
            //else
            //{
            //    System.Console.WriteLine("请求数据data:\n" + result.data);
            //    System.Console.Read();
            //}
            #endregion

            #region 测试上上签_Upload接口
            //string filePath = Path.GetFullPath("..\\..") + "\\File\\平台借款合同.pdf";
            //var fileMd5 = SignUtils.CreateMD5Hex(SignUtils.StreamToBytes(SignUtils.FileToStream(filePath)));
            //var fileBase64Data = Convert.ToBase64String(SignUtils.StreamToBytes(SignUtils.FileToStream(filePath)));
            //var title = "平台借款合同";
            //var expireTime = SignUtils.ToUnixEpochDate(DateTime.Now.AddDays(1)).ToString();

            //SingleDocServiceAPI singleDocServiceAPI = new SingleDocServiceAPI();
            //var result = singleDocServiceAPI.Upload("450881198603110017", fileMd5, "pdf", "平台借款合同.pdf", "4", fileBase64Data, title, expireTime);
            //if (result.errno != 0 || !string.IsNullOrEmpty(result.errmsg))
            //{
            //    System.Console.WriteLine("请求数据cost:\n" + result.cost);
            //    System.Console.WriteLine("请求数据errmsg:\n" + result.errmsg);
            //    System.Console.WriteLine("请求数据errno:\n" + result.errno);
            //    System.Console.Read();
            //}
            //else
            //{
            //    System.Console.WriteLine("请求数据data:\n" + result.data.contractId);
            //    System.Console.Read();
            //}

            #endregion

            #region 测试上上签_Cert接口
            //List<Dictionary<string, object>> signaturePositions = new List<Dictionary<string, object>>
            //{
            //     new Dictionary<string, object>
            //     {
            //         { "x", "0.4" },
            //         { "y", "0.2" },
            //         { "pageNum", "4" }
            //     },
            //};

            //SingleDocServiceAPI singleDocServiceAPI = new SingleDocServiceAPI();
            //var result = singleDocServiceAPI.SignCert("153922673601000001", "450881198603110017", signaturePositions);
            //if (result.errno != 0 || !string.IsNullOrEmpty(result.errmsg))
            //{
            //    //日志记录，提示用户
            //    System.Console.WriteLine("请求数据cost:\n" + result.cost);
            //    System.Console.WriteLine("请求数据errmsg:\n" + result.errmsg);
            //    System.Console.WriteLine("请求数据errno:\n" + result.errno);
            //    System.Console.Read();
            //}
            //else
            //{
            //    System.Console.WriteLine("请求数据data:\n" + result.data);
            //    System.Console.Read();
            //}
            #endregion

            #region 测试上上签_Download接口
             
            Dictionary<string, object> credential = new Dictionary<string, object>
            {
                { "contractId", "153922673601000001" },
            };

            SingleDocServiceAPI singleDocServiceAPI = new SingleDocServiceAPI();
            var result = singleDocServiceAPI.Download("153922673601000001", Path.GetFullPath("..") + "\\合同.pdf");
            if (!result)
            {
                System.Console.WriteLine("下载失败");
                System.Console.Read();
            }
            else
            {
                System.Console.WriteLine("下载成功");
                System.Console.Read();
            }
            #endregion

            #region 动态生成Word合同
            //WordToPDF(GenerateWord());
            #endregion
        }


        public static string GenerateWord()
        {
            var upperMoeny = "零";
            var lowerMoney = "0";
            var totleMoney = 15448.00M;

            upperMoeny = Utils.ConvertToChinese(totleMoney);
            lowerMoney = totleMoney.ToString();


            var sendYear = DateTime.Now.Year;
            var sendMonth = DateTime.Now.Month;
            var sendDay = DateTime.Now.Day;
            var dayCount = 3 * 30;
            var dealYear = DateTime.Now.Year;
            var dealMonth = DateTime.Now.Month;
            var dealDay = DateTime.Now.AddDays(dayCount).Day;


            string templatePath = Path.GetFullPath("..\\..") + "\\Resources\\TemplateFile.docx";

            using (var document = DocX.Load(templatePath))
            {
                Formatting formatting = new Formatting();
                formatting.UnderlineStyle = UnderlineStyle.singleLine;
                formatting.Italic = false;
                formatting.FontFamily = new Xceed.Words.NET.Font("宋体");


                document.Bookmarks["合同编号"].Paragraph.InsertText("CD" + "000001", false, formatting);
                document.Bookmarks["甲方"].Paragraph.InsertText("刘君", false, formatting);
                document.Bookmarks["乙方"].Paragraph.InsertText("张婷", false, formatting);
                document.Bookmarks["甲方2"].Paragraph.InsertText("刘君", false, formatting);
                document.Bookmarks["乙方2"].Paragraph.InsertText("张婷", false, formatting);

                document.ReplaceText("[大写金额]", upperMoeny.ToString());
                document.ReplaceText("[小写金额]", lowerMoney.ToString());
                document.ReplaceText("[借款用途]", "资金周转");
                document.ReplaceText("[放款年]", sendYear.ToString());
                document.ReplaceText("[放款月]", sendMonth.ToString());
                document.ReplaceText("[放款日]", sendDay.ToString());
                document.ReplaceText("[放款至年]", dealYear.ToString());
                document.ReplaceText("[放款至月]", dealMonth.ToString());
                document.ReplaceText("[放款至日]", dealDay.ToString());
                document.ReplaceText("[共计天数]", dayCount.ToString());
                document.ReplaceText("[利息方式]", "");

                document.ReplaceText("[还款日]", dealDay.ToString());
                document.ReplaceText("[按月付息年]", dealYear.ToString());
                document.ReplaceText("[按月付息月]", dealMonth.ToString());
                document.ReplaceText("[按月付息日]", dealDay.ToString());
                document.ReplaceText("[本金偿还年]", dealYear.ToString());
                document.ReplaceText("[本金偿还月]", dealMonth.ToString());
                document.ReplaceText("[本金偿还日]", dealDay.ToString());

                document.ReplaceText("[签订年]", sendYear.ToString());
                document.ReplaceText("[签订月]", sendMonth.ToString());
                document.ReplaceText("[签订日]", sendDay.ToString());

                document.SaveAs(Path.GetFullPath("..\\..") + "\\File\\平台借款合同.docx");
                return Path.GetFullPath("..\\..") + "\\File\\平台借款合同.docx";
            }
        }

        public static void WordToPDF(string docPath)
        {
            Application wordApplication = new Application();
            Document wordDocument = null;

            // Get full path of input and output files.
            object paramSourceDocPath = docPath;
            string paramExportFilePath = Path.GetFullPath("..\\..") + "\\File\\平台借款合同.pdf";

            ///////////////////////////////////////////////
            /// STATIC CONFIGURATION PARAMETERS
            //////////////////////////////////////////////

            WdExportFormat paramExportFormat = WdExportFormat.wdExportFormatPDF;
            bool paramOpenAfterExport = false;
            WdExportOptimizeFor paramExportOptimizeFor =
                WdExportOptimizeFor.wdExportOptimizeForPrint;
            WdExportRange paramExportRange = WdExportRange.wdExportAllDocument;

            int paramStartPage = 0;
            int paramEndPage = 0;

            WdExportItem paramExportItem = WdExportItem.wdExportDocumentContent;

            bool paramIncludeDocProps = true;
            bool paramKeepIRM = true;
            WdExportCreateBookmarks paramCreateBookmarks =
                WdExportCreateBookmarks.wdExportCreateWordBookmarks;

            bool paramDocStructureTags = true;
            bool paramBitmapMissingFonts = true;
            bool paramUseISO19005_1 = false;

            object paramMissing = Type.Missing;

            try
            {
                // Open the source document.
                wordDocument = wordApplication.Documents.Open(
                    ref paramSourceDocPath, ref paramMissing, ref paramMissing,
                    ref paramMissing, ref paramMissing, ref paramMissing,
                    ref paramMissing, ref paramMissing, ref paramMissing,
                    ref paramMissing, ref paramMissing, ref paramMissing,
                    ref paramMissing, ref paramMissing, ref paramMissing,
                    ref paramMissing);

                // Export it in the specified format.
                if (wordDocument != null)
                    wordDocument.ExportAsFixedFormat(paramExportFilePath,
                        paramExportFormat, paramOpenAfterExport,
                        paramExportOptimizeFor, paramExportRange, paramStartPage,
                        paramEndPage, paramExportItem, paramIncludeDocProps,
                        paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                        paramBitmapMissingFonts, paramUseISO19005_1,
                        ref paramMissing);
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine(ex);
            }
            finally
            {
                // Close and release the Document object.
                if (wordDocument != null)
                {
                    wordDocument.Close(ref paramMissing, ref paramMissing,
                        ref paramMissing);
                    wordDocument = null;
                }

                // Quit Word and release the ApplicationClass object.
                if (wordApplication != null)
                {
                    wordApplication.Quit(ref paramMissing, ref paramMissing,
                        ref paramMissing);
                    wordApplication = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

        }
    }
}
