namespace VyeshalDecoder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 1 || string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("You need to give at least 1 argument!");
                Environment.Exit(1);
            }
            else if (args[0].Contains("help"))
            {
                Console.WriteLine("Usage: \"VyeshalDecoder text specialCases\"\nspecialCases is a bool and the default value is true");
                Environment.Exit(1);
            }

            string data = args[0];
            bool specialCases = true;
            if (args.Length > 1) { _ = bool.TryParse(args[1], out specialCases); }
            string result = string.Empty;
            int skip = 0;
            int count = 0;

            foreach (char c in data)
            {
                // Skip the right amount of cicles
                if (skip > 0)
                {
                    skip--;
                    count++;
                    continue;
                }

                int actualCount = count + 1;
                // Decode multiple-char parts, if the length is okay
                if (actualCount < data.Length)
                {
                    if (c == 'a') // Vowels
                    {
                        switch (data[actualCount])
                        {
                            case 'h':
                                result += "yaw"; skip = 1; count++;
                                continue;
                            case 'n':
                                if ((actualCount + 1) < data.Length && data[actualCount + 1] == 'g') { result += "ang"; skip = 2; count++; continue; }
                                break;
                        }
                    }
                    else if (c == 'e')
                    {
                        switch (data[actualCount])
                        {
                            case 'e':
                                result += "oo"; skip = 1; count++;
                                continue;
                            case 'r':
                                result += "al"; skip = 1; count++;
                                continue;
                            case 'n':
                                if ((actualCount + 1) < data.Length && data[actualCount + 1] == 'g') { result += "eng"; skip = 2; count++; continue; }
                                break;
                        }
                    }
                    else if (c == 'i')
                    {
                        if ((actualCount + 1) < data.Length && data[actualCount] == 'n' && data[actualCount + 1] == 'g')
                        {
                            result += "eeng";
                            skip = 2; count++;
                            continue;
                        }
                    }
                    else if (c == 'o')
                    {
                        switch (data[actualCount])
                        {
                            case 'o':
                                result += "(ee)OR(a)"; skip = 1; count++;
                                continue;
                            case 'w':
                                result += "ow"; skip = 1; count++;
                                continue;
                            case 'y':
                                result += "yoo"; skip = 1; count++;
                                continue;
                            case 'n':
                                if ((actualCount + 1) < data.Length && data[actualCount + 1] == 'g') { result += "ong"; skip = 2; count++; continue; }
                                break;
                        }
                    }
                    else if (c == 'u')
                    {
                        switch (data[actualCount])
                        {
                            case 'h':
                                result += "ye"; skip = 1; count++;
                                continue;
                            case 'n':
                                if ((actualCount + 1) < data.Length && data[actualCount + 1] == 'g') { result += "oong"; skip = 2; count++; continue; }
                                break;
                        }
                    }
                    else if (c == 's') // Consonants
                    {
                        if (data[actualCount] == 'h')
                        {
                            result += "ch";
                            skip = 1; count++;
                            continue;
                        }
                    }
                    else if (c == 't')
                    {
                        if (data[actualCount] == 'h')
                        {
                            result += "sh";
                            skip = 1; count++;
                            continue;
                        }
                    }
                    else if (c == 'c')
                    {
                        if (data[actualCount] == 'h')
                        {
                            result += 'j';
                            skip = 1; count++;
                            continue;
                        }
                    }
                    else if (c == 'z')
                    {
                        if (data[actualCount] == 'h')
                        {
                            result += 'j';
                            skip = 1; count++;
                            continue;
                        }
                    }
                }
                // Decode normal characters
                switch (c)
                {
                    case 'a': result += 'i'; break;
                    case 'e': result += 'o'; break;
                    case 'i': result += 'e'; break;
                    case 'o': result += "aw"; break;
                    case 'A': result += "ya"; break;
                    case 'I': result += "yo"; break;

                    case 's': result += 's'; break;
                    case 't': result += 't'; break;
                    case 'n': result += 'n'; break;
                    case 'k': result += 'k'; break;
                    case 'd': result += 'g'; break;
                    case 'g': result += 'd'; break;
                    case 'm': result += 'v'; break;
                    case 'v': result += 'm'; break;
                    case 'f': result += 'h'; break;
                    case 'h': result += 'f'; break;
                    case 'p': result += 'b'; break;
                    case 'b': result += 'p'; break;
                    case 'l': result += 'l'; break;
                    case 'r': result += 'l'; break;
                    case 'w': result += "vw"; break;
                    case 'z': result += "zh"; break;
                    case 'y': result += 'z'; break;
                    case 'j': result += 'z'; break;
                    default: result += c; break;
                }
                count++;
            }

            if (specialCases) // Manipulate string based on special cases
            {
                // TODO
                if (data == "freedom") { result = "hyeloogyev"; }
                else if (data == "land") { result = "lingye"; }
                else if (data == "right") { result = "loyot"; }
            }
            Console.WriteLine(result);
        }
    }
}