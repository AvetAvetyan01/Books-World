import { InsertPager } from "../Constructors/Pager.js"
import { InsertBook } from "../Constructors/BookCard.js"
import { fetchData } from "../DataProvider.js"
import { InsertFormGenre } from "../Constructors/FormGenre.js"
import { fillCheckboxes } from "../Events/Components/Form/CheckboxMenu.js"
import { valueInput } from "../Events/Components/Form/ValueInput.js"
import { fillRangeInput } from "../Events/Components/Form/RangeMenu.js"
import { toTickToggleSwitch } from "../Events/Components/Form/ToggleSwitch.js"

const url = window.location.href.replace("7009", "7227")
const pageData = await fetchData(url)

const formData = pageData.request
const booksData = pageData.response

const booksList = document.getElementById("booksList")
const booksPager = document.getElementById("booksPager")

InsertBook(booksData.collection, booksList) 

if (booksData.pagesCount > 1)
    InsertPager(booksPager, booksData.currentPage, booksData.pagesCount)

// Page
const selectedPage = document.getElementById("Page")

selectedPage.value = formData.page

// Genres Menu
const genresTitle = document.getElementById("genreTitle")
const genresSmallList = document.getElementById("genresSmallList")
const genresLargeList = document.getElementById("genresLargeList")

if (formData.genreId)
{
    console.log(formData)
    const genre = await fetchData("https://localhost:7227/Genre/" + formData.genreId)
    genresTitle.innerText = genre.name

    const genresValueInput = valueInput("GenreId", genresTitle.closest("form"))
    genresValueInput.value = genre.id

    if (genre.subgenres.length > 0) {
        InsertFormGenre(genre.subgenres.slice(0, 5), genresSmallList)

        if (genre.subgenres.length > 6) {
            InsertFormGenre(genre.subgenres, genresLargeList)
            genresListButton.classList.remove("inactive-button")
        }
    }
}
else
{
    // ժանռներից ստանանք մենակ հիմնայինները (root-երը)
    const rootGenres = await fetchData("https://localhost:7227/Genre/all")
    genresTitle.innerText = "Genres"

    InsertFormGenre(rootGenres.slice(0, 5), genresSmallList)

    if (rootGenres.length > 6) {
        InsertFormGenre(rootGenres, genresLargeList)
        genresListButton.classList.remove("inactive-button")
    }
}

// Toggle-switches
if (formData.discount) toTickToggleSwitch("Discount")
if (formData.highRating) toTickToggleSwitch("HighRating")

// Ranges
if (formData.minYear) fillRangeInput("MinYear", formData.minYear)
if (formData.maxYear) fillRangeInput("MaxYear", formData.minYear)

if (formData.minPagesCount) fillRangeInput("MinPagesCount", formData.minPagesCount)
if (formData.maxPagesCount) fillRangeInput("MaxPagesCount", formData.maxPagesCount)

if (formData.minPrice) fillRangeInput("MinPrice", formData.minPrice)
if (formData.maxPrice) fillRangeInput("MaxPrice", formData.maxPrice)

// Formats and Languages
if (formData.formats != "None" && formData.formats)
{
    const formatLabels = document.getElementById("formatsList").querySelectorAll("label")

    fillCheckboxes(formData.formats, formatLabels, "Formats")
}

if (formData.languages)
{
    const languageLabels = document.getElementById("languagesList").querySelectorAll("label")

    fillCheckboxes(formData.languages, languageLabels, "Languages")
}

// Sorting Menu
const sortingType = document.getElementById("SortingType")
const sortingTypeTitle = document.getElementById("sortingTitle")
const sortingTypes = document.getElementById("sortingTypes")

sortingTypes.querySelectorAll("li").forEach(type =>
{
    if (type.innerText == formData.sortingType)
    {
        sortingTypeTitle.innerText = formData.sortingType
        sortingType.value = formData.sortingType
        type.classList.add("active")
    }
})