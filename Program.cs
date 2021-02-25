using System;
using System.Collections.Generic;
using System.Linq;

namespace ImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> chars = Console.ReadLine()
                .ToCharArray() 
                .ToList();  //read the input and turn it to List of chars

            while (true)
            {
                string newLine = Console.ReadLine();

                if (newLine == "Decode")
                {
                    //to do 
                    break;
                }

                string [] inputData = newLine
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);  // read teh commands

                string comand = inputData[0];
                
                if (comand == "Move")
                {
                    int secPart = int.Parse(inputData[1]);

                    for (int i = 0; i < secPart; i++)
                    {
                        chars.Add(chars[i]);
                    }

                    chars.RemoveRange(0, secPart);
                }
                else if (comand == "Insert") 
                {
                    int secPart = int.Parse(inputData[1]);
                    char[] letterToEnter = inputData[2].ToCharArray();

                    for (int i = letterToEnter.Length - 1; i >=0 ; i--)
                    {                        
                        chars.Insert(secPart, letterToEnter[i]);
                    }
                }
                else // if comand == ChangeAll
                {
                    char symbol = char.Parse(inputData[1]);

                    for (int i = 0; i < chars.Count; i++)
                    {
                        if (chars.Contains(symbol))
                        {
                            char replacementChar = char.Parse(inputData[2]);
                            int idx = chars.IndexOf(symbol);                            
                            chars[idx] = replacementChar;                             
                        }
                    }
                }
            }

            Console.Write("The decrypted message is: ");

            for (int i = 0; i < chars.Count; i++)
            {
                Console.Write(chars[i]);
            }
        }
    }
}
