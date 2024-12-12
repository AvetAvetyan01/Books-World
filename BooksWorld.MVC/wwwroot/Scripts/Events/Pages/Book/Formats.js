const formatsList = document.getElementById("formatsList")
const formats = formatsList.querySelectorAll("button")
const infoTable = document.getElementById("infoTable")
const infoTableRows = () => infoTable.querySelectorAll("tr")

let activeFormatIndex;

formatsList.onclick = (e) => {
    const format = e.target.closest("button")

    if (format != null) {
        infoTableRows().forEach(row => row.remove())
        changeFormat(format.dataset.index)
        
        if (format.dataset.year != null)        infoTable.append(tableRow("Year", format.dataset.year))
        if (format.dataset.type != null)        infoTable.append(tableRow("Format", format.dataset.type))
        if (format.dataset.duration != null)    infoTable.append(tableRow("Duration", format.dataset.duration)) 
        if (format.dataset.language != null)    infoTable.append(tableRow("Language", format.dataset.language)) 
        if (format.dataset.publisher != null)   infoTable.append(tableRow("Publisher", format.dataset.publisher))
        if (format.dataset.pages_count != null) infoTable.append(tableRow("Pages count", format.dataset.pages_count))
    }
}

function changeFormat(newFormatIndex) {
    if (activeFormatIndex != null)
        formats[activeFormatIndex].classList.remove("active")
    
    formats[+newFormatIndex].classList.add("active")
    activeFormatIndex = +newFormatIndex
}

function tableRow(title, value) {   
    const tableRow = document.createElement("tr")
    const propertyTitle = document.createElement("td")
    const propertyValue = document.createElement("td")

    propertyTitle.innerText = title
    propertyValue.innerText = value

    tableRow.append(propertyTitle)
    tableRow.append(propertyValue)

    return tableRow
}

formats[0]?.click()