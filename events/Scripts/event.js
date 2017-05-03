
let addToCart = (itemId) => {
    $.ajax({
        url: "/home/ShoppingCart/" + itemId,
        method: "POST",
        dataType: "html",
        success: (partial) => {
            $("#shoppingCart").html(partial);
        }
    });
}