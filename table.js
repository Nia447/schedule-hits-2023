let monday = new Date();
let curNumDay = getDate();
let curMonth = getMonth();
let curDay = getDay();

function convertDay()
{switch (curDay)
{

    case 1:
        curDay = "ПН"
        break;

    case 2:
        curDay = "ВТ"
        break;

    case 3:
        curDay = "СР"
        break;
    case 4:
        curDay = "ЧТ"
        break;
    case 5:
        curDay = "ПТ"
        break;
    case 6:
        curDay = "СБ"
        break;
}
}

function getMonday()
{
    let monday = new Date();
    let shift = [6, 0, 1, 2, 3, 4, 5];
    monday.setDate(monday.getDate()-shift[monday.getDay()]);
    monday.toLocaleString;
    let dateNum = {
        day: monday.getDay(),
        date: monday.getDate(),
        month: monday.getMonth

    }
    return dateNum;
}

/*
let table = document.querySelector('table');

table.querySelectorAll('th');
*/

let tbl = [];
tbl [0] = [];

for (let i = 1; i < 7; i++)
{
   tbl[0][i] = {
    day: convertDay(getMonday(dateNum.day)),
    date: getMonday(dateNum.date),
    month: getMonday(dateNum.month)

   }

}

