module MSTestSettings

open System.Linq
open Microsoft.VisualStudio.TestTools.UnitTesting
open Microsoft.EntityFrameworkCore

[<assembly: Parallelize(Scope = ExecutionScope.MethodLevel)>]
do ()

type Book = 
    {
        Title: string

    }

type ApplicationDbContext(options: DbContextOptions<ApplicationDbContext>) =
    inherit DbContext(options)
    member val Books = base.Set<Book>()

[<TestClass>]
type BookTests() =

    [<TestMethod>]
    member this.AddBookPage_Returns_View() =
  
        let controller = new BooksController()

   
        let result = controller.Create() :?> ViewResult

    
        Assert.IsNotNull(result)

    [<TestMethod>]
    member this.AddBook_ToInMemoryDatabase() =
    
        let options = DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase("TestDb")
                          .Options

     
        use context = new ApplicationDbContext(options)
        let book = { Title = "Test Book" }
        context.Books.Add(book) |> ignore
        context.SaveChanges() |> ignore

        use context2 = new ApplicationDbContext(options)
        Assert.AreEqual(1, context2.Books.Count())
        Assert.AreEqual("Test Book", context2.Books.Single().Title)
