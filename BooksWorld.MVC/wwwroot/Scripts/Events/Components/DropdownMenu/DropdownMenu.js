import { submitForm } from "../Form/Submit.js"
import { valueInput } from "../Form/ValueInput.js"

export function dropdownMenu(menu, title, button, valueInputName)
{
    menu.querySelectorAll("li").forEach(type =>
    {
        type.onclick = () =>
        {
            const menuValueinput = valueInput(valueInputName)

            menuValueinput.value = type.innerText

            title.innerText = type.innerText
                
            menu.classList.remove("active-menu")

            submitForm()
        }
    })

    button.onclick = () => menu.classList.toggle("active-menu")
}