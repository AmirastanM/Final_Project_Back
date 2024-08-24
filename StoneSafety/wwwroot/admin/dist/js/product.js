$(document).on("click", "#edit-area .set-main, .img-delete", function () {
    let imageId = parseInt($(this).attr("data-id"));
    let productId = parseInt($(this).attr("data-productId"));
    let isDelete = $(this).hasClass("img-delete");

    // Проверка значений
    console.log("Image ID:", imageId);
    console.log("Product ID:", productId);
    console.log("Is Delete:", isDelete);

    // Данные для AJAX
    let data = {
        productId: productId,
        imageId: imageId,
        imagePath: "assets/images"
    };

    // URL в зависимости от действия
    let url = isDelete ? `/admin/product/deleteimage` : `/admin/product/setmainimage`;

    // Проверка URL и данных
    console.log("URL:", url);
    console.log("Data:", data);

    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        success: function () {
            if (isDelete) {
                console.log("Image deleted successfully");
                $(`[data-id=${imageId}]`).closest(".col-3").remove();
            } else {
                console.log("Image set as main successfully");
                $(".image-main").removeClass("image-main");
                let $newMainImage = $(`[data-id=${imageId}]`).closest(".col-3").find("img");
                console.log("New main image:", $newMainImage);
                $newMainImage.addClass("image-main");

                $(".hide-btn")
                    .addClass("show-btn")
                    .removeClass("hide-btn");
                $(`[data-id=${imageId}]`).closest(".col-3")
                    .addClass("hide-btn")
                    .removeClass("show-btn");
            }
        },
        error: function (xhr) {
            console.log("AJAX Error Status:", xhr.status);
            console.log("Error:", xhr.responseText);
        }
    });
});
