using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetWorkControllerPort: MonoBehaviour {

    public GameObject NetworkController;
	public Text myTextEval;
	public Text errText;
    public Text TryAgain;
    public GameObject TryAgainPanel;
    public GameObject QuitPanel;
    public GameObject PanelBlank;
    public GameObject SplashPanel;
    public GameObject FB_MainMenu;
    public int n;
    public string urltarget;


    public string fb_fname;
    public string fb_lname;
    public string fb_email;
    public string fb_id;

    public string loadMobile = "no";

    public GameObject DialogShare;


    UniWebView webView;
    public string webConnectionStatus;



    // Use this for initialization


    public RectTransform myUITransform;







    void Start () {

           
        // GameObject mT = GameObject.FindWithTag("myTextEval");

       // GameObject infoText = GameObject.FindGameObjectWithTag("infoText");

        var webViewGameObject = new GameObject("UniWebView");
		webView = webViewGameObject.AddComponent<UniWebView>();

		webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
        //var url = UniWebViewHelper.StreamingAssetURLForPath("art/css3animation.html");

        webView.Load(urltarget ); 
        //webView.Load(url);        

        webView.OnPageErrorReceived += (view, error, message) => {
            print("Errored.");
            webConnectionStatus = "error";
           myTextEval.text = "Please check your internet connection";
           // webView.Hide();
           // TryAgain.text = "Please check your internet connection, Tap to try again";
            //TryAgainPanel.SetActive(true);
           // infoText.SendMessage("SetText", "Please check your internet connection");
        };


        



        if (webConnectionStatus == "error") { 
			webView.Hide();
        }else{

            webView.ReferenceRectTransform = myUITransform;
           // webView.Show();
             webView.AddUrlScheme("pag");
            webView.OnPageFinished += (view, statusCode, url) => {
                // Page load finished


                Debug.Log("status = " + statusCode);

                if (statusCode != 200)
                {
                    webView.Hide();
                    
                }
                
                webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
                //webView.Show(true, UniWebViewTransitionEdge.Bottom, 1.5f);
                webView.Show();
                //StartCoroutine(hideME());                
               // webView.CleanCache();
                //myTextEval.text = "Connected";
            };

            webView.CleanCache();

        }
		
		IEnumerator hideME(){
            yield return new WaitForSeconds(5f);
            webView.Hide();
        }
		
		

		webView.OnMessageReceived += (view, message) => {

           webView.Hide();


            /*
            if (message.Path.Equals("SetOneSignal")) {
				var OneSignalU_id = message.Args["id"];
				

                //OneSignal.SendTag("u_id", OneSignalU_id.ToString());
				//Debug.Log("OneSignalU_id: " + OneSignalU_id.ToString() );
               // OneSignal.SetExternalUserId(OneSignalU_id.ToString());

                webView.EvaluateJavaScript("alert('tag sent ' + OneSignalU_id.ToString())", (payload) => {
                        string htmldata = payload.data;                       
                    });

			}
            */

            
            if (message.Path.Equals("SocketData")) {
				var data = message.Args["d"];
                NetworkController.SendMessage("SocketData", data);
                //Debug.Log("SocketData" + data);								
			}


            if (message.Path.Equals("savedata")) {
				var u = message.Args["username"];
				var p = message.Args["password"];
				Debug.Log("Data: " + u + p );
				//errText.text ="Data: " + u + p ;
				PlayerPrefs.SetString("u", u);
				PlayerPrefs.SetString("p", p);
				//webView.Hide();
			}

			if (message.Path.Equals("getdataFB")) {
			
			Debug.Log("getdataFB");
                // var info = message.Args["info"];

                webView.Hide();

                
                GameObject Main_Controller = GameObject.FindGameObjectWithTag("Main_Controller") as GameObject;
                Main_Controller.SendMessage("FBLogin");
                /*
                GameObject Main_Control = GameObject.FindGameObjectWithTag("Main_Control");
                Main_Control.SendMessage("ShowInfoPanel", "Logging in");
                */
                

            }

            
            

            if (message.Path.Equals("loadGameTemplate"))
            {
                var gid = message.Args["gameid"];
                Debug.Log(gid);
                GameObject Main = GameObject.FindWithTag("Main");
                Main.SendMessage("ChangeGame", gid);
                Main.SendMessage("AddToListahan", gid);
                Main.SendMessage("writingJsonAgain");
            }
            

            if (message.Path.Equals("hideWebView"))
            {
                webView.Hide();
            }

            if (message.Path.Equals("OpenMsgr"))
            {
                var fb_name = message.Args["fb_name"];
                Application.OpenURL("https://m.me/" + fb_name);
            }

            if (message.Path.Equals("OpenUrl"))
            {
                var url_target = message.Args["url_target"];
                Debug.Log(url_target);
                Application.OpenURL("https://"+url_target);
            }

            
            if (message.Path.Equals("ShareGame"))
            {
                var d = message.Args["d"];
                Debug.Log(d);
                Application.OpenURL("https://holoworld.asia/gamekoyan/share.php?d="+d);
            }

            if (message.Path.Equals("loadMobile"))
            {
                webView.Show(true, UniWebViewTransitionEdge.Bottom, 1.5f);
                Debug.Log("loadMobile");
                loadMobile = "yes";
            }

            if (message.Path.Equals("FbShare"))
            {
                var photolink = message.Args["photolink"];
                FBShare(photolink);
            }

            if (message.Path.Equals("makeDataSet"))
            {
                
                if (string.IsNullOrEmpty(fb_id)) {
                //infoText.SendMessage("SetText", "Internet gateway changes, Please reload the app and login again");
                 hideWebView();   
                } else{
                
                GameObject TargetOnFly = GameObject.FindGameObjectWithTag("TargetOnFly");
                TargetOnFly.SendMessage("takePhotoButtonEnable");
                hideWebView();



                }
                
                
            }

            if (message.Path.Equals("loadHoloGroup"))
            {

                
                var group = message.Args["group"];
                GameObject Managers = GameObject.FindGameObjectWithTag("Managers");
                Managers.SendMessage("LoadHoloFromWeb", group);
                hideWebView();
               
                //GameObject infoText = GameObject.FindGameObjectWithTag("infoText");
               // infoText.SendMessage("SetText", group);
            }

            

            if (message.Path.Equals("PreviewHolo"))
            {

                var holo = message.Args["holo"];
                GameObject HelloPoly = GameObject.FindGameObjectWithTag("HelloPoly");
                HelloPoly.SendMessage("LoadPoly", holo);
                hideWebView();

                //GameObject infoText = GameObject.FindGameObjectWithTag("infoText");
              //  infoText.SendMessage("SetText", "Loading Holo: " + holo);
            }



           // Debug.Log(message.Path);
           // string urlpath = message.Path.ToString();
           // StartCoroutine(LoadURL(urlpath));

        };




		webView.OnShouldClose += (view) => {
            webView = null;
            return true;
           // QuitPanel.SetActive(true);
        };


        
        // Enable line below to enable logging if you are having issues setting up OneSignal. (logLevel, visualLogLevel)
        // OneSignal.SetLogLevel(OneSignal.LOG_LEVEL.INFO, OneSignal.LOG_LEVEL.INFO);
    /*
        OneSignal.StartInit("d26ed769-acdf-4091-95b3-160334451d97")
          .HandleNotificationOpened(HandleNotificationOpened)
          .EndInit();

        OneSignal.inFocusDisplayType = OneSignal.OSInFocusDisplayOption.Notification;
      */  

    }

    /*
    // Gets called when the player opens the notification.
    private static void HandleNotificationOpened(OSNotificationOpenedResult result)
    {

        GameObject WebController = GameObject.FindGameObjectWithTag("UniwebController");

        WebController.SendMessage("AjaxOpen", "notification.php");


    }
    */
	public void ShowWebView(){

        if (webConnectionStatus == "error") { 
			webView.Hide();
            return;
        }

            webView.Show(true, UniWebViewTransitionEdge.Bottom, 1.5f);

        if (loadMobile == "yes")
        {
            webView.Show(true, UniWebViewTransitionEdge.Bottom, 1.5f);
            //SplashPanel.SetActive(false);

        }
        else {
           // GameObject Main_Control = GameObject.FindGameObjectWithTag("Main_Control");
           // Main_Control.SendMessage("ShowInfoPanel", "Unable to connect to server");

        }


	}

    void OnStart()
    {

        n++;
        if (n < 2) { 
        GameObject Uni = GameObject.FindWithTag("UniwebController");
        Uni.SendMessage("LoadURL", urltarget);
        }
       
    }


    void QuitApp(){
        Application.Quit();
    }

    public void UrlLoader(string urlpath){

        StartCoroutine(LoadURL(urlpath));
    }

    IEnumerator LoadURL(string urlpath){
        //QuitPanel.SetActive(false);

        //webView.RemoveUrlScheme("https");
        yield return new WaitForSeconds(0.5f);

        webView.OnPageErrorReceived += (view, error, message) => {
            print("Errored.");
            webConnectionStatus = "error";
            errText.text = "Please check your internet connection";
            TryAgain.text = "Please check your internet connection, Tap to try again";
            TryAgainPanel.SetActive(true);
            webView.Hide();
        };


        webView.Load("https://" +  urlpath);
        webView.Show();
        Debug.Log("https://" + urlpath);
        //errText.text = "https://" + urlpath;

       

        webView.OnPageFinished += (view, statusCode, url) => {
            // Page load finished


            Debug.Log("status = " + statusCode);


            webView.ReferenceRectTransform = myUITransform;

            webView.Frame = new Rect(0, 0, Screen.width, Screen.height);


            if (statusCode != 200)
            {
                webView.Hide();

            } else{
                webView.Show();
                webView.SetZoomEnabled(false);
            }
            

        };




    }


    IEnumerator OnLoad(){

        yield return new WaitForSeconds(5.0f);
        Debug.Log("Onload");
        webView.EvaluateJavaScript("loadMobile();", (payload) => {
            if (payload.resultCode.Equals("0"))
            {
                Debug.Log("App Started!");

            }
            else
            {
                Debug.Log("Unable Initialize Mobile Website: " + payload.data);
            }

        });


    }

















    public void NavigationButton(string url){
        StartCoroutine(LoadURL(url));
    }


	// Update is called once per frame
	void historyBack () {
        webView.GoBack();
    }


    IEnumerator ShowQuitPanel(){

        yield return new WaitForSeconds(3.0f);
        QuitPanel.SetActive(true);

    }


    public void goQuit(){

        Application.Quit();

    }

    public void cancelQuit(){

       // SceneManager.UnloadScene(0);
        SceneManager.LoadScene(0);
        //StartCoroutine(LoadURL("beebeelee.com/"));
        //QuitPanel.SetActive(false);
    }



    void hideWebView()
    {

        webView.Hide();

    }


    void FBlogin(string data){

        webView.EvaluateJavaScript("SendPost('&d=" + data + "','processlogin_mobile_fb.php');", (payload) => {
            string htmldata = payload.data;
            StartCoroutine(FBloginCheck(htmldata));
        });

    }




    IEnumerator FBloginCheck(string s){

        yield return new WaitForSeconds(1.0f);

        if (s == "logging in...")
        {

            webView.EvaluateJavaScript("doLog();", (payload) =>
            {
                string htmldata = payload.data;
            });
        }
        else {

            webView.EvaluateJavaScript("ajaxpagefetcher.load('window', 'home.php', true);", (payload) => {
                string htmldata = payload.data;
            });


        }
        //GameObject CheckCoins = GameObject.FindGameObjectWithTag("CheckCoins");
        //CheckCoins.SendMessage("CheckMyCredits");
        //FB_MainMenu.SetActive(false);

    }

        IEnumerator checkIfLoginToGetOneSignalTag(string data){
        
                yield return new WaitForSeconds(10.0f); 

        webView.EvaluateJavaScript("setoneSignal('ha7aidhadf829j2')", (payload) => {
            string htmldata = payload.data;            
        });
    } 

        void checkIfLoginToGetOneSignalTagNow(string data){

                Debug.Log("u_id=" + data);
            myTextEval.text = "u_id=" + data;

        }


    public void triggerBackButton(){

        webView.EvaluateJavaScript("backButton()", (payload) => {
            string htmldata = payload.data;
        });


    }

    public void AjaxOpen(string pagejs){

        if (webConnectionStatus == "error") { 
			webView.Hide();
            return;
        }

            Debug.Log(pagejs);
            string[] p = pagejs.Split('+');
            var page = p[0];
            var js = p[1];

        webView.EvaluateJavaScript("ajaxpagefetcher.load('window', '"+page+"', true "+js+" );", (payload) => {
            string htmldata = payload.data;
        });

        
    }

    void FBShare(string photolink)
    {
        DialogShare.SendMessage("FBSHARE", photolink);
    }


    void SetFbInfos(string fbInfo)
    {

        string[] fb = fbInfo.Split('+');
        fb_id = fb[0];
        fb_email = fb[1];
        fb_fname = fb[2];

    }


    public void MoveObject(){

         webView.EvaluateJavaScript("UnityMove()", (payload) => {
            string htmldata = payload.data;
        });
    }

    public void SendDataToSocket(string data){
        webView.EvaluateJavaScript("DataFromUnity('"+ data +"')", (payload) => {
            string htmldata = payload.data;
        });

    }

}
