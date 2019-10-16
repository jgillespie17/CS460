let stats = ["Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charism", "Gold", "Hitpoints"];

function makeSheet() {
    formClear();
    $("#theSheet").empty();
    //body.empty();
    $("#myList").empty();
    //creates stats
    var Str = Math.round(Math.random() * 20);
    var Dex = Math.round(Math.random() * 20);
    var Con = Math.round(Math.random() * 20);
    var Int = Math.round(Math.random() * 20);
    var Wis = Math.round(Math.random() * 20);
    var Cha = Math.round(Math.random() * 20);
    var lev = document.getElementById("levelData").value;
    var lev2 = parseInt(lev, 10)
    var Gold = lev2 * 20;
    var hitpoints = calcHit(lev2);
    let statNum = [Str, Dex, Con, Int, Wis, Cha, Gold, hitpoints];

    //creates table
    var body = null;
    var body = document.body;
    var tab = document.createElement('table');
    var tr = tab.insertRow();
    //adds headers for the table
    for (var i = 0; i < 8; i++) {
        var th = tr.insertCell();
        th.appendChild(document.createTextNode(stats[i]));
    }
    body.appendChild(tab);
    //adds data under the headers
    tr = tab.insertRow();
    for (var j = 0; j < 8; j++) {
        var td = tr.insertCell();
        td.appendChild(document.createTextNode(statNum[j]));
    }
    body.appendChild(tab);

    var list = document.createElement('li');
    var back = document.getElementById('backgroundData').value;
    var race = document.getElementById('raceData').value;
    var skill = document.getElementById('classData').value;
    let desc = [back, race, skill],
        ul = document.createElement('ul');

    document.getElementById('myList').appendChild(ul);
    desc.forEach(function(item) {
        let li = document.createElement('li');
        ul.appendChild(li);
        li.innerHTML += item;

    });
}

function calcHit(lev) {
    var total = 0;
    var num = 0;
    for (var i = 0; i < lev; i++) {
        total = total + Math.round(Math.random() * 8)
    }
    return total;

}