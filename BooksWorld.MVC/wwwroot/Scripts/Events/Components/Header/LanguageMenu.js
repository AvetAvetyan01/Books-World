import { dropdownMenu } from "../DropdownMenu/DropdownMenu.js"

//const languageValue = document.getElementById("languageValue")
const languages = document.getElementById("languages")
const languageTitle = document.getElementById("languageTitle")
const menuButton = document.getElementById("languageMenuButton")

dropdownMenu(languages, languageTitle, menuButton, "languageValue")