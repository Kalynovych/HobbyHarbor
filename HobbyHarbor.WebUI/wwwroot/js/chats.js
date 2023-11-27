"use strict";

var creatorId, companionId, replyMessageId, messageId, publicChatId;
var editMode = false, isPublic = false;
var privateChatsConnection = new signalR.HubConnectionBuilder().withUrl("/privateChatHub").build();
var publicChatsConnection = new signalR.HubConnectionBuilder().withUrl("/publicChatHub").build();

document.body.addEventListener('click', function (event) {
    $('#contextMenu').addClass('hide');
    $("#deletePrivateChat").addClass("hide");
    $("#deletePublicChat").addClass("hide");
});

document.getElementById("sendButton").disabled = true;

privateChatsConnection.on("ReceiveMessage", (id) => receiveMessage(id));
publicChatsConnection.on("ReceiveMessage", (id) => receiveMessage(id));

privateChatsConnection.on("ReceiveEditedMessage", (message) => receiveEditedMessage(message));
publicChatsConnection.on("ReceiveEditedMessage", (message) => receiveEditedMessage(message));

privateChatsConnection.on("DeleteMessage", (id) => deleteMessage(id));
publicChatsConnection.on("DeleteMessage", (id) => deleteMessage(id));

function receiveMessage(id) {
    $.ajax({
        type: "GET",
        url: `/message/getMessage?id=${id}`,
        success: function (result) {
            $("#messageSpace").append(result);
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}

function receiveEditedMessage(message) {
    var messageText = document.getElementById(message.id).querySelector(".message-text");
    messageText.textContent = message.messageText;
}

function deleteMessage(id) {
    document.getElementById(id).parentElement.remove();
}

privateChatsConnection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

publicChatsConnection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var messageBox = document.getElementById("messageInput");
    var message = messageBox.value;
    messageBox.value = "";

    if (message == "") return;

    editMode ? editMessage(message) : sendMessage(event, message);
});

function onContextMenuPreventDefault(event) {
    event.preventDefault();
}

function sendMessage(event, message) {
    isPublic ? sendPublic(message) : sendPrivate(message);
    event.preventDefault();

    onCancelReplyClick();
}

function sendPrivate(message) {
    var messageModel = {
        "creatorId": parseInt(creatorId),
        "companionId": parseInt(companionId),
        "messageText": message,
        "replyMessageId": parseInt(replyMessageId)
    }

    privateChatsConnection.invoke("SendMessage", messageModel).catch(function (err) {
        return console.error(err.toString());
    });
}

function sendPublic(message) {
    var messageModel = {
        "publicChatId": parseInt(publicChatId),
        "messageText": message,
        "replyMessageId": parseInt(replyMessageId)
    }

    publicChatsConnection.invoke("SendMessage", messageModel).catch(function (err) {
        return console.error(err.toString());
    });
}

function onPrivateChatClick(creator, companion) {
    isPublic = false;
    $("#sendMessageSection").removeClass("hide");
    creatorId = creator;
    companionId = companion;

    $.ajax({
        type: "GET",
        url: `/message/getPrivateMessages?creatorId=${creatorId}&companionId=${companionId}`,
        success: function (result) {
            if (result == "") {
                var newDiv = $("<div>");
                newDiv.addClass("empty-messages-list");
                newDiv.text("There is no messages yet");
                $("#messageSpace").append(newDiv);
            }
            else {
                $("#messageSpace").html(result);
            }
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}

function onPrivateChatContextMenu(e, creator, companion) {
    creatorId = creator;
    companionId = companion;

    var contextMenu = $('#deletePrivateChat');
    contextMenu.removeClass('hide');
    contextMenu.css({ 'top': e.y, 'left': e.x });
}

function onPrivateChatDeleteClick() {
    var answer = confirm("Do you want to delete this chat?");

    if (answer) {
        $.ajax({
            type: "DELETE",
            url: `/chat/deletePrivateChat?creatorId=${creatorId}&companionId=${companionId}`,
            success: function (result) {
                var chat = $(`[data-creatorId="${creatorId}"][data-companionId="${companionId}"]`);
                chat.remove();
            },
            error: function (jqXHR, textStatus, error) {
                console.log(textStatus);
            }
        });
    }
}

function onReplyClick(id, message) {
    if (editMode) return;
    replyMessageId = id;

    var replyTo = document.getElementById('replyTo');
    replyTo.parentElement.parentElement.classList.remove('hide');
    replyTo.textContent = message;
}

function onCancelReplyClick() {
    var replyTo = document.getElementById('replyTo');
    replyTo.parentElement.parentElement.classList.add('hide');

    replyMessageId = null;
}

function scrollToElement(id) {
    const element = document.getElementById(id);

    element.classList.add('changed-color');
    setTimeout(function () {
        element.classList.remove('changed-color');
    }, 300);

    element.scrollIntoView();
    element.scrollIntoView(false);
    element.scrollIntoView({ block: "end" });
    element.scrollIntoView({ behavior: "smooth", block: "end", inline: "nearest" });
}

function onMessageContextMenu(e, id, isFromCurrentUser) {
    e.preventDefault();
    messageId = id;

    if (isFromCurrentUser == 'True') {
        var contextMenu = $('#contextMenu');
        contextMenu.removeClass('hide');
        contextMenu.css({ 'top': e.y, 'left': e.x });
    }
}

function editMessage(message) {
    if (messageId == null) return;
    onCancelEditClick();

    isPublic ? editPublic(message) : editPrivate(message);
}

function editPrivate(message) {
    $.ajax({
        type: "PUT",
        url: '/message/editPrivateMessage',
        contentType: 'application/json',
        data: JSON.stringify({ "id": parseInt(messageId), "messageText": message }),
        success: function (result) {
            privateChatsConnection.invoke("EditMessage", result).catch(function (err) {
                return console.error(err.toString());
            });
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}

function editPublic(message) {
    $.ajax({
        type: "PUT",
        url: '/message/editPublicMessage',
        contentType: 'application/json',
        data: JSON.stringify({ "id": parseInt(messageId), "messageText": message }),
        success: function (result) {
            privateChatsConnection.invoke("EditMessage", result).catch(function (err) {
                return console.error(err.toString());
            });
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}

function onCancelEditClick() {
    document.querySelector(".edit-row").classList.add("hide");
    document.getElementById("messageInput").value = "";

    editMode = false;
}

function onEditClick() {
    editMode = true;

    document.querySelector(".edit-row").classList.remove("hide");
    var messageBox = document.getElementById("messageInput");
    var message = document.getElementById(messageId).querySelector(".message-text").textContent;
    messageBox.value = message;
}

function onDeleteClick() {
    var answer = confirm("Do you want to delete this message?");

    if (answer) {
        $.ajax({
            type: "DELETE",
            url: `/message/deleteMessage?id=${messageId}&isPublic=${isPublic}`,
            success: function (result) {
                if (isPublic) {
                    publicChatsConnection.invoke("DeleteMessage", result).catch(function (err) {
                        return console.error(err.toString());
                    });
                }
                else {
                    privateChatsConnection.invoke("DeleteMessage", result).catch(function (err) {
                        return console.error(err.toString());
                    });
                }
            },
            error: function (jqXHR, textStatus, error) {
                console.log(textStatus);
            }
        });
    }
}

function onPublicChatClick(chatId) {
    isPublic = true;
    $("#sendMessageSection").removeClass("hide");
    publicChatId = chatId;

    $.ajax({
        type: "GET",
        url: `/message/getPublicMessages?publicChatid=${publicChatId}`,
        success: function (result) {
            if (result == "") {
                var newDiv = $("<div>");
                newDiv.addClass("empty-messages-list");
                newDiv.text("There is no messages yet");
                $("#messageSpace").append(newDiv);
            }
            else {
                $("#messageSpace").html(result);
            }
        },
        error: function (jqXHR, textStatus, error) {
            console.log(textStatus);
        }
    });
}

function onPublicChatContextMenu(e, id) {
    publicChatId = id;

    var contextMenu = $('#deletePublicChat');
    contextMenu.removeClass('hide');
    contextMenu.css({ 'top': e.y, 'left': e.x });
}

function onPublicChatDeleteClick() {
    var answer = confirm("Do you want to delete this chat?");

    if (answer) {
        $.ajax({
            type: "DELETE",
            url: `/chat/deletePublicChat?publicChatId=${publicChatId}`,
            success: function (result) {
                var chat = $(`[data-publicChatId="${publicChatId}"]`);
                chat.remove();
            },
            error: function (jqXHR, textStatus, error) {
                console.log(textStatus);
            }
        });
    }
}