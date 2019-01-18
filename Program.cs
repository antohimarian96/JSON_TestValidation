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
            if(text[0]=='\"' && text[text.Length-1] == '\"')
            {
                if (text[1] == '\\')
                    return false;
                if (text[(text.Length - 1) / 2] == '\"')
                    return false;
                return true;
            }
            if (text[0] == ' ' && text[text.Length - 1] == '\"' || text[0] == '\"' && text[text.Length - 1] == ' ')
                return false;
            return false;
        }
    }
}
