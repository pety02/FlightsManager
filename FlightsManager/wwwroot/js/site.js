// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict"
function showLogOutBtn() {

    let btn = document.getElementById("logOutBtn");
    btn.style.display="block";
}

function addNewPassagerInputs() {

    let newRow = document.createElement("tr");
    document.getElementById("extrPassagers").appendChild(newRow);

    let name = document.createElement("td");
    let nameInp = document.createElement("input");
    nameInp.type = "text";
    nameInp.placeholder = "First Name";

    let sname = document.createElement("td");
    let snameInp = document.createElement("input");
    snameInp.type = "text";
    snameInp.placeholder = "Second Name";

    let fam = document.createElement("td");
    let famInp = document.createElement("input");
    famInp.type = "text";
    famInp.placeholder = "Last Name";

    let pin = document.createElement("td");
    let pinInp = document.createElement("input");
    pinInp.type = "text";
    pinInp.placeholder = "First Name";

    let natInp = document.getElementById("nat");
    let nat = natInp.cloneNode(true);

    newRow.appendChild(name);
    name.appendChild(nameInp);

    newRow.appendChild(sname);
    sname.appendChild(snameInp);

    newRow.appendChild(fam);
    fam.appendChild(famInp);

    newRow.appendChild(pin);
    pin.appendChild(pinInp);

    newRow.appendChild(nat);

    let br = document.createElement("br");
    document.getElementById("extrPassagers").appendChild(br);
}