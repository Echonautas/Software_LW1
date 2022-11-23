using System.IO;
internal class TextFieldParser
{
    static void Main(string[] args)
    {
        using(var reader = new StreamReader(@".\data\apartment_buildings_2019.csv"))
        {
            List<string> ID = new List<string>();
            List<string> Status = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                ID.Add(values[0]);
                Status.Add(values[12]);
            }

            int i=0;
            float x=0;
            foreach(string numbers in ID)
            {
                if(Status[i]=="Nerenovuotas")
                {
                    Console.WriteLine($"{numbers} : {Status[i]}");
                }
                if(Status[i]=="Renovuotas")
                {
                    Console.WriteLine($"{numbers} : {Status[i]}");
                    x++;
                }
                i++;
            }
            Console.WriteLine($"i = {i}");
            Console.WriteLine($"x = {x}");
            x = (x/i)*100;
            Console.WriteLine($"Renovuotu pastatu yra :{x}%, nerenovuotu yra {100-x}%");
        }
    }
}