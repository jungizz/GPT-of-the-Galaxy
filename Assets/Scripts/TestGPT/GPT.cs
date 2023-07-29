using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.Runtime;

namespace OpenAI
{
    public class GPT : MonoBehaviour
    {
        [SerializeField] private Button recordButton;
        [SerializeField] private Image progressBar;
        [SerializeField] private Text message;
        [SerializeField] private Dropdown dropdown;
        [SerializeField] private Text answer;

        private readonly string fileName = "output.wav";
        private readonly int duration = 5;

        private AudioClip clip;
        private bool isRecording;
        private float time;
        private OpenAIApi openai = new OpenAIApi();

        private List<ChatMessage> messages = new List<ChatMessage>();
        private string prompt = "너는 한국어만 사용한다. 너는 우주에 대해 잘 안다. You keep your responses short and the point. Don't break character.";

        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            dropdown.options.Add(new Dropdown.OptionData("Microphone not supported on WebGL"));
#else
            foreach (var device in Microphone.devices)
            {
                dropdown.options.Add(new Dropdown.OptionData(device));
            }
            recordButton.onClick.AddListener(StartRecording);
            dropdown.onValueChanged.AddListener(ChangeMicrophone);

            var index = PlayerPrefs.GetInt("user-mic-device-index");
            dropdown.SetValueWithoutNotify(index);

#endif
        }

        private void ChangeMicrophone(int index)
        {
            PlayerPrefs.SetInt("user-mic-device-index", index);
        }

        private void StartRecording()
        {
            isRecording = true;
            recordButton.enabled = false;

            var index = PlayerPrefs.GetInt("user-mic-device-index");

#if !UNITY_WEBGL
            clip = Microphone.Start(dropdown.options[index].text, false, duration, 44100);
#endif
        }

        public async void EndRecording()
        {
            message.text = "입력 중...";

#if !UNITY_WEBGL
            Microphone.End(null);
#endif

            byte[] data = SaveWav.Save(fileName, clip);

            var req = new CreateAudioTranscriptionsRequest
            {
                FileData = new FileData() { Data = data, Name = "audio.wav" },
                // File = Application.persistentDataPath + "/" + fileName,
                Model = "whisper-1",
                Temperature = 0.1f, // 랜덤대답
                //MaxTokens = 1000,
                Language = "ko"
            };
            var res = await openai.CreateAudioTranscription(req);

            progressBar.fillAmount = 0;
            message.text = res.Text;
            answer.text = "답변 중...";
            recordButton.enabled = true;

            ChatMessage newMessage = new ChatMessage();
            newMessage.Content = res.Text;
            newMessage.Role = "user";

            messages.Add(newMessage);

            CreateChatCompletionRequest request = new CreateChatCompletionRequest();
            request.Messages = messages;
            request.Model = "gpt-3.5-turbo";

            var response = await openai.CreateChatCompletion(request);

            if (response.Choices != null && response.Choices.Count > 0)
            {
                var chatResponse = response.Choices[0].Message;
                messages.Add(chatResponse);

                answer.text = chatResponse.Content;
            }

            var credentials = new BasicAWSCredentials("AKIA23G7G5VBWR5NUR7J", "XnD+jcOgHM35JMENcjJCF/VjVEby7NES5gSDa5wA");
            var client = new AmazonPollyClient(credentials, RegionEndpoint.EUCentral1);

            var request2 = new SynthesizeSpeechRequest()
            {
                Text = answer.text,
                Engine = Engine.Neural,
                VoiceId = VoiceId.Seoyeon,
                OutputFormat = OutputFormat.Mp3
            };

            var response2 = await client.SynthesizeSpeechAsync(request2);

            WriteIntoFile(response2.AudioStream);

            using (var www = UnityWebRequestMultimedia.GetAudioClip($"{ Application.persistentDataPath }/audio.mp3", AudioType.MPEG))
            {
                var op = www.SendWebRequest();

                while (!op.isDone) await Task.Yield();

                var clip = DownloadHandlerAudioClip.GetContent(www);

                audioSource.clip = clip;
                audioSource.Play();
            }
        }

        private void Update()
        {
            if (isRecording)
            {
                time += Time.deltaTime;
                progressBar.fillAmount = time / duration;

                if (time >= duration)
                {
                    time = 0;
                    isRecording = false;
                    EndRecording();
                }
            }
        }

        private void WriteIntoFile(Stream stream)
        {
            using (var fileStream = new FileStream($"{ Application.persistentDataPath }/audio.mp3", FileMode.Create))
            {
                byte[] buffer = new byte[8 * 1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
