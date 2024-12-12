import { submitForm } from "./Submit.js"
import { valueInput } from "./ValueInput.js"

export function verticalMenu(button, smallMenu, largeMenu, inputValueName)
{
    // << dataset.genreId >> da koptaguyn sxala 
    // Petqa metid@ drsic ban chimana
    smallMenu.onclick = (e) => select(inputValueName, e.target.dataset.genreid, button.closest("form"))
    largeMenu.onclick = (e) => select(inputValueName, e.target.dataset.genreid, button.closest("form"))

    button.onclick = (e) =>
    {
        let string = e.target.querySelector("p")
        let icon = e.target.querySelector("i")

        string.innerText = string.innerText == "Show all" ? "Hide the rest" : "Show all"

        icon.classList.toggle("fa-chevron-down")
        icon.classList.toggle("fa-chevron-up")  

        smallMenu.classList.toggle("active")
        largeMenu.classList.toggle("active")    
    }
}               

function select(name, value, space)
{
    let menuValueInput = valueInput(name, space)

    menuValueInput.value = value

    submitForm()
}