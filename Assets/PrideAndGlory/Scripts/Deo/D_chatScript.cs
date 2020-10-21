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
    string messages ="";
    public InputField chatBox;
    public Color playerMessage, info;


    List<Message> messageList = new List<Message>();
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                messages = chatBox.text;
                GameObject M = GameObject.FindWithTag("Main");
                string data = "action:Chat,receiverObj:" + gameObject.name + ",message:"+ chatBox.text;
                Debug.Log(data);
                M.SendMessage("SendDataToSocket", data);
                SendMessageToChat(messages, Message.MessaType.playerMessage);
                chatBox.text = "";
            }

        }
        else {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return)) {
                chatBox.ActivateInputField();
            }
        }
    }

    void Chat(string data)
    {
        var N = JSON.Parse(data);
        var mess = N["message"].Values;
        Debug.Log("Here Deo"+mess);

        messages = mess.ToString();
    }

    public void SendMessageToChat(string text,Message.MessaType messageType){ 

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
    public MessaType messaType;
    public enum MessaType { 
        playerMessage,
        info

    }
    }
