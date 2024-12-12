const adsImages = document.getElementById("adsImages").querySelectorAll("li")
const adsDots = document.getElementById("adsDots")

var adsActiveId = 0

 //Onclick event on dots (if you want)  
//adsDots.addEventListener("click", (e) => {
//    if (e.target.localName == "i") {
//        const id = +e.target.parentElement.dataset.dot
//        if (adsActiveId !== id) {
//            adsChangeTime = 5000
//            clicked = true
//            changeAdsImage(id)
//            changeAdsDot(id)  
//            adsActiveId = id
//        }
//    }
//})

const adsAutoSlide = setInterval(() => {
    const nextAdsId = adsActiveId < 2 ? adsActiveId + 1 : 0
    changeAdsImage(nextAdsId)
    changeAdsDot(nextAdsId)
    adsActiveId = nextAdsId
}, 3000)

function changeAdsImage(imageId) {
    const previousImage = adsImages[adsActiveId]

    previousImage.classList.add("ads-image")
    previousImage.classList.remove("active-ads-image")

    const currentImage = adsImages[imageId]

    currentImage.classList.add("active-ads-image")
    currentImage.classList.remove("ads-image")
}

function changeAdsDot(dotId) {
    const previousDot = adsDots.querySelectorAll("i")[adsActiveId]

    previousDot.classList.add("fa-regular")
    previousDot.classList.remove("fa-solid")

    const currentDot = adsDots.querySelectorAll("i")[dotId]

    currentDot.classList.add("fa-solid")
    currentDot.classList.remove("fa-regular")
}