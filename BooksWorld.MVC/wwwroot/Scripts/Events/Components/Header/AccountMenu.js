const accountMenuButton = document.getElementById("accountMenuButton")
const accountMenuContainer = document.getElementById("accountMenuContainer")
const toggleClass = "inactive-account-menu"

const accountMenuToggle = () => accountMenuContainer.classList.toggle(toggleClass)

accountMenuButton?.addEventListener("click", () => accountMenuToggle())