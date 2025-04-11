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

            // Iterar sobre cada carácter de la entrada
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsDigit(c)) // Si el carácter es un número
                {
                    // Si la secuencia tiene el mismo número, añadimos el nuevo número
                    if (sequence.Length > 0 && sequence[0] == c)
                    {
                        sequence += c;
                    }
                    else
                    {
                        // Si hay una secuencia activa, la procesamos antes de iniciar una nueva
                        output += ConvertSequence(sequence);
                        sequence = c.ToString(); // Iniciamos una nueva secuencia
                    }
                }
                else if (c == ' ') // Si encontramos un espacio, procesamos la secuencia
                {
                    output += ConvertSequence(sequence);
                    sequence = ""; // Reseteamos la secuencia
                }
                else if (c == '*') // Si encontramos un asterisco, borramos el último número de la secuencia
                {
                    if (sequence.Length > 0)
                    {
                        sequence = sequence.Substring(0, sequence.Length - 1); // Borrar el último número
                    }
                    else if (output.Length > 0) // Si no hay secuencia, borramos la última letra
                    {
                        output = output.Substring(0, output.Length - 1);
                    }
                }
                else if (c == '#') // Si encontramos el símbolo '#', procesamos la secuencia
                {
                    output += ConvertSequence(sequence);
                    break; // Terminamos el ciclo, ya que encontramos el # que marca el fin
                }
            }

            // Si llegamos al final del input y no encontramos un #, procesamos la secuencia restante
            if (sequence.Length > 0 && input[input.Length - 1] != '#')
            {
                output += ConvertSequence(sequence);
            }

            return output;
        }


        private static string ConvertSequence(string seq)
        {
            if (string.IsNullOrEmpty(seq))
                return "";

            // Validar que todos los caracteres de la secuencia sean iguales
            if (!seq.All(c => c == seq[0]))
                throw new Exception($"Secuencia inválida: '{seq}'");

            char key = seq[0];
            int pressCount = seq.Length;

            string letters = key switch
            {
                '2' => "ABC",
                '3' => "DEF",
                '4' => "GHI",
                '5' => "JKL",
                '6' => "MNO",
                '7' => "PQRS",
                '8' => "TUV",
                '9' => "WXYZ",
                _ => throw new Exception($"Tecla inválida: '{key}'")
            };

            int index = (pressCount - 1) % letters.Length;
            return letters[index].ToString();
        }

    }
}

