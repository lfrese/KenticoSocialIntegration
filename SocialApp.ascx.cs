using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Web.Script.Serialization;

using CMS.Controls;
using CMS.EventLog;
using CMS.Helpers;
using CMS.IO;
using CMS.PortalControls;
using CMS.ExtendedControls;
using CMS.DataEngine;



//Developed by Laura Frese (lfrese@imediainc.com)
//iMedia Inc http://www.imediainc.com/
public partial class CMSWebParts_iMediaInc_SocialApp : CMSAbstractWebPart
{
    #region "Document properties"
    private string s_twitter_user = null;
    private string s_TwitterOAuthConsumerID = null;
    private string s_TwitterOAuthConsumerSecret = null;
    private string s_TwitterOAuthAccessToken = null;
    private string s_TwitterOAuthAccessSecret = null;
    private string s_num_tweets  = null;

    private string s_InstagramUserID = null;
    private string s_InstagramOAuthConsumerID = null;
    private string s_InstagramOAuthConsumerSecret = null;
    private string s_RedirectURL = null;

    private string s_FacebookAuthToken = null;
    private string s_FacebookUserID = null;
    private string s_facebook_app_id = null;
    private string s_facebook_client_secret = null;
    private string s_facebook_redirect_uri = null;

    private string s_youtube_playlist_id = null;
    private string s_youtube_api_key = null;

    private string s_images_list = null;
    private string s_CTAs = null;

	private string mControlName = null;
    private string s_num_boxes = null;


    public string SocialBoxCount
    {
        get
        {
            return ValidationHelper.GetString(GetValue("SocialBoxCount"), s_num_boxes);
        }
        set
        {
            SetValue("SocialBoxCount", value);
            s_num_boxes = value;
        }
    }

    //your sites domain name http://www.mysite.com
    public string RedirectURL
    {
        get
        {
            return ValidationHelper.GetString(GetValue("RedirectURL"), s_RedirectURL);
        }
        set
        {
            SetValue("RedirectURL", value);
            s_RedirectURL = value;
        }
    }

    public string BackupImages
    {
        get
        {
            return ValidationHelper.GetString(GetValue("BackupImages"), s_images_list);
        }
        set
        {
            SetValue("BackupImages", value);
            s_images_list = value;
        }
    } 

    public string CTAS
    {
        get
        {
            return ValidationHelper.GetString(GetValue("CTAS"), s_CTAs);
        }
        set
        {
            SetValue("CTAS", value);
            s_CTAs= value;
        }
    }
    
    /// <summary>
    /// Gets or sets the name of the control.
    /// </summary>
    public string ControlName
    {
        get
        {
            return ValidationHelper.GetString(GetValue("ControlName"), mControlName);
        }
        set
        {
            SetValue("ControlName", value);
            mControlName = value;
        }
    }
	
	/// <summary>
    /// Gets or sets the name of the Twitter User
    /// </summary>
    public string TwitterUser
    {
        get
        {
            return ValidationHelper.GetString(GetValue("TwitterUser"), s_twitter_user);
        }
        set
        {
            SetValue("TwitterUser", value);
            s_twitter_user = value;
        }
    }
	
	public string TwitterOAuthConsumerID
    {
        get
        {
            return ValidationHelper.GetString(GetValue("TwitterOAuthConsumerID"), s_TwitterOAuthConsumerID);
        }
        set
        {
            SetValue("TwitterOAuthConsumerID", value);
            s_TwitterOAuthConsumerID = value;
        }
    }
	
	public string TwitterOAuthConsumerSecret
    {
        get
        {
            return ValidationHelper.GetString(GetValue("TwitterOAuthConsumerSecret"), s_TwitterOAuthConsumerSecret);
        }
        set
        {
            SetValue("TwitterOAuthConsumerSecret", value);
            s_TwitterOAuthConsumerSecret = value;
        }
    }
	
	public string TwitterOAuthAccessToken
    {
        get
        {
            return ValidationHelper.GetString(GetValue("TwitterOAuthAccessToken"), s_TwitterOAuthAccessToken);
        }
        set
        {
            SetValue("TwitterOAuthAccessToken", value);
            s_TwitterOAuthAccessToken = value;
        }
    }
	
