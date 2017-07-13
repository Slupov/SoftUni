function personalBMI(name, age, weight, height) {
    let obj = {
        name: name,
        personalInfo: {
            age: age,
            weight: Number(weight),
            height: Number(height)
        },
        BMI: 0 ,
        calcBMI: function () {
            return this.weight / (this.height / 100 * this.height / 100)
        },
        status: ""
    };

    return obj;
}
console.log(personalBMI("Peter", 29, 75, 182));