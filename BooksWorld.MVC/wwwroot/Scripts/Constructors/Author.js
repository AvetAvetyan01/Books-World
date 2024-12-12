export function InsertAuthor(data, space, count = 0)
{
    if (count != 0)
        data = data.slice(0, count)

    data.map(author => {
        const card = document.createElement("li")
        const link = document.createElement("a")
        const image = document.createElement("img")
        const fullName = document.createElement("p")

        // Classes
        card.classList.add("author-card")
        link.classList.add("link")
        image.classList.add("image")
        fullName.classList.add("fullname")

        // Properties
        link.href = ""
        image.src = author.imageUrl
        fullName.innerText = author.fullName

        // Inserting
        card.append(link)
        link.append(image)
        link.append(fullName)

        // Append to list
        space?.append(card)
    })
}