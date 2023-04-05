using Clase4.Models;

namespace Clase4.Services;

public static class MovieService{
    static List<Movie> Movies { get; set;}

    static MovieService(){
        Movies = new List<Movie>
        {
            new Movie { Name = "Back to the Future", Code="BTF", Category="Sci fi", Minutes=110},
            new Movie { Name = "Avatar", Code="AVT", Category="Sci fi", Minutes=500, Review="Buenos efectos, pero muy larga..."},
            new Movie { Name = "Hannibal", Code="HNL", Category="Terror", Minutes=110},
            new Movie { Name = "Super man", Code="SPM", Category="Action", Minutes=110},
            new Movie { Name = "Esperando Carroza", Code="ELC", Category="Comedy", Minutes=110},
            new Movie { Name = "Argentina 1985", Code="ARG", Category="Drama", Minutes=110},
            new Movie { Name = "El Padrino", Code="ELP", Category="Drama", Minutes=120}
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