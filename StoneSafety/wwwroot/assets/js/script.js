document.addEventListener("DOMContentLoaded", function () {
    // Burger
    $('.header__burger,.header__bg').click(function () {
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
        } else {
            $('.header').removeClass("transition");
        }
    });



    // Slider
    $('.slider-for').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: true,
        fade: false,
        asNavFor: '.slider-nav',
        prevArrow: '<button type="button" class="slick-prev"><i class="fas fa-arrow-left"></i></button>',
        nextArrow: '<button type="button" class="slick-next"><i class="fas fa-arrow-right"></i></button>',
    });

    $('.slider-nav').on('init', function () {
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


    var myCarousel = document.querySelector('#product-carousel');
    var carousel = new bootstrap.Carousel(myCarousel, {
        interval: 3000,
        wrap: true
    })
})