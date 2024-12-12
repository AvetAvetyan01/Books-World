import { verticalMenu } from "../../Components/Form/VerticalMenu.js"
import { checkboxMenu } from "../../Components/Form/CheckboxMenu.js"
import { dropdownMenu } from "../../Components/DropdownMenu/DropdownMenu.js"
import { rangeMenu } from "../../Components/Form/RangeMenu.js"
import { toggleSwitch } from "../../Components/Form/ToggleSwitch.js"

// genres
const genresSmallList = document.getElementById("genresSmallList")
const genresLargeList = document.getElementById("genresLargeList")
const genresListButton = document.getElementById("genresListButton")

verticalMenu(
    genresListButton,
    genresSmallList,
    genresLargeList,
    "GenreId"
)

toggleSwitch("Discount")
toggleSwitch("HighRating")

rangeMenu("MinYear","MinYear")
rangeMenu("MaxYear", "MaxYear")

rangeMenu("MinPagesCount", "MinPagesCount")
rangeMenu("MaxPagesCount", "MaxPagesCount")

rangeMenu("MinPrice", "MinPrice")
rangeMenu("MaxPrice", "MaxPrice")

// checkboxes
const formatCheckboxes = document.getElementById("formatsList")
const languageCheckboxes = document.getElementById("languagesList")

checkboxMenu(formatCheckboxes, "Formats")
checkboxMenu(languageCheckboxes, "Languages")

// sorting menu
const sortingTypes = document.getElementById("sortingTypes")
const sortingTitle = document.getElementById("sortingTitle")
const sortingMenuButton = document.getElementById("sortingMenuButton")

dropdownMenu(sortingTypes, sortingTitle, sortingMenuButton, "SortingType")