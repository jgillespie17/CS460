function buildTable(id, event) {
    console.log(id, event)
    $("#graph").empty();
    var graph = $('#graph');
    var table = document.getElementById('dataTable');
    var uri = "/api/graphdata?AID=" + id + "&Event=" + event;
    console.log(uri);
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: uri,
        success: function (data) {
            console.log(data)
            console.log(data.Date)
            var DateList = [];
            var TimeList = [];
            for (let i = 0; i < data.length; i++) {
                DateList[i] = data[i].Date
                TimeList[i] = data[i].Time

            }
            var trace = {
                x: DateList,
                y: TimeList,
                type: 'scatter'
            };
            var plotData = [trace];
            Plotly.newPlot('graph', plotData);
        }
    });
};
