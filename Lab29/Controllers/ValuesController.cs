using Lab29.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab29.Controllers
{
	public class ValuesController : ApiController
	{
		public List<Movy> GetCatalog()
		{
			MovieEntities db = new MovieEntities();
			List<Movy> Movies = db.Movies.ToList();
			return Movies;
		}

		public List<Movy> GetMovieByCategory(string id)
		{

			MovieEntities db = new MovieEntities();
			List<Movy> Category = (from m in db.Movies
								  where m.Category.Contains(id)
								  select m).ToList();
			return Category;
		}

		public Movy GetRandomMovie()
		{
			Random Rnd = new Random();
			 int id = Rnd.Next(1, 15);
			MovieEntities db = new MovieEntities();
			Movy RandomMovie = (from m in db.Movies
								   where m.ID==(id)
								   select m).Single();
			return RandomMovie;
		}

		public  Movy GetRandomMovieByCategory(string id)
		{
			Random Rnd = new Random();
			int rando = Rnd.Next(1, 15);
			MovieEntities db = new MovieEntities();
			Movy RandomMovie = (
									  from m in db.Movies
									  where m.Category.Contains(id) where m.ID == rando
									  select m).Single();
			return RandomMovie;
		}
	}
}
