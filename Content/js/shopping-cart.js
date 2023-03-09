
let minus_btn = document.getElementsByClassName('minus');
let plus_btn = document.getElementsByClassName('plus');

let minus_leng = minus_btn.length;
let plus_leng = plus_btn.length;
for (i = 0; i < minus_leng; i++) {
    let button = minus_btn.item(i);
    button.addEventListener('click', function (event) {
        var buttonClicked = event.target;
        // console.log(buttonClicked);
        var input = buttonClicked.parentElement.children[1];
        // console.log(input)
        var inputValue = input.value;
        // console.log(inputValue);
        if (inputValue < 2) {
            input.value = 1;
        } else {
            input.value = parseInt(inputValue) - 1;
        }
        updateCart();
    })
}
;

for (i = 0; i < plus_leng; i++) {
    let button = plus_btn.item(i);
    button.addEventListener('click', function (event) {
        var buttonClicked = event.target;
        // console.log(buttonClicked);
        var input = buttonClicked.parentElement.children[1];
        // console.log(input)
        var inputValue = input.value;
        // console.log(inputValue);
        if (inputValue > 98) {
            input.value = 99;
        } else {
            input.value = parseInt(inputValue) + 1;
        }
        updateCart();
    })
}
;

let delete_btn = document.getElementsByClassName('delete-btn');
for (let i = 0; i < delete_btn.length; i++) {
    let button = delete_btn.item(i);
    button.addEventListener('click', function (event) {
        button.parentElement.parentElement.parentElement.parentElement.remove();
        // console.log(document.getElementsByClassName("cart-row"))
        updateCart();


    })

}

function updateCart() {
    let cart_items = document.getElementsByClassName("cart-items")[0];
    let cart_rows = cart_items.getElementsByClassName("cart-row");

    let total = 0;
    // console.log(total)
    for (let i = 0; i < cart_rows.length; i++) {
        let cart_row = cart_rows[i];

        let price_item = cart_row.getElementsByClassName("cart-price")[0].getElementsByClassName("cart-price-content")[0];
        let quantity_item = cart_row.getElementsByClassName("cart-quantity-input")[0];
        // console.log(quantity_item)
        let price = parseInt(price_item.innerText);
        // console.log(total)
        let quantity = parseInt(quantity_item.value);
       // console.log(price_item)
       //  console.log(quantity_item)

        total = total + (price * quantity);
        // console.log(total)
    }
    document.getElementById("product-price-total-value").innerText= total + 'đ';

}

