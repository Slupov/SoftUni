function examResults(input) {
    let allStudents = [];
    let regex = /\s+/g;
    let searchedCourse = input.pop().trim();
    let count = 0;
    let sum = 0;

    for (let line of input) {
        line = line.trim();

        let [studentName,course,examPoints,bonuses] = line.split(regex);

        examPoints = Number(examPoints);
        bonuses = Number(bonuses);

        if (course === searchedCourse) {
            count++;
            sum += examPoints;
        }

        let coursePoints = examPoints / 5 + bonuses;
        coursePoints = +Number(coursePoints).toFixed(2);

        let currentGrade = (coursePoints / 80) * 4 + 2;

        if (currentGrade > 6) {
            currentGrade = 6;
        }

        currentGrade = Number(currentGrade).toFixed(2);

        if (examPoints < 100) {
            coursePoints = "failed";
        }

        let currentStudent = {
            name: studentName,
            course: course,
            grade: currentGrade,
            coursePoints: coursePoints
        };

        allStudents.push(currentStudent);
    }

    for (let student of allStudents) {
        if (student.coursePoints === "failed") {
            console.log(`${student.name} failed at "${student.course}"`);
        } else {
            console.log(`${student.name}: Exam - "${student.course}"; Points - ${student.coursePoints}; Grade - ${student.grade}`);
        }
    }

    let average = sum / count;
    average = +Number(average).toFixed(2);
    console.log(`"${searchedCourse}" average points -> ${average}`);

}

// examResults([
//     'Pesho C#-Advanced 100 3',
//     'Gosho Java-Basics 157 3',
//     'Tosho HTML&CSS 317 12',
//     'Minka C#-Advanced 57 15',
//     'Stanka C#-Advanced 157 15',
//     'Kircho C#-Advanced 300 0',
//     'Niki C#-Advanced 400 10',
//     'C#-Advanced'
//
// ]);
//
// console.log("--------------------------------");
// examResults([
//     "Student1 C#-Advanced 100 3",
//     "Student2 C#-Advanced 157 3",
//     "Student3 C#-Advanced 317 12",
//     "Student4 C#-Advanced 57 15",
//     "Student5 C#-Advanced 157 15",
//     "Student6 C#-Advanced 333 7",
//     "Student7 C#-Advanced 222 6",
//     "Student8 C#-Advanced 111 15",
//     "Student9 C#-Advanced 99 1",
//     "Student10 C#-Advanced 0 0",
//     "Student11 C#-Advanced 236 0",
//     "Student12 C#-Advanced 150 0",
//     "Student13 C#-Advanced 77 1",
//     "Student14 C#-Advanced 390 12",
//     "Student15 C#-Advanced 100 10",
//     "C#-Advanced"
// ]);

console.log("=================================");

examResults([
    'EDUU    JS-Basics                317          15',
    '           RoYaL        HTML5        121         10',
    'ApovBerger      OOP   0    10',
    'Stamat OOP   190 10',
    'MINKA OOP   230 10',
    '   OOP'
])