// VEGAS
// Background SLideShow
// Codepen Demo
// http://vegas.jatysalvat.com



$('.kenbarn').vegas({
  overlay: true,
  transition: 'fade', 
  transitionDuration: 4000,
  delay: 10000,
  animation: 'random',
  animationDuration: 20000,
  slides: [
    { src: 'images/construct/kenburn-1.jpg' },
    { src: 'images/construct/kenburn-2.jpg' },
    { src: 'images/construct/kenburn-3.jpg' },
    { src: 'images/construct/kenburn-4.jpg' }
  ]
});