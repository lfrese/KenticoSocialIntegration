README

Social feed integration web part
Developed by
Laura Frese (lfrese@imediainc.com)
Matt Reale
Jennifer Graeff
iMedia Inc 
http://www.imediainc.com/


This web part outputs random feed from Facebook, Twitter, Instagram, and YouTube into a set number of boxes which change position on each page load.
In addition to the social boxes, HTML can be entered into the web part to display custom content in boxes that will always appear on the page. 
There is also an option to include backup content in case the social feed gets cut for any reason.
You must have the required access tokens, keys, secrets, usernames, userids from the social sites in order to get the social feed using this web part. 
If you are having trouble getting the long term Facebook access token, check out our Facebook Long Term Access Token Generator

INSTRUCTIONS:
In Kentico CMS go to Sites > Import Site or objects
Upload the package you downloaded, select it > Next
IMPORTANT:*****!!!!Under Import Settings CHECK Import Code Files!!!!!!****
You can find the web part in the CMS in the WebParts app, iMediaInc category

If you need to modify the code it will be found in /CMSWebParts/iMediaInc/SocialApp.ascx.cs

(optional) add included CSS to your site & modify as needed.

***************************CUSTOM BOXES*************************
HTML can be entered in the Custom Box Markup if you dont want all of the boxes to be social.
There should be a "{}" between the markup for each box. For example
<div class="box">Hello World</div>{}<div class="box"><a href="#">Click MEE!!!!</a></div>
Custom boxes will always show up on the page in a random place each time the page loads.


Backup content functions the same way as the custom boxes. Enter HTML with {} between each box. The backup content
will only show up if some of the social feeds are not functioning and you need to make sure all of the boxes always have content. 
Images work well as backup
<img src="images/img1.jpg">{}<img src="images/img2.jpg">{}<img src="images/img3.jpg">{}<img src="images/img4.jpg">


*****************************************FACEBOOK**********************************************
Facebook Token:
Create a facebook website app https://developers.facebook.com/apps/
In Settings Add your domain http://whatever as the site url

At the top there are 3 tabs Basic |  Advanced | Migrations
Click Advanced. Scroll down to Client OAuth Settings > Turn on Web OAuth Login
Add the same domain for Valid OAuth redirect URLs

Copy the AppID and the Secret from the Dashboard

Use iMedias Facebook Access Token Generator web part to generate a long term access token if needed. 
only copy the access token value.

Note that the Access Token Generator web part will throw an error if you are viewing it within the CMS Design view,  but it's fine on the actual page.

OR get the never expiring page token if you can get the manage_pages permission


*******************************TWITTER********************************************************
Create an app https://apps.twitter.com/
More information on Twitter Tokens at https://dev.twitter.com/oauth/overview/application-owner-access-tokens

**************************************INSTAGRAM********************************************
More information on Instagram tokens https://instagram.com/developer/authentication/?hl=en
To get your use id go to https://instagram.com/developer/api-console/  Select OAuth2 , 
sign in if needed, create an app if needed, run the /users/self query (https://instagram.com/developer/api-console/) , 
grab the id from the data

***************************************YOUTUBE***************************************
Create a project at https://console.developers.google.com/  Get Public API Access - Add Youtube Data API, Get Key for Browser applications - 
make sure edit allowed referrers is blank. More info: https://developers.google.com/youtube/v3/getting-started

To find yout playlist ID:
Go to your youtube playlist page 
look at the url and copy the content after "list="
ie. https://www.youtube.com/watch?v=2wU7rNzC95w&list=PL9RdJplq_ukbK467eOdH2cE9LKU8cFF64