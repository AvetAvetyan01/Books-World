export function InsertHeaderGenre(data, space, count = 0)
{
    if (count != 0)
        data = data.slice(0, count)

    data.map(genre => {
        const li = document.createElement("li")
        const a = document.createElement("a")

        a.href = "/genre/" + genre.name
        a.innerText = genre.name + " (" + genre.subgenresCount + ")"

        li.append(a)
        space?.append(li)
    })
}