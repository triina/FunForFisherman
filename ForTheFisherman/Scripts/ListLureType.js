function listLureType() {
    $.getJSON("/LureType/List", function (result) {
        var ddl = $("#ltId");
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