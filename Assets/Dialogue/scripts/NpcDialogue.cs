using System;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UIElements;


public class NpcDialogue : MonoBehaviour
{
    [SerializeField] private string NpcName;
    [SerializeField] private string NpcJob_Ocupation;
    [TextArea(15, 20)]
    [SerializeField] private string NpcDescription;
    [TextArea(5, 10)]
    [SerializeField] private string OtherNpcs;
    private enum Tone
    {
        Friendly, Neutral, Serious, Apprehensive, Aggressive
    }; 
    
    [SerializeField] private Tone toneType;
    
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
                      NpcName +
                      "NPC job: " +
                      NpcJob_Ocupation +
                      "NPC Description: " +
                      NpcDescription+
                      "Your Tone is"+
                      toneType+
                      "Other NPC residents: " +
                      OtherNpcs,
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
