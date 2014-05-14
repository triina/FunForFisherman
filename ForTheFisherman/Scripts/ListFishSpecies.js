function listFishSpecies() {
    $.getJSON("/FishSpecies/List", function (result) {
        var ddl = $("#fiId");
        ddl.empty();
        $(result).each(function () {
            if (this.Value == id) {
                $(document.createElement("option"))
                    .attr("value", this.Value)
                    .attr("selected", "selected")
                    .text(this.Text)
                    .appendTo(ddl);
            }
            else {
                $(document.createElement("option"))
                    .attr("value", this.Value)
                    .text(this.Text)
                    .appendTo(ddl);
            }
        });
    });
}