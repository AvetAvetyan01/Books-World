import { fetchData } from "../DataProvider.js"
import { InsertBook } from "../Constructors/BookCard.js"

const recomendedBooksData = await fetchData("https://localhost:7227/Book/books-collection?Page=3&ByDescending=false&SortingType=Rating&Formats=Electronic&Size=15")
const recomendedBooks = document.getElementById("recomendedBooks")

InsertBook(recomendedBooksData, recomendedBooks)