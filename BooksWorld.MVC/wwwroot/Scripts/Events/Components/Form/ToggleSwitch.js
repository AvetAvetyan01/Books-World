import { submitForm } from "./Submit.js"

export function toggleSwitch(id)
{
    const toggleSwitch = document.getElementById(id)    

    toggleSwitch.onclick = (e) =>
    {
        e.target.value = e.target.checked ? true : false

        const circle = e.target.closest("li").querySelector("span")

        circle.classList.toggle("active")

        submitForm()
    }
}
export function toTickToggleSwitch(id)
{
    const toggleSwitch = document.getElementById(id)

    toggleSwitch.closest("li").querySelector("span").classList.toggle("active")

    toggleSwitch.checked = true
    toggleSwitch.value = true
}