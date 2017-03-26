using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Win32;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace Helobot
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form1 : Form
    {

        SpeechRecognitionEngine recognizer;

        BaseState currentState = null;

        public Form1()
        {
            InitializeComponent();
            currentState = new Face1(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wmp.Size = new Size(this.Size.Width, this.Size.Height + 60);

            //registry key
            try
            {
                int RegVal = 11001;
                RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);
                Key.Close();
            }
            catch
            {
                MessageBox.Show("Run this as administrator for multiplayer.");
            }


            //setup webbrowser
            webBrowser.ObjectForScripting = this;
            webBrowser.DocumentText = "<html><body><script src=\"https://cdn.webrtc-experiment.com/DataChannel.js\">"
                + "</script><script>var channel = new DataChannel();function create(server){channel.open(server);"
                + "}function join(server){channel.connect(server);}"
                + "function send(text){channel.send(text);}channel.onmessage = function(message, userid)"
                + "{window.external.MessageReceived(message,userid);}</script></body></html>";

            

            //speech recognition
            recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));

            Choices words = new Choices(new string[] { "hello bot", "dance for me", "sing me a song", "what is your code", "do a happy face", "go to sleep", "bye bye hello bot", "do a shrug face"});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(words);

            Grammar servicesGrammar = new Grammar(findServices);
            recognizer.LoadGrammarAsync(servicesGrammar);

            recognizer.SpeechRecognized += recognizer_SpeechRecognized;
            recognizer.SetInputToDefaultAudioDevice();

            recognizer.RecognizeAsync(RecognizeMode.Multiple);


            //start video
            wmp.URL = "videos//faceCollection.mp4";
            timer.Enabled = true;

            try
            {
                serialPort.Open();
            }
            catch
            {
            }
        }

        void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string message = e.Result.Text;
            if (message == "sing me a song")
            {
                this.currentState = new SongState(this);
                label1.Visible = false;
            }
            else if (message == "dance for me")
            {
                this.currentState = new DanceState(this);
                label1.Visible = false;
            }
            else if (message == "what is your code")
            {
                MessageBox.Show("a5d8f-86fj2-009b3-6781c");
            }
            else if (message == "bye bye hello bot")
            {
                Application.Exit();
            }
            else if (message == "go to sleep")
            {
                this.currentState = new Face5(this);
                label1.Visible = false;
            }
            else if (message == "do a happy face")
            {
                this.currentState = new Face1(this);
                label1.Visible = false;
            }
            else if (message == "do a shrug face")
            {
                this.currentState = new Face4(this);
                label1.Visible = false;
            }
        }

        public void SetTime(double time)
        {
            wmp.Ctlcontrols.currentPosition = time;
        }

        public void SetState(BaseState state)
        {
            this.currentState = state;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            currentState.AddTime();
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            webBrowser.Document.InvokeScript("create", new object[] { "a5d8f-86fj2-009b3-6781c" });
        }

        public void MessageReceived(string message, string userID)
        {
            if (message == "face1")
            {
                this.currentState = new Face1(this);
                label1.Visible = false;
            }
            else if (message == "face2")
            {
                this.currentState = new Face2(this);
                label1.Visible = false;
            }
            else if (message == "face3")
            {
                this.currentState = new Face3(this);
                label1.Visible = false;
            }
            else if (message == "face4")
            {
                this.currentState = new Face4(this);
                label1.Visible = false;
            }
            else if (message == "face5")
            {
                this.currentState = new Face5(this);
                label1.Visible = false;
            }
            else if (message == "start_song")
            {
                this.currentState = new SongState(this);
                label1.Visible = false;
            }
            else if (message == "stop_song")
            {
                this.currentState = new Face1(this);
                label1.Visible = false;
            }
            else if (message == "start_song2")
            {
                this.currentState = new DanceState(this);
                label1.Visible = false;
            }
            else if (message == "stop_song2")
            {
                this.currentState = new DanceState(this);
                label1.Visible = false;
            }
            else if (message.StartsWith("q:"))
            {
                this.currentState = new Face1(this);
                label1.Text = message.Substring(2);
                label1.Location = new Point((this.Width - label1.Width) / 2, 30);
                label1.Visible = true;
            }
            else if (message == "Good")
            {
                this.currentState = new GoodAnswer(this);
                label1.Text = "Good!";
                label1.Location = new Point((this.Width - label1.Width) / 2, 30);
                label1.Visible = true;
            }
            else if (message == "Incorrect")
            {
                this.currentState = new BadAnswer(this);
                label1.Text = "Incorrect...";
                label1.Location = new Point((this.Width - label1.Width) / 2, 30);
                label1.Visible = true;
            }
            else if (message == "stop_voice")
            {
                recognizer.RecognizeAsyncStop();
            }
            else if (message == "start_voice")
            {
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }
    }
}
