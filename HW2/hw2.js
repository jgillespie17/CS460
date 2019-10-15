function makeSheet() {
    var tab1 = $("<table>");
    var capt = $("<caption>").html("Character stats");
    capt.appendTo(tab1);
    var thead = $("<thead>\
                    <tr>\
                        <th>Strength</th>\
                        <th>Dexterity</th>\
                        <th>Constitution</th>\
                        <th>Intelligence</th>\
                        <th>Wisdom</th>\
                        <th>Charisma</th>\
                        <th>Gold</th>\
                        <th>Hitpoints</th>\
                    </tr>\
                </thead>");
    thead.appendTo(tab1);
    var tbody = $("<tbody>");
    var trow = $("<tr>");
    var Str = Math.round(Math.random() * 10);
    var Dex = Math.round(Math.random() * 10);
    var Con = Math.round(Math.random() * 10);
    var Int = Math.round(Math.random() * 10);
    var Wis = Math.round(Math.random() * 10);
    var Cha = Math.round(Math.random() * 10);
    var lev = document.getElementById("Level");
    var Gold = lev * 20;
    var hitpoints = calcHit(lev);
    console.log(hitpoints);
    return tab1;
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