﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webnhahangasp.Models;

namespace webnhahangasp.Repository
{
    public class NewsRepository
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();

        public List<News> GetNews(int page, int pagesize)
        {
            return myDb.news.OrderByDescending(u => u.NewsId).ToList().
                Skip((page - 1) * pagesize).Take(pagesize).ToList();
        }


        public int getNumberNews()
        {
            int total = myDb.news.ToList().Count;
            int count = 0;
            count = total / 4;
            if (total % 4 != 0)
            {
                count++;
            }
            return count;
        }

        public News GetNew(int id)
        {
            return myDb.news.FirstOrDefault(x => x.NewsId == id);
        }

        public List<News> getAll()
        {
            return myDb.news.OrderByDescending(x => x.NewsId).ToList();
        }

        public void add(News branch)
        {
            myDb.news.Add(branch);
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var obj = myDb.news.FirstOrDefault(x => x.NewsId == id);
            myDb.news.Remove(obj);
            myDb.SaveChanges();
        }

        public void update(News branch)
        {
            var obj = myDb.news.FirstOrDefault(x => x.NewsId == branch.NewsId);
            obj.Title = branch.Title;
            obj.Image = branch.Image;
            obj.Content = branch.Content;
            myDb.SaveChanges();
        }
    }
}