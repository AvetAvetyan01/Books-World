import { fetchData }    from "./DataProvider.js"
import { InsertHeaderGenre }  from "./Constructors/HeaderGenre.js"

const genreData = await fetchData("https://localhost:7227/Genre/all")
const genres = document.getElementById("categoryList")

InsertHeaderGenre(genreData, genres, 21)









