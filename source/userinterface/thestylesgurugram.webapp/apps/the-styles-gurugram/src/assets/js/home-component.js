 /*=====================
     13. slick slider
     ==========================*/
     $('.slide-1').slick({
        // autoplay: true,
        // autoplaySpeed: 5000
    });

    $('.slide-2').slick({
        infinite: true,
        slidesToShow: 2,
        slidesToScroll: 2,
        responsive: [{
            breakpoint: 991,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1
            }
        }]
    });

    $('.slide-3').slick({
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 5000,
        responsive: [{
                breakpoint: 1200,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 767,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
        ]
    });

    $('.team-4').slick({
        infinite: true,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 3000,
        responsive: [{
                breakpoint: 1200,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3
                }
            },
            {
                breakpoint: 991,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 586,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1
                }
            }
        ]
    });

    $('.slide-4').slick({
        infinite: false,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 5000,
        responsive: [{
                breakpoint: 1200,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3
                }
            },
            {
                breakpoint: 991,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 586,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
        ]
    });

    $('.product-4').slick({
        infinite: true,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 4,
        autoplay: true,
        autoplaySpeed: 3000,
        responsive: [{
                breakpoint: 1200,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3
                }
            },
            {
                breakpoint: 991,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            }
        ]
    });

    $('.tools-product-4').slick({
        infinite: true,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 4,
        autoplay: true,
        autoplaySpeed: 5000,
        responsive: [{
                breakpoint: 1200,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3
                }
            },
            {
                breakpoint: 767,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            }
        ]
    });

    $('.product_4').slick({
        infinite: true,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 4,
        autoplay: true,
        autoplaySpeed: 5000,
        responsive: [{
                breakpoint: 1430,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3
                }
            },
            {
                breakpoint: 1200,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 991,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            }
        ]
    });

    $('.product-3').slick({
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        autoplay: true,
        autoplaySpeed: 5000,
        responsive: [{
            breakpoint: 991,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 2
            }
        }]
    });

    $('.slide-5').slick({
        dots: false,
        infinite: true,
        speed: 300,
        slidesToShow: 5,
        slidesToScroll: 5,
        responsive: [{
                breakpoint: 1367,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 4
                }
            },
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3
                }
            }
        ]
    });

    $('.slide-6').slick({
        dots: false,
        infinite: true,
        speed: 300,
        slidesToShow: 6,
        slidesToScroll: 6,
        responsive: [{
                breakpoint: 1367,
                settings: {
                    slidesToShow: 5,
                    slidesToScroll: 5,
                    infinite: true
                }
            },
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 4,
                    infinite: true
                }
            },
            {
                breakpoint: 767,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            }

        ]
    });

    $('.brand-6').slick({
        dots: false,
        infinite: true,
        speed: 300,
        slidesToShow: 6,
        slidesToScroll: 6,
        responsive: [{
                breakpoint: 1367,
                settings: {
                    slidesToShow: 5,
                    slidesToScroll: 5,
                    infinite: true
                }
            },
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 4,
                    infinite: true
                }
            },
            {
                breakpoint: 767,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 360,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }

        ]
    });

    $('.product-slider-5').slick({
        dots: false,
        infinite: true,
        speed: 300,
        slidesToShow: 5,
        slidesToScroll: 5,
        responsive: [{
                breakpoint: 1200,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3
                }
            },
            {
                breakpoint: 991,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            }
        ]
    });

    $('.product-5').slick({
        dots: false,
        infinite: true,
        speed: 300,
        slidesToShow: 5,
        slidesToScroll: 5,
        responsive: [{
                breakpoint: 1367,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 4
                }
            },
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            }
        ]
    });

    $('.slide-7').slick({
        dots: false,
        infinite: true,
        speed: 300,
        slidesToShow: 7,
        slidesToScroll: 7,
        responsive: [{
                breakpoint: 1367,
                settings: {
                    slidesToShow: 6,
                    slidesToScroll: 6
                }
            },
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 5,
                    slidesToScroll: 5,
                    infinite: true
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 4
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3
                }
            }
            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
        ]
    });

    $('.slide-8').slick({
        infinite: true,
        slidesToShow: 8,
        slidesToScroll: 8,
        responsive: [

            {
                breakpoint: 1200,
                settings: {
                    slidesToShow: 6,
                    slidesToScroll: 6
                }
            }
        ]
    });

    $('.center').slick({
        centerMode: true,
        centerPadding: '60px',
        slidesToShow: 3,
        responsive: [{
                breakpoint: 768,
                settings: {
                    arrows: false,
                    centerMode: true,
                    centerPadding: '40px',
                    slidesToShow: 3
                }
            },
            {
                breakpoint: 480,
                settings: {
                    arrows: false,
                    centerMode: true,
                    centerPadding: '40px',
                    slidesToShow: 1
                }
            }
        ]
    });

    $('.product-slick').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: true,
        fade: true,
        asNavFor: '.slider-nav'
    });

    $('.slider-nav').slick({
        vertical: false,
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.product-slick',
        arrows: false,
        dots: false,
        focusOnSelect: true
    });

    $('.product-right-slick').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: true,
        fade: true,
        asNavFor: '.slider-right-nav'
    });
    if ($(window).width() > 575) {
        $('.slider-right-nav').slick({
            vertical: true,
            verticalSwiping: true,
            slidesToShow: 3,
            slidesToScroll: 1,
            asNavFor: '.product-right-slick',
            arrows: false,
            infinite: true,
            dots: false,
            centerMode: false,
            focusOnSelect: true
        });
    } else {
        $('.slider-right-nav').slick({
            vertical: false,
            verticalSwiping: false,
            slidesToShow: 3,
            slidesToScroll: 1,
            asNavFor: '.product-right-slick',
            arrows: false,
            infinite: true,
            centerMode: false,
            dots: false,
            focusOnSelect: true,
            responsive: [{
                breakpoint: 576,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 1
                }
            }]
        });
    }