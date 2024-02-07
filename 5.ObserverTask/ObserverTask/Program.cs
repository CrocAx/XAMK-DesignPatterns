using System;

namespace ObserverTask
{
    public interface Subject
    {
        public void registerObserver(Observer o);
        public void removeObserver(Observer o);
        public void notifyObservers();
    }

    public interface Observer
    {
        public void update(float temp, float humidity, float pressure, float avgTemp, float maxTemp, float minTemp, string forecast);
    }

    public interface DisplayElement
    {
        public void display();
    }

    public class WeatherData : Subject
    {
        private List<Observer> observers = new List<Observer>();
        private float temperature;
        private float humidity;
        private float pressure;
        private float avgTemp;
        private float minTemp;
        private float maxTemp;
        private string forecast;

        public WeatherData()
        {
            observers = new List<Observer>();
        }

        public void registerObserver (Observer o)
        {
            observers.Add(o);
        }

        public void removeObserver(Observer o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.RemoveAt(i);
            }
        }

        public void notifyObservers()
        {
            for (int i = 0; i< observers.Count; i++)
            {
                Observer observer = observers[i];
                observer.update(temperature, humidity, pressure, avgTemp, maxTemp, minTemp, forecast);
            }
        }

        public void measurementsChanged()
        {
            notifyObservers();
        }

        public void setMeasurements(float temperature, float humidity, float pressure, float avgTemp, float maxTemp, float minTemp, string forecast)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            this.avgTemp = avgTemp;
            this.maxTemp = maxTemp;
            this.minTemp = minTemp;
            this.forecast = forecast;
            measurementsChanged();
        }
    }

    public class CurrentConditionsDisplay : Observer, DisplayElement
    {
        private float temperature;
        private float humidity;
        private float pressure;
        private Subject weatherData;

        public CurrentConditionsDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }

        public void update (float temperature, float humidity, float pressure, float avgTemp, float maxTemp, float minTemp, string forecast)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;

            display();
        }

        public void display()
        {
            Console.Write("|-------------------------------------------------------------------|\n");
            Console.WriteLine("|Current conditions: " + temperature + "F degrees and " + humidity + "% humidity ");
            Console.WriteLine("|Current pressure: " + pressure + " Mbs");
        }
    }

    public class StatisticsDisplay : Observer, DisplayElement
    {
        private float avgTemp;
        private float maxTemp;
        private float minTemp;
        private Subject weatherData;

        public StatisticsDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }

        public void update(float temperature, float humidity, float pressure, float avgTemp, float maxTemp, float minTemp, string forecast)
        {

            this.avgTemp = avgTemp;
            this.maxTemp = maxTemp;
            this.minTemp = minTemp;
            display();
        }

        public void display()
        {
            Console.WriteLine("|Average temperature " + avgTemp + "F |" + " Max temperature " + maxTemp + "F |" + " Min temperature " + minTemp + "F " );
            Console.WriteLine("|");

        }
    }

    public class ForecastDisplay : Observer, DisplayElement
    {
        private string forecast;
        private Subject weatherData;

        public ForecastDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }

        public void update(float temperature, float humidity, float pressure, float avgTemp, float maxTemp, float minTemp, string forecast)
        {
            this.forecast = forecast;
            display();
        }

        public void display()
        {
            Console.WriteLine("|Forecast: " + forecast + ".");

        }
    }

    public class WeatherStation
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);

            weatherData.setMeasurements(80, 65, 30.4f, 80, 80, 80, "Improving weather on the way");
            weatherData.setMeasurements(82, 70, 29.2f, 81, 82, 80, "Watch out for cooler, rainy weather");
            weatherData.setMeasurements(78, 90, 29.2f, 80, 82, 78, "More of the same");
            Console.Write("|-------------------------------------------------------------------|");
        }
    }
}