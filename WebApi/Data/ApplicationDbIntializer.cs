using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data
{
    public class ApplicationDbIntializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            //using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            //    if (!context.Books.Any())
            //    {
            //        context.Books.AddRange(
            //            new Book()
            //            {
            //                Title = "C#",
            //                Description = "CSharp",
            //                IsRead = true,
            //                Rate = 4,
            //                DateRead = DateTime.Now.AddDays(-24),
            //                Genre = "Programming",
            //                ImageURL = "https://balka-book.com/files/2021/07_16/17_05/u_files_store_25_1759.jpg",
            //                //Author = "Mark J. Price",
            //                DateAdded = DateTime.Now.AddDays(-48),

            //            },
            //        new Book()
            //        {
            //            Title = "1984",
            //            Description = "Последний роман «1984» культового британского писателя Джорджа Оруэлла вышел в 1949 году — за год до его смерти. Он имел бешеную популярность в Англии и США, был " +
            //            "переведен более чем на шестьдесят языков, неоднократно экранизировался. Но в" +
            //            " Советском Союзе долгие годы даже имени его автора никто не слышал... Отечественные политики называли Оруэлла троцкистом. " +
            //            "Его книги были под запретом сорок лет. «Роман Оруэлла представляет" +
            //            " собой разнузданную клевету на социализм и социалистическое общество», — говорилось об антиутопии «1984» в секретной записке Всесоюзного " +
            //            "общества культурной связи с заграницей.",
            //            IsRead = false,
            //            DateRead = DateTime.Now.AddDays(-24),
            //            Genre = "Romance",
            //            ImageURL = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/c/o/cover1__w600_1__120.jpg",
            //            //Author = "Джодж Оруэл",
            //            DateAdded = DateTime.Now.AddDays(-48),

            //        }
            //            );
            //        context.SaveChanges();
            //    }
            //}
        }
    }
}
