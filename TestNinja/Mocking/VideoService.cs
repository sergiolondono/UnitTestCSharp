﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
	public class VideoService
	{
		// public IFileReader FileReader { get; set; }        

		//public VideoService()
		//{
		//    FileReader = new FileReader();
		//}

		private IFileReader _fileReader;
		private IVideoRepository _repository;

		public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
		{
			_fileReader = fileReader ?? new FileReader();
			_repository = repository ?? new VideoRepository();
		}

		public string ReadVideoTitle()
		{
			var str = _fileReader.Read("video.txt");
			var video = JsonConvert.DeserializeObject<Video>(str);
			if (video == null)
				return "Error parsing the video.";
			return video.Title;
		}

		//public string ReadVideoTitle(IFileReader fileReader)
		//{
		//    var str = fileReader.Read("video.txt");
		//    var video = JsonConvert.DeserializeObject<Video>(str);
		//    if (video == null)
		//        return "Error parsing the video.";
		//    return video.Title;
		//}

		//public string ReadVideoTitle()
		//{
		//    var str = FileReader.Read("video.txt");
		//    var video = JsonConvert.DeserializeObject<Video>(str);
		//    if (video == null)
		//        return "Error parsing the video.";
		//    return video.Title;
		//}

		///// <summary>
		///// Without Refactory
		///// </summary>
		///// <returns></returns>
		//      public string GetUnprocessedVideosAsCsv()
		//      {
		//          var videoIds = new List<int>();

		//          using (var context = new VideoContext())
		//          {
		//              var videos = 
		//                  (from video in context.Videos
		//                  where !video.IsProcessed
		//                  select video).ToList();

		//              foreach (var v in videos)
		//                  videoIds.Add(v.Id);

		//              return String.Join(",", videoIds);
		//          }
		//      }

		/// <summary>
		/// Whit Refactory
		/// </summary>
		/// <returns></returns>
		public string GetUnprocessedVideosAsCsv()
		{
			var videoIds = new List<int>();

			var videos = _repository.GetUnprocessedVideos();

			foreach (var v in videos)
				videoIds.Add(v.Id);

			return String.Join(",", videoIds);
		}

	}

	public class Video
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public bool IsProcessed { get; set; }
	}

	public class VideoContext : DbContext
	{
		public DbSet<Video> Videos { get; set; }
	}
}