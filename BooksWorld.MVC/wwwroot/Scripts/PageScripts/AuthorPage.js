import { InsertBook } from "../Constructors/BookCard"
import { fetchData } from "../DataProvider"

const authorId = document.getElementById("authorId").value

const url = "https://localhost:7227/Book/books-collection?Size=15&authorId=" + authorId
console.log(url)

const authorsBooks = document.getElementById("authorsBooks")
const authorsBooksContainer = document.getElementById("authorsBooksContainer")
const authorsBooksData = await fetchData(url)

console.log(authorsBooksData)

if (authorsBooksData.length > 0)
{
    authorsBooksContainer.style.display = "grid"
    InsertBook(authorsBooksData, authorsBooks)
}