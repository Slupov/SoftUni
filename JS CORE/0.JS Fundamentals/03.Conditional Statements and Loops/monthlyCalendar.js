function monthlyCalendar([day, month, year]) {
    let currentDate = new Date(year, month - 1, day);
    //calculate how many dates from the last month
    //should we print, based on what day of the week is the
    // 1st of this month
    let previousMonthDates = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1).getDay();

    let html = '<table>\n';
    html += "\t<tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>\n";

    //printing the first calendar row (contains prev month dates)
    html += "\t<tr>";
    let lastDayOfPrevMonth = new Date(currentDate.getFullYear(), currentDate.getMonth(), 0).getDate();

    //previous month dates printing
    for (let i = lastDayOfPrevMonth - previousMonthDates + 1; i <= lastDayOfPrevMonth; i++) {
        html += `<td class=\"prev-month\">${i}</td>`;
    }

    let firstSaturday = 0;

    for (let i = 1; i <= 7 - previousMonthDates; i++) {
        if(i == day){
            html += `<td class="today">${i}</td>`;
        }
        else html += `<td>${i}</td>`;

        if (i == 7 - previousMonthDates) {
            firstSaturday = i;
        }
    }

    html += "</tr>\n";

    //printing all other weeks
    let lastDayOfCurrentMonth = new Date(currentDate.getFullYear(), currentDate.getMonth() + 1, 0);
    let monthDay = firstSaturday + 1;

    while (lastDayOfCurrentMonth.getDate() >= monthDay) {
        if (new Date(currentDate.getFullYear(), currentDate.getMonth(), monthDay).getDay() == 0) {
            html += "\t<tr>";
        }

        if(monthDay == day){
            html += `<td class="today">${monthDay}</td>`;
        }
        else{
            html += `<td>${monthDay}</td>`;
        }

        if (new Date(currentDate.getFullYear(), currentDate.getMonth(), monthDay).getDay() == 6) {
            html += "</tr>\n"
        }

        monthDay++;
    }

    // now add all days from the next month
    let daysOfNextMonth = 6-lastDayOfCurrentMonth.getDay();

    for (let i = 1; i <= daysOfNextMonth; i++) {
        html+=`<td class="next-month">${i}</td>`
        if(i==daysOfNextMonth){
            html+="</tr>\n";
        }
    }
    html += '</table>';
    return html;
}

console.log(monthlyCalendar(['1', '10', '2016']));