var invitedFriendsIDs = new Array();

function inviteFriend(id) {
    invitedFriendsIDs.push(id);
    $("div#" + id).hide();

}

function finishInviting() {

    var resID = $("#reservationID").val();

    $.post(
            "../Restaurant/SuccesfullyInvitedFriends",
            {
                friendsIDsList: invitedFriendsIDs,
                reservationID: resID
            },
            function () {
                location.replace("http://localhost:50353/Restaurant/SuccesfullyInvitedFriendsConfirmed");

            });
}