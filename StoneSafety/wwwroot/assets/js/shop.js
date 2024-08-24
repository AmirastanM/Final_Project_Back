
function handleToggle(event) {
    event.preventDefault();

    const toggleElement = event.target;
    const submenu = toggleElement.nextElementSibling;

    if (submenu && submenu.tagName === 'UL') {
        submenu.style.display = submenu.style.display === 'none' ? 'block' : 'none';
        const icon = toggleElement.querySelector('.toggle-icon');
        if (icon) {
            icon.textContent = icon.textContent === '+' ? '-' : '+';
        }
    }
}



    document.querySelectorAll('.category-toggle, .subcategory-toggle').forEach(link => {
        link.addEventListener('click', handleToggle);
    });

    document.addEventListener('click', function (event) {
        if (event.target.matches('.category-toggle, .subcategory-toggle, .product-link')) {
            event.preventDefault();

            const id = event.target.getAttribute('data-id');
            const type = event.target.getAttribute('data-type');
           

            if (!type) {
                console.error('Type is not specified.');
                return;
            }

            
            fetchProducts(id, type);
        }
    });


    function fetchProducts(id, type) {
    

        fetch(`/Shop/GetProductsBy${type}?id=${id}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                return response.json();
            })
            .then(data => {               
                const productContainer = document.getElementById('product-container');
                productContainer.innerHTML = data.map(product => `
                        <div class="col-lg-4 col-md-6 col-sm-12 mb-4">
                            <div class="product-item bg-light">
                                <div class="product-img position-relative overflow-hidden">
                                    <img class="img-fluid w-100" src="/assets/images/${product.image}" alt="${product.name}">
                                    <div class="product-action">
                                        <a class="btn btn-outline-dark btn-square" href="#" data-bs-toggle="modal" data-bs-target="#productModal" data-id="${product.id}">
                                            <i data-id="${product.id}" class="fa fa-search  btn-square"></i>
                                        </a>
                                    </div>
                                </div>
                                <div class="text-center py-4">
                                    <a class="h6 text-decoration-none text-truncate" href="#">${product.name}</a>
                                    <div class="d-flex flex-column align-items-center justify-content-center mt-2">
                                        <h3>${product.productCode}</h3>
                                        <h5>$${product.price}</h5>
                                    </div>
                                     <div class="cart align-items-center">
                                         <input type="hidden" class="form-control" data-id="${product.id}" value="1">
                                         <button class="btn btn-danger add-to-cart-btn" data-id="${product.id}" data-price="${product.price}">Add to Cart</button>
                                     </div>
                                </div>
                            </div>
                        </div>
                    `).join('');
            })
            .catch(error => console.error('Error fetching products:', error));
    }

    const sortButtons = document.querySelectorAll('#sort-menu .dropdown-item');
    sortButtons.forEach(button => {
        button.addEventListener('click', function () {
          
            const sortOrder = this.getAttribute('data-sort');          
            window.location.href = `/ShopController/Index?sortOrder=${sortOrder}`;
        });
    });


