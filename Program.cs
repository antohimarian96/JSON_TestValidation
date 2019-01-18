using System;

namespace JSON_TextValidation
{
    public class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            bool validation = ValidationText(text);
            Console.Write(WriteResult(validation));
            Console.ReadLine();
        }

        private static string WriteResult(bool validation)
        {
            if (validation)
                return "Valid";
            else
               return "Invalid";
        }

        public static bool ValidationText(string text)
        {
            char[] exceptionalChars = { '\\', '\"', 'b', 'f', 'n', 'r', 't' ,'u' ,'/'};
            if(text[0]=='\"' && text[text.Length-1] == '\"')
            {
                for (int i = 1; i < text.Length - 2; i++)
                {
                    int count = 0;
                    if (text[i] == '\"' && text[i-1]!='\\')
                        return false;
                    if (text[i] == '\\')
                    {
                        bool index = false;
                        for (int j = 0; j < exceptionalChars.Length && count!=1 ; j++)
                        {
                            if (text[i + 1] == exceptionalChars[j] && exceptionalChars[j] != 'u')
                                index = true;
                            if (text[i + 1] == 'u')
                            {
                                index = CheckDigits(text,i+1);
                                count = 1;
                            }
                        }
                        if (index == false)
                            return false;
                    }
                }
                return true;
            }
            if (text[0] == ' ' && text[text.Length - 1] == '\"' || text[0] == '\"' && text[text.Length - 1] == ' ')
                return false;
            return false;
        }

        private static bool CheckDigits(string text, int index)
        {
            if ((text.Length - 2) - index < 4)
                return false;
            for (int i = index + 1; i <= index + 4; i++)
                if ((text[i] < '0' || text[i] > '9' )&& !CheckChar(text[i]))
                    return false;
            return true;
        }

        private static bool CheckChar(char character)
        {
           switch(character)
            {
                case 'A':
                    return true;
                case 'B':
                    return true;
                case 'C':
                    return true;
                case 'D':
                    return true;
                case 'E':
                    return true;
                case 'F':
                    return true;
                default:
                    return false;
            }
        }
    }
}
