import { submitForm } from "../Form/Submit.js"

const selectedPage = document.getElementById("Page")
const pager = document.getElementById("booksPager")

pager.onclick = (e) =>
{  
    selectedPage.value = e.target.innerText
    submitForm()
}