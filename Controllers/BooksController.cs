using CodebaseProject.Data;
using CodebaseProject.Models;
using CodebaseProject.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodebaseProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly MVCDbContext mvcdbContext;
        public BooksController(MVCDbContext mvcdbContext)
        {
            this.mvcdbContext = mvcdbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await mvcdbContext.BooksInfo.ToListAsync();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel addBookRequest)
        {
            var book = new Book()
            {
                BookId = Guid.NewGuid(),
                BookName = addBookRequest.BookName,
                Edition = addBookRequest.Edition,
                Author = addBookRequest.Author,

            };

            await mvcdbContext.BooksInfo.AddAsync(book);
            await mvcdbContext.SaveChangesAsync();
            return RedirectToAction("Add");

        }

        [HttpGet]
		public async Task<IActionResult> View(Guid bookid)
		{
            
			var book = await mvcdbContext.BooksInfo.FirstOrDefaultAsync(x => x.BookId == bookid);

			if (book!= null)
			{
				var viewModel = new UpdateBookViewModel()
				{
					BookId = book.BookId,
					BookName = book.BookName,
					Edition = book.Edition,
					Author = book.Author,
				};

				return await Task.Run(() => View("View", viewModel));
			}

			return RedirectToAction("Index");

		}

		[HttpPost]
        public async Task<IActionResult> View(UpdateBookViewModel model)
        {
            var book = await mvcdbContext.BooksInfo.FindAsync(model.BookId);

            if (book != null)
            {

                
                    book.BookName = model.BookName;
                    book.Edition = model.Edition;
                    book.Author = model.Author;

                    await mvcdbContext.SaveChangesAsync();
                    return RedirectToAction("Index");

         
              
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateBookViewModel model)
        {
            var book = await mvcdbContext.BooksInfo.FindAsync(model.BookId);

            if (book != null)
            {
                mvcdbContext.BooksInfo.Remove(book);

                await mvcdbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

