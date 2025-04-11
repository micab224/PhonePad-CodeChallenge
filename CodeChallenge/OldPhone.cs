using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class OldPhone
    {
        public static string OldPhonePad(string input)
        {
            string output = "";
            string sequence = "";

            // Iterate through each character in the input string
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsDigit(c))
                {
                    if (c == '0')
                    {
                        // 0 finish the current sequence and continue with a new sequence
                        if (sequence.Length > 0)
                        {
                            output += ConvertSequence(sequence) + " ";
                            sequence = "";
                        }
                    }
                    else
                    {
                        // If the current digit is the same as the previous one, its part of the sequence
                        if (sequence.Length > 0 && sequence[0] == c)
                        {
                            sequence += c;
                        }
                        else
                        {
                            // A new digit means the previous sequence should be converted to a letter
                            if (sequence.Length > 0)
                            {
                                output += ConvertSequence(sequence);
                            }
                            sequence = c.ToString();
                        }
                    }
                }
                else if (c == ' ')
                {

                    if (sequence.Length > 0)
                    {
                        output += ConvertSequence(sequence);
                        sequence = "";
                    }
                }
                else if (c == '*')
                {
                    if (sequence.Length > 0)
                    {
                        // If the user is in the middle of a sequence, remove the last digit from that sequence
                        sequence = sequence.Substring(0, sequence.Length - 1);
                    }
                    else if (output.Length > 0)
                    {
                        // If no sequence is active, remove the last letter from the final output
                        output = output.Substring(0, output.Length - 1);
                    }
                }
                else if (c == '#')
                {
                    // End of input signal — finalize any remaining sequence and stop processing
                    if (sequence.Length > 0)
                    {
                        output += ConvertSequence(sequence);
                    }
                    break;
                }
            }

            // If the string ended without # make sure the last sequence is processed
            if (sequence.Length > 0 && input[input.Length - 1] != '#')
            {
                output += ConvertSequence(sequence);
            }

            return output.Trim();
        }

        private static string ConvertSequence(string seq)
        {
            if (string.IsNullOrEmpty(seq))
                return "";

            // Ensure all characters in the sequence are the same 
            char firstChar = seq[0];
            foreach (char c in seq)
            {
                if (c != firstChar)
                {
                    throw new Exception($"Invalid sequence: '{seq}'");
                }
            }

            // Map each digit to its corresponding group of letters
            var keyToLetters = new Dictionary<char, string>
            {
                 { '2', "ABC" },
                 { '3', "DEF" },
                 { '4', "GHI" },
                 { '5', "JKL" },
                 { '6', "MNO" },
                 { '7', "PQRS" },
                 { '8', "TUV" },
                 { '9', "WXYZ" }
            };

            
            char key = seq[0];

            // Validate the key
            if (!keyToLetters.ContainsKey(key))
                throw new Exception($"Invalid key: '{key}'");

            string letters = keyToLetters[key];

            // Calculate the index based on the length of the sequence
            int index = (seq.Length - 1) % letters.Length;

            return letters[index].ToString();
        }

    }
}
