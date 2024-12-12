export function InsertFormGenre(data, space)
{
    data.map(genre =>
    {
        const li = document.createElement("li")

        li.innerText = genre.name
        li.dataset.genreid = genre.id

        space.append(li)
    })
}