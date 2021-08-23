var barchart = document.getElementById('bar').getContext('2d');
var bar = document.getElementById('residualValue');
var yearKeyElement = bar.getElementsByClassName("recordKey");
var yearValueElement = bar.getElementsByClassName("recordValue")

var yearKey = [];
var yearValue = [];



for (let item of yearKeyElement) {
    yearKey.push(item.value);
}

for (let item of yearValueElement) {
    var value = item.value.replace(",", ".")
    yearValue.push(parseFloat(value))
}

for (let item of yearValue) {
    console.log(item)
}

var mybarChart = new Chart(barchart,
    {
        type: 'bar',
        data: {
            labels: yearKey,
            datasets: [
                {
                    label: 'Остаточная стоимость',
                    data: yearValue,
                    backgroundColor: 'rgba(6,128,250)',

                }]
        },
        options: {
            scales: {
                yAxes: [
                    {
                        ticks: {
                            beginAtZero: true
                        }
                    }]
            }
        }
    })