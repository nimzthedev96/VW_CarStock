﻿// This file contains all the AJAX JS calls

function saveCar()
{
    var car = {
        CarId: -1,
        CarModel: "Polo Vivo",
        CarMake: "VW",
        CarTrimLevel: "Comfortline",
        CarEngine: "1.0",
        Price: 1000.00,
        NumInStock: 0
       // Features: ["Code", "Coffee", "Stackoverflow"]
    };

    console.log(JSON.stringify(car));

    $.ajax({
        type: "POST",
        url: 'https://localhost:44394/api/createcar',
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(car),
        success:
            function (response) {
                alert("Success: " + response.responseText);
            },
        error:
            function (response) {
                alert("Error: " + response.responseText);
            }
    })

        //.done(function (res) {
     //   console.log(html(res));
    //}
}


function deleteCar() {
    var car = {
        CarId: -1,
        CarModel: "Polo Vivo",
        CarMake: "VW",
        CarTrimLevel: "Comfortline",
        CarEngine: "1.0",
        Price: 1000.00,
        NumInStock: 0
        // Features: ["Code", "Coffee", "Stackoverflow"]
    };

    console.log(JSON.stringify(car));

    $.ajax({
        type: "POST",
        url: 'https://localhost:44394/api/deletecar',
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(car),
        success:
            function (response) {
                alert("Success: " + response.responseText);
            },
        error:
            function (response) {
                alert("Error: " + response.responseText);
            }
    })

    //.done(function (res) {
    //   console.log(html(res));
    //}
}