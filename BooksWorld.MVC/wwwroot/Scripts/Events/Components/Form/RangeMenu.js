import { submitForm } from "./Submit.js"

export function rangeMenu(id, name)
{
    const input = document.getElementById(id)

    input.onkeyup = (e) =>
    {
        input.value.length
         ? input.name = name 
         : input.removeAttribute("name")        

        if (e.key == "Enter")
            submitForm()
    }
}
export function fillRangeInput(name, value)
{
    const input = document.getElementById(name)

    input.name = name
    input.value = value
}