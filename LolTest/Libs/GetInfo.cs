using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;

namespace LolTest.Libs
{
    public class GetInfo
    {
        public static Form frm = new Form();
        public static void getSummonerInfoByName(string name)
        {

            try
            {
                var url = "https://" + Important.Region + ".api.riotgames.com/lol/summoner/v4/summoners/by-name/" + name + "?api_key= " + Important.API;

                var request = WebRequest.Create(url);
                request.Method = "GET";

                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();

                var reader = new StreamReader(webStream);
                var data = reader.ReadToEnd();
                dynamic json = JsonConvert.DeserializeObject(data);
                string level = json["summonerLevel"];
                int iconNum = json["profileIconId"];
                string sumName = json["name"];

                

                frm.Text = "Info about " + name;
                frm.Width = 600;
                frm.Height = 900;
                Color color = Color.FromArgb(83, 77, 86);
                Color text1 = Color.FromArgb(248, 241, 255);
                frm.BackColor = color;
                frm.FormBorderStyle = FormBorderStyle.None;


                PictureBox exitButton = new PictureBox();

                var exitb = WebRequest.Create("https://imgur.com/TszRqQN.png");

                using (var responseb = exitb.GetResponse())
                using (var streamb = responseb.GetResponseStream())
                {
                    exitButton.Image = Bitmap.FromStream(streamb);

                }
                exitButton.SizeMode = PictureBoxSizeMode.StretchImage;
                exitButton.Width = 20;
                exitButton.Height = 20;
                exitButton.Left = (frm.ClientSize.Width - 1);
                exitButton.Top = 1;
                exitButton.Click += ExitButton_Click;



                //PictureBox
                PictureBox summonerIcon = new PictureBox();


                var newr = WebRequest.Create("https://ddragon.leagueoflegends.com/cdn/" + Important.newVersion + "/img/profileicon/" + iconNum + ".png");

                using (var response1 = newr.GetResponse())
                using (var stream1 = response1.GetResponseStream())
                {
                    summonerIcon.Image = Bitmap.FromStream(stream1);

                }
                summonerIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                summonerIcon.Width = 150;
                summonerIcon.Height = 150;
                summonerIcon.Left = (frm.ClientSize.Width - summonerIcon.Width) / 2;
                summonerIcon.Top = 50;









                //SummonerLevel
                Label summonerLevel = new Label();
                summonerLevel.Text = level;
                summonerLevel.Name = "SummonerLevel";
                summonerLevel.Left = (frm.ClientSize.Width - summonerLevel.Width) / 2;
                summonerLevel.Top = 25;
                summonerLevel.ForeColor = text1;
                summonerLevel.TextAlign = ContentAlignment.MiddleCenter;



                //SummonerName
                Label summonerName = new Label();
                summonerName.Text = sumName;
                summonerName.Name = "SummonerName";
                summonerName.Left = (frm.ClientSize.Width - summonerLevel.Width) / 2;
                summonerName.Top = 200;
                summonerName.ForeColor = text1;
                summonerName.TextAlign = ContentAlignment.MiddleCenter;

                frm.Controls.Add(summonerName);
                frm.Controls.Add(summonerLevel);
                frm.Controls.Add(summonerIcon);
                frm.Controls.Add(exitButton);

                frm.Show();
            } catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private static void ExitButton_Click(object sender, EventArgs e)
        {
            frm.Close();
        }


        public static string pass;
        public static string port;
        public static string url = @"https://127.0.0.1:";


        public static void noRegister()
        {

            try{
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



                setSummmoner();



            } catch (Exception e)
            {
                MessageBox.Show("You are first time user of this app. Please open LoL, so we can register your user. " + e);
            }





        }


        static void setSummmoner()
        {
            try
            {
                // Create a request for the URL. 		
                WebRequest summonerResponse = WebRequest.Create(url + port + LCUInfo.currentSummoner);
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
                string sumName = summonerJson["displayName"];

                string data = File.ReadAllText("account.json");
                dynamic json = JsonConvert.DeserializeObject(data);
                string newAcc = json["newacc"];
                json["summoner"] = sumName;

                
            }
            catch
            {

            }



        }
































        public static ComboBox regionbox = new ComboBox();
        public static TextBox name = new TextBox();
        public static Form form = new Form();
        public static void newRegister()
        {

            Color color = Color.FromArgb(83, 77, 86);
            Color text1 = Color.FromArgb(248, 241, 255);


            form.FormBorderStyle = FormBorderStyle.None;
            form.Text = "New Account registration";
            form.Width = 200;
            form.Height = 250;
            form.BackColor = color;


            Label maintext = new Label();
            maintext.Text = "New account registration!";
            maintext.Left = (form.ClientSize.Width - maintext.Width) / 2;
            maintext.Top = 0;
            maintext.TextAlign = ContentAlignment.MiddleCenter;
            maintext.ForeColor = text1;
            maintext.Font = new Font("Segoe UI", 13);

            Label nametext = new Label();
            nametext.Text = "Summoner Name";
            nametext.Left = (form.ClientSize.Width - nametext.Width) / 2;
            nametext.Top = 20;
            nametext.TextAlign = ContentAlignment.MiddleCenter;
            nametext.ForeColor = text1;
            nametext.Font = new Font("Segoe UI", 8);

            Label selectReg = new Label();
            selectReg.Text = "Select region";
            selectReg.Left = (form.ClientSize.Width - selectReg.Width) / 2;
            selectReg.Top = 80;
            selectReg.TextAlign = ContentAlignment.MiddleCenter;
            selectReg.ForeColor = text1;
            selectReg.Font = new Font("Segoe UI", 8);

            name.Left = (form.ClientSize.Width - name.Width) / 2;
            name.Top = 40;


            regionbox.DropDownStyle = ComboBoxStyle.DropDownList;
            regionbox.Items.Add("EUNE");
            regionbox.Items.Add("EUW");
            regionbox.Items.Add("NA");
            regionbox.Items.Add("Brazil");
            regionbox.Items.Add("Oceania");
            regionbox.Items.Add("Russia");
            regionbox.Items.Add("Turkey");
            regionbox.Items.Add("Japan");
            regionbox.Items.Add("LAN");
            regionbox.Left = (form.ClientSize.Width - regionbox.Width) / 2;
            regionbox.Top = 100;


            Button confirm = new Button();
            confirm.Text = "Done";
            confirm.Left = (form.ClientSize.Width - confirm.Width) / 2;
            confirm.Top = 200;
            confirm.ForeColor = text1;
            confirm.Font = new Font("Segoe UI", 8);

            form.Controls.Add(name);
            form.Controls.Add(regionbox);
            form.Controls.Add(confirm);
            form.Controls.Add(maintext);
            form.Controls.Add(nametext);
            form.Controls.Add(selectReg);

            confirm.Click += Confirm_Click;
            form.Show();
        }




        private static void Confirm_Click(object sender, EventArgs e)
        {
            string dataacc = File.ReadAllText("account.json");
            dynamic jsonacc = JsonConvert.DeserializeObject(dataacc);
            string newAcc = jsonacc["newacc"];
            string summoner = jsonacc["summoner"];
            string server = jsonacc["server"];


            if (regionbox.Text == "EUNE")
            {
                jsonacc["server"] = "eun1";
            }else if(regionbox.Text == "EUW")
            {
                Properties.Settings.Default.serverRegion = "euw1";
            }
            else if (regionbox.Text == "NA")
            {
                Properties.Settings.Default.serverRegion = "na1";
            }
            else if (regionbox.Text == "Brazil")
            {
                Properties.Settings.Default.serverRegion = "br1";
            }
            else if (regionbox.Text == "Oceania")
            {
                Properties.Settings.Default.serverRegion = "oc1";
            }
            else if (regionbox.Text == "Russia")
            {
                Properties.Settings.Default.serverRegion = "ru1";
            }
            else if (regionbox.Text == "Turkey")
            {
                Properties.Settings.Default.serverRegion = "tr1";
            }
            else if (regionbox.Text == "Japan")
            {
                Properties.Settings.Default.serverRegion = "jp1";
            }
            else if (regionbox.Text == "LAN")
            {
                Properties.Settings.Default.serverRegion = "la1";
            }

            Properties.Settings.Default.summonerAcc = name.Text;


            try{
                var url = "https://" + Properties.Settings.Default.serverRegion + ".api.riotgames.com/lol/summoner/v4/summoners/by-name/" + Properties.Settings.Default.summonerAcc + "?api_key= " + Important.API;

                var request = WebRequest.Create(url);
                request.Method = "GET";

                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();

                var reader = new StreamReader(webStream);
                var data = reader.ReadToEnd();
                dynamic json = JsonConvert.DeserializeObject(data);
                string sumName = json["name"];
                if (sumName == Properties.Settings.Default.summonerAcc)
                {
                    Properties.Settings.Default.newUser = false;
                    form.Close();
                }
                

            }
            catch
            {
                MessageBox.Show("Invalid Account");
            }


        }
    }




}
