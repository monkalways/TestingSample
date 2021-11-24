using System;
using System.Linq;
using TestingSample.Web.Models;

namespace TestingSample.Web.Data
{
    public class DbInitializer
    {
        public static void Initialize(MusicCatalogContext context)
        {
            // Look for any students.
            if (context.Artists.Any())
            {
                return;   // DB has been seeded
            }

            var artists = new Artist[]
            {
                new Artist{ArtistName="The Mandevilles"},
                new Artist{ArtistName="The Hip"},
                new Artist{ArtistName="Fifty Diamond Rocks"},
                new Artist{ArtistName="The Stones"}
            };

            context.Artists.AddRange(artists);
            context.SaveChanges();

        }
    }
}
