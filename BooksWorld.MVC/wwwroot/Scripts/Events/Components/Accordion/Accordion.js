const questions = document.getElementById("questions")
    
questions.onclick = (e) =>
{
    const item = e.target.closest("li")

    item.classList.toggle("active-item")
}