$(function() {
    $.ajax("/versions.json", { dataType: "json" })
        .done(function(data) {
            $("select.versions-dropdown")
                .append(data.versions.map(function(v) { return $("<option/>", { value: v.tag, text: v.name }); }))
                .val(location.pathname.substring(data.urlPrefix.length).split("/")[0])
                .on("change", function(evt) {
                    location.href = location.origin + "/" + evt.target.value + "/"
                });
            $(".version-selector").show();
        });
});