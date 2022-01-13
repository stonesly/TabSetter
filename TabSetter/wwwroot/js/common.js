window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful");
    }
    if (type === "error") {
        toastr.error(message, "Operation Failed");
    }
}

window.Console = (message) => {
    console.log(message);
}

window.Focus = (id) => {
    document.getElementById(id).focus();
}
