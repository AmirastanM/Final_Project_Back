document.addEventListener('DOMContentLoaded', () => {

    document.querySelectorAll('[data-action="view-details"]').forEach(button => {
        button.addEventListener('click', () => {
            const productId = button.getAttribute('data-id');
            fetch(`/Product/GetProductDetails/${productId}`)
                .then(response => response.json())
                .then(data => {
                    document.getElementById('modal-content').innerHTML = `
                        <h5>${data.name}</h5>
                        <p>${data.description}</p>
                        <p><img src="/assets/images/${data.mainImage}" alt="${data.name}" style="width: 100px;"> </p>
                        <p>Price: $${data.price.toFixed(2)}</p>
                        <p>Available Quantity: ${data.availableQuantity}</p>
                    `;
                    document.querySelector('.add-to-cart-btn').setAttribute('data-id', data.id);
                })
                .catch(error => console.error('Error loading product details:', error));
        });
    });

    document.querySelectorAll('.add-to-cart-btn').forEach(button => {
        button.addEventListener('click', () => {
            const productId = button.getAttribute('data-id');
            const productPrice = button.getAttribute('data-price');
            fetch('/Card/AddToCart', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=utf-8'
                },
                body: JSON.stringify({ id: productId, count: 1,  price: productPrice})
            })
                .then(response => response.json())
                .then(data => {
            
                    document.querySelector('.shop-cart sup').textContent = data.basketCount;
                    document.querySelector('.shop-cart a').textContent = `CART ($${data.totalPrice.toFixed(2)})`;

                    if (window.location.pathname === '/Card/Index') {
                        updateCartPage();
                    }
                })
                .catch(error => console.error('Error adding to cart:', error));
        });
    });


    let cartTable = document.getElementById('cart-table');
    let cartButtons = cartTable.querySelectorAll('button')

    cartButtons.forEach(button => {
     
        button.addEventListener('click', event => {

            let iconArea = event.target.closest('tr')
            let input = iconArea.querySelector('input')
            let count = input.value
            let buttonIcon = event.target.closest('button')

           
            

            if (buttonIcon.classList.contains('btn-plus')) {
                count++;
                input.value = count;
                const productId = buttonIcon.getAttribute('data-id');
                updateProductQuantity(productId, 1);
               
            } else if (buttonIcon.classList.contains('btn-minus') & count > 1) {
                count--;
                input.value = count;
                const productId = buttonIcon.getAttribute('data-id');
                updateProductQuantity(productId, -1);
             
            } else if (buttonIcon.classList.contains('btn-remove')) {

                const productId = buttonIcon.getAttribute('data-id');

                deleteProductFromBasket(productId);
                iconArea.remove();
             
            }
        });
    })
   

    function updateProductQuantity(productId, quantityChange) {
        fetch('/Card/UpdateProductQuantity', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            },
            body: JSON.stringify({ id: productId, count: quantityChange })
        })
            .then(response => response.json())
            .then(data => {
          
                if (window.location.pathname === '/Card/Index') {
                    updateCartPage();
                }

                document.querySelector('.shop-cart sup').textContent = data.basketCount;
                document.querySelector('.shop-cart a').textContent = `CART ($${data.totalPrice.toFixed(2)})`;
            })
            .catch(error => console.error('Error updating product quantity:', error));
    }

    function deleteProductFromBasket(productId) {
        fetch('/Card/DeleteProductFromBasket', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            },
            body: JSON.stringify({ id: productId })
        })
            .then(response => response.json())
            .then(data => {
         
                if (window.location.pathname === '/Card/Index') {
                    updateCartPage();
                }

                document.querySelector('.shop-cart sup').textContent = data.basketCount;
                document.querySelector('.shop-cart a').textContent = `CART ($${data.totalPrice.toFixed(2)})`;
            })
            .catch(error => console.error('Error deleting product from basket:', error));
    }

    function updateCartPage() {
        fetch('/Card/Index')
            .then(response => response.json())
            .then(data => {
          
                const tbody = document.querySelector('table tbody');
                tbody.innerHTML = '';
                data.products.forEach(product => {
                    tbody.innerHTML += `
                        <tr>
                            <td class="align-middle">
                                <img src="/assets/images/${product.mainImage}" alt="${product.name}" style="width: 50px;"> ${product.name}
                            </td>
                            <td class="align-middle">$${product.price.toFixed(2)}</td>
                            <td class="align-middle">
                                <div class="input-group quantity mx-auto" style="width: 100px;">
                                    <div class="input-group-btn">
                                        <button class="btn btn-sm btn-primary btn-minus" data-id="${product.id}">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                    </div>
                                    <input type="text" class="form-control form-control-sm bg-secondary border-0 text-center" value="${product.count}">
                                    <div class="input-group-btn">
                                        <button class="btn btn-sm btn-primary btn-plus" data-id="${product.id}">
                                            <i class="fa fa-plus"></i>
                                        </button>
                                    </div>
                                </div>
                            </td>
                            <td class="align-middle">$${(product.price * product.count).toFixed(2)}</td>
                            <td class="align-middle">
                                <button class="btn btn-sm btn-danger btn-remove" data-id="${product.id}">
                                    <i class="fa fa-times"></i>
                                </button>
                            </td>
                        </tr>
                    `;
                });

        
                document.querySelector('.cart-summary .total-price').textContent = `$${data.totalPrice.toFixed(2)}`;
                document.querySelector('.cart-summary .total-count').textContent = data.totalCount;
            })
            .catch(error => console.error('Error updating cart page:', error));
    }
});