	public string TwitterOAuthAccessSecret
    {
        get
        {
            return ValidationHelper.GetString(GetValue("TwitterOAuthAccessSecret"), s_TwitterOAuthAccessSecret);
        }
        set
        {
            SetValue("TwitterOAuthAccessSecret", value);
            s_TwitterOAuthAccessSecret = value;
        }
    }
	
	public string InstagramUserID
    {
        get
        {
            return ValidationHelper.GetString(GetValue("InstagramUserID"), s_InstagramUserID);
        }
        set
        {
            SetValue("InstagramUserID", value);
            s_InstagramUserID = value;
        }
    }
	
	public string InstagramOAuthConsumerID
    {
        get
        {
            return ValidationHelper.GetString(GetValue("InstagramOAuthConsumerID"), s_InstagramOAuthConsumerID);
        }
        set
        {
            SetValue("InstagramOAuthConsumerID", value);
            s_InstagramOAuthConsumerID = value;
        }
    }
	
	public string InstagramOAuthConsumerSecret
    {
        get
        {
            return ValidationHelper.GetString(GetValue("InstagramOAuthConsumerSecret"), s_InstagramOAuthConsumerSecret);
        }
        set
        {
            SetValue("InstagramOAuthConsumerSecret", value);
            s_InstagramOAuthConsumerSecret = value;
        }
    }
	
	public string FacebookAuthToken
    {
        get
        {
            return ValidationHelper.GetString(GetValue("FacebookAuthToken"), s_FacebookAuthToken);
        }
        set
        {
            SetValue("FacebookAuthToken", value);
            s_FacebookAuthToken = value;
        }
    }
	
	public string FacebookUserID
    {
        get
        {
            return ValidationHelper.GetString(GetValue("FacebookUserID"), s_FacebookUserID);
        }
        set
        {
            SetValue("FacebookUserID", value);
            s_FacebookUserID = value;
        }
    }

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


	public string youtube_playlist_id
    {
        get
        {
            return ValidationHelper.GetString(GetValue("youtube_playlist_id"), s_youtube_playlist_id);
        }
        set
        {
            SetValue("youtube_playlist_id", value);
            s_youtube_playlist_id = value;
        }
    }
	
	public string youtube_api_key
    {
        get
        {
            return ValidationHelper.GetString(GetValue("youtube_api_key"), s_youtube_api_key);
        }
        set
        {
            SetValue("youtube_api_key", value);
            s_youtube_api_key = value;
        }
    }

	#endregion


    /// <summary>
    /// Content loaded event handler.
    /// </summary>
    public override void OnContentLoaded()
    {
        base.OnContentLoaded();
        SetupControl();
    }


    /// <summary>
    /// Initializes the control properties.
    /// </summary>
    protected void SetupControl()
    {
        // In design mode is processing of control stopped
        if (StopProcessing)
        {
            // Do nothing
        }
        else
        {
            LoadSocialBoxes();
        }
    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        LoadSocialBoxes();
    }


    /// <summary>
    /// Load control .
    /// </summary>
    private void LoadSocialBoxes()
    {

        List<String> cta_boxes = new List<String>();
        int total_boxes = Convert.ToInt32(SocialBoxCount);
        if (!String.IsNullOrEmpty(CTAS))
        {
            try{
                cta_boxes = Regex.Split(CTAS, "{}").ToList();
            }
            catch (Exception ex)
            {
                 EventLogProvider.LogException("SocialApp control", "LoadSocialBoxes CTA", ex);
            }
        }
        int social_count = total_boxes - cta_boxes.Count();
        List<String> obj_list = new List<String>();

        if (!String.IsNullOrEmpty(InstagramUserID))
        {
            try
            {
                InstagramManager imgr = new InstagramManager(InstagramOAuthConsumerID, InstagramOAuthConsumerSecret, RedirectURL);
                List<String> instgrm = imgr.GetRandom(Convert.ToInt32(InstagramUserID), total_boxes).ToList();
                obj_list = obj_list.Concat(instgrm).ToList();

            }
            catch (Exception ex)
            {
                  EventLogProvider.LogException("SocialApp control", "LoadSocialBoxes Instagram", ex);
            }
        }
        if (!String.IsNullOrEmpty(TwitterUser))
        {
            try
            {
                TwitterManager tm = new TwitterManager(TwitterOAuthConsumerID, TwitterOAuthConsumerSecret, TwitterOAuthAccessToken, TwitterOAuthAccessSecret);

                List<String> tweet = tm.GetRandomTweet(TwitterUser, total_boxes).ToList();
                obj_list = obj_list.Concat(tweet).ToList();

            }
            catch (Exception ex)
            {
                 EventLogProvider.LogException("SocialApp control", "LoadSocialBoxes Twitter", ex);               
            }
        }
        if (!String.IsNullOrEmpty(FacebookUserID))
        {
            try
            {
                FacebookManager fmgr = new FacebookManager(FacebookAuthToken, FacebookAppID, FacebookClientSecret, FacebookRedirectURI);
                List<String> fbpost = fmgr.GetRandomPost(FacebookUserID, total_boxes).ToList();
                obj_list = obj_list.Concat(fbpost).ToList();

            }
            catch (Exception ex)
            {
                  EventLogProvider.LogException("SocialApp control", "LoadSocialBoxes Facebook", ex);              
            }
        }
        if (!String.IsNullOrEmpty(youtube_api_key))
        {
            try
            {
                YouTubeManager ytmgr = new YouTubeManager(youtube_api_key);
                List<String> ytvideo = ytmgr.GetVideosByPlaylistID(youtube_playlist_id, total_boxes).ToList();
                obj_list = obj_list.Concat(ytvideo).ToList();

            }
            catch (Exception ex)
            {
                 EventLogProvider.LogException("SocialApp control", "LoadSocialBoxes Youtube", ex);
            }
        }

        //Randomize the list of social items and take the top # of social boxes
        obj_list = obj_list.OrderBy(x => Guid.NewGuid()).Take(social_count).ToList();

        //CTAs are always shown, add on to the end of the main list
        if (!String.IsNullOrEmpty(CTAS))
        {
            OtherManager cta_build = new OtherManager();
            List<String> ctas = cta_build.BuildCTAList(cta_boxes).ToList();
            obj_list = obj_list.Concat(ctas).ToList();            
        }

        //If the number of boxes are less than the number requested, fill with backup images
        if ((obj_list.Count() < total_boxes) && !String.IsNullOrEmpty(BackupImages))
        {
            try
            {
                int num_images = total_boxes - obj_list.Count();
                OtherManager img_build = new OtherManager();
                List<String> imgs = img_build.BuildImageList(s_images_list, num_images).ToList();
                obj_list = obj_list.Concat(imgs).ToList();            
            }
            catch (Exception ex)
            {
                 EventLogProvider.LogException("SocialApp control", "LoadSocialBoxes BackupImages", ex);
            }
        }

        //randomize again
        obj_list = obj_list.OrderBy(x => Guid.NewGuid()).ToList();

        StringBuilder sb = new StringBuilder();
        foreach (String s in obj_list)
        {
            sb.Append(s);
        }
        community_box_list.InnerHtml = sb.ToString();
        
    }
	
}

//Handles boxes that contain content other than social
public class OtherManager
{
    public OtherManager()
    {
    }
    //Builds call to action boxes (box with just text or other content)
    //CTA boxes always show up on the page and take priority over social boxes and backup images
    public List<String> BuildCTAList(List<String> ctas)
    {
        List<String> cta_list = new List<string>();
        foreach (String s in ctas)
        {
            MarkupBuilder mb = new MarkupBuilder();
            string ct_str = mb.GetMarkup("Other");
            string ct = string.Format(ct_str, s);
            cta_list.Add(ct);
        }
        return cta_list;
    }

    public List<String> BuildImageList(string images, int num_images)
    {
        List<String> img_list = new List<string>();
        List<string> all_images = Regex.Split(images, "{}").ToList();
        foreach (string img in all_images)
        {
            MarkupBuilder mb = new MarkupBuilder();
            string img_str = mb.GetMarkup("Other");
            string im = string.Format(img_str, img);
            img_list.Add(im);
        }
        return img_list.OrderBy(x => Guid.NewGuid()).Take(num_images).ToList();
    }
}

//Handles generating the HTML for the boxes
//depending on which type of box (twitter, facebook, other, etc)
public class MarkupBuilder
{
    public MarkupBuilder()
    {
    }

    //Shortens the string & adds ... at the end if its too long
    public string PreviewPrettyTrunc(string workstring, int maxlength)
    {

        if (workstring.Length <= maxlength)
            return workstring;
        else
        {
            int curridx = maxlength;
            while (curridx > 0)
            {
                if (workstring[curridx] == ' ' || workstring[curridx] == '\r' || workstring[curridx] == '\n' || workstring[curridx] == '\t')
                {
                    return workstring.Substring(0, curridx) + "...";
                }
                else
                    curridx--;
            }

            return workstring.Substring(0, maxlength) + "...";
        }
    }


    /// <summary>
    /// Returns a markup string based on what type of social site is being pulled
    /// Types include:
    /// Facebook, Twitter, Instagram, Youtube, Other
    /// </summary>
    /// <param name="type">Type of box</param>
    /// <returns>string of HTML</returns>
    public string GetMarkup(string type)
    {
        string html = "";
        switch (type)
        {
            case "Facebook":
                html = "<div class='community_box fb_box'>";
                html += "<div class='social-tile-inner'>";
                html += "<div class='icon'> </div>";
                html += "<div class='social-text'>";
                html += "<a href='{0}' target='_blank'>{1}</a>";
                html += "</div>";
                html += "<!--<div class='social-date'>{2}</div>-->";
                html += "</div>";
                html += "</div>";

                break;
            case "Twitter":
                html = "<div class='community_box tw_box'>";
                html += "<div class='tw_text'>";
                html += "<div class='icon'> </div>";
                html += "<a href='{0}' target='_blank'>{1}</a>";
                html += "</div>";
                html += "<!--<div class='tw_time'>{2}</div>-->";
                html += "</div>";
                break;
            case "Instagram":
                html = "<div class='community_box ins_box'>";
                html += "<div class='icon'> </div>";
                html += "<div class='social-tile-inner' style='background-image:url({1});'>";
                html += "<a href='{0}' target='_blank'><img src='{1}' alt='{2}' title='{2}' class='ig-img' /></a>";
                html += "</div>";
                html += "</div>";
                break;
            case "YouTube":
                html = "<div class='community_box yt_box'>";
                html += "<div class='icon'> </div>";
                html += "<div class='social-tile-inner'>";
                html += "<a class='lightbox desktop' href='https://www.youtube.com/watch?v={0}'><img alt='{2}' title='{2}' src='{1}' /></a>";
                html += "</div>";
                html += "</div>";
                break;
            case "Other":
                html = "<div class='community_box other'>{0}</div>";
                break;
        }
        return html;
    }
}

//Handles the HTTP Requests
public abstract class BaseSocialManager
{

    protected string GET(string uri)
    {
        try
        {
            var request = HttpWebRequest.Create(uri);
            request.Method = "GET";

            return ReadResponse(request.GetResponse().GetResponseStream());
        }
        catch (WebException ex)
        {
            return ReadResponse(ex.Response.GetResponseStream());
        }
    }

    private string ReadResponse(System.IO.Stream response)
    {
        System.IO.StreamReader reader = new System.IO.StreamReader(response);
        string line;
        StringBuilder result = new StringBuilder();
        while ((line = reader.ReadLine()) != null)
        {
            result.Append(line);
        }
        return result.ToString();
    }

}


public class TwitterManager
{
    private string _consumerKey;
    private string _consumerSecret;

    private string _accessToken;
    private string _accessTokenSecret;
    private string TWITTER_API_URI = "https://api.twitter.com/1.1/statuses/user_timeline.json?count=20&exclude_replies=true&include_rts=false&trim_user=1&screen_name={0}";
      //store oauth version here
    private static string version = "1.0";
    //store signature method here
    private static string signaturemethod = "HMAC-SHA1";

    public TwitterManager(string Key, string Secret, string accessToken, string accessTokenSecret)
    {
        _consumerKey = Key;
        _consumerSecret = Secret;
        _accessToken = accessToken;
        _accessTokenSecret = accessTokenSecret;
    }

    public List<String> GetRandomTweet(string uname, int numtweets)
    {
        List<string> tw_list = new List<string>();
        string resourceurl = string.Format(TWITTER_API_URI, uname);
        string tw_response = GetTwitterData(resourceurl);
        JavaScriptSerializer ser = new JavaScriptSerializer();
        dynamic tweets = ser.Deserialize<dynamic>(tw_response);        

        foreach (var t in tweets)
        {
            try
            {
                MarkupBuilder mb = new MarkupBuilder();
                string tw_str = mb.GetMarkup("Twitter");
                string s = string.Format(tw_str, "https://twitter.com/ACPNY/status/"+t["id"], t["text"], t["created_at"]);
                tw_list.Add(s);
            }
            catch
            {
                string dsd = "";
            }
        }

        if (tw_list.Count > 0)
        {
            return tw_list.OrderBy(x => Guid.NewGuid()).Take(numtweets).ToList();             
        }
        else
        {
            return null;
        }
    }

    /////////////AUTHENTICATION
    ////////////https://github.com/bmdeveloper/TweetService/blob/master/App_Code/TwitterApiCall.cs

    //this gets the json data from twitter api
    public string GetTwitterData(string resourceurl)
    {
        //create parameter list
        List<string> parameterlist;
        //check for query string
        if (resourceurl.Contains("?"))
        {
            parameterlist = getparameterlistfromurl(resourceurl);
            resourceurl = resourceurl.Substring(0, resourceurl.IndexOf('?'));
        }

        else
        {
            parameterlist = null;
        }
        //build the oauth header
        string authheader = buildheader(resourceurl, parameterlist);

        //make the request to the twitter api and get the JSON response
        string jsonresponse = TwitterWebRequest(resourceurl, authheader, parameterlist);

        return jsonresponse;


    }

    //retreive a list if parameters from the resource url. This will be used when making the request to the twitter api and in generating the signature
    private List<string> getparameterlistfromurl(string resourceurl)
    {

        //Uri MyUrl = new Uri(resourceurl);
        string querystring = resourceurl.Substring(resourceurl.IndexOf('?') + 1);



        List<string> listtoreturn = new List<string>();


        NameValueCollection nv = HttpUtility.ParseQueryString(querystring);

        foreach (string parameter in nv)
        {
            listtoreturn.Add(parameter + "=" + Uri.EscapeDataString(nv[parameter].ToString()));

        }
        return listtoreturn;
    }



    //this gets the timeline data from twitter api
    private string buildheader(string resourceurl, List<string> parameterlist)
    {

        string nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
        TimeSpan timespan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        string timestamp = Convert.ToInt64(timespan.TotalSeconds).ToString();

        string signature = getSignature(nonce, timestamp, resourceurl, parameterlist);

        // build the authentication header with all information collected

        var HeaderFormat = "OAuth " +
        "oauth_consumer_key=\"{0}\", " +
        "oauth_nonce=\"{1}\", " +
        "oauth_signature=\"{2}\", " +
        "oauth_signature_method=\"{3}\", " +
        "oauth_timestamp=\"{4}\", " +
        "oauth_token=\"{5}\", " +
        "oauth_version=\"{6}\"";

        string authHeader = string.Format(HeaderFormat,
        Uri.EscapeDataString(_consumerKey),
        Uri.EscapeDataString(nonce),
        Uri.EscapeDataString(signature),
        Uri.EscapeDataString(signaturemethod),
        Uri.EscapeDataString(timestamp),
        Uri.EscapeDataString(_accessToken),
        Uri.EscapeDataString(version)
        );

        return authHeader;

    }



    private string getSignature(string nonce, string timestamp, string resourceurl, List<string> parameterlist)
    {
        // generate the base string for the signature

        string baseString = generatebasestring(nonce, timestamp, resourceurl, parameterlist);

        baseString = string.Concat("GET&", Uri.EscapeDataString(resourceurl), "&", Uri.EscapeDataString(baseString));


        // generate the signature using the base string, consumer secret and access secret from the application api. Using the HMAC-SHA1 signature method

        var signingKey = string.Concat(Uri.EscapeDataString(_consumerSecret), "&", Uri.EscapeDataString(_accessTokenSecret));
        string signature;

        //generate hash using signing key
        HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(signingKey));

        signature = Convert.ToBase64String(hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
        //get signature signature using the hash

        return signature;

    }

    private string generatebasestring(string nonce, string timestamp, string resourceurl, List<string> parameterlist)
    {

        string basestring = "";
        //create list with all the security parameters
        List<string> baseformat = new List<string>();
        baseformat.Add("oauth_consumer_key=" + _consumerKey);
        baseformat.Add("oauth_nonce=" + nonce);
        baseformat.Add("oauth_signature_method=" + signaturemethod);
        baseformat.Add("oauth_timestamp=" + timestamp);
        baseformat.Add("oauth_token=" + _accessToken);
        baseformat.Add("oauth_version=" + version);


        //append parameter list as twitter requires the parameters to be in alphabetical order
        if (parameterlist != null)
        {
            baseformat.AddRange(parameterlist);

        }
        //sort list alphabetically
        baseformat.Sort();


        //loop through list and generate base string

        foreach (string value in baseformat)
        {
            basestring += value + "&";
        }

        basestring = basestring.TrimEnd('&');

        return basestring;


    }

    //makes the request to twitter and returns a string of JSON data

    private string TwitterWebRequest(string resourceurl, string authheader, List<string> parameterlist)
    {

        //build  the http web request to the twitter api
        ServicePointManager.Expect100Continue = false;

        string postBody;

        if (parameterlist != null)
        {
            postBody = GetPostBody(parameterlist);
        }
        else
        {
            postBody = "";
        }
        resourceurl += "?" + postBody;



        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resourceurl);
        request.Headers.Add("Authorization", authheader);
        request.Method = "GET";
        request.ContentType = "application/x-www-form-urlencoded";

        // Retrieve the response json data
        WebResponse response = request.GetResponse();

        //json reponse data
        string responseData = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();

        return responseData;

    }

    private string GetPostBody(List<string> parameterlist)
    {
        string stringtoreturn = "";

        foreach (string item in parameterlist)
        {
            stringtoreturn += item + "&";

        }
        stringtoreturn = stringtoreturn.TrimEnd('&');
        return stringtoreturn;

    }

}

public class InstagramManager : BaseSocialManager
{
    private string _consumerKey;
    private string _consumerSecret;
    private static string INSTAGRAM_API_URL = "https://api.instagram.com/v1/users/{0}/media/recent/?client_id={1}";

    private string REDIRECT_URL;

    public InstagramManager(string Key, string Secret, string redirectURL)
    {
        _consumerKey = Key;
        _consumerSecret = Secret;
        REDIRECT_URL = redirectURL;

    }

    public List<String> GetRandom(int userid, int num_imgs)
    {
        List<String> im_list = new List<String>();
       
        var jdata = GetMedia(userid);
        if (jdata.Length > 0)
        {
            int max_results = Math.Min(num_imgs, jdata.Length);
            for (int i = 0; i < max_results; i++)
            {
                MarkupBuilder mb = new MarkupBuilder();
                string im_str = mb.GetMarkup("Instagram");
                var latestig = jdata[i];
                string im = string.Format(im_str, latestig["link"], latestig["images"]["standard_resolution"]["url"], latestig["caption"]["text"]);
              
                im_list.Add(im);
            }
  
        }
        return im_list.OrderBy(x => Guid.NewGuid()).ToList();
        
    }

    private dynamic GetMedia(int userid)
    {

        string uri = string.Format(INSTAGRAM_API_URL, userid, _consumerKey);
        try
        {
            string response = GET(uri);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            dynamic d = ser.Deserialize<dynamic>(response);  
            return d["data"];

        }
        catch(Exception ex)
        {
            EventLogProvider.LogException("SocialApp control", "InstagramManager GetMedia", ex);
            return null;
        }

    }
}


public class FacebookManager : BaseSocialManager
{

    private const string FACEBOOK_API_URL = "https://graph.facebook.com/{0}?fields=posts.limit({3}){2}&access_token={1}";

    private string access_token = "";
    private string facebook_app_id = "";
    private string facebook_client_secret = "";
    private string facebook_redirect_uri = "";

    public FacebookManager(string AccessToken, string FbAppId, string FbClientSec, string fbRedirURL)
    {
        access_token = AccessToken;
        facebook_app_id = FbAppId;
        facebook_client_secret = FbClientSec;
        facebook_redirect_uri = fbRedirURL;
    }

    public List<String> GetRandomPost(string username, int num_posts)
    {
        List<String> fbpost_list = new List<String>();
        
        var data = getStatuses(username, num_posts);

        if (data != null)
        {
            foreach (var post in data)
            {
                try
                {
                    MarkupBuilder mb = new MarkupBuilder();
                    string fb_str = mb.GetMarkup("Facebook");
                    string link = "http://www.facebook.com/" + post["id"].ToString().Replace("_", "/posts/");
                    string im = string.Format(fb_str, link, mb.PreviewPrettyTrunc(post["message"].ToString(), 200), post["updated_time"].ToString());
                    fbpost_list.Add(im);
                }
                catch { }
            }

            return fbpost_list.OrderBy(x => Guid.NewGuid()).ToList();
        }
        else
        {
            return fbpost_list;
        }
    

    }

    private dynamic getStatuses(string userId, int num_posts)
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();
        // //Get code and exchange for another token
        // //This handles / prevents expiration after 60d
        // //https://developers.facebook.com/docs/facebook-login/access-tokens#pagetokens

        // //get the code using the long term token
        // string code_uri = "https://graph.facebook.com/oauth/client_code?" + access_token + "&client_secret=" + facebook_client_secret + "&redirect_uri=" + facebook_redirect_uri + "&client_id=" + facebook_app_id;
        // string code_token_resp = GET(code_uri);
        // //JObject jresponse1 = JObject.Parse(code_token_resp);
        // dynamic jresponse1 = ser.Deserialize<dynamic>(code_token_resp);
        // var code_token = jresponse1["code"];

        // //Exchange for another long term token
        // string long2_uri = "https://graph.facebook.com/oauth/access_token?code=" + code_token.ToString() + "&client_id=" + facebook_app_id + "&redirect_uri=" + facebook_redirect_uri;
        // string long2_token_resp = GET(long2_uri);

        // dynamic jresponse2 = ser.Deserialize<dynamic>(long2_token_resp);

        //string new_long_token = jresponse2["access_token"].ToString();

        string uri = string.Format(FACEBOOK_API_URL, userId, access_token, "{message,object_id,updated_time}", num_posts.ToString()); //string.Format(FACEBOOK_API_URL, userId, new_long_token, "{message,object_id,updated_time}", num_posts.ToString());
        try
        {
            string response = GET(uri);
            dynamic jresponse = ser.Deserialize<dynamic>(response);
            var data = jresponse["posts"]["data"];
            return data;

        }
        catch(Exception ex)
        {
            EventLogProvider.LogException("SocialApp control", "FacebookManager getStatuses", ex);
            return null;
        }

    }
}


public class YouTubeManager : BaseSocialManager
{
    private string api_key = "";
    private const string YOUTUBE_API_URL = "https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&playlistId={0}&maxResults={1}&key={2}";
    public YouTubeManager(string ApiKey)
    {
        api_key = ApiKey;
    }


    public List<String> GetVideosByPlaylistID(string sPlaylistID, int num_vids)
    {
        List<String> feed = new List<String>();

         try
        {            
            string request_uri = string.Format(YOUTUBE_API_URL, sPlaylistID, num_vids.ToString(), api_key);
            string yt_response = GET(request_uri);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            dynamic jresponse = ser.Deserialize<dynamic>(yt_response);
            
            var data = jresponse["items"];
            foreach (var searchResult in data)
            {
                MarkupBuilder mb = new MarkupBuilder();
                string yt_str = mb.GetMarkup("YouTube");
                string im = string.Format(yt_str, searchResult["snippet"]["resourceId"]["videoId"], searchResult["snippet"]["thumbnails"]["medium"]["url"], searchResult["snippet"]["title"]);
                feed.Add(im);
            }
            
            
        }
        catch (Exception ex)
        {
            EventLogProvider.LogException("SocialApp control", "YouTubeManager GetVideosByPlaylistID", ex);
        }

        return feed.OrderBy(x => Guid.NewGuid()).ToList();
    }
}

