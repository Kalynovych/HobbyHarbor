$(document).ready(function () {
    $(".post-comment-count").on("click", onCommentsClick);
});

function onCommentsClick() {
    let commentSection = $(this).parent().parent().find(".post-comment-section");
    commentSection.toggleClass("hide");
    let postId = $(this).data("postid");

    $.ajax({
        type: "GET",
        url: "/home/getComments?postId=" + postId,
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
    let replies = $(this).parent().find(".comment-reply-wrapper");
    replies.toggleClass("hide");
    let commentId = $(this).data("commentid");

    $.ajax({
        type: "GET",
        url: "/home/getReplies?commentId=" + commentId,
        success: function (result) {
            replies.html(result);
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}