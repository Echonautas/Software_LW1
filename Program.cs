using System.IO;
internal class TextFieldParser
{
    static void Main(string[] args)
    {
        using(var reader = new StreamReader(@".\data\apartment_buildings_2019.csv"))
        {
            //initializing values for counting how many buildings there are, how many of them are renovated and not renovated.
            int building_count=(-1);
            double renovated=0;
            double nonrenovated=0;
            int admin=0;
            int JVS=0;
            int bendrija=0;

            //reading untill the end of the file.
            while (!reader.EndOfStream)
            {
                //reading one line and spliting it by the seperator used in the file.
                var line = reader.ReadLine();
                var values = line.Split(';');
                
                //checking the specific values to see if the building is documented to be renovated or not.
                if(values[12] =="Renovuotas")
                {
                    renovated++;
                    
                    if(values[3]=="Administravimas")
                        admin++;
                        else if(values[3]=="JVS")
                            JVS++;
                            else if(values[3]=="Bendrija")
                            bendrija++;
                }
                    

                else if(values[12] =="Nerenovuotas")
                    nonrenovated++;

                //counting the total number of buildings there are in the given csv file.
                building_count++;
            }

            //calculating the percentages for the output    
            double renovated_percentage = Math.Round((renovated/building_count)*100,3);
            double nonrenovated_percentage = Math.Round((nonrenovated/building_count)*100,3);

            double admin_percentage = Math.Round((admin/renovated)*100,3);
            double JVS_percentage = Math.Round((JVS/renovated)*100,3);
            double bendrija_percentage = Math.Round((bendrija/renovated)*100,3);

            //outputing
            Console.WriteLine($"Renovated houses make up: {renovated_percentage} %");
            Console.WriteLine($"Not renovated houses make up: {nonrenovated_percentage} %");
            Console.WriteLine($"The rest of the houses make up: {Math.Round(100 - (renovated_percentage + nonrenovated_percentage),3)} %");

            Console.WriteLine();

            Console.WriteLine($"Form of management of renovated houses :");
            Console.WriteLine($"Administration : {admin_percentage} %");
            Console.WriteLine($"JVS : {JVS_percentage} %");
            Console.WriteLine($"Community: {bendrija_percentage} %");
            Console.WriteLine($"The rest: {Math.Round(100-(bendrija_percentage+JVS_percentage+admin_percentage),3)} %");
        }
    }
}