
    function setupDeleteFunctionality(buttonClass, yesButtonClass, urlPrefix) {
        const deleteButtons = document.querySelectorAll(buttonClass);
        const yesButton = document.querySelector(yesButtonClass);
        let deleteId = null;

        deleteButtons.forEach(button => {
            button.addEventListener('click', function () {
                deleteId = this.getAttribute('data-id');
                console.log(deleteId);
            });
        });

        if (yesButton) {
            yesButton.addEventListener('click', function () {
                if (deleteId) {
                    fetch(`${urlPrefix}/delete/${deleteId}`, {
                        method: 'DELETE'
                       
                    })
                        .then(response => {
                            if (response.ok) {
                                location.reload();
                            } else {
                                alert(`An error occurred while deleting the ${buttonClass.slice(1)}.`);
                            }
                        })
                        .catch(error => console.error('Error:', error));
                }
            });
        } else {
            console.warn(`No element found for ${yesButtonClass}`);
        }


    }
 

    setupDeleteFunctionality('.delete-btn-about', '.yes-btn-about', '/admin/about');
    setupDeleteFunctionality('.delete-btn-banner', '.yes-btn-banner', '/admin/banner');
    setupDeleteFunctionality('.delete-btn-category', '.yes-btn-category', '/admin/category');
    setupDeleteFunctionality('.delete-btn-product', '.yes-btn-product', '/admin/product');
    setupDeleteFunctionality('.delete-btn-subcategory', '.yes-btn-subcategory', '/admin/subcategory');
    setupDeleteFunctionality('.delete-btn-subsubcategory', '.yes-btn-subsubcategory', '/admin/subsubcategory');
    setupDeleteFunctionality('.delete-btn-contact', '.yes-btn-contact', '/admin/contact');

