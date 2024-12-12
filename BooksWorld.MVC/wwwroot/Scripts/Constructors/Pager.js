export function InsertPager(pager, currentPage, pagesCount)
{
    const pages = FindNighbours(currentPage, pagesCount)

    pages.map(page => pager.append(PageButton(page)))

    const activePageIndex = pages.findIndex(page => page == currentPage)

    pager.childNodes[activePageIndex].classList.add("active-page")
}

function FindNighbours(currentPage, pagesCount) {
    // ---!!! adding also previous and next pages buttons !!!---
    // more better method is slicing
    let nighboursCount = 3 // or parameter
    let [leftNighbours, rightNighbours] = [[], []]

    for (let i = 1; i <= nighboursCount; i++)
    {
        const leftNighbourExist = currentPage - i > 0
        const rightNighbourExist = currentPage + i <= pagesCount

        if (leftNighbourExist) leftNighbours.unshift(currentPage - i)
        if (rightNighbourExist) rightNighbours.push(currentPage + i)
    }

    return [...leftNighbours, currentPage, ...rightNighbours]
}

function PageButton(pageNumber)
{
    const page = document.createElement("li")

    page.innerText = pageNumber

    page.classList.add("page")

    return page
}