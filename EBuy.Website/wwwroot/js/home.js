const addToCart = function () {
    let productId = (Number)(this.getAttribute('data-id'));
    let amount = (Number)(this.parentNode.querySelector(".amount").value);
    let totalPrice = (Number)(this.parentNode.querySelector(".price").getAttribute('data-price')) * amount;

    const obj = {};
    obj['productId'] = productId;
    obj['amount'] = amount;
    obj['totalPrice'] = totalPrice;

    let result = JSON.stringify(obj);
    console.log(result);

    $.ajax({
        type: 'POST',
        url: '/Home/AddToCart/',
        contentType: 'application/json',
        data: result,
        success: function (result) {
            console.log('Success ');
        },
        error: function () {

            console.log('Failed ');
        }
    });

};

let buttons = document.querySelectorAll('.cart');

for (let i = 0; i < buttons.length; i++) {
    buttons[i].addEventListener('click', addToCart);
}