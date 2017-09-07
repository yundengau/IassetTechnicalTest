$(document).ready(function () {
    $("#btn_findCity").click(function () {
        var country = $("#country").val();
        if (country == '') {
            alert("Please enter a country.");
            return;
        }


        $.ajax({
            url: "/Home/GetCountryCity",
            method: "POST",
            data: { country: country },
        }).done(function (response) {
            console.log(response);
            $("#city").empty();
            $('#city').append(new Option("---- Select City ---", ""));
            console.log(response);
            $.each(response, function (index, item) {

                var option = new Option(item.Name, item.Name + "_" + item.CountryCode);
                $('#city').append($(option));
            });
        });
    });

    $("#city").change(function () {

        var city = $("#city option:selected").text();
        var cityVal = $("#city option:selected").val();
        alert(cityVal);
        var countryCode = cityVal.split('_')[1];
        alert(countryCode);

        $.ajax({
            url: "/Home/GetWeather",
            data: { countryCode: countryCode, city: city },
            method: "POST",
        }).done(function (response) {
            console.log(response);
            $("#name").text(response.name);
            $("#temp").text(response.main.temp);
            $("#humidity").text(response.main.humidity);
        });


    });


})