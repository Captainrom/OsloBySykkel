$(document).ready(function() {
    SendData();
});

    function addcell(row,value) {
        let td = document.createElement('td');

        td.innerHTML = value;
        row.appendChild(td);
    }

    function addrow(tablebody, value1, value2, value3) {
        let row = tablebody.insertRow();

        addcell(row, value1);
        addcell(row, value2);
        addcell(row, value3);
    }

    function Showtable(stations) {
        let firsttable = document.querySelector("table");
        let tablebody = document.getElementById("tablebody");
        let tbody = firsttable.createTBody();
  
        for (let station of stations) {
        addrow(tbody, station.name, station.num_docks_available, station.num_bikes_available);
        }
    }

    function SendData() {
        $.ajax({
            //url: '@Url.Action("GetStationJson","Home")',
            url: "/stations",                                                      
            type: 'Get',
            contentType: "application/json",
            dataType: 'json',

            success: function (result) {
                Showtable(result.data.stations);
            }
        });
    }