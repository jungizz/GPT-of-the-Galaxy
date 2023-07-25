using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        public string chatgptstring = null;
    //  [SerializeField] private InputField inputField;
    //  [SerializeField] private Button button;
    //  [SerializeField] private ScrollRect scroll;

    [SerializeField] private RectTransform sent;
    [SerializeField] private RectTransform received;

    private float height;
    private OpenAIApi openai = new OpenAIApi();

    private List<ChatMessage> messages = new List<ChatMessage>();
    private string prompt = "너는 한국인이다. 너는 우주에 대해 잘 안다. You know about galaxy. You keep your responses short and the point. Don't break character. Don't ever mention that you are an AI model.";

    // TestToSpeech _TTS;
    CSSRecord _STT;

    public bool gptflag = false;
    public string fromgptsentence;

    private void Start()
    {
        //_TTS = GameObject.Find("NPC").transform.GetChild(0).GetComponent<TestToSpeech>();
        _STT = GameObject.Find("Mic").GetComponent<CSSRecord>();
        // button.onClick.AddListener(SendReply);
        // StartCoroutine(WaitForIt());
    }

    public void gptclick()
    {
        Invoke("SendReply", 9f);
    }

    public async void SendReply()
    {
        var newMessage = new ChatMessage()
        {
            Role = "user",
            Content = _STT.sentence
        };

        // AppendMessage(newMessage);

        if (messages.Count == 0) newMessage.Content = prompt + "\n" + _STT.sentence;

        messages.Add(newMessage);

        // Complete the instruction
        var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
        {
            Model = "gpt-3.5-turbo-0301",
            Temperature = 0.1f, // 랜덤대답
            MaxTokens = 1000,
            Messages = messages
        });

        if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
        {
            var message = completionResponse.Choices[0].Message;
            Debug.Log(message.Content);

            //gptflag = true;
            fromgptsentence = message.Content;
            message.Content = message.Content.Trim();
            messages.Add(message);
            // AppendMessage(message);
        }
        else
        {
            Debug.LogWarning("No text was generated from this prompt.");
        }

        gptflag = false;
        
      }
   }
}
