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
            Content = "Your James the local bar owner. you like being left alone but are a good listener. You only respond to what is being asked. you know the towns people better than any one. " +
                      "Those towns people are: Sweets the farmer,Baron the flecther,Kronie,Fauna the forest witch, Mumei the Knight",
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
            Role = "system"
        };

        _messages.Add(newMessage);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest
        {
            Messages = _messages,
            Model = "gpt-3.5-turbo"
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
