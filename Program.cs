using System.IO;
using System.Net;

internal class TextFieldParser
{
    static void Main(string[] args)
    {
        //downloads the needed data file
        using (var client = new WebClient())
        {
            client.DownloadFile("https://raw.githubusercontent.com/vilnius/apartment-buildings/master/apartment_buildings_2019.csv", "apartment_buildings_2019.csv");
        }

        using(var reader = new StreamReader(@"apartment_buildings_2019.csv"))
        {
            //initializing values for counting how many buildings there are, how many of them are renovated and not renovated.
            int building_count=(-1);
            double renovated=0;
            double nonrenovated=0;
            

            //reading untill the end of the file.
            while (!reader.EndOfStream)
            {
                //reading one line and spliting it by the seperator used in the file.
                var line = reader.ReadLine();
                
                var values = line.Split(';');


                //skips two lines where there is an uneeded end line and the data differes from the rest of the file for no reason
                if((values[0] != "120") && (!values[0].StartsWith('"')))
                {
                    //checking the specific values to see if the building is documented to be renovated or not.
                    if(values[12] =="Renovuotas")
                    renovated++;

                    else if(values[12] =="Nerenovuotas")
                    nonrenovated++;
                }

                //counting the total number of buildings there are in the given csv file.
                building_count++;
            }

            //calculating the percentages for the output    
            double renovated_percentage = Math.Round((renovated/building_count)*100,3);
            double nonrenovated_percentage = Math.Round((nonrenovated/building_count)*100,3);

            //outputing
            Console.WriteLine($"Renovated houses make up: {renovated_percentage} %");
            Console.WriteLine($"Not renovated houses make up: {nonrenovated_percentage} %");
            Console.WriteLine($"The rest of the houses make up: {Math.Round(100 - (renovated_percentage + nonrenovated_percentage),3)} %");
        }
    }
}