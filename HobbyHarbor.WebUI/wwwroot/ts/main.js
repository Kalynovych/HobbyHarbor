var skipProfiles = 0;
$(document).ready(function () {
    $(".post-comment-count").on("click", onCommentsClick);
});
function onCommentsClick() {
    var commentSection = $(this).parent().parent().find(".post-comment-section");
    commentSection.toggleClass("hide");
    var postId = $(this).data("postid");
    $.ajax({
        type: "GET",
        url: "/comment/getComments?postId=" + postId,
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
        url: "/comment/getReplies?commentId=" + commentId,
        success: function (result) {
            replies.html(result);
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}
function onPostLikeClick(sender, reaction, postId) {
    setReaction(sender, reaction, postId, true);
}
function onPostDislikeClick(sender, reaction, postId) {
    setReaction(sender, reaction, postId, false);
}
function setReaction(sender, reaction, postId, newReaction) {
    var likes = sender.parentElement.querySelector(".likes");
    var dislikes = sender.parentElement.querySelector(".dislikes");
    if (reaction == "") {
        putReaction(sender, newReaction, postId);
        likes.setAttribute('onclick', "onPostLikeClick(this, '".concat(newReaction.toString(), "', ").concat(postId, ")"));
        dislikes.setAttribute('onclick', "onPostDislikeClick(this, '".concat(newReaction.toString(), "', ").concat(postId, ")"));
    }
    else {
        if (reaction.toLowerCase() == newReaction.toString()) {
            removeReaction(sender, postId);
            likes.setAttribute('onclick', "onPostLikeClick(this, '', ".concat(postId, ")"));
            dislikes.setAttribute('onclick', "onPostDislikeClick(this, '', ".concat(postId, ")"));
        }
        else {
            putReaction(sender, newReaction, postId);
            likes.setAttribute('onclick', "onPostLikeClick(this, '".concat(newReaction.toString(), "', ").concat(postId, ")"));
            dislikes.setAttribute('onclick', "onPostDislikeClick(this, '".concat(newReaction.toString(), "', ").concat(postId, ")"));
        }
    }
}
function setLikesAndDislikes(sender, value) {
    var response = JSON.parse(value);
    var likes = sender.parentElement.querySelector(".likes");
    var dislikes = sender.parentElement.querySelector(".dislikes");
    likes.querySelector("p").textContent = response.likes;
    dislikes.querySelector("p").textContent = response.dislikes;
}
function removeReaction(sender, postId) {
    $.ajax({
        type: "DELETE",
        url: "/post/deleteReaction?postId=" + parseInt(postId),
        success: function (result) {
            setLikesAndDislikes(sender, result);
            var reacted = sender.querySelector(".reacted");
            reacted.classList.remove("reacted");
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}
function putReaction(sender, reaction, postId) {
    $.ajax({
        type: "PUT",
        url: "/post/putReaction",
        contentType: 'application/json',
        data: JSON.stringify({ "postId": parseInt(postId), "reaction": reaction }),
        success: function (result) {
            setLikesAndDislikes(sender, result);
            var reacted = sender.parentElement.querySelector(".reacted");
            if (reacted != null)
                reacted.classList.remove("reacted");
            sender.querySelector("p").classList.add("reacted");
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}
function nextProfile() {
    skipProfiles += 1;
    $.ajax({
        type: "GET",
        url: "/profile/getProfile?skip=" + skipProfiles,
        success: function (result) {
            $("#profileChoice").html(result);
        },
        error: function (jqXHR, textStatus, error) {
            var newDiv = $("<div>");
            newDiv.addClass("profile-not-found");
            newDiv.text("No profile found");
            $("#profileChoice").replaceWith(newDiv);
        }
    });
}
function setChoice(target, isLiked) {
    $.ajax({
        type: "POST",
        url: "/profile/postChoice?target=".concat(target, "&isLiked=").concat(isLiked),
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}
function createChat(target) {
    $.ajax({
        type: "POST",
        url: "/chat/createPrivateChat?companionUsername=".concat(target),
        success: function (result) {
            window.location.href = '/home/privateChats';
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}
function onSkipProfileClick(target) {
    setChoice(target, false);
    nextProfile();
}
function onLikeProfileClick(target) {
    setChoice(target, true);
    nextProfile();
}
function onSendMessageClick(target) {
    setChoice(target, true);
    createChat(target);
}
//# sourceMappingURL=main.js.map