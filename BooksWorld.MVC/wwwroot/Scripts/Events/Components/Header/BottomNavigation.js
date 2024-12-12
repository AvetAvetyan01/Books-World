const bottomHeaderNav = document.getElementById("bottomHeaderNav")
const bottomHeaderOpenners = document.getElementById("headerMainMenu").querySelectorAll(".accordion-nav")

var activeOpennerItemId = -1;
var isActiveNavbar = false

bottomHeaderOpenners.forEach((navItem) => {
    navItem.addEventListener("mouseenter", () => {
        const navItemId = +navItem.dataset.nav
        if (isActiveNavbar) {
            if (activeOpennerItemId != navItemId) {
                navbarItemsToggle(navItemId)
                activeOpennerItemId = navItemId
            }
        }
        else
        {
            activeOpennerItemId = navItemId
            isActiveNavbar = true
            headerNavbarToggle()
            navbarItemsToggle(-1)
        }
    })
    navItem.addEventListener("mouseleave", (e) => {
        const cursorExitEdge = closestEdge(e, navItem)

        if (cursorExitEdge == "top"
        ||
        cursorExitEdge == "left" && activeOpennerItemId == 0
        ||
        cursorExitEdge == "right" && activeOpennerItemId == 2)
        {
            headerNavbarToggle()
            navbarItemsToggle(-1)
            activeOpennerItemId = -1
            isActiveNavbar = false
        }
    })
})

bottomHeaderNav.addEventListener("mouseleave", () => {
    headerNavbarToggle()
    navbarItemsToggle(-1)
    activeOpennerItemId = -1
    isActiveNavbar = false
})

function navbarItemsToggle(newOpennerId) {
    if (activeOpennerItemId >= 0) bottomHeaderOpenners[activeOpennerItemId].classList.toggle("nav-active-item")
    if (newOpennerId >= 0 &&
        newOpennerId < bottomHeaderOpenners.length &&
        newOpennerId != activeOpennerItemId)
        bottomHeaderOpenners[newOpennerId].classList.toggle("nav-active-item")
}

function headerNavbarToggle() {
    bottomHeaderNav.classList.toggle("hidden-nav")
    bottomHeaderNav.classList.toggle("active-nav")
}

function closestEdge(mouse, elem) {
    const elemBounding = elem.getBoundingClientRect();

    const [elementLeftEdge, elementRightEdge, elementTopEdge, elementBottomEdge] =
          [elemBounding.left, elemBounding.right, elemBounding.top, elemBounding.bottom]

    const [mouseX, mouseY] = [mouse.pageX, mouse.pageY];

    const topEdgeDist = Math.abs(elementTopEdge - mouseY);
    const bottomEdgeDist = Math.abs(elementBottomEdge - mouseY);
    const leftEdgeDist = Math.abs(elementLeftEdge - mouseX);
    const rightEdgeDist = Math.abs(elementRightEdge - mouseX);

    const min = Math.min(topEdgeDist, bottomEdgeDist, leftEdgeDist, rightEdgeDist);

    switch (min) {
        case leftEdgeDist:   return "left";
        case rightEdgeDist:  return "right";
        case topEdgeDist:    return "top";
        case bottomEdgeDist: return "bottom";
    }
}