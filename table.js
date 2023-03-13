
function convertDay(curDay)
{

    switch (curDay)
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
    return curDay;
}

function getMonday()
{
    let monday = new Date();
    let shift = [6, 0, 1, 2, 3, 4, 5];
    monday.setDate(monday.getDate()-shift[monday.getDay()]);
    monday.toLocaleString;

    return monday;
}

/*
let table = document.querySelector('table');

table.querySelectorAll('th');
*/

let tbl = [];
tbl [0] = [];
headers = [];

let monday = getMonday();
let dateNum = new Date(monday);

for (let i = 1; i < 7; i++)
{
    let day = convertDay(dateNum.getDay());
    let date = dateNum.getDate();
    let month = dateNum.getMonth() + 1;

    headers[i] = {
    day: day,
    date: date,
    month: month, 
    fulldate: new Date(dateNum)
   }
   dateNum.setDate(dateNum.getDate()+1);

}

setTableHeders();

function setTableHeders()
{
    let table = document.querySelector('table');
    let ths = table.querySelectorAll('th');
    for (let i = 1; i < 7; i++)
    {
        ths[i].innerHTML = `${headers[i].day}<br>${headers[i].fulldate.toLocaleDateString()}`;
    }
}