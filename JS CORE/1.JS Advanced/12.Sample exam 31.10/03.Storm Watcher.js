(function () {
    let ID = 0;

    class StormWatcher{
        constructor(temperature,humidity,pressure,windSpeed){
            this.id = ID;
            ID++;
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            this.windSpeed = windSpeed;
        }

        toString(){
            let weatherStatus = "Not stormy";
            if(this.temperature < 20 && (this.pressure < 700 || this.pressure > 900) && this.windSpeed > 25){
                weatherStatus = "Stormy";
            }
           return "Reading ID: " + this.id + "\n" +
           "Temperature: " + this.temperature + "*C"+ "\n" +
           "Relative Humidity: " + this.humidity + "%"+ "\n" +
           "Pressure: " + this.pressure + "hpa"+ "\n" +
           "Wind Speed: " + this.windSpeed + "m/s"+ "\n" +
           "Weather: " + weatherStatus;
        }
    }
    return StormWatcher
})();
