let stats = ["Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charism", "Gold", "Hitpoints"];

function makeSheet() {
    //creates stats
    var Str = Math.round(Math.random() * 10);
    var Dex = Math.round(Math.random() * 10);
    var Con = Math.round(Math.random() * 10);
    var Int = Math.round(Math.random() * 10);
    var Wis = Math.round(Math.random() * 10);
    var Cha = Math.round(Math.random() * 10);
    var lev = document.getElementById("levelData").value;
    var lev2 = parseInt(lev, 10)
    var Gold = lev2 * 20;
    var hitpoints = calcHit(lev2);
    let statNum = [Str, Dex, Con, Int, Wis, Cha, Gold, hitpoints];

    //creates table
    var body = document.body;
    var tab = document.createElement('table');
    var tr = tab.insertRow();
    for (var i = 0; i < 8; i++) {
        var th = tr.insertCell();
        th.appendChild(document.createTextNode(stats[i]));
        th.style.border = '1px solid black';
    }
    body.appendChild(tab);
    tr = tab.insertRow();
    for (var j = 0; j < 8; j++) {
        var td = tr.insertCell();
        td.appendChild(document.createTextNode(statNum[j]));
        th.style.border = '1x solid black;'
    }
    body.appendChild(tab);

}

function calcHit(lev) {
    var total = 0;
    var num = 0;
    for (var i = 0; i < lev; i++) {
        total = total + Math.round(Math.random() * 8)
    }
    return total;

}
$("#generateSheet").submit(function(event) {
    document.getElementById("generate").style.color = "red";
    event.preventDefault();
    $("theSheet").empty();
    $("theSheet").append(makeSheet());
    console.log("Got called");
});