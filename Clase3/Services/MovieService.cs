using Clase3.Models;

namespace Clase3.Services;

public static class MovieService{
    static List<Movie> Movies { get; set;}

    static MovieService(){
        Movies = new List<Movie>
        {
            new Movie { Name = "Back to the Future", Code="BTF", Category="Sci fi", Minutes=110},
            new Movie { Name = "Avatar", Code="AVT", Category="Sci fi", Minutes=500, Review="Buenos efectos, pero muy larga..."},
            new Movie { Name = "Hannibal", Code="HNL", Category="Terror", Minutes=110}
        };
    }

    public static List<Movie> GetAll() => Movies;

    public static void Add(Movie obj){
       if(obj == null){
         return;
       }

       Movies.Add(obj);
    }

    public static void Delete(string code){
        var movieToDelete = Get(code);

        if (movieToDelete != null){
            Movies.Remove(movieToDelete);
        }
    }
    public static Movie? Get(string code) => Movies.FirstOrDefault(x => x.Code.ToLower() == code.ToLower());
}