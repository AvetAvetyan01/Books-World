import { submitForm } from "./Submit.js"
import { valueInput } from "./ValueInput.js"

export function checkboxMenu(checkboxes, valueInputName)
{
    checkboxes.querySelectorAll("input").forEach(checkbox =>
        checkbox.onclick = () =>
        {
            let checkboxesValueInput = valueInput(valueInputName, checkboxes.closest("form"))

            checkboxesValueInput.value = setValue(checkboxesValueInput.value, checkbox.value)

            if (["", "None", 0, null, undefined].includes(checkboxesValueInput.value)) checkboxesValueInput.remove()

            submitForm()
        })    
}

export function fillCheckboxes(data, labels, valueInputName)
{
    const checkboxValueInput = valueInput(valueInputName, labels[0].closest("form"))

    data.split(", ").map(datum => {
        labels.forEach(label => {
            if (label.innerText.trim() == datum)
            {
                const checkbox = label.firstElementChild

                checkbox.checked = true
                checkboxValueInput.value = setValue(checkboxValueInput.value, datum)
            }
        })
    })
}

function setValue(str, value)
{
    let splitedValues = str.length ? str.split(", ") : []

    splitedValues.includes(value)
        ? splitedValues.splice(splitedValues.indexOf(value), 1)
        : splitedValues.push(value)

    return splitedValues.join(", ")
}
