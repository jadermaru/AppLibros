using BackendLibreria.Models;

namespace BackendLibreria.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            // Crear usuario por defecto si no existe
            if (!context.Users.Any())
            {
                var admin = new User
                {
                    Name = "admin",
                    Password = "admin123" 
                };
                context.Users.Add(admin);
                context.SaveChanges();
            }

            // Evita duplicar datos si ya existen categorías o libros
            if (context.Categories.Any() || context.Books.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category { Name = "Novel" },
                new Category { Name = "Science Fiction" },
                new Category { Name = "Romance" },
                new Category { Name = "Fable" },
                new Category { Name = "Epic" },
                new Category { Name = "Mystery" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var books = new Book[]
            {
                new Book { Title = "One Hundred Years of Solitude", Author = "Gabriel García Márquez", CategoryId = 1, Summary = "Story of the Buendía family in the mythical Macondo.", Details = "Published in 1967, magic realism." },
                new Book { Title = "Don Quixote", Author = "Miguel de Cervantes", CategoryId = 1, Summary = "Adventures of a nobleman who goes mad reading chivalric romances.", Details = "Masterpiece of Spanish literature, 17th century." },
                new Book { Title = "1984", Author = "George Orwell", CategoryId = 2, Summary = "A dystopian future under a totalitarian regime.", Details = "Published in 1949, political and social critique." },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", CategoryId = 3, Summary = "Social and romantic relationships in 19th-century England.", Details = "Published in 1813, one of Austen's most beloved works." },
                new Book { Title = "The Little Prince", Author = "Antoine de Saint-Exupéry", CategoryId = 4, Summary = "Philosophical story disguised as a children's tale.", Details = "Published in 1943, translated into more than 250 languages." },
                new Book { Title = "The Odyssey", Author = "Homer", CategoryId = 5, Summary = "Odysseus' journey home after the Trojan War.", Details = "Composed in ancient Greece, one of the oldest epic poems." },
                new Book { Title = "Chronicle of a Death Foretold", Author = "Gabriel García Márquez", CategoryId = 1, Summary = "Story of a foretold murder in a small town.", Details = "Published in 1981, based on real events." },
                new Book { Title = "Hopscotch", Author = "Julio Cortázar", CategoryId = 1, Summary = "Experimental novel that can be read in multiple ways.", Details = "Published in 1963, iconic work of the Latin American Boom." },
                new Book { Title = "The Hunger Games", Author = "Suzanne Collins", CategoryId = 2, Summary = "Teenagers fight to the death in a televised event.", Details = "Published in 2008, first of a popular trilogy." },
                new Book { Title = "The Shadow of the Wind", Author = "Carlos Ruiz Zafón", CategoryId = 6, Summary = "A young boy discovers a book that will change his life.", Details = "First novel of the 'Cemetery of Forgotten Books' series, published in 2001." }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
