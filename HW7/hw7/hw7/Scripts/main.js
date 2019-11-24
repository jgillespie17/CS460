function commits(owner, repo) {
    $("#CommitTable").empty();
    var $table = $('#CommitTable');
    var uri = "/api/commits?user=" + owner + "&repo=" + repo;
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: uri,
        success: function (data) {
            console.log(data);
            $table.append('<tr> <th>Sha</th> <th>Timestamp</th> <th>Committer</th> <th>Commit Message</th> </tr>')
            $.each(data, function (i, data) {
                var str = data.Sha;
                str = str.slice(0, 8);
                $table.append('<tr> <td>' + str.link(data.CommitHtmlURL) + '</td><td>' + data.TimeStamp + '</td><td>' + data.Committer + '</td><td>' + data.CommitMessage + '</td> <tr>')
            });
        }
           
    });
}

function errorOnAjax() {
    console.log("ERROR in ajax request.");
}

function displayCommits() {
    var $CommitTable = $('#CommitTable');
    $.each(data, function (i, data) {
        document.getElementById('CommitTable').append("<th>name")

    });
    //var count = Object.keys(data).length;
    //for (var j = 0; j < count; j++) {
    //    $
    //}
}