using System;

public class Program
{
    public static void Main()
    {
        //Input 400 Swim Time in hh:mm:ss Format
        var inputMinutesFourHundred = 05d;//
        var inputSecondsFourHundred = 41d;//
        var inputMillisecondsFourHundred = .33d;//

        //Input 200 Swim Time in hh:mm:ss Format
        var inputMinutesTwoHundred = 02d;//
        var inputSecondsTwoHundred = 53d;//
        var inputMillisecondsTwoHundred = .00d;//

        //Input Unit of Measurement Parameters (in whole units)
        var inputUnitOfMeasurementSwam = "Yards";
        var inputDistanceSwam = 400d;//

        var inputUnitOfMeasurementPoolLength = "Yards";
        var inputPoolLength = 25d;//

        //Multipliers for Conversion to Seconds
        const int divisorCss = 200;
        const int secondsInMinute = 60;
        const int unitOfMeasurementDistance = 100;

        //Placeholder for converted results
        var distanceSwam = inputDistanceSwam;
        var poolLength = inputPoolLength;

        //Calculate Seconds Per 400 and 200 per Unit of Measure (Yards or Meters)
        var secondsPerFourHundredUnitOfMeasurement = ((inputMinutesFourHundred * secondsInMinute) + inputSecondsFourHundred + inputMillisecondsFourHundred);
        var secondsPerTwoHundredUnitOfMeasurement = ((inputMinutesTwoHundred * secondsInMinute) + inputSecondsTwoHundred + inputMillisecondsTwoHundred);
        var paceTimeCss = unitOfMeasurementDistance / (divisorCss / (secondsPerFourHundredUnitOfMeasurement - secondsPerTwoHundredUnitOfMeasurement));

        //Calculate Finish Times for 1 Mile and 1.2 Miles (Yards)
        var secondsPerMile = paceTimeCss * 17.6;
        var secondsPerOnePoint2Miles = paceTimeCss * 21.12;

        //Convert Seconds Per 100 Unit of Measurement (Yards or Meters) Pace to mm:ss per 100 Yards
        var paceTimeCssPerHundred = TimeSpan.FromSeconds(paceTimeCss);
        var paceTimeCssPerLength = TimeSpan.FromSeconds(paceTimeCss * (inputPoolLength / unitOfMeasurementDistance));

        //Convert Seconds Per Mile to mm:ss 
        var mileFinishTime = TimeSpan.FromSeconds(secondsPerMile);
        var milePointTwoFinishTime = TimeSpan.FromSeconds(secondsPerOnePoint2Miles);
        
        Console.WriteLine($"Your CSS Pace (per 100 {inputUnitOfMeasurementSwam}): {paceTimeCssPerHundred.ToString(@"m\:ss\.fff")}");
        Console.WriteLine($"Your CSS Pace (per {inputPoolLength} {inputUnitOfMeasurementPoolLength}): {paceTimeCssPerLength.ToString(@"ss\.fff")}");

        Console.WriteLine($"Your Finish Time for 1 Mile: {mileFinishTime.ToString(@"m\:ss\.fff")}");
        Console.WriteLine($"Your Finish Time for 1.2 Miles: {milePointTwoFinishTime.ToString(@"m\:ss\.fff")}");
    }
}
