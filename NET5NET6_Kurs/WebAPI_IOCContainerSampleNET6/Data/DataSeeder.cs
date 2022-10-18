namespace WebAPI_IOCContainerSampleNET6.Data
{
    public static class DataSeeder
    {
        public static void Initialize(MovieDbContext movieDbContext)
        {
            //sind Datensätze in der Tabelle Movies
            if(!movieDbContext.Movies.Any())
            {
                movieDbContext.Movies.Add(new Models.Movie() { Id = 1, Title = "Jurrasic Park", Description = "T-Rex wird Veganer", Price = 11.99m, Genre = Models.GenreTyp.Action });
                movieDbContext.Movies.Add(new Models.Movie() { Id = 2, Title = "Jurrasic Park 2", Description = "T-Rex züchtet Menschen", Price = 12.99m, Genre = Models.GenreTyp.Action });
                movieDbContext.Movies.Add(new Models.Movie() { Id = 3, Title = "Jurrasic Park 3", Description = "Auf Sylt lebt der Allosaurus", Price = 13.99m, Genre = Models.GenreTyp.Action });
                movieDbContext.Movies.Add(new Models.Movie() { Id = 4, Title = "Jurrasic Park 4", Description = "Weiterer Titel", Price = 14.99m, Genre = Models.GenreTyp.Action });

                movieDbContext.SaveChanges(); //SQL wird hier erst erstellt 
            }
        }
    }
}
