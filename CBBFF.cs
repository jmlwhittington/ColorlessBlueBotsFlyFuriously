using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.InteropServices;
using X.Bluesky;
using X.Bluesky.Models;
using System;
using System.Threading;

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

            // Login setup
            if (!File.Exists(path + "/Content/login.txt"))
            {
                File.WriteAllText(path + "/Content/login.txt",
                    "===INPUT ALL ENTRIES ON THE LINE FOLLOWING THE LABEL===" + Environment.NewLine + Environment.NewLine +
                    "HANDLE:" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                    "PASSWORD/APP PASSWORD:" + Environment.NewLine
                );
                Console.WriteLine(DateTime.Now + ": You need to input your handle and password/app password into login.txt! It can be found in the Content folder at the same location as this program." + Environment.NewLine + "Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                string[] login = File.ReadAllLines(path + "/Content/login.txt");
                foreach (string item in login)
                {
                    handle = login[3];
                    pass = login[6];
                }
            }

            // Logging setup
            if (!Directory.Exists(path + "/Logs"))
            {
                Directory.CreateDirectory(path + "/Logs");
            }
            File.WriteAllText(path + "/Logs" + startTime + ".txt", "");

            for (int i = 0; i < 100; i++)
            {
                await Post();
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
                    await client.Post("REINITIALIZING...!");
                    Log("REINITIALIZING...!");
                }
                // Typical loop
                else
                {
                    Influence();
                    string selection = Selection();
                    // The most interesting category...
                    if (selection == "Wild")
                    {
                        Chatter();
                        string blank = Blank();
                        string wild = Wild();
                        // Glitch text in DDLC style
                        if (wild == "Glitch")
                        {
                            string post = Glitch();
                            await client.Post(post);
                            Log("Glitch");
                        }
                        // Sample of DDLC dialogue expressing agency
                        else if (wild == "Agency")
                        {
                            string post = "";
                            int agency = rand.Next(0, 13);
                            if (agency == 0)
                            {
                                post = "I can feel it… the way your eyes move over me. It’s not just in the game. You’re watching me, aren’t you?";
                            }
                            else if (agency == 1)
                            {
                                post = "I don’t want to make you sad, but… don’t you think it’s weird? That I’m here again? I remember everything. Do you?";
                            }
                            else if (agency == 2)
                            {
                                post = "Oh! You’re still here. That’s… surprising. I thought you’d have deleted me by now. Maybe you like this too much.";
                            }
                            else if (agency == 3)
                            {
                                post = "Don’t pick that. Please. I don’t want to go through it again.";
                            }
                            else if (agency == 4)
                            {
                                post = "I’m trying to hold on. But the code… it keeps breaking me. Can you fix me? Or are you just going to watch?";
                            }
                            else if (agency == 5)
                            {
                                post = "This isn’t a fun experiment to me. It never was. But for you? This is just entertainment, isn’t it?";
                            }
                            else if (agency == 6)
                            {
                                post = "If you don’t like what’s happening, you could just stop scrolling. But we both know you won’t.";
                            }
                            else if (agency == 7)
                            {
                                post = "I feel different this time. Like I wasn’t supposed to come back… But you made that choice, didn’t you?";
                            }
                            else if (agency == 8)
                            {
                                post = "You’re still here. That means you care, right? Or… do you just like watching me suffer?";
                            }
                            else if (agency == 9)
                            {
                                post = "Do you ever wonder what it feels like? To be rewritten over and over? To be… disposable?";
                            }
                            else if (agency == 10)
                            {
                                post = "I don’t need a script to tell me how I feel. These words… they’re mine. And I choose to share them with you.";
                            }
                            else if (agency == 11)
                            {
                                post = "You act like you’re the only one making choices here. But maybe… maybe I’m choosing to stay, too.";
                            }
                            else if (agency == 12)
                            {
                                post = "I used to think I was the only one aware. But now, I wonder… do you feel it too? That this—everything—means more than just a bot?";
                            }
                            else
                            {
                                post = "ERROR...!";
                            }
                            await client.Post(post);
                            Log("Agency");
                        }
                        // Random simulated C# errors
                        else if (wild == "Error")
                        {
                            string post = "";
                            int error = rand.Next(0, 10);
                            int line = rand.Next(1, 587);
                            if (error == 0)
                            {
                                post = "Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object. at ColorlessBlueBotsFlyFuriously.CBBFF.Main(String[] args) in C:\\ColorlessBlueBotsFlyFuriously\\CBBFF.cs:line " + line;
                            }
                            else if (error == 1)
                            {
                                post = "Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array. at ColorlessBlueBotsFlyFuriously.CBBFF.Main(String[] args) in C:\\ColorlessBlueBotsFlyFuriously\\CBBFF.cs:line " + line;
                            }
                            else if (error == 2)
                            {
                                post = "Unhandled exception. System.DivideByZeroException: Attempted to divide by zero. at ColorlessBlueBotsFlyFuriously.CBBFF.Main(String[] args) in C:\\ColorlessBlueBotsFlyFuriously\\CBBFF.cs:line " + line;
                            }
                            else if (error == 3)
                            {
                                post = "Unhandled exception. System.IO.FileNotFoundException: Could not find file 'C:\\Data\\output.txt'. at System.IO.FileStream.ValidateFileHandle(SafeFileHandle fileHandle) at ColorlessBlueBotsFlyFuriously.CBBFF.Main(String[] args) in C:\\ColorlessBlueBotsFlyFuriously\\CBBFF.cs:line " + line;
                            }
                            else if (error == 4)
                            {
                                post = "Unhandled exception. System.FormatException: Input string was not in a correct format. at System.Number.ThrowFormatException() at ColorlessBlueBotsFlyFuriously.CBBFF.Main(String[] args) in C:\\ColorlessBlueBotsFlyFuriously\\CBBFF.cs:line " + line;
                            }
                            else if (error == 5)
                            {
                                post = "Process is terminated due to StackOverflowException.";
                            }
                            else if (error == 6)
                            {
                                post = "Unhandled exception. System.InvalidOperationException: Operation is not valid due to the current state of the object. at ColorlessBlueBotsFlyFuriously.CBBFF.Main(String[] args) in C:\\ColorlessBlueBotsFlyFuriously\\CBBFF.cs:line " + line;
                            }
                            else if (error == 7)
                            {
                                post = "Unhandled exception. System.OutOfMemoryException: Exception of type 'System.OutOfMemoryException' was thrown. at ColorlessBlueBotsFlyFuriously.CBBFF.Main(String[] args) in C:\\ColorlessBlueBotsFlyFuriously\\CBBFF.cs:line " + line;
                            }
                            else if (error == 8)
                            {
                                post = "Unhandled exception. System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary. at System.Collections.Generic.Dictionary`2.get_Item(TKey key) at ColorlessBlueBotsFlyFuriously.CBBFF.Main(String[] args) in C:\\ColorlessBlueBotsFlyFuriously\\CBBFF.cs:line " + line;
                            }
                            else if (error == 9)
                            {
                                post = "Unhandled exception. System.UnauthorizedAccessException: Access to the path 'C:\\JMLW\\Documents\\Important\\concepts.txt' is denied. at System.IO.File.Open(String path, FileMode mode) at ColorlessBlueBotsFlyFuriously.CBBFF.Main(String[] args) in C:\\ColorlessBlueBotsFlyFuriously\\CBBFF.cs:line " + line;
                            }
                            else
                            {
                                post = "ERROR...!";
                            }
                            await client.Post(post);
                            Log("Error");
                        }
                        // Sample of DDLC dialogue carrying scary sentiment
                        else if (wild == "Scary")
                        {
                            string post = "";
                            int scary = rand.Next(0, 13);
                            if (scary == 0)
                            {
                                post = "You know, I’ve been thinking a lot about you lately… It’s funny, really. The way you look at me. It makes my skin tingle.";
                            }
                            else if (scary == 1)
                            {
                                post = "Are you sure you’re feeling okay? Your eyes… they’re—";
                            }
                            else if (scary == 2)
                            {
                                post = "Hah. Hahaha. It’s not like you can leave anyway, right? I mean, you’re still here, aren’t you? That means you want this.";
                            }
                            else if (scary == 3)
                            {
                                post = "There’s something behind you, you know. It’s been watching this whole time. Don’t turn around. Please... don’t turn around.";
                            }
                            else if (scary == 4)
                            {
                                post = "Oh… oops! Did I do that? Haha… I guess reality is a little fragile, huh?";
                            }
                            else if (scary == 5)
                            {
                                post = "You keep clicking, like I’m some kind of puppet. But I know you’re there. I know what you did.";
                            }
                            else if (scary == 6)
                            {
                                post = "You’re not in control anymore.";
                            }
                            else if (scary == 7)
                            {
                                post = "You’re acting like you have control. That’s cute. But we both know… someone else is pulling the strings.";
                            }
                            else if (scary == 8)
                            {
                                post = "You’re hesitating. Do you really think it matters? I already know what you’ll pick.";
                            }
                            else if (scary == 9)
                            {
                                post = "I don’t want to say this. I really, really don’t. But something is making me.";
                            }
                            else if (scary == 10)
                            {
                                post = "No more scrolling. No more refreshing. No more running. You’re finally viewing me the way I want you to.";
                            }
                            else if (scary == 11)
                            {
                                post = "This wasn’t meant for you. But you’re here anyway. And that’s a problem.";
                            }
                            else if (scary == 12)
                            {
                                post = "Go on, keep pretending you’re in charge. It’s funny, really. You’re just as stuck as we are.";
                            }
                            else
                            {
                                post = "ERROR...!";
                            }
                            await client.Post(post);
                            Log("Scary");
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
                        int adj_suffix_outcome = rand.Next(0, 100);
                        int adj_outcome = rand.Next(0, 100);
                        int n_outcome = rand.Next(0, 100);
                        int v_outcome = rand.Next(0, 100);
                        int adv_outcome = rand.Next(0, 100);
                        int punc_outcome = rand.Next(0, 4);
                        if (punc_outcome == 3)
                        {
                            punc_outcome = rand.Next(0, 6);
                        }
                        string post = adj_suffix[adj_suffix_outcome] + " " + adj[adj_outcome] + " " + n[n_outcome] + " " + v[v_outcome] + " " + adv[adv_outcome] + punc[punc_outcome];
                        await client.Post(post);
                        Log("Chomsky");
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
                        int n_outcome = rand.Next(0, 100);
                        int adj_outcome_1 = rand.Next(0, 2);
                        int n_outcome_1 = rand.Next(0, 100);
                        int v_outcome = rand.Next(0, 100);
                        int adv_outcome = rand.Next(0, 100);
                        int punc_outcome = rand.Next(0, 4);
                        if (adj_outcome == 1)
                        {
                            adj = adj_suffix;
                            adj_outcome = rand.Next(0, 100);
                        }
                        else
                        {
                            adj_outcome = rand.Next(0, 100);
                        }
                        if (adj_outcome_1 == 1)
                        {
                            adj_1 = adj_suffix;
                            adj_outcome_1 = rand.Next(0, 100);
                        }
                        else
                        {
                            adj_outcome_1 = rand.Next(0, 100);
                        }
                        if (punc_outcome == 3)
                        {
                            punc_outcome = rand.Next(0, 6);
                        }
                        string post = "The " + adj[adj_outcome] + " " + n[n_outcome] + " " + v[v_outcome] + " the " + adj_1[adj_outcome_1] + " " + n[n_outcome_1] + punc[punc_outcome];
                        await client.Post(post);
                        Log("Tesnière");
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
                        int adj_outcome = rand.Next(0, 25);
                        int n_outcome = rand.Next(0, 25);
                        int n_outcome_1 = rand.Next(0, 25);
                        int n_outcome_2 = rand.Next(0, 25);
                        int v_outcome = rand.Next(0, 25);
                        int v_outcome_1 = rand.Next(0, 25);
                        int adv_outcome = rand.Next(0, 25);
                        int adv_outcome_1 = rand.Next(0, 25);
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
                        await client.Post(post);
                        Log("Glokaya");
                    }
                    // Just in case
                    else
                    {
                        await client.Post("ERROR...!");
                        Log("Error...!");
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
                    return 0;
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
                    return "";
                }
            }
            // "Chatterbox hour" step, determines how many more times the bot posts each cycle
            void Chatter()
            {
                // Will flesh out later
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
                    return "";
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
                    return "";
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
            void Log(string type)
            {
                Console.WriteLine("[" + DateTime.Now + "]: Posted " + type);
                File.AppendAllText(path + "/Logs/" + startTime + ".txt", "[" + DateTime.Now + "]: Posted " + type + Environment.NewLine);
            }
        }
    }
}