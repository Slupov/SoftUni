function summary(button) {
    //attach event
    let summaryObj = $("<div id='summary'></div>");
    let highlighted = $("#content").find("strong");

    //console.dir(highlighted);
    $(button).on("click" ,function () {
        let newP = $("<p>");

        for (let hl of highlighted) {
            $(hl).clone().appendTo(newP);
        }

        newP.appendTo(summaryObj);
    });

    summaryObj.insertAfter($("#content"));
}
summary($("#generate"));