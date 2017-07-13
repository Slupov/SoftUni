(function () {
    let ID = 0;
    class StormWatcher{
        constructor(temperature,humidity,pressure,windSpeed){
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            this.windSpeed = windSpeed;
            this.id = ID++;
        }

        toString(){
            let status = 'Not stormy';

            if(this.temperature < 20){
                if(this.pressure < 700 || this.pressure > 900){
                    if(this.windSpeed > 25){
                        status = 'Stormy';
                    }
                }
            }
            return "Reading ID: " + this.id + "\n" +
                    "Temperature: " + this.temperature + "*C\n"+
                    "Relative Humidity: " + this.humidity + "%\n"+
                    "Pressure: " + this.pressure + "hpa\n" +
                    "Wind Speed: " + this.windSpeed + "m/s\n"+
                    "Weather: " + status;
        }
    }

    return StormWatcher;
})();