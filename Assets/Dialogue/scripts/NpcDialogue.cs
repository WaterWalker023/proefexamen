using System;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class NpcDialogue : MonoBehaviour
{
    
    private enum Tone
    {
        Friendly, Neutral, Serious, Apprehensive, Aggressive
    };

    [SerializeField] private string startInput;
    [SerializeField] private string NpcName;
    [SerializeField] private string NpcOccupation;
    
    [TextArea(10, 20)] [SerializeField] private string NpcDescription;
    [TextArea(5, 10)] [SerializeField] private string OtherNpcs;
    [TextArea(5, 10)] [SerializeField] private string textForQuest;
    
    [SerializeField] private Tone toneType;
    
    public OnResponseEvent onResponse;
    
    [SerializeField] private GameObject dia;
    
    [SerializeField] private GameObject inputField;
    [SerializeField] private bool _hasDoneQuest;
    [Serializable]
    public class OnResponseEvent: UnityEvent<string>
    {
        
    }
    
    private OpenAIApi _openAI = new (Environment.GetEnvironmentVariable("OPENAI_API_KEY", EnvironmentVariableTarget.User));
    private List<ChatMessage> _messages = new List<ChatMessage>();
    private bool _once;
    
    public void ActivedUi()
    {
        dia.SetActive (true);
        dia.transform.Find("NPC_Name").transform.Find("Name_txt").GetComponent<TMP_Text>().SetText(NpcName);
        inputField.GetComponent<TMP_InputField>().onEndEdit.AddListener(AskChatGpt);
        Time.timeScale = 0;
        Choices(startInput);
    }
    
    public void DeactivedUi()
    {
        inputField.GetComponent<TMP_InputField>().onEndEdit.RemoveListener(AskChatGpt);
        onResponse.Invoke("....");
        dia.SetActive(false);
        Time.timeScale = 1;
    }


    public void Choices(string text)
    {
        if (!_hasDoneQuest)
        {
            onResponse.Invoke(textForQuest);
        }
        else
        {
            AskChatGpt(text);
        }
    }
    
    private async void AskChatGpt(string newText)
    {
        ChatMessage devMessage = new ChatMessage
        {
            Content = "you are:" +
                      "NPC: " +
                      NpcName +
                      "NPC Occupation: " +
                      NpcOccupation +
                      "NPC Description: " +
                      NpcDescription +
                      "Your Tone is" +
                      toneType,
            Role = "developer"
        };
        if (!_once)
        {
            _messages.Add(devMessage);
            _once = true;
        }

        if (_hasDoneQuest)
        {
            ChatMessage Quest = new ChatMessage
            {
                Content = "the player has completed your request"+
                          "Other NPC residents: " +
                          OtherNpcs+
                          "when asked about other people only use the info you know dont generate locations for them",
                Role = "developer"
            };
            _messages.Add(Quest);
        }
        
        
        ChatMessage newMessage = new ChatMessage()
        {
            Content = newText,
            Role = "system"
        };
        
        _messages.Add(newMessage);
        
        CreateChatCompletionRequest request = new CreateChatCompletionRequest
        {
            Messages = _messages,
            Model = "gpt-3.5-turbo",
            Temperature = 0.85f
        };

        var response = await _openAI.CreateChatCompletion(request);
       
        if (response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            _messages.Add(chatResponse);
            onResponse.Invoke(chatResponse.Content);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
