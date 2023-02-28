using FilmDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmDB.Logic
{
    public class FilmManager
    {
        public FilmManager AddFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                //context.Add(filmModel);
                //context.SaveChanges();
                try
                {
                    context.Add(filmModel);
                    context.SaveChanges();
                }
                catch (System.Exception)
                {
                    filmModel.ID = 0;
                    context.Add(filmModel);
                    context.SaveChanges();
                }
            }
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            using (var context = new FilmContext())
            {
                var filmDelete = context.Films.SingleOrDefault(x => x.ID == id);
                context.Films.Remove(filmDelete);
                context.SaveChanges();
            }
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                //var filmUpdate= context.Films.SingleOrDefault(x => x.ID == filmModel.ID);
                context.Films.Update(filmModel);
                context.SaveChanges();
            }
            return this;
        }

        public FilmManager ChangeName(int id, string newName)
        {
            using (var context = new FilmContext())
            {
                var zmianaName = context.Films.Single(x => x.ID == id);
                if (string.IsNullOrEmpty(newName))
                    zmianaName.Name = "Brak Tytułu";
                else
                    zmianaName.Name = newName;

                UpdateFilm(zmianaName);
                context.SaveChanges();

            }
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            using (var context = new FilmContext())
            {
                var jedenGetFilm = context.Films.Single(x => x.ID == id);
                return jedenGetFilm;

            }
        }

        public List<FilmModel> GetFilms()
        {
            using (var context = new FilmContext())
            {
                var listaGetFilms = context.Films.ToList();
                return listaGetFilms;
            }
        }
    }
}
