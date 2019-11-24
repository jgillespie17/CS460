function commits(owner, repo) {
    $("#CommitTable").empty();
    $("#help").empty();
    var $table = $('#CommitTable');
    var $header = $('#help');
    var uri = "/api/commits?user=" + owner + "&repo=" + repo;
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: uri,
        success: function (data) {
            //console.log(data);
            $header.append('<h3>' + repo + '</h3>');
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
}