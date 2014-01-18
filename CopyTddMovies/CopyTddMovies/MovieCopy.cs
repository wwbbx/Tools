using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CopyTddMovies
{
    class MovieCopy
    {
        internal void Copy(string rootDir, string targetDir)
        {
            var movies = Directory.GetFiles(rootDir, "*", SearchOption.AllDirectories);

            if(!DoIt)
            {
                Console.WriteLine("Demo Mode. Use '-doit' for real moving action.");
            }

            foreach(var movie in movies)
            {
                if (!IsMovieFile(movie)) continue;

                var targetMovie = Path.Combine(targetDir, Path.GetFileName(movie));

                if (DoIt)
                {
                    PrepareEnvironment(targetDir);
                    File.Move(movie, targetMovie);
                }

                Console.WriteLine(string.Format("Movied {0}.", targetMovie));
            }
        }

        private void PrepareEnvironment(string targetDir)
        {
            if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);
        }

        private bool IsMovieFile(string movie)
        {
            if (movie.EndsWith("mkv")) return true;

            if (movie.EndsWith("rmvb")) return true;

            return false;
        }

        public bool DoIt { get; set; }
    }
}
