using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SimpleTermFrequencyAnalyser
{
	
	
    class Program
    {
        static void Main(string[] args)
        {   string curFilePath;
        	Console.WriteLine("Please enter file path (For example: C:\file.txt)" );
        	Console.WriteLine();
   
         curFilePath = Console.ReadLine();
         if (curFilePath == null){ 
             Console.WriteLine("Please enter file path");
         	 Console.ReadKey();
         }
         else {
         	Console.WriteLine("Your text file: " + curFilePath);
           	Console.ReadKey();
         }
          
           Console.WriteLine(File.Exists(curFilePath) ? "File exists." : "File does not exist.");
           Console.ReadKey(); 
           if(!File.Exists(curFilePath))
           	Console.WriteLine("File does not exists.");
           else{
           Console.WriteLine  ("File exist.");         		
           Console.WriteLine("Counting words in a file...)" );
           
            string inputStringFromFile = File.ReadAllText(curFilePath);
            inputStringFromFile = inputStringFromFile.ToLower();  
            string[] Chars = { ";", ",", ".", "-", "_", "^", "(", ")", "[", "]",
						"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "\n", "\t", "\r" };
			foreach (string character in Chars)
			{
				inputStringFromFile = inputStringFromFile.Replace(character,"");
			}
            List<string> wordList = inputStringFromFile.Split(' ').ToList();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            
            foreach (string word in wordList)
            {           
                if (dictionary.ContainsKey(word))
                    {
                         dictionary[word]++;
                    }
                    else
                    {
                         dictionary[word] = 1;
                    }
             } 
           var sortedDictionary = (from entry in dictionary orderby entry.Value descending select entry).ToDictionary(wordsNamber => wordsNamber.Key, wordsNamber => wordsNamber.Value);

            int count = 1;
            Console.WriteLine("Words and their number in the file: " + curFilePath);
            Console.WriteLine();
            foreach (KeyValuePair<string, int> wordsNamber in sortedDictionary)
            {
            	Console.WriteLine(count + "\t" + wordsNamber.Key + "\t"+ wordsNamber.Value);
                count++;

            }

            Console.ReadKey();}

        } 
    }

    } 