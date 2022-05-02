
// Author: Dashie


using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using HTMLTempler;


// The base for a new foundation. 

// This is so inefficient. I am going to make it so one generator module takes the element type by string so it can fill out the rest. Too much repeating code. But for the sake of understanding my own idea will I finish this shit. -future dashie

namespace HTMLTemplateGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            void Print(object j) => Console.WriteLine(j.ToString());

            Print(HTMLParser.Generate(HTMLParseType.H2Title, "The Title"));
            Print(HTMLParser.Generate(HTMLParseType.H4Summary, "Some summary about a caterpillar that likes to eat.", "And this eating caterpillar is on another line mate."));
            Print(HTMLParser.Generate(HTMLParseType.PDesc, "This is some description in that p, you know."));
            Print(HTMLParser.Generate(HTMLParseType.PTableDesc, "This table contains my hobbies"));
            Print(HTMLParser.Generate(HTMLParseType.TableRows, "hobby", "level of joy"));
            Print
            (
                HTMLParser.Generate
                (
                    HTMLParseType.TableColumns, "code", "10"
                ) +
                
                HTMLParser.Generate
                (
                    HTMLParseType.TableColumns, "weed", "10"
                ) +
                
                HTMLParser.Generate
                (
                    HTMLParseType.TableColumns, "rolling", "10"
                )
            );
            Print(HTMLParser.Generate(HTMLParseType.PLastWords, "Some last words for you people shits."));
        }
    }
}
