using System;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UIElements;


public class TestDial : MonoBehaviour
{
    public OnResponseEvent onResponse;
    
    [Serializable]
    public class OnResponseEvent: UnityEvent<string>
    {
        
    }
    private OpenAIApi _openAI = new (Environment.GetEnvironmentVariable("OPENAI_API_KEY", EnvironmentVariableTarget.User));
    private List<ChatMessage> _messages = new List<ChatMessage>();
    private bool _once;
    public async void AskChatGPT(string newText)
    {
        ChatMessage devMessage = new ChatMessage
        {
            Content = "you are:"+
                      "NPC: " +
                      "James; " +
                      "NPC job: " +
                      "Town Bar owner; " +
                      "NPC Description: " +
                      "James is an older fellow that runs the only bar on this island and thus has interacted with a lot of people." +
                      "He has a lot of drinks like chocomelk, koffie and thee. " +
                      "He also has a deer head he shot himself he is realy proud of that. " +
                      "He also was on a cool adventure that he cant stop talking about" +
                      "Other NPC residents: " +
                      "Sweets the farmer,Baron the flecther,Kronie the Mage,Fauna the forest witch, Mumei the Knight; ",
            Role = "developer"
        };
        if (!_once)
        {
            _messages.Add(devMessage);
            _once = true;
        }
    
        ChatMessage newMessage = new ChatMessage
        {
            Content = newText,
            Role = "user"
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
            
            Debug.Log(chatResponse.Content);
            
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
