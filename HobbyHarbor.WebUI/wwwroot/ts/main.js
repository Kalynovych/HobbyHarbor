$(document).ready(function () {
    $(".post-comment-count").on("click", onCommentsClick);
});
function onCommentsClick() {
    var commentSection = $(this).parent().parent().find(".post-comment-section");
    commentSection.toggleClass("hide");
    var postId = $(this).data("postid");
    $.ajax({
        type: "GET",
        url: "/comments/getComments?postId=" + postId,
        success: function (result) {
            commentSection.find(".comments-wrapper").html(result);
            $(".comment-replies-button").on("click", onCommentRepliesClick);
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}
function onCommentRepliesClick() {
    var replies = $(this).parent().find(".comment-reply-wrapper");
    replies.toggleClass("hide");
    var commentId = $(this).data("commentid");
    $.ajax({
        type: "GET",
        url: "/comments/getReplies?commentId=" + commentId,
        success: function (result) {
            replies.html(result);
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}
//# sourceMappingURL=main.js.map