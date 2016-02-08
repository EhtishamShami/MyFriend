﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.IO;
namespace My_Friend
{

    public partial class My_Friend : Form
    {
        public Choices slist = new Choices();
        public String path;
        string[] result = File.ReadAllLines("file.txt");
        public My_Friend()
        {
             InitializeComponent();             
        }
        SpeechSynthesizer speech = new SpeechSynthesizer();
     //   PromptBuilder builder = new PromptBuilder();
        SpeechRecognitionEngine recognize = new SpeechRecognitionEngine();
        private void Form1_Load(object sender, EventArgs e)
        {
            if (result.Length > 1)
            { slist.Add(new string[] { result[0] }); }
            Visualiser.Hide();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //private void button1_Click(object sender, EventArgs e)
        //{

        //    builder.ClearContent();
        //    builder.AppendText(Command.Text);
        //    speech.Speak(builder);
        //}

        //private void pictureBox1_Click_1(object sender, EventArgs e)
        //{
            
        //}
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            InfoBox.Hide();
            try
            {
                 
              
                slist.Add(new string[]{"Hi","What are you doing","who is my love","who is my butterfly","Why","I am feeling sick",
                "I want to Play game","Can you help me","Where do you live","Do you have feelings","I am hungry","Do you want to eat something",
                "Hello","Hey","Take Care","Ok take care","Ok good by","Ok thats it","Ok thats enough","Suggest me few good movies",
                "Good by","Thats it","I want to be a good programmer","Do you want to be friend of mine","Exit","How are you","What is time",
                "Tell me your name","Who is your developer","Who is president of USA","Tell me few products of Pepsi",
                "Who is your favourite star","Who is best Apple or Samsung", "Who is founder of Apple company","I am fine how are you"});
                   
                    Grammar gr = new Grammar(new GrammarBuilder(slist)); 
                    recognize.RequestRecognizerUpdate();
                    recognize.LoadGrammar(gr);
                    recognize.SpeechRecognized += recognize_SpeechRecognized;
                    recognize.SetInputToDefaultAudioDevice();
                    recognize.RecognizeAsync(RecognizeMode.Multiple);
                    //Visualiser.Show();
                
            }
            catch
            {
                return;
            }   
            
        }
        private void recognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Visualiser.Show();  
           // visualizer2.Hide(); 
            
            if (e.Result.Text == "Exit")
            {
                Application.Exit();
            }
            else
            {
                Command.Clear();
                Reply.Clear();
                Command.Text = Command.Text + " " + e.Result.Text.ToString() + " ";
                String question = e.Result.Text.ToString();
                if (result.Length > 1)
                {
                    if (question.Contains(result[0]))
                    {
                        Process.Start(@result[1]);
                    }
                }
                if (question.Contains("who is my butterfly"))
                {
                    Reply.Text = Reply.Text + " She is your butterfly";
                    speech.Speak(" She is your butterfly her name is mujay sharm a gie");
                    Process.Start(@"c:\NVIDIA");
                }
                if (question.Contains("How are you"))
                {
                    Reply.Text = Reply.Text + " I am fine";
                    speech.Speak(" I am fine");
                }
                else if (question.Contains("who is my love"))
                {
                    Reply.Text = Reply.Text + " ooooohhhhhh u know her name i will just give u a hint she is pathan";
                    speech.Speak(" ooooooooooh u know her name i will just give u a hint she is pathan");
                }
                else if (question.Contains("What are you doing"))
                {
                    Reply.Text = Reply.Text + " Answering your questions";
                    speech.Speak(" Answering your questions");
                }
                else if (question.Contains("Lets go for a walk"))
                {
                    Reply.Text = Reply.Text + " Sorry, I can't";
                    speech.Speak(" Sorry, I can't");
                }
                else if (question.Contains("Why"))
                {
                    Reply.Text = Reply.Text + " Because I am just a computer software";
                    speech.Speak(" Because I am just a computer software");
                }
                else if (question.Contains("I am feeling sick"))
                {
                    Reply.Text = Reply.Text + " You should go to a physician";
                    speech.Speak(" You should go to a physician");
                }
                else if (question.Contains("I want to Play game"))
                {
                    Reply.Text = Reply.Text + " You should focus on studies";
                    speech.Speak(" You should focus on studies");
                }
                else if (question.Contains("Can you help me"))
                {
                    Reply.Text = Reply.Text + " How may I help you";
                    speech.Speak(" How may I help you");
                }
                else if (question.Contains("Do you have feelings"))
                {
                    Reply.Text = Reply.Text + " No I don't";
                    speech.Speak(" No I don't");
                }
                else if (question.Contains("I am hungry"))
                {
                    Reply.Text = Reply.Text + " You should eat something";
                    speech.Speak(" You should eat something");
                }
                else if (question.Contains("Where do you live"))
                {
                    Reply.Text = Reply.Text + " I don't live anywhere";
                    speech.Speak(" I don't live anywhere");
                }
                else if (question.Contains("Do you want to eat something"))
                {
                    Reply.Text = Reply.Text + " No I can't eat";
                    speech.Speak(" No I can't eat");
                }
                else if (question.Contains("Hello"))
                {
                    Reply.Text = Reply.Text + " Hello sir";
                    speech.Speak(" Hello sir");
                }
                else if (question.Contains("Hey"))
                {
                    Reply.Text = Reply.Text + " Hey sir";
                    speech.Speak(" Hey sir");
                }
                else if (question.Contains("Take Care"))
                {
                    Application.Exit();
                }
                else if (question.Contains("Suggest me few good movies"))
                {
                    Reply.Text = Reply.Text + " You should google them";
                    speech.Speak(" You should google them");
                }
                else if (question.Contains("I am feeling sick"))
                {
                    Reply.Text = Reply.Text + " You should go to a physician";
                    speech.Speak(" You should go to a physician");
                }
                else if (question.Contains("I want to be a good programmer"))
                {
                    Reply.Text = Reply.Text + " You should work hard then";
                    speech.Speak(" You should work hard then");
                }
                else if (question.Contains("Do you want to be friend of mine"))
                {
                    Reply.Text = Reply.Text + " That is the reason I am designed for";
                    speech.Speak(" That is the reason I am designed for");
                }

                else if (question.Contains("What is time"))
                {
                    //DateTime date = new DateTime();
                    string custom = DateTime.Now.ToLongTimeString();
                    //MessageBox.Show(custom);
                    Reply.Text = Reply.Text + "Its " + custom;
                    speech.Speak("Its " + custom);
                }
                else if (question.Contains("Tell me your name"))
                {
                    Reply.Text = Reply.Text + "My name is My Friend";
                    speech.Speak(" My name is My Friend");
                }
                else if (question.Contains("Who is your developer"))
                {
                    Reply.Text = Reply.Text + "You are my developer";
                    speech.Speak(" You are my developer");
                }
                else if (question.Contains("Who is president of USA"))
                {
                    Reply.Text = Reply.Text + "Barack Obama is the President of USA";
                    speech.Speak(" Barack Obama is the President of USA");
                }
                else if (question.Contains("Tell me few products of Pepsi"))
                {
                    Reply.Text = Reply.Text + "Dew, Pepsi Fanta are Pepsi's product";
                    speech.Speak("Dew, Pepsi Fanta are Pepsi's product");
                }
                else if (question.Contains("Who is your favourite star"))
                {
                    Reply.Text = Reply.Text + "Johnny Depp is my favourite star";
                    speech.Speak(" Johnny Depp is my favourite star");
                }
                else if (question.Contains("Who is best Apple or Samsung"))
                {
                    Reply.Text = Reply.Text + "Both are best but my choice is Apple";
                    speech.Speak(" Both are best but my choice is Apple");
                }
                else if (question.Contains("Who is founder of Apple company"))
                {
                    Reply.Text = Reply.Text + "Steve Jobs is the fouder of Apple company";
                    speech.Speak(" Steve Jobs is the fouder of Apple company");
                }
                else if (question.Contains("Exit"))
                {
                    Application.Exit();

                }
                else if (question.Contains("Take Care"))
                {
                    Application.Exit();

                }
                else if (question.Contains("Ok take care"))
                {
                    Application.Exit();

                }
                else if (question.Contains("Ok good by"))
                {
                    Application.Exit();

                }
                else if (question.Contains("Ok thats it"))
                {
                    Application.Exit();

                }
                else if (question.Contains("Ok thats enough"))
                {
                    Application.Exit();

                }
                else if (question.Contains("Good by"))
                {
                    Application.Exit();

                }
                else if (question.Contains("Thats it"))
                {
                    Application.Exit();

                }
                else if (question.Contains("Thats enough"))
                {
                    Application.Exit();

                }
                Visualiser.Hide();
            }
        }          
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Binder obj = new Binder();
            obj.Show();
            this.Hide();
        }
    }
}
