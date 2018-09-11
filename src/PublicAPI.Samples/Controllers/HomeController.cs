using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PublicAPI.Samples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Route("Home/Details/{AdvertToken}/{token}")]
        public ActionResult Details(string AdvertToken, string token)
        {
            if (!string.IsNullOrEmpty(AdvertToken) && !string.IsNullOrEmpty(token))
            {
                string URL = $"{Utils.Utils.EndPoint}/api/Adverts/{AdvertToken}";
                var request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "GET";
                request.Headers.Add("Authorization", token);
                var responseString = "";

                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                            responseString = reader.ReadToEnd();
                        }
                        ViewData["Title"] = $"Advert <b>{AdvertToken}</b>";
                        ViewData["Advert"] = responseString;
                        Session["oAuth2Token"] = token;
                        return View();
                    }
                    else {
                        return View("Index");
                    }
                }
                catch (WebException Ex)
                {
                    return View("Index");
                }
            }
            else {
                return View("Index");
            }
        }

        public ActionResult RefreshToken()
        {
            string CallBackUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/Home/SaveToken";
            if (Session["oAuth2Token"] != null)
            {
                string token = Session["oAuth2Token"].ToString();
                var request = (HttpWebRequest)WebRequest.Create(Utils.Utils.GetRefreshToken(token));
                request.Method = "POST";
                request.Headers.Add("Authorization", token);
                var responseString = "";
                request.ContentLength = 0;
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                            responseString = reader.ReadToEnd().Replace("\"","");
                        }
                        Response.Redirect($"{CallBackUrl}?token={responseString}");
                        return View();
                    }
                    else
                    {
                        return View("Index");
                    }
                }
                catch (WebException Ex)
                {
                    return View("Index");
                }
            }
            else {
                string WizardUrl = Utils.Utils.GetUrlWizardToken(CallBackUrl);
                Response.Redirect(WizardUrl);
            }

            return View();
        }
        public ActionResult SaveToken(string token)
        {
            Session["oAuth2Token"] = token;
            return View();
        }

        public ActionResult Dummy1(Models.DummyModel oDummyModel)
        {
            string CallBackUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/Home/SaveToken";
            if (Session["oAuth2Token"] != null)
            {
                if (oDummyModel != null && !string.IsNullOrEmpty(oDummyModel.id))
                {
                    string token = Session["oAuth2Token"].ToString();
                    var request = (HttpWebRequest)WebRequest.Create(Utils.Utils.GetUrlDummy("Dummy1", oDummyModel.id));
                    request.Method = "GET";
                    request.Headers.Add("Authorization", token);
                    var responseString = "";
                    try
                    {
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            using (Stream stream = response.GetResponseStream())
                            {
                                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                                responseString = reader.ReadToEnd().Replace("\"", "");
                            }
                            oDummyModel.result = responseString;
                        }
                        else
                        {
                            oDummyModel.result = $"{response.StatusCode} - {response.StatusDescription}";
                        }
                    }
                    catch (WebException Ex)
                    {
                        oDummyModel.result = Ex.Message;
                    }
                    Response.Redirect($"{Request.Url.Scheme}://{Request.Url.Authority}/Home/DummyResult?id={oDummyModel.id}&result={oDummyModel.result}");
                    return View("");
                }
                else {
                    return View();
                }
            }
            else
            {
                string WizardUrl = Utils.Utils.GetUrlWizardToken(CallBackUrl);
                Response.Redirect(WizardUrl);
            }
            return View("");
        }

        public ActionResult Dummy2(Models.DummyModel oDummyModel)
        {
            string CallBackUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/Home/SaveToken";
            if (Session["oAuth2Token"] != null)
            {
                if (oDummyModel != null && !string.IsNullOrEmpty(oDummyModel.id))
                {
                    string token = Session["oAuth2Token"].ToString();
                    var request = (HttpWebRequest)WebRequest.Create(Utils.Utils.GetUrlDummy("Dummy2", oDummyModel.id));
                    request.Method = "GET";
                    request.Headers.Add("Authorization", token);
                    var responseString = "";
                    try
                    {
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            using (Stream stream = response.GetResponseStream())
                            {
                                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                                responseString = reader.ReadToEnd().Replace("\"", "");
                            }
                            oDummyModel.result = responseString;
                        }
                        else
                        {
                            oDummyModel.result = $"{response.StatusCode} - {response.StatusDescription}";
                        }
                    }
                    catch (WebException Ex)
                    {
                        oDummyModel.result = Ex.Message;
                    }
                    Response.Redirect($"{Request.Url.Scheme}://{Request.Url.Authority}/Home/DummyResult?id={oDummyModel.id}&result={oDummyModel.result}");
                    return View("");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                string WizardUrl = Utils.Utils.GetUrlWizardToken(CallBackUrl);
                Response.Redirect(WizardUrl);
            }
            return View("");
        }
        public ActionResult DummyResult(Models.DummyModel oDummyModel) {
            ViewData["Title"] = $"ID <b>{oDummyModel.id}</b>";
            ViewData["DummyMessage"] = oDummyModel.result;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}