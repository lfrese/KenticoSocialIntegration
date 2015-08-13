using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;

using CMS.Helpers;
using CMS.PortalControls;
using CMS.UIControls;
using CMS.EventLog;


//Developed by Laura Frese (lfrese@imediainc.com)
//iMedia Inc http://www.imediainc.com/
public partial class CMSWebParts_iMediaInc_GetFacebookToken : CMSAbstractWebPart
{
    
    public string s_facebook_app_id = null;
    private string s_facebook_client_secret = null;
    private string s_facebook_redirect_uri = null;


    public string FacebookAppID
    {
        get
        {
            return ValidationHelper.GetString(GetValue("FacebookAppID"), s_facebook_app_id);
        }
        set
        {
            SetValue("FacebookAppID", value);
            s_facebook_app_id = value;
        }
    }

    public string FacebookClientSecret
    {
        get
        {
            return ValidationHelper.GetString(GetValue("FacebookClientSecret"), s_facebook_client_secret);
        }
        set
        {
            SetValue("FacebookClientSecret", value);
            s_facebook_client_secret = value;
        }
    }

    public string FacebookRedirectURI
    {
        get
        {
            return ValidationHelper.GetString(GetValue("FacebookRedirectURI"), s_facebook_redirect_uri);
        }
        set
        {
            SetValue("FacebookRedirectURI", value);
            s_facebook_redirect_uri = value;
        }
    }


  


    /// <summary>
    /// Content loaded event handler.
    /// </summary>
    public override void OnContentLoaded()
    {
        base.OnContentLoaded();
        SetupControl();
    }


    /// <summary>
    /// Reloads data for partial caching.
    /// </summary>
    public override void ReloadData()
    {
        base.ReloadData();
        SetupControl();
    }



 




    /// <summary>
    /// Initializes the control properties.
    /// </summary>
    protected void SetupControl()
    {
        
    }

    public string GET(string uri)
    {
        try
        {
            var request = HttpWebRequest.Create(uri);
            request.Method = "GET";

            return ReadResponse(request.GetResponse().GetResponseStream());
        }
        catch (WebException ex)
        {
            EventLogProvider.LogException("GetFacebookAccessToken", "GET ", ex);
            return ReadResponse(ex.Response.GetResponseStream());
        }
    }

    public string ReadResponse(Stream response)
    {
        StreamReader reader = new StreamReader(response);
        string line;
        StringBuilder result = new StringBuilder();
        while ((line = reader.ReadLine()) != null)
        {
            result.Append(line);
        }
        return result.ToString();
    }



    public void btnGetToken(Object sender, EventArgs e)
    {
        //Short term token gotten from front end login & approvals
        string token = hfToken.Value;
        string uri = "https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&fb_exchange_token=" + token + "&client_secret=" + FacebookClientSecret + "&redirect_uri=" + FacebookRedirectURI + "&client_id=" + FacebookAppID + "&code=" + FacebookAppID + "|" + FacebookClientSecret;
        JavaScriptSerializer ser = new JavaScriptSerializer();
        try{
            string long_token = GET(uri);
            tbLong.Text = long_token;

            //get the code using the long term token
            //string code_uri = "https://graph.facebook.com/oauth/client_code?" + long_token + "&client_secret=" + FacebookClientSecret + "&redirect_uri=" + FacebookRedirectURI + "&client_id=" + FacebookAppID;
            //string code_token_resp = GET(code_uri);

            //dynamic jresponse = ser.Deserialize<dynamic>(code_token_resp);
            //JObject jresponse = JObject.Parse(code_token_resp);

            //var code_token = jresponse["code"];

            //tbCode.Text = code_token.ToString();

            //Exchange for another long term token
            //string long2_uri = "https://graph.facebook.com/oauth/access_token?code=" + code_token.ToString() + "&client_id=" + FacebookAppID + "&redirect_uri=" + FacebookRedirectURI;
            //string long2_token_resp = GET(long2_uri);

            //JObject jresponse2 = JObject.Parse(long2_token_resp);


            //tbLong2.Text = jresponse2["access_token"].ToString();  
        }        
        catch (Exception ex)
        {
             EventLogProvider.LogException("GetFacebookAccessToken", "btnGetToken ", ex);
        }
    }

    protected override void OnPreRender(EventArgs e)
    {       
        base.OnPreRender(e);
    }
}