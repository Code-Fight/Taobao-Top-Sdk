using System;
using System.Collections.Generic;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            WirelessShareTpwdCreateRequest.IsvTpwdInfoDomain obj1 = new WirelessShareTpwdCreateRequest.IsvTpwdInfoDomain();
            WirelessShareTpwdCreateRequest req = new WirelessShareTpwdCreateRequest();
            obj1.Ext = "{\"xx\":\"xx\"}";
            obj1.Logo = "http://m.taobao.com/xxx.jpg";
            obj1.Text = "超值活动，惊喜活动多多";
            obj1.Url = "http://e22a.com/h.bKLqFH?cv=AATHWSlP&sm=761abb";
            obj1.UserId = 112244;
            req.TpwdParam_ = obj1;


            Dictionary<string, string> dicP = new Dictionary<string, string>
            {
                {"method", "taobao.wireless.share.tpwd.create"},
                {"app_key", "23493845"},
                {"timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                {"format", "xml"},
                {"v", "2.0"},
                {"sign_method", "md5"},
            };
            //dicP.Add("sign", TopUtils.SignTopRequest(dicP, "bd0af6f3badd3721152b139910bb5124", "hmac"));
            string url = "http://gw.api.taobao.com/router/rest?";
            foreach (var VARIABLE in dicP)
            {
                url += VARIABLE.Key + "=" + VARIABLE.Value + "&";
            }
            url = url.Remove(url.LastIndexOf("&", StringComparison.Ordinal), 1);
            //            ITopClient client = new DefaultTopClient(url, "23493845", "bd0af6f3badd3721152b139910bb5124");
            //           
            //            
            //            //req.TpwdParam_ = obj1;
            //            WirelessShareTpwdCreateResponse rsp = client.Execute(req);


            ITopClient client = new DefaultTopClient(url, "23493845", "bd0af6f3badd3721152b139910bb5124");
            //WirelessShareTpwdCreateRequest req = new WirelessShareTpwdCreateRequest();
            //req.TpwdParam = "{\"ext\":\"{\"xx\":\"xx\"}\",\"logo\":\"http://m.taobao.com/xxx.jpg\",\"text\":\"超值活动，惊喜活动多多\",\"url\":\"http://m.taobao.com\",\"user_id\":112244}";
            WirelessShareTpwdCreateResponse response = client.Execute(req);
           // Console.WriteLine(response.Body);

            string ret= Util.Post("http://gw.api.taobao.com/router/rest", "23493845", "bd0af6f3badd3721152b139910bb5124",
                "taobao.wireless.share.tpwd.create", "", new Dictionary<string, string>() { { "tpwd_param", req.TpwdParam } });
            Console.WriteLine(ret);
            Console.ReadLine();
        }


    }
}
