﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using OpinionAPI.Context;
using OpinionAPI.Interface;
using OpinionAPI.Model;
using static System.Net.Mime.MediaTypeNames;

namespace OpinionAPI.DL
{
    public class MoviesLayer : IMovies
    {
        private readonly OpinionDbContext _dbcontext;
        public MoviesLayer(OpinionDbContext context)
        {
            _dbcontext = context;
        }
        public async Task<ActionResult> AddMovie(AddMoviesContext movies)
        {
            try
            {
                string connectionString = "DefaultEndpointsProtocol=https;AccountName=opinionsvk;AccountKey=EEP5cph1EePHI6sQy5KFYAQ/JFyR6i3wuOfY8arisPautM4jskmAXowa/7fxHgXbrh9bXB2NFi5p+AStHxem3Q==;EndpointSuffix=core.windows.net";
                string containerName = "moviestitle";

                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                string blobName = movies.Name + "_" + DateTime.Now.TimeOfDay + ".jpg";

                BlobUploadOptions options = new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders
                    {
                        ContentType = movies.Image.ContentType
                    }
                };
                using (Stream stream = movies.Image.OpenReadStream())
                {
                    await containerClient.UploadBlobAsync(blobName, stream);
                }

                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                string imageUrl = blobClient.Uri.ToString();
                Movies movieObj = new Movies();
                movieObj.Name = movies.Name;
                movieObj.Description = movies.Description;
                movieObj.Genre = movies.Genre;
                movieObj.Image = imageUrl;

                await _dbcontext.Movies.AddAsync(movieObj);
                await _dbcontext.SaveChangesAsync();

                return new ObjectResult(new { message = "Movie Added!" })
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch(Exception ex)
            {

                return new ObjectResult(new { message = ex.Message.ToString() })
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
        }

        public List<Movies> GetMovies()
        {
            var movies = _dbcontext.Movies.ToList();
            return movies;
        }

        public async Task<ActionResult> AddRating (RatingContext ratingContext)
        {
            try
            {
                Rating rating = new Rating()
                {
                    UserId = ratingContext.UserId,
                    MovieId = ratingContext.MovieId,
                    MovieRating = ratingContext.MovieRating,
                    Comment = ratingContext.Comment
                };
                await _dbcontext.Rating.AddAsync(rating);
                await _dbcontext.SaveChangesAsync();
                return new ObjectResult(new { message = "Comment Added!" })
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { message = ex.Message.ToString() })
                {
                    StatusCode = StatusCodes.Status403Forbidden                };
            }
            
        }
    }
}