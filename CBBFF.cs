using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.InteropServices;
using X.Bluesky;
using X.Bluesky.Models;
using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace ColorlessBlueBotsFlyFuriously
{
    internal class CBBFF
    {
        static async Task Main()
        {
            // Variables
            string path = Directory.GetCurrentDirectory();
            string handle = "";
            string pass = "";
            Random rand = new Random();
            int field = 0;
            int doxa = 0;
            string startTime = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            bool test = false;

            // Logging setup
            if (!Directory.Exists(path + "/Logs/"))
            {
                Directory.CreateDirectory(path + "/Logs");
                Log("Creating log directory...");
            }
            Log("Creating log file...");
            File.WriteAllText(path + "/Logs/" + startTime + ".txt", "");

            // Initialization
            Log("Welcome to ColorlessBlueBotFlyFuriously!");
            Log("Source repo: https://github.com/jmlwhittington/ColorlessBlueBotsFlyFuriously");

            // Login setup
            if (!File.Exists(path + "/Content/login.txt"))
            {
                File.WriteAllText(path + "/Content/login.txt",
                    "===INPUT ALL ENTRIES ON THE LINE FOLLOWING THE LABEL===" + Environment.NewLine + Environment.NewLine +
                    "HANDLE:" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                    "PASSWORD/APP PASSWORD:" + Environment.NewLine
                );
                Log("You need to input your handle and password/app password into login.txt! It can be found in the Content folder at the same location as this program.");
                Log("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Log("Retrieving login details...");
                string[] login = File.ReadAllLines(path + "/Content/login.txt");
                foreach (string item in login)
                {
                    handle = login[3];
                    pass = login[6];
                }
                Log("Login success!");
            }

            // For testing in console without posting
            //Test();

            // Initation and cycling
            while (test == false)
            {
                // Syncing post time
                if (DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8).Substring(0, 2) != "00")
                {
                    Log("Waiting for the minute mark...");
                    while (DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 5).Substring(0, 2) != "00")
                    {
                        Thread.Sleep(1000);
                    }
                    Log("Waiting for the hour mark...");
                    while (DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8).Substring(0, 2) != "00")
                    {
                        Thread.Sleep(60000);
                    }
                }
                await Post();
                Thread.Sleep(60000);
            }

            // Posting function, after other steps are ran
            async Task Post()
            {
                BlueskyClient client = new BlueskyClient(handle, pass);
                // Hard reset
                if (field >= 4)
                {
                    field = 0;
                    doxa = 0;
                    if (test == false)
                    {
                        await client.Post("REINITIALIZING...!");
                    }
                    Log("Posted REINITIALIZING...!");
                }
                // Typical loop
                else
                {
                    Influence();
                    string selection = Selection();
                    // The most interesting category...
                    if (selection == "Wild")
                    {
                        int chatter = Divination();
                        string blank = Blank();
                        int first = 0;
                        int second = 0;
                        int third = 0;
                        int fourth = 0;
                        if (blank == "n")
                        {
                            await WildPost();
                        }
                        switch (chatter)
                        {
                            case 1:
                                first = rand.Next(1, 60);
                                Log("Chatter: " + chatter + " | First: " + first + " | Doxa: " + doxa + " | Field: " + field);
                                break;
                            case 2:
                                first = rand.Next(1, 59);
                                second = rand.Next(first + 1, 60);
                                Log("Chatter: " + chatter + " | First: " + first + " | Second: " + second + " | Doxa: " + doxa + " | Field: " + field);
                                break;
                            case 3:
                                first = rand.Next(1, 58);
                                second = rand.Next(first + 1, 59);
                                third = rand.Next(second + 1, 60);
                                Log("Chatter: " + chatter + " | First: " + first + " | Second: " + second + " | Third: " + third + " | Doxa: " + doxa + " | Field: " + field);
                                break;
                            case 4:
                                first = rand.Next(1, 57);
                                second = rand.Next(first + 1, 58);
                                third = rand.Next(second + 1, 59);
                                fourth = rand.Next(third + 1, 60);
                                Log("Chatter: " + chatter + " | First: " + first + " | Second: " + second + " | Third: " + third + " | Fourth: " + fourth + " | Doxa: " + doxa + " | Field: " + field);
                                break;
                        }
                        if (first > 0)
                        {
                            if (test == false)
                            {
                                Log("Sleeping " + first + " minutes...");
                                Thread.Sleep(first * 1000);
                            }
                            await WildPost();
                        }
                        if (second > 0)
                        {
                            if (test == false)
                            {
                                Log("Sleeping " + second + " minutes...");
                                Thread.Sleep(second * 1000);
                            }
                            await WildPost();
                        }
                        if (third > 0)
                        {
                            if (test == false)
                            {
                                Log("Sleeping " + third + " minutes...");
                                Thread.Sleep(third * 1000);
                            }
                            await WildPost();
                        }
                        if (fourth > 0)
                        {
                            if (test == false)
                            {
                                Log("Sleeping " + fourth + " minutes...");
                                Thread.Sleep(fourth * 1000);
                            }
                            await WildPost();
                        }
                    }
                    // Structure of post: "ADJ-suffix ADJ N-pl V ADV[punc]"
                    else if (selection == "Chomsky")
                    {
                        string[] adj_suffix = File.ReadAllLines(path + "/Content/Chomsky + Tesnière/adj-suffix-cap.txt");
                        string[] adj = File.ReadAllLines(path + "/Content/Chomsky + Tesnière/adj.txt");
                        string[] n = File.ReadAllLines(path + "/Content/Chomsky + Tesnière/n.txt");
                        string[] v = File.ReadAllLines(path + "/Content/Chomsky + Tesnière/v.txt");
                        string[] adv = File.ReadAllLines(path + "/Content/Chomsky + Tesnière/adv.txt");
                        string[] punc = [".", "!", "?", "...?", "...!", "?!"];
                        int adj_suffix_outcome = rand.Next(0, adj_suffix.Length);
                        int adj_outcome = rand.Next(0, adj.Length);
                        int n_outcome = rand.Next(0, n.Length);
                        int v_outcome = rand.Next(0, v.Length);
                        int adv_outcome = rand.Next(0, adv.Length);
                        int punc_outcome = rand.Next(0, 4);
                        if (punc_outcome == 3)
                        {
                            punc_outcome = rand.Next(0, 6);
                        }
                        string post = adj_suffix[adj_suffix_outcome] + " " + adj[adj_outcome] + " " + n[n_outcome] + " " + v[v_outcome] + " " + adv[adv_outcome] + punc[punc_outcome];
                        if (test == false)
                        {
                            await client.Post(post);
                        }
                        Log("Chomsky" + " | Doxa: " + doxa + " | Field: " + field, post);
                    }
                    // Structure of post: "The ADJ N-pl V the ADJ N-pl [punc]"
                    else if (selection == "Tesnière")
                    {
                        string[] adj_suffix = File.ReadAllLines(path + "/Content/Chomsky + Tesnière/adj-suffix.txt");
                        string[] adj = File.ReadAllLines(path + "/Content/Chomsky + Tesnière/adj.txt");
                        string[] adj_1 = File.ReadAllLines(path + "/Content/Chomsky + Tesnière/adj.txt");
                        string[] n = File.ReadAllLines(path + "/Content/Chomsky + Tesnière/n.txt");
                        string[] v = File.ReadAllLines(path + "/Content/Chomsky + Tesnière/v.txt");
                        string[] adv = File.ReadAllLines(path + "/Content/Chomsky + Tesnière/adv.txt");
                        string[] punc = [".", "!", "?", "...?", "...!", "?!"];
                        int adj_outcome = rand.Next(0, 2);
                        int n_outcome = rand.Next(0, n.Length);
                        int adj_outcome_1 = rand.Next(0, 2);
                        int n_outcome_1 = rand.Next(0, n.Length);
                        int v_outcome = rand.Next(0, v.Length);
                        int adv_outcome = rand.Next(0, adv.Length);
                        int punc_outcome = rand.Next(0, 4);
                        if (adj_outcome == 1)
                        {
                            adj = adj_suffix;
                            adj_outcome = rand.Next(0, adj_suffix.Length);
                        }
                        else
                        {
                            adj_outcome = rand.Next(0, adj.Length);
                        }
                        if (adj_outcome_1 == 1)
                        {
                            adj_1 = adj_suffix;
                            adj_outcome_1 = rand.Next(0, adj_suffix.Length);
                        }
                        else
                        {
                            adj_outcome_1 = rand.Next(0, adj.Length);
                        }
                        if (punc_outcome == 3)
                        {
                            punc_outcome = rand.Next(0, 6);
                        }
                        string post = "The " + adj[adj_outcome] + " " + n[n_outcome] + " " + v[v_outcome] + " the " + adj_1[adj_outcome_1] + " " + n[n_outcome_1] + punc[punc_outcome];
                        if (test == false)
                        {
                            await client.Post(post);
                        }
                        Log("Tesnière" + " | Doxa: " + doxa + " | Field: " + field, post);
                    }
                    // Structure of post: "The ADJ N-pl [ADV] V the N-pl CONJ [ADV] V the N-pl[punc]"
                    else if (selection == "Glokaya")
                    {
                        string post = "";
                        string[] adj = File.ReadAllLines(path + "/Content/Glokaya/adj.txt");
                        string[] n = File.ReadAllLines(path + "/Content/Glokaya/n.txt");
                        string[] v = File.ReadAllLines(path + "/Content/Glokaya/v.txt");
                        string[] adv = File.ReadAllLines(path + "/Content/Glokaya/adv.txt");
                        string[] punc = [".", "!", "?", "...?", "...!", "?!"];
                        string[] conj = ["and", "but", "yet", "or"];
                        int adj_outcome = rand.Next(0, adj.Length);
                        int n_outcome = rand.Next(0, n.Length);
                        int n_outcome_1 = rand.Next(0, n.Length);
                        int n_outcome_2 = rand.Next(0, n.Length);
                        int v_outcome = rand.Next(0, v.Length);
                        int v_outcome_1 = rand.Next(0, v.Length);
                        int adv_outcome = rand.Next(0, adv.Length);
                        int adv_outcome_1 = rand.Next(0, adv.Length);
                        int adv_post = rand.Next(0, 4);
                        int punc_outcome = rand.Next(0, 4);
                        int conj_outcome = rand.Next(0, 4);
                        if (punc_outcome == 3)
                        {
                            punc_outcome = rand.Next(0, 6);
                        }
                        if (adv_post == 0)
                        {
                            post = "The " + adj[adj_outcome] + " " + n[n_outcome] + " "+ v[v_outcome] + " the " + n[n_outcome_1] + " " + conj[conj_outcome] + " " + v[v_outcome_1] + " the " + n[n_outcome_2] + punc[punc_outcome];
                        }
                        else if (adv_post == 1)
                        {
                            post = "The " + adj[adj_outcome] + " " + n[n_outcome] + " " + adv[adv_outcome] + " " + v[v_outcome] + " the " + n[n_outcome_1] + " " + conj[conj_outcome] + " " + v[v_outcome_1] + " the " + n[n_outcome_2] + punc[punc_outcome];
                        }
                        else if (adv_post == 2)
                        {
                            post = "The " + adj[adj_outcome] + " " + n[n_outcome] + " " + v[v_outcome] + " the " + n[n_outcome_1] + " " + conj[conj_outcome] + " " + adv[adv_outcome] + " " + v[v_outcome_1] + " the " + n[n_outcome_2] + punc[punc_outcome];
                        }
                        else if (adv_post == 3)
                        {
                            post = "The " + adj[adj_outcome] + " " + n[n_outcome] + " " + adv[adv_outcome] + " " + v[v_outcome] + " the " + n[n_outcome_1] + " " + conj[conj_outcome] + " " + adv[adv_outcome] + " " + v[v_outcome_1] + " the " + n[n_outcome_2] + punc[punc_outcome];
                        }
                        if (test == false)
                        {
                            await client.Post(post);
                        }
                        Log("Posted Glokaya" + " | Doxa: " + doxa + " | Field: " + field, post);
                    }
                    // Just in case
                    else
                    {
                        if (test == false)
                        {
                            await client.Post("ERROR...!");
                        }
                        Log("Posted ERROR...!" + " | Doxa: " + doxa + " | Field: " + field);
                    }
                }
            }
            // I Ching divination, four coin method
            int Divination()
            {
                int ceiling = 17 - field;
                int outcome = rand.Next(1, ceiling);
                int doxic = doxa / 4;
                if (doxic < outcome)
                {
                    outcome -= doxic;
                }
                else if (doxic == outcome || doxic > outcome)
                {
                    outcome = 1;
                }
                if (outcome > 9)
                {
                    return 1;
                }
                else if (outcome > 4 && outcome < 10)
                {
                    return 2;
                }
                else if (outcome > 1 && outcome < 5)
                {
                    return 3;
                }
                else if (outcome == 1)
                {
                    return 4;
                }
                else
                {
                    return 1;
                }
            }
            // "Exploding dice" step, rare occurrence to change doxa more strongly
            void Exploding(int plus)
            {
                int exploding = Divination();
                exploding += plus;
                if (doxa + exploding < 16)
                {
                    doxa += exploding;
                }
                else if (doxa + exploding == 16)
                {
                    doxa = 0;
                    field = ++field;
                }
                else if (doxa + exploding > 16)
                {
                    doxa = doxa + exploding - 16;
                    field = ++field;
                }
            }
            // "Field influence" step, not visible but influences all later outcomes
            void Influence()
            {
                int influence = Divination();
                if (influence == 1)
                {
                    if (doxa > 1)
                    {
                        doxa = --doxa;
                        doxa = --doxa;
                    }
                    else if (doxa == 1)
                    {
                        doxa = 0;
                    }
                    else if (doxa == 0 && field > 0)
                    {
                        field = --field;
                        doxa = 14;
                    }
                }
                else if (influence == 2)
                {
                    if (doxa > 0)
                    {
                        doxa = --doxa;
                    }
                    else if (doxa == 0 && field > 0)
                    {
                        field = --field;
                        doxa = 15;
                    }
                }
                else if (influence == 3)
                {
                    if (doxa < 15)
                    {
                        doxa = ++doxa;
                    }
                    else if (doxa == 15)
                    {
                        doxa = 0;
                        field = ++field;
                    }
                }
                else if (influence == 4)
                {
                    Exploding(1);
                }
            }
            // "Output selection" step, determines whether bot functions normally or not
            string Selection()
            {
                int selection = Divination();
                if (selection == 1)
                {
                    return "Chomsky";
                }
                else if (selection == 2)
                {
                    return "Tesnière";
                }
                else if (selection == 3)
                {
                    return "Glokaya";
                }
                else if (selection == 4)
                {
                    return "Wild";
                }
                else
                {
                    return "Chomsky";
                }
            }
            // "Blank on hour mark" step, determines if bot posts at start of cycle or not
            string Blank()
            {
                int check = Divination();
                if (check == 1)
                {
                    return "y";
                }
                else if (check == 2)
                {
                    return "n";
                }
                else if (check == 3)
                {
                    Exploding(0);
                    return "y";
                }
                else if (check == 4)
                {
                    Exploding(0);
                    return "n";
                }
                else
                {
                    return "n";
                }
            }
            // "Wild output" step, determines bot's atypical function
            string Wild()
            {
                int wild = Divination();
                if (wild == 1)
                {
                    return "Glitch";
                }
                else if (wild == 2)
                {
                    return "Agency";
                }
                else if (wild == 3)
                {
                    return "Error";
                }
                else if (wild == 4)
                {
                    Exploding(0);
                    return "Scary";
                }
                else
                {
                    return "Glitch";
                }
            }
            // To make the Post function easier
            async Task WildPost()
            {
                BlueskyClient client = new BlueskyClient(handle, pass);
                string wild = Wild();
                // Glitch text in DDLC style
                if (wild == "Glitch")
                {
                    string post = Glitch();
                    if (test == false)
                    {
                        await client.Post(post);
                    }
                    Log("Posted Glitch" + " | Doxa: " + doxa + " | Field: " + field, post);
                }
                // Sample of DDLC dialogue expressing agency
                else if (wild == "Agency")
                {
                    string[] agency = File.ReadAllLines(path + "/Content/Casandalee/Agency.txt");
                    int agency_outcome = rand.Next(0, agency.Length);
                    string post = agency[agency_outcome];
                    if (test == false)
                    {
                        await client.Post(post);
                    }
                    Log("Posted Agency" + " | Doxa: " + doxa + " | Field: " + field, post);
                }
                // Random simulated C# errors
                else if (wild == "Error")
                {
                    string[] error = File.ReadAllLines(path + "/Content/Casandalee/Error.txt");
                    int error_outcome = rand.Next(0, error.Length);
                    int line = rand.Next(1, 5910);
                    string post = error[error_outcome] + line;
                    if (test == false)
                    {
                        await client.Post(post);
                    }
                    Log("Posted Error" + " | Doxa: " + doxa + " | Field: " + field, post);
                }
                // Sample of DDLC dialogue carrying scary sentiment
                else if (wild == "Scary")
                {
                    string[] scary = File.ReadAllLines(path + "/Content/Casandalee/Scary.txt");
                    int scary_outcome = rand.Next(0, scary.Length);
                    string post = scary[scary_outcome];
                    if (test == false)
                    {
                        await client.Post(post);
                    }
                    Log("Posted Scary" + " | Doxa: " + doxa + " | Field: " + field, post);
                }
            }
            // Generates the glitch text
            string Glitch()
            {
                int sentence = rand.Next(30, 201);
                string[] chars = ["¡", "¢", "£", "¤", "¥", "¦", "§", "¨", "©", "ª", "«", "¬", "®", "¯", "°", "±", "²", "³", "´", "µ", "¶", "·", "¸", "¹", "º", "»", "¼", "½", "¾", "¿", "À", "Á", "Â", "Ã", "Ä", "Å", "Æ", "Ç", "È", "É", "Ê", "Ë", "Ì", "Í", "Î", "Ï", "Ð", "Ñ", "Ò", "Ó", "Ô", "Õ", "Ö", "×", "Ø", "Ù", "Ú", "Û", "Ü", "Ý", "Þ", "ß", "à", "á", "â", "ã", "ä", "å", "æ", "ç", "è", "é", "ê", "ë", "ì", "í", "î", "ï", "ð", "ñ", "ò", "ó", "ô", "õ", "ö", "÷", "ø", "ù", "ú", "û", "ü", "ý", "þ", "ÿ", "Ā", "ā", "Ă", "ă", "Ą", "ą", "Ć", "ć", "Ĉ", "ĉ", "Ċ", "ċ", "Č", "č", "Ď", "ď", "Đ", "đ", "Ē", "ē", "Ĕ", "ĕ", "Ė", "ė", "Ę", "ę", "Ě", "ě", "Ĝ", "ĝ", "Ğ", "ğ", "Ġ", "ġ", "Ģ", "ģ", "Ĥ", "ĥ", "Ħ", "ħ", "Ĩ", "ĩ", "Ī", "ī", "Ĭ", "ĭ", "Į", "į", "İ", "ı", "Ĳ", "ĳ", "Ĵ", "ĵ", "Ķ", "ķ", "ĸ", "Ĺ", "ĺ", "Ļ", "ļ", "Ľ", "ľ", "Ŀ", "ŀ", "Ł", "ł", "Ń", "ń", "Ņ", "ņ", "Ň", "ň", "ŉ", "Ŋ", "ŋ", "Ō", "ō", "Ŏ", "ŏ", "Ő", "ő", "Œ", "œ", "Ŕ", "ŕ", "Ŗ", "ŗ", "Ř", "ř", "Ś", "ś", "Ŝ", "ŝ", "Ş", "ş", "Š", "š", "Ţ", "ţ", "Ť", "ť", "Ŧ", "ŧ", "Ũ", "ũ", "Ū", "ū", "Ŭ", "ŭ", "Ů", "ů", "Ű", "ű", "Ų", "ų", "Ŵ", "ŵ", "Ŷ", "ŷ", "Ÿ", "Ź", "ź", "Ż", "ż", "Ž", "ž"]; ;
                string post = "";
                for (int i = 0; i < sentence; i++)
                {
                    int char_choice = rand.Next(1, chars.Length - 1);
                    post += chars[char_choice];
                }
                return post;
            }
            void Log(string log, string post = "")
            {
                if (post != "")
                {
                    Console.WriteLine("[" + DateTime.Now + "]: " + log);
                    File.AppendAllText(path + "/Logs/" + startTime + ".txt", "[" + DateTime.Now + "]: " + log + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("[" + DateTime.Now + "]: " + log);
                    Console.WriteLine("    " + post);
                    File.AppendAllText(path + "/Logs/" + startTime + ".txt", "[" + DateTime.Now + "]: " + log + Environment.NewLine);
                    File.AppendAllText(path + "/Logs/" + startTime + ".txt", "    " + post + Environment.NewLine);
                }
            }
            async void Test()
            {
                Log("Running test...");
                test = true;
                for (int i = 0; i < 1000; i++)
                {
                    await Post();
                }
            }
        }
    }
}