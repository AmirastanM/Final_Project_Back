
document.getElementById('checkout-form').addEventListener('submit', function (event) {
    event.preventDefault();


    let formData = new FormData(this);
    let name = document.getElementById('name')
    let surname = document.getElementById('surname')
    let email = document.getElementById('email')
    let phone = document.getElementById('phone')
    formData.append('name', name.value)
    formData.append('surname', surname.value)
    formData.append('email', email.value)
    formData.append('phone', phone.value)


    fetch(this.action, {
        method: 'POST',
        body: formData


    })
        .then(response => {
            if (response.ok) {
       
                return response.text(); 
            } else {
                throw new Error('Network response was not ok.');
            }
        })
        .then(data => {
     
            window.location.href = '/'
        })
        .catch(error => {
      
            console.error('There was a problem with the fetch operation:', error);
        });
});
