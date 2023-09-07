function DeleteCategory(Id, UserId) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, Delete!",
    }).then((result) => {
        if (result.isConfirmed) {
            $("#DeleteBTN").attr("disabled", "disabled");

            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                url: "/api/Expenses/DeleteCategory",
                data: JSON.stringify({ Id: Id, UserId: UserId }),
                success: function (resp) {
                    $("#DeleteBTN").removeAttr("disabled", "disabled");

                    if (resp.statusCode === "000") {
                        Swal.fire({
                            title: resp.statusDescription + "!",
                            text: "Category Deleted Successfully",
                            icon: "success",
                            confirmButtonText: "Okay",
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = "/Home/AddCategory";
                            }
                        });

                    } else if (resp.statusCode === "001") {
                        Swal.fire({
                            title: resp.statusDescription + "!",
                            text: "Failed Deleting Category",
                            icon: "error",
                            confirmButtonText: "Okay",
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = "/Home/AddCategory";
                            }
                        });
                    } else {
                        Swal.fire({
                            title: resp.StatusDescription + "!",
                            text: "Failed Deleting Category",
                            icon: "error",
                            confirmButtonText: "Okay",
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = "/Home/AddCategory";
                            }
                        });
                    }
                },
            });
        }
    });
}

function DeleteBudget(Id, UserId) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, Delete!",
    }).then((result) => {
        if (result.isConfirmed) {
            $("#DeleteBTN").attr("disabled", "disabled");

            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                url: "/api/Expenses/DeleteBudget",
                data: JSON.stringify({ Id: Id, UserId: UserId }),
                success: function (resp) {
                    $("#DeleteBTN").removeAttr("disabled", "disabled");

                    if (resp.statusCode === "000") {
                        Swal.fire({
                            title: resp.statusDescription + "!",
                            text: "Budget Deleted Successfully",
                            icon: "success",
                            confirmButtonText: "Okay",
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = "/Home/AddBudget";
                            }
                        });

                    } else if (resp.statusCode === "001") {
                        Swal.fire({
                            title: resp.statusDescription + "!",
                            text: "Failed Deleting Budget",
                            icon: "error",
                            confirmButtonText: "Okay",
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = "/Home/AddBudget";
                            }
                        });
                    } else {
                        Swal.fire({
                            title: resp.StatusDescription + "!",
                            text: "Failed Deleting Budget",
                            icon: "error",
                            confirmButtonText: "Okay",
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = "/Home/AddBudget";
                            }
                        });
                    }
                },
            });
        }
    });
}

