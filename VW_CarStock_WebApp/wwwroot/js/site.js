// This file contains all the AJAX JS calls


function saveCar() {


    /* validate price*/ 
    var price = $("#price").val() ;

    if (price == 0)
    {
        $("#Result").css("display", "block");
        $("#Result").html('<div id="Error" class="alert alert-danger alert-dismissible fade show" role="alert"> Please enter in a price before saving. <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div> ');

        return;
    }

    var selected = [];
    var val;

    for (var option of document.getElementById('featurelist').options) {
        if (option.selected) {
            var val =
                {
                    key: option.value,
                    value: option.text
                };
            console.log(val);
            selected.push(val)
        }
    }

    var car = {
        CarId: $("#carId").val(),
        CarModelId: $("#carModelId").val(),
        CarMakeId: $("#carMakeId").val(),
        CarTrimLevelId: $("#carTrimId").val(),
        CarEngineId: $("#engineTypeId").val(),
        Price: $("#price").val(),
        NumInStock: 0,
        Features: selected
    };

    console.log(JSON.stringify(car));

    if ($("#carId").val() == -1)
    {
        var urlstr = 'https://localhost:44394/api/createcar';
    }
    else
    {
        var urlstr = 'https://localhost:44394/api/updatecar';
    }

    $.ajax({
        type: "POST",
        url: urlstr,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(car),
        success:
            function (response) {
                $("#Result").css("display", "block");
                if ($("#carId").val() == -1) {
                    $("#Result").html('<div class="alert alert-success alert-dismissible fade show" role="alert"> New car created successfully. <button type="button" class="close" data-dismiss="alert" aria-label="Close"> <span aria-hidden="true">&times;</span></button>');
                }
                else {
                    $("#Result").html('<div class="alert alert-success alert-dismissible fade show" role="alert"> Car updated successfully. <button type="button" class="close" data-dismiss="alert" aria-label="Close"> <span aria-hidden="true">&times;</span></button>');
                }
            },
        error:
            function (response) {
                var respArr = response.responseText.split();
                var error = respArr.toString();
                $("#Result").css("display", "block");
                $("#Result").html('<div id="Error_@Html.DisplayFor(m => car.CarId)" class="alert alert-danger alert-dismissible fade show" role="alert"> Error: ' + error + ' < button type = "button" class= "close" data - dismiss="alert" aria - label="Close" < span aria - hidden="true" >& times;</span ></button > </div > ');

            }
    })

}

function deleteCar() {
    var car = {
        CarId: $("#carId").val(),
        CarModelId: $("#carModelId").val(),
        CarMakeId: $("#carMakeId").val(),
        CarTrimLevelId: $("#carTrimId").val(),
        CarEngineId: $("#engineTypeId").val(),
        Price: $("#price").val(),
        NumInStock: 0
    };

    var check = confirm("Are you sure you want to delete this car?");

    if (check == false)
        return;

    console.log(JSON.stringify(car));

    $.ajax({
        type: "POST",
        url: 'https://localhost:44394/api/deletecar',
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(car),
        success:
            function (response) {
                $("#Result").css("display", "block");
                $("#Result").html('<div class="alert alert-success alert-dismissible fade show" role="alert"> Car delete updated successfully. <button type="button" class="close" data-dismiss="alert" aria-label="Close"> <span aria-hidden="true">&times;</span></button>');

                //history.back();

            },
        error:
            function (response) {
                var respArr = response.responseText.split();
                var error = respArr.toString();
                $("#Result").css("display", "block");
                $("#Result").html('<div id="Error_@Html.DisplayFor(m => car.CarId)" class="alert alert-danger alert-dismissible fade show" role="alert"> Error: ' + error + ' <button type="button" class="close" data-dismiss="alert" aria-label="Close" <span aria-hidden="true" >&times;</span></button> </div> ');

            }
    })


}

function allowStockSave(btn)
{
    console.log(btn.id.replaceAll("editBtn", "numInStock"));
    var name = '#' + btn.id.replaceAll("editBtn", "saveBtn");
    $(name).show();
    $(name).css("display", "block");

    name = '#' + btn.id.replaceAll("editBtn", "numInStock");
    $(name).prop("disabled", false);

    name = '#' + btn.id;
    $(name).hide();
    $(name).css("display", "none");
}


function updateStock(btn)
{
    var carid = btn.id.replaceAll("saveBtn_", "");
    var name = "#numInStock_" + carid;
    var numStockValue = $(name).val();

    var car = {
        CarId: carid,
        NumInStock: numStockValue
    };

    $.ajax({
        type: "POST",
        url: 'https://localhost:44394/api/updatecarstock',
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(car),
        success:
            function (response) {
                var name = "#Result_" + carid;
                $(name).css("display", "block");
                $(name).html('<div class="alert alert-success alert-dismissible fade show" role="alert"> Car stock updated successfully. <button type="button" class="close" data-dismiss="alert" aria-label="Close"> <span aria-hidden="true">&times;</span></button>');

                name = "#editBtn_"  + carid;
                $(name).css("display", "block");

                name = "#editImg_" + carid;
                $(name).show();

                name = "#numInStock_" + carid;
                $(name).prop("disabled", true);

                name = "#saveBtn_" + carid;
                $(name).css("display", "none");
                $(name).hide();

            },
        error:
            function (response) {
                var name = "#Result_" + carid;

                var respArr = response.responseText.split();
                var error = respArr.toString();
                $(name).css("display", "block");
                $(name).html('<div id="Error_@Html.DisplayFor(m => car.CarId)" class="alert alert-danger alert-dismissible fade show" role="alert"> Error: ' + error + ' <button type="button" class="close" data-dismiss="alert" aria - label="Close" <span aria-hidden="true" >&times;</span></button></div> ');
            }
    })


}
