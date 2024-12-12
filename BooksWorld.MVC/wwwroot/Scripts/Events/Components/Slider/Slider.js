const slides = document.getElementById("slides")?.querySelectorAll("li")
const slideDots = document.getElementById("sliderDots")

var activeSlideId = 0

slideDots?.addEventListener("click", (e) => {
    const slideId = e.target.dataset.slideid

    if (checkSlideId(slideId))
        changeSlide(+slideId)
})

function checkSlideId(slideId) {
    return !Number.isNaN(+slideId) && +slideId != activeSlideId
}

function changeSlide(newSlideId) {
    changeSlideContent(newSlideId)
    changeSlideDot(newSlideId)
    activeSlideId = newSlideId;
}

function changeSlideContent(newSlideId) {
    slides[activeSlideId].classList.add("inactive-slide")
    slides[activeSlideId].classList.remove("active-slide")

    slides[newSlideId].classList.add("active-slide")
    slides[newSlideId].classList.remove("inactive-slide")
}
function changeSlideDot(newSlideId) {
    const previousSlideDot = slideDots.querySelectorAll("li")[activeSlideId]
    previousSlideDot.classList.add("inactive-slide-dot")
    previousSlideDot.classList.remove("active-slide-dot")

    const currentSlideDot = slideDots.querySelectorAll("li")[newSlideId]
    currentSlideDot.classList.add("active-slide-dot")
    currentSlideDot.classList.remove("inactive-slide-dot")
}