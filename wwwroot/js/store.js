

if (document.readyState == 'loading') {
    document.addEventListener('DOMContentLoaded', ready)
} else {
    ready()
}

function ready() {
    initProducts();
    initCart();
    var removeCartItemButtons = document.getElementsByClassName('btn-danger')
    for (var i = 0; i < removeCartItemButtons.length; i++) {
        var button = removeCartItemButtons[i]
        button.addEventListener('click', removeCartItem)
    }

    var quantityInputs = document.getElementsByClassName('cart-quantity-input')
    for (var i = 0; i < quantityInputs.length; i++) {
        var input = quantityInputs[i]
        input.addEventListener('change', quantityChanged)
    }
}

function initCart() {
    var cart = localStorage.getItem('cart');
    if (!cart) {
        localStorage.setItem('cart', JSON.stringify([]));
    }
}

function addItemToCart(productId) {
    var cart = JSON.parse(localStorage.getItem('cart'));
    cart.push(productId);
    localStorage.setItem('cart', JSON.stringify(cart));
}

function updateCartTotal() {
    var cartItemContainer = document.getElementsByClassName('cart-items')[0]
    var cartRows = cartItemContainer.getElementsByClassName('cart-row')
    var total = 0
    for (var i = 0; i < cartRows.length; i++) {
        var cartRow = cartRows[i]
        var priceElement = cartRow.getElementsByClassName('cart-price')[0]
        var quantityElement = cartRow.getElementsByClassName('cart-quantity-input')[0]
        var price = parseFloat(priceElement.innerText.replace('$', ''))
        var quantity = quantityElement.value
        total = total + (price * quantity)
    }
    total = Math.round(total * 100) / 100
    document.getElementsByClassName('cart-total-price')[0].innerText = '$' + total
}

function initProducts() {
    var products = [{
        id: '1',
        title: 'Guitar 1',
        imageSrc: '~/img/Products/Guitars/Music Man - Sabre Cobra Burst.jpg',
        price: 300
    }, {
        id: '2',
        title: 'Guitar 2',
        imageSrc: '~/img/Products/Guitars/Music Man - Sabre Cobra Burst.jpg',
        price: 400
    }];
    localStorage.setItem('products', JSON.stringify(products));
}


//append
//function addToCartClicked(event) {
//    var button = event.target
//    var shopItem = button.parentElement.parentElement
//    var title = shopItem.getElementsByClassName('shop-item-title')[0].innerText
//    var price = shopItem.getElementsByClassName('shop-item-price')[0].innerText
//    var imageSrc = shopItem.getElementsByClassName('shop-item-image')[0].src
//    addItemToCart(title, price, imageSrc)
//    updateCartTotal()
//}