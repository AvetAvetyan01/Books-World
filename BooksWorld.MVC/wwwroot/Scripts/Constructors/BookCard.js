export function InsertBook(data, space)
{
    data.map(book => {
        // Containers
        const card = document.createElement("li")
        const topIconsContainer = document.createElement("div")
        const titleContainer = document.createElement("div")
        const ratingContainer = document.createElement("div")
        const ratingAndFormatContainer = document.createElement("div")
        const formatContainer = document.createElement("ul")
        // Links
        const link = document.createElement("a")
        // Elements
        const image = document.createElement("img")
        const title = document.createElement("a")
        const author = document.createElement("a")
        const rating = document.createElement("p")
        const countOfGrades = document.createElement("p")
        const discount = document.createElement("p")
        // Emojies
        const likeEmojy = document.createElement("i")
        const ratingStarEmojy = document.createElement("i")

        // Classes
        card             .classList.add("book-card")
        topIconsContainer.classList.add("top-icons-container")
        titleContainer   .classList.add("title-contianer")
        ratingContainer  .classList.add("rating-container")
        formatContainer  .classList.add("format-container")
        link             .classList.add("link")
        image            .classList.add("image")
        author           .classList.add("author-name")
        title            .classList.add("title")
        rating           .classList.add("rating")
        countOfGrades    .classList.add("count-of-grades")
        discount         .classList.add("discount")
        likeEmojy        .classList.add("like-emojy", "fa-regular", "fa-heart")
        ratingStarEmojy  .classList.add("fa-solid", "fa-star")
        ratingAndFormatContainer.classList.add("rating-and-format-container")

        // Properties       
        link.href = "https://localhost:7009/Book/Book/" + book.id

        if (book.discount != null) {
            discount.innerText = book.discount.percent + "%"
            discount.style.opacity = 1
        }
        else 
            discount.style.opacity = 0;
        
        image.src = book.imageUrl

        author.href = "https://localhost:7028/Author/Author/" + book?.author?.id + "/Info"
        author.innerText = book.author.fullName

        title.href = link.href
        title.innerText = book.title
        
        rating.innerText = book.rating
        countOfGrades.innerText = "("+book.countOfGrades+")"
        
        // Inserting
        // Containers
        card.append(link)
        card.append(titleContainer)
        ratingAndFormatContainer.append(ratingContainer)
        ratingAndFormatContainer.append(formatContainer)
        ratingAndFormatContainer.append(formatContainer)
        card.append(ratingAndFormatContainer)
        // links
        topIconsContainer.append(discount)
        topIconsContainer.append(likeEmojy)
        link.append(image)
        link.append(topIconsContainer)
        // title container
        titleContainer.append(title)
        titleContainer.append(author)
        // rating container
        ratingContainer.append(ratingStarEmojy)
        ratingContainer.append(rating)
        ratingContainer.append(countOfGrades)

        // icons
        if (![null, 0, "None", ""].includes(book.formats))
        {
            const bookFormats = book.formats.match(/, /g)
                ? book.formats.split(", ")
                : [book.formats]

            const formatIconCodes = {
                "Electronic" : ["fa-regular", "fa-file-lines"],
                "Audio" : ["fa-solid", "fa-headphones"],
                "Paper" : ["fa-solid", "fa-book-open"]
            }

            bookFormats.map(format =>
            {
                if (formatIconCodes[format])
                {
                    const iconContainer = document.createElement("li")
                    const icon = document.createElement("i")

                    icon.classList.add(formatIconCodes[format][0])
                    icon.classList.add(formatIconCodes[format][1])
                    icon.title = format

                    iconContainer.append(icon)
                    formatContainer.append(iconContainer)
                }
            })
        }
        // adding to list
        space?.append(card)
    })
}