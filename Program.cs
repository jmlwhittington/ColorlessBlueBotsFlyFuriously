using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlessBlueBotsFlyFuriously
{
    internal class Program
    {
        static void Main()
        {
            // Variables
            Random rand = new Random();
            int field = 0;
            int doxa = 0;
            // Test
            for (int i = 0; i < 10000; i++)
            {
                if (field >= 16)
                {
                    field = 0;
                    doxa = 0;
                    Console.WriteLine("Test: " + i + " | Field: " + field + " | Doxa: " + doxa + " | REINITIALIZING...!");
                }
                else
                {
                    Influence();
                    string selection = Selection();
                    string blank = "";
                    string wild = "";
                    if (selection == "Wild")
                    {
                        Chatter();
                        blank = Blank();
                        wild = Wild();
                    }
                    // Record outcome
                    if (wild != "")
                    {
                        Console.WriteLine("Test: " + i + " | Field: " + field + " | Doxa: " + doxa + " | Selection: " + selection + " | Blank: " + blank + " | Wild: " + wild);
                    }
                    else
                    {
                        Console.WriteLine("Test: " + i + " | Field: " + field + " | Doxa: " + doxa + " | Selection: " + selection);
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
                else if (outcome > 5 && outcome < 10)
                {
                    return 2;
                }
                else if (outcome > 1 && outcome < 6)
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
        }
    }
}
