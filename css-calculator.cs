using System;

public class Program
{
            public static void Main()
            {
                        //Input 400 swim time in mm:ss.fff format
                        var inputMinutesFourHundred = 05d;
                        var inputSecondsFourHundred = 29d;
                        var inputMillisecondsFourHundred = .64d;
                        
                        //Input 200 swim time in mm:ss.fff format
                        var inputMinutesTwoHundred = 02d;
                        var inputSecondsTwoHundred = 42d;
                        var inputMillisecondsTwoHundred = .08d;
                        
                        //Input unit of measurement parameters
                        var inputUnitOfMeasurementSwam = "Yards";
                        var inputPoolLength = 25d;//
                        
                        //Multipliers for conversion to seconds
                        const int divisorCss = 200;
                        const int secondsInMinute = 60;
                        const int unitOfMeasurementDistance = 100;

                        //Calculate seconds per 400 and 200 per unit of measure (Yards or Meters)
                        var secondsPerFourHundredUnitOfMeasurement = ((inputMinutesFourHundred * secondsInMinute) + inputSecondsFourHundred + inputMillisecondsFourHundred);
                        var secondsPerTwoHundredUnitOfMeasurement = ((inputMinutesTwoHundred * secondsInMinute) + inputSecondsTwoHundred + inputMillisecondsTwoHundred);
                        var paceTimeCss = unitOfMeasurementDistance / (divisorCss / (secondsPerFourHundredUnitOfMeasurement - secondsPerTwoHundredUnitOfMeasurement));
                        
                        //Convert seconds per 100 unit of measurement (Yards or Meters) pace to mm:ss.fff
                        var paceTimeCssPerHundred = TimeSpan.FromSeconds(paceTimeCss);
                        var paceTimeCssPerLength = TimeSpan.FromSeconds(paceTimeCss * (inputPoolLength / unitOfMeasurementDistance));
                        
                        Console.WriteLine($"Your CSS Pace (per 100 {inputUnitOfMeasurementSwam}): {paceTimeCssPerHundred.ToString(@"m\:ss\.fff")}");
                        Console.WriteLine($"Your CSS Pace (per {inputPoolLength} {inputUnitOfMeasurementSwam}): {paceTimeCssPerLength.ToString(@"ss\.fff")}");
            }
}
