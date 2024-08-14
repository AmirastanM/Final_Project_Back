// Burger
$(document).ready(function () {
  $('.header__burger,.header__bg').click(function (event) {
    $('.header__burger,.header__menu,.header__bg').toggleClass('active');
    $('body').toggleClass('lock');
  });

  $(".mobile__acc").dcAccordion({
    speed: 300
  });

  $(window).scroll(function () {
    var $heightScrolled = $(window).scrollTop();
    var $defaultHeight = 0;

    if ($heightScrolled > $defaultHeight) {
      $('.header').addClass("transition");
    }
    else {
      $('.header').removeClass("transition");
    }
  });
});

mybutton = document.getElementById("myBtn");


window.onscroll = function () { scrollFunction() };

function scrollFunction() {
  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    mybutton.style.display = "block";
  } else {
    mybutton.style.display = "none";
  }
}


function topFunction() {
  document.body.scrollTop = 0; 
  document.documentElement.scrollTop = 0; 
}

//Slider


$('.slider-for').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  arrows: true,
  fade: false,
  asNavFor: '.slider-nav',
  prevArrow: '<button type="button" class="slick-prev"><i class="fas fa-arrow-left"></i></button>',
  nextArrow: '<button type="button" class="slick-next"><i class="fas fa-arrow-right"></i></button>',
});

$('.slider-nav').on('init', function (event, slick) {
  $('.slider-nav .slick-slide.slick-current').addClass('is-active');
})
  .slick({
    asNavFor: '.slider-for',
    slidesToShow: 3,
    slidesToScroll: 1,
    dots: false,
    focusOnSelect: true,
    infinite: true,
    arrows: false,
  });


$('.slider-for').on('afterChange', function (event, slick, currentSlide) {
  $('.slider-nav').slick('slickGoTo', currentSlide);
  var currrentNavSlideElem = '.slider-nav .slick-slide[data-slick-index="' + currentSlide + '"]';
  $('.slider-nav .slick-slide.is-active').removeClass('is-active');
  $(currrentNavSlideElem).addClass('is-active');
});

$('.slider-nav').on('click', '.slick-slide', function (event) {
  event.preventDefault();
  var goToSingleSlide = $(this).data('slick-index');

  $('.slider-for').slick('slickGoTo', goToSingleSlide);
});




document.addEventListener("DOMContentLoaded", function () {
  function toggleVisibility(element, toggleIcon) {
    if (element.style.display === "none" || element.style.display === "") {
      element.style.display = "block";
      toggleIcon.textContent = '-'; 
    } else {
      element.style.display = "none";
      toggleIcon.textContent = '+'; 
    }
  }

  const categoryToggles = document.querySelectorAll('.category-toggle');
  const subcategoryToggles = document.querySelectorAll('.subcategory-toggle');

  categoryToggles.forEach(function (toggle) {
    toggle.addEventListener('click', function (e) {
      e.preventDefault();
      const subcategoryList = this.parentElement.querySelector('.sidebar_boots_subcategories');
      const toggleIcon = this.nextElementSibling;
      toggleVisibility(subcategoryList, toggleIcon);
    });
  });

  subcategoryToggles.forEach(function (toggle) {
    toggle.addEventListener('click', function (e) {
      e.preventDefault();
      const subSubcategoryList = this.parentElement.querySelector('.sidebar_subcategories');
      const toggleIcon = this.nextElementSibling;
      toggleVisibility(subSubcategoryList, toggleIcon);
    });
  });
});

var myCarousel = document.querySelector('#product-carousel');
var carousel = new bootstrap.Carousel(myCarousel, {
  interval: 3000, 
  wrap: true 
});

document.querySelectorAll('[data-action="view-details"]').forEach(button => {
  button.addEventListener('click', function(event) {
      event.preventDefault();

      // Получение информации о продукте из атрибутов data
      var productId = this.getAttribute('data-product-id');
      var productElement = document.querySelector(`[data-product-id="${productId}"]`);
      var productName = productElement.getAttribute('data-product-name');
      var productPrice = productElement.getAttribute('data-product-price');
      var productImageSrc = productElement.querySelector('img').getAttribute('src');

      // Заполнение модального окна
      var modalContent = `
          <img src="${productImageSrc}" class="img-fluid mb-3" alt="${productName}">
          <h5>${productName}</h5>
          <p>Price: $${productPrice}</p>
      `;

      document.getElementById('modalProductContent').innerHTML = modalContent;

      // Открытие модального окна
      var productModal = new bootstrap.Modal(document.getElementById('productModal'));
      productModal.show();
  });
});