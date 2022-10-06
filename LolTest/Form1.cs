using RiotSharp;
using System;
using LolTest.Libs;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace LolTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }


        public static string pass;
        public static string port;
        public static string url = @"https://127.0.0.1:";



        //Get league of legends LCU pass and port
        static void SetDataBeggining()
        {
            try
            {
                var process = Process.GetProcessesByName("LeagueClient").First(); // Or whatever method you are using
                string fullPath = process.MainModule.FileName;
                string path1 = fullPath.Replace(@"\LeagueClient.exe", "");

                using (var fs = new FileStream(path1 + @"\lockfile", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs, Encoding.Default))
                {
                    string a = sr.ReadToEnd();
                    string b = a.Replace(":", " ");
                    string c = string.Join(" ", b.Split().Take(3));
                    string porttemp = c.Split(' ').Last();


                    string b1 = a.Replace(":", " ");
                    string c1 = string.Join(" ", b1.Split().Take(4));
                    string passtemp = c1.Split(' ').Last();


                    pass = passtemp;
                    port = porttemp;


                }


                



            }
            catch (Exception e)
            {
                MessageBox.Show("You are first time user of this app. Please open LoL, so we can register your user. " + e);
            }
        }
        string sumName = "";
        string level = "";
        string percentToNextLvL = "";
        string profileIconId = "";
        string summonerID = "";
        private void setSummmoner()
        {

            try
            {
                // Create a request for the URL. 		
                WebRequest summonerResponse = WebRequest.Create(url + port + Libs.LCUInfo.currentSummoner);
                // If required by the server, set the credentials.
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                        delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                        System.Security.Cryptography.X509Certificates.X509Chain chain,
                        System.Net.Security.SslPolicyErrors sslPolicyErrors)
                        {
                            return true; // **** Always accept
                        };
                summonerResponse.Credentials = new NetworkCredential("riot", pass);
                // Get the response.
                var summonerWebResponse = summonerResponse.GetResponse();
                var summonerWebStream = summonerWebResponse.GetResponseStream();

                var summonerReader = new StreamReader(summonerWebStream);
                var summonerData = summonerReader.ReadToEnd();

                dynamic summonerJson = JsonConvert.DeserializeObject(summonerData);


                sumName = summonerJson["displayName"]; level = summonerJson["summonerLevel"]; profileIconId = summonerJson["profileIconId"];
                nameLabel.Text = sumName;
                lvlLabel.Text = level;
                var newr = WebRequest.Create("https://ddragon.leagueoflegends.com/cdn/" + Libs.Important.newVersion + "/img/profileicon/" + profileIconId + ".png");

                using (var response1 = newr.GetResponse())
                using (var stream1 = response1.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream1);

                }


            }
            catch (Exception ex)
            {
                
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            SetDataBeggining();
            setSummmoner();
            FriendsList();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            lvlLabel.TextAlign = ContentAlignment.MiddleCenter;
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            lvlLabel.Left = (panel1.ClientSize.Width - lvlLabel.Width) / 2;
            nameLabel.Left = (panel1.ClientSize.Width - nameLabel.Width) / 2;







            string data = File.ReadAllText("account.json");
            dynamic json = JsonConvert.DeserializeObject(data);
            string newAcc = json["newacc"];



            

            
        }



        //Get Summoner by name text field
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Libs.GetInfo.getSummonerInfoByName(textBox1.Text);

            }
        }

        bool autoAccept = false;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            SetDataBeggining();
            setSummmoner();
        }


        //autoaccept checkbox tick
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                autoAccept = true;
            }
            else {
                autoAccept = false;
            }
        }



        //Timer2
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (autoAccept == true)
            {
                string auth;

                auth = Base64Encode("riot:" + pass);
                Libs.AutoAccept.Accept(auth, port);




            }

        }





        //ToBase64 Encode
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }



        //Cancel Button
        private void CancelButton_Click(object sender, EventArgs e)
        {
            string auth;

            auth = Base64Encode("riot:" + pass);

            Libs.StartGame.Stop(port, auth);
        }

        //AcceptButton
        private void StartButton_Click(object sender, EventArgs e)
        {
            string auth;

            auth = Base64Encode("riot:" + pass);

            Libs.StartGame.Start(port, auth);
        }








        private void FriendsList()
        {
            int heightint = 2;


            Label friend1 = new Label();
            friend1.Text = "Friend 1";
            friend1.Left = FriendsPanel.Left;
            friend1.Height = FriendsPanel.Height;


            this.Controls.Add(friend1);

        }
    }
}
