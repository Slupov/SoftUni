function nextDay([year, month, day]) {
    let today = new Date(year,month-1,day);
    let dayInMillisecs = 24*60*60*1000;
    let nextDate = new Date(today.getTime() + dayInMillisecs);

    return nextDate.getFullYear() + "-" + (nextDate.getMonth() + 1) + "-" + nextDate.getDate();
}
