$(document).ready(function () {
    $("#openComments").click(function () {
        $("#commentSection").toggleClass("hide");

        $.ajax({
            url: "/home/getComments?postId=1",
            success: function (result) {
                $("#commentsContainer").html(result);
            },
            error: function (ex, status, smth) {
                console.log(status);
            }
        });
    })
});