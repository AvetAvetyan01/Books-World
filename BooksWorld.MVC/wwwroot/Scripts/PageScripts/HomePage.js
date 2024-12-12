import { fetchData }    from "../DataProvider.js"
import { InsertBook }   from "../Constructors/BookCard.js"
import { InsertAuthor } from "../Constructors/Author.js"

const popularAuthorsData = await fetchData("https://localhost:7227/Author/all")
const popularBooksData = await fetchData("https://localhost:7227/Book/books-collection?Size=15&HighRating=true")
const newestBooksData = await fetchData("https://localhost:7227/Book/books-collection?Size=15&MinYear=1976")
const saleBooksData = await fetchData("https://localhost:7227/Book/books-collection?Size=15&Discount=true")

const popularAuthors = document.getElementById("popularAuthors")
const popularBooks = document.getElementById("popularBooks")
const newestBooks = document.getElementById("newestBooks")
const saleBooks = document.getElementById("saleBooks")

InsertAuthor(popularAuthorsData, popularAuthors, 5)
InsertBook(popularBooksData, popularBooks)
InsertBook(newestBooksData, newestBooks)
InsertBook(saleBooksData, saleBooks)