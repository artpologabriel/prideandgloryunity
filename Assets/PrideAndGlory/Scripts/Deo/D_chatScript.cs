using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_chatScript : MonoBehaviour
{
    [SerializeField]

    public GameObject chatPanel, textObject;

    public int maxMessages = 25;
    string messages = "";


    List<Message> messageList = new List<Message>();
    // Start is called before the first frame update
    void Start()
    {
        
    }



    void NewChat(string data)
    {
        var N = JSON.Parse(data);
        var mess = N["message"].Value;
        messages = mess;
    }


 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {

            GameObject M = GameObject.FindWithTag("Main");
            string data = "action:NewChat,receiverObj:" + gameObject.name + ",message:New Message";
            M.SendMessage("SendDataToSocket", data);
            string data1 = "New Messages : " + messages;
            SendMessageToChat(data1);
            //Debug.Log("space"+ data);
        }
    }

    public void SendMessageToChat(string text){ 

        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessages = new Message(); 
        newMessages.text = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessages.textObject = newText.GetComponent<Text>();
        newMessages.textObject.text = newMessages.text;

        messageList.Add(newMessages);

    }
}

    [System.Serializable]
    public class Message{
        public string text;
        public Text textObject;
    }
