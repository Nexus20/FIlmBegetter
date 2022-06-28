using FilmBegetter.DAL.Interfaces;

namespace FilmBegetter.DAL; 

public class DbInitializer {

    private readonly IUnitOfWork _unitOfWork;

    private readonly ApplicationDbContext _dbContext;

    public DbInitializer(IUnitOfWork unitOfWork, ApplicationDbContext dbContext) {
        _unitOfWork = unitOfWork;
        _dbContext = dbContext;
    }

    public async Task Initialize() {
        // using var textFieldParser = new TextFieldParser(@"InitialData/ratings.csv");
        //
        // textFieldParser.TextFieldType = FieldType.Delimited;
        // textFieldParser.SetDelimiters(",");
        // while (!textFieldParser.EndOfData) {
        //     var rows = textFieldParser.ReadFields();
        //
        //     if (rows[0] == "userId" && rows[1] == "movieId" && rows[2] == "rating") {
        //         continue;
        //     }
        //
        //     try {
        //
        //         await using var command = _dbContext.Database.GetDbConnection().CreateCommand();
        //
        //         command.CommandText = "INSERT INTO [dbo].[Ratings] ([Id],[MovieId],[UserId],[RatingValue],[CreationDate])" +
        //             "VALUES (@id, @movieId, NULL, @rating, GETDATE())";
        //         
        //         command.Parameters.Add(new SqlParameter("@id", Guid.NewGuid().ToString()));
        //         command.Parameters.Add(new SqlParameter("@movieId", rows[1]));
        //         command.Parameters.Add(new SqlParameter("@rating", double.Parse(rows[2].Replace('.', ','))));
        //
        //         await _dbContext.Database.OpenConnectionAsync();
        //         await command.ExecuteNonQueryAsync();
        //     
        //     }
        //     catch (Exception e) {
        //         Console.WriteLine(e);
        //         await _dbContext.Database.CloseConnectionAsync();
        //     }
        // }


        // textFieldParser.TextFieldType = FieldType.Delimited;
        // textFieldParser.SetDelimiters(",");
        // while (!textFieldParser.EndOfData) {
        //     var rows = textFieldParser.ReadFields();
        //
        //     if (rows[0] == "movieId" && rows[1] == "title" && rows[2] == "genres") {
        //         continue;
        //     }
        //
        //     var movieId = rows[0];
        //     
        //     var title = rows[1];
        //
        //     var dateRegex = new Regex(@"\(\d{4}\)");
        //     var matches = dateRegex.Matches(title);
        //     
        //     var publicationDate = DateTime.UnixEpoch;
        //
        //     if (matches.Any()) {
        //         title = dateRegex.Replace(title, "").Trim(' ');
        //         var year = matches[0].Value.Substring(1, 4);
        //         publicationDate = new DateTime(int.Parse(year), 1, 1);
        //     }
        //
        //     var genres = rows[2];
        //
        //     if (genres == "(no genres listed)") {
        //         continue;
        //     }
        //
        //     var movie = new Movie() {
        //         Id = movieId,
        //         Country = "USA",
        //         Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras fermentum elementum tortor. Suspendisse vestibulum mi id sagittis interdum. Sed dui urna, tristique vel ex ac, ultrices pellentesque dui. Mauris scelerisque lorem vel efficitur luctus. Morbi non hendrerit mauris, at ornare dolor. Vestibulum tempor convallis mollis. Aliquam hendrerit mollis tortor vel congue. Pellentesque et tempus diam. Phasellus interdum varius lorem, vel faucibus ligula ullamcorper vitae. Nullam dictum justo gravida metus rutrum varius. Curabitur ultricies luctus erat posuere facilisis. Integer vitae elit vulputate, mattis nulla ac, dictum augue. Sed dapibus mi ex, sit amet ornare nibh luctus quis. Praesent euismod metus sed libero sollicitudin maximus. ",
        //         Director = "Peter Jackson",
        //         Title = title,
        //         PublicationDate = publicationDate,
        //         CreationDate = DateTime.Now,
        //         ImagePath = $"../../../../../assets/MLP-20M/{movieId}.jpg"
        //     };
        //
        //     await _unitOfWork.GetRepository<IRepository<Movie>, Movie>().CreateAsync(movie);
        //     await _unitOfWork.SaveChangesAsync();
        //     
        //     var genresCollection = genres.Split('|').Select(g => new Genre() {
        //         Name = g,
        //         Id = Guid.NewGuid().ToString(),
        //         CreationDate = DateTime.Now,
        //     });
        //
        //     foreach (var genre in genresCollection) {
        //
        //         var g = await _unitOfWork.GetRepository<IRepository<Genre>, Genre>()
        //             .FirstOrDefaultAsync(g => g.Name == genre.Name);
        //
        //         var movieGenre = new MovieGenre() {
        //             MovieId = movieId
        //         };
        //             
        //         if (g == null) {
        //             await _unitOfWork.GetRepository<IRepository<Genre>, Genre>().CreateAsync(genre);
        //             movieGenre.GenreId = genre.Id;
        //         }
        //         else {
        //             movieGenre.GenreId = g.Id;
        //         }
        //
        //         await _unitOfWork.GetRepository<IRepository<MovieGenre>, MovieGenre>().CreateAsync(movieGenre);
        //     }
        //         
        //     await _unitOfWork.SaveChangesAsync();
        // }
    }
}