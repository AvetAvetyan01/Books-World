using Bogus;
using BooksWorld.Domain.Common.Enums;
using BooksWorld.Domain.Models;
using BooksWorld.Domain.Models.Book;

namespace BooksWorld.Domain.Common.DataGenerators;

public static class Generator
{
    private static readonly Faker _faker = new();

    public static Book GenerateBook => new()
    {
        ImageUrl = _faker.PickRandom(new string[]
        {
            "https://i.pinimg.com/originals/8c/fa/42/8cfa42565975a75ea29af51dcb0897c6.jpg",
            "https://marketplace.canva.com/EAFWZynj3fk/1/0/1003w/canva-yellow-fantasy-novel-book-cover-XL6F20t4VFI.jpg",
            "https://i.pinimg.com/736x/3c/09/c4/3c09c4794128f3fa072d3cebe6720411.jpg",
            "https://cdn.img-gorod.ru/nomenclature/28/832/2883299.jpg",
            "https://cdn.book24.ru/v2/ASE000000000725472/COVER/cover1__w600.jpg",
            "https://avatars.mds.yandex.net/i?id=fac88348aa7f499703235ecb7f39cc4c0126965b-5288064-images-thumbs&ref=rim&n=33&w=167&h=263",
            "https://thebookcoverdesigner.com/wp-content/uploads/2017/10/il-passaggio.jpg",
            "https://i.pinimg.com/736x/7a/b5/b7/7ab5b73a76c9ac8cbeb9c49f8955778c.jpg",
            "https://i.pinimg.com/474x/12/c4/66/12c46661e1f9d88de0d90d3b878df9e6.jpg",
            "https://i.pinimg.com/736x/44/8f/8a/448f8a2388976a7e1440448f11fb53b3.jpg",
            "https://i.pinimg.com/736x/ee/b3/36/eeb33662b064d31ac6ced2cd4068f9e6--book-recommendations-smileys.jpg",
            "https://avatars.mds.yandex.net/i?id=e017cc935e7bf3d48bcf4048744f034416e8f3db-10667843-images-thumbs&n=13",
            "https://cdn1.ozone.ru/s3/multimedia-j/6417886975.jpg",
            "https://cdn1.ozone.ru/s3/multimedia-z/6009160199.jpg",
            "https://cdn1.ozone.ru/s3/multimedia-q/6009160190.jpg",
            "https://i.pinimg.com/originals/dc/8c/26/dc8c26af295ba48cac3204e489f7ef03.png",
        }),
        Title = string.Join(" ", _faker.Lorem.Words(_faker.Random.Int(1, 5))),
        Description = _faker.Lorem.Paragraph(15),
        Rating = Math.Round(_faker.Random.Double(1,5), 1),
        CountOfGrades = _faker.Random.Int(1, 121),
        Author = null!,
        Genre = null!,
        Discount = null,
        Audiobooks = null,
        eBooks = null,
        Paperbooks = null,
        Reviews = null
    };

    public static EBook GenerateEBook => new()
    {
        BookId = _faker.Random.Int(1, 499),
        Language = _faker.PickRandom(new Language[6] { Language.Armenian, Language.English, Language.Russian, Language.German, Language.France, Language.Italian }),
        Year = _faker.Random.Int(1950, 2024),
        Price = _faker.Random.Int(20, 41) * 250,
        Publisher = _faker.Company.CompanyName(),
        PagesCount = _faker.Random.Int(80, 400),
        Url = "",
        IntroductionUrl = ""
    };

    public static Paperbook GeneratePaperbook => new()
    {
        BookId = _faker.Random.Int(1, 499),
        Language = _faker.PickRandom(new Language[6] { Language.Armenian, Language.English, Language.Russian, Language.German, Language.France, Language.Italian }),
        Year = _faker.Random.Int(1950, 2024),
        Price = _faker.Random.Int(20, 41) * 250,
        Publisher = _faker.Company.CompanyName(),
        PagesCount = _faker.Random.Int(80, 400),
        Quantity = _faker.Random.Int(3, 14),
        CountOfSales = _faker.Random.Int(1,12)
    };

    public static Audiobook GenerateAudiobook => new()
    {
        BookId = _faker.Random.Int(1, 499),
        Language = _faker.PickRandom(new Language[6] { Language.Armenian, Language.English, Language.Russian, Language.German, Language.France, Language.Italian }),
        Year = _faker.Random.Int(1950, 2024),
        Duration = new DateTime(1111, 1, 1, _faker.Random.Int(1, 5), _faker.Random.Int(1,59), _faker.Random.Int(1,59), DateTimeKind.Utc),
        Reader = _faker.Person.FullName,
        Price = _faker.Random.Int(20, 41) * 250,
        Publisher = _faker.Company.CompanyName(),
        Url = "",
        IntroductionUrl = "",
    };

    public static Review GenerateReview => new()
    {
        BookId = _faker.Random.Int(1, 499),
        UserId = Guid.NewGuid(),
        Grade = _faker.Random.Int(1, 5),
        Comment = _faker.Rant.Review("book"),
        Date = _faker.Date.Between(new DateTime(1950, 11, 11, 11, 11, 11, DateTimeKind.Utc), new DateTime(2022, 11, 11, 11, 11, 11, DateTimeKind.Utc))
    };

    public static Author GenerateAuthor => new()
    {
        FullName = _faker.Name.FullName(Bogus.DataSets.Name.Gender.Male),
        ImageUrl = _faker.PickRandom(new string[]
        {
            "https://i.pinimg.com/736x/57/fe/1d/57fe1dce389b9479e9e9bc4d3d89071c.jpg",
            "https://avatars.mds.yandex.net/i?id=2425b1e8061d7fde78a78e8d174feeeae6212dbd-10671814-images-thumbs&n=13",
            "https://sun6-22.userapi.com/impf/c855632/v855632466/139ee2/EIeFbokmHfg.jpg?size=766x602&quality=96&sign=b999f4dae6b15f44b95ccf7e598345db&c_uniq_tag=v-EUuB5bZD_yucYu5EYygXs0pTkEGI-C-Q1anYkKUug&type=album",
            "https://avatars.dzeninfra.ru/get-zen_doc/1866101/pub_5dd93c59ddb0193a8f321dc4_5dd93c6f0d13017d4ff74daf/scale_1200",
            "https://avatars.mds.yandex.net/i?id=28a30286f13c1dd0ba938a18598d1963ec91a60d-5236641-images-thumbs&n=13",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5b/Yeghishe_Charents_Armenian_poet.jpg/1200px-Yeghishe_Charents_Armenian_poet.jpg",
        }),
        Autobiographical = _faker.Lorem.Paragraph(28)
    };

    public static Genre GenerateGenre(int? baseId) => new ()
    {
        BaseGenreId = baseId,
        Name = _faker.PickRandom(new List<string>
        {
            "Adventure",
            "Anthology",
            "Art",
            "Biography",
            "Children's",
            "Classic",
            "Comic",
            "Cookbooks",
            "Crime",
            "Drama",
            "Fantasy",
            "Fiction",
            "Graphic Novel",
            "Historical Fiction",
            "Horror",
            "Humor",
            "Literary Fiction",
            "Memoir",
            "Mystery",
            "Non-fiction",
            "Paranormal",
            "Poetry",
            "Political",
            "Psychological Thriller",
            "Romance",
            "Science Fiction",
            "Self-help",
            "Short Story",
            "Thriller",
            "Travel",
            "Action",
            "Adult Fiction",
            "Allegory",
            "Apocalyptic",
            "Autobiography",
            "Biographical Fiction",
            "Chick Lit",
            "Christian Fiction",
            "Children's Non-fiction",
            "Cozy Mystery",
            "Cyberpunk",
            "Dystopian",
            "Epic Fantasy",
            "Erotica",
            "Fairy Tale",
            "Family Saga",
            "Fantasy Romance",
            "Gothic",
            "Grimdark",
            "Historical Romance",
            "Humorous Fiction",
            "Juvenile Fiction",
            "Literary Fantasy",
            "Magical Realism",
            "Medical Thriller",
            "Middle Grade",
            "Military Fiction",
            "Music",
            "Mythology",
            "New Adult",
            "Paranormal Romance",
            "Political Thriller",
            "Post-apocalyptic",
            "Prehistoric",
            "Psychological Fiction",
            "Religious Fiction",
            "Satire",
            "Science Fantasy",
            "Space Opera",
            "Spy Fiction",
            "Steampunk",
            "Superhero Fiction",
            "Survival",
            "Suspense",
            "Technothriller",
            "Utopian",
            "Urban Fantasy",
            "Virtual Reality",
            "Western",
            "Women's Fiction",
            "Young Adult Fantasy",
            "Young Adult Horror",
            "Algorithm",
            "Artificial Intelligence",
            "Big Data",
            "Blockchain",
            "Cloud Computing",
            "Computer Graphics",
            "Cybersecurity",
            "Data Science",
            "Database Management",
            "DevOps",
            "Game Development",
        }),
        SubgenresCount = 0,
        Subgenres = new List<Genre>()
    };
}