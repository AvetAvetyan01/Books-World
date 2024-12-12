export function valueInput(name, space)
{
    let valueInput = document.getElementById(name)

    if (valueInput) return valueInput

    valueInput = document.createElement("input")
    valueInput.id = name        
    valueInput.name = name
    valueInput.type = "hidden"
    space.append(valueInput)

    return valueInput
}