function showAddTran() {
    $("#add-tran-div").show();
}
function hideAddTran() {
    $("#add-tran-div").hide();
}
function deleteTransaction(acctId, tranId) {
    openLoadingModal();
    var url = "/Finances/DeleteTransaction";
    if (window.location.hostname == 'localhost') {
        url = "/YMB/Finances/DeleteTransaction";
    }
    $.ajax({
        type: "post",
        async: true,
        url: url,
        data: { acctId: acctId, tranId: tranId },
        success: function (result) {
            closeLoadingModal();
            location.reload();
        }
    });
}

function pendingTransaction(acctId, tranId) {

    var url = "/Finances/PendingTransaction";
    if (window.location.hostname == 'localhost') {
        url = "/YMB/Finances/PendingTransaction";
    }
    $.ajax({
        type: "post",
        async: true,
        url: url,
        data: { acctId: acctId, tranId: tranId },
        success: function (result) {
            location.reload();
        }
    });
}
function addTransaction(acctId, acctType) {
    openLoadingModal();
    var url = "/Finances/AddTransactions";
    if (window.location.hostname == 'localhost') {
        url = "/YMB/Finances/AddTransactions";
    }
    var isPending = false;
    var isChecked = $("#isPending")[0].checked;
    if (isChecked) isPending = true;
    var tranDesc = $("#tranDesc").val();
    var tranAmount = $("#tranAmount").val();
    var tranType = $("#tranType").val();
    if (tranDesc <= "" || tranAmount <= 0.00 || tranType == 0) {
        alert("Please enter every field.");
        return false;
    }
    $.ajax({
        type: "post",
        async: true,
        url: url,
        data: { acctId: acctId, tranType: tranType, tranDesc: tranDesc, tranAmount: tranAmount, acctType: acctType, pending: isPending },
        success: function (result) {
            closeLoadingModal();
            location.reload();
        }
    });
}