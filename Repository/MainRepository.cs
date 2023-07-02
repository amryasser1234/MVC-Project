using Microsoft.EntityFrameworkCore;
using ProjectOwn.Date;
using ProjectOwn.Repository.Base;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectOwn.Date;
using ProjectOwn.Models;


namespace ProjectOwn.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDbContext context) 
        { 
           this.context = context;
        }

        protected AppDbContext context;
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public T SelectOne(Expression<Func<T, bool>> Match)
        {
            return context.Set<T>().SingleOrDefault(Match);
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();   
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> GetAll(params string[] agers)
        {
            IQueryable<T> query= context.Set<T>();
            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
                
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();
            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }

            }
            return await query.ToListAsync();
        }
//-------------------------------------------------------------------------------------------------------
        public void AddOne(T MyItem)
        {
             context.Set<T>().Add(MyItem);
             context.SaveChanges();
        }

        public void UpdateOne(T MyItem)
        {
             context.Set<T>().Update(MyItem);
             context.SaveChanges();
        }

        public void DeleteOne(T MyItem)
        {
           context.Set<T>().Remove(MyItem);
           context.SaveChanges();
        }

        public void AddList(IEnumerable<T> MyList)
        {
            context.Set<T>().AddRange(MyList);
            context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> MyList)
        {
            context.Set<T>().UpdateRange(MyList);
            context.SaveChanges();    
        }

        public void DeleteList(IEnumerable<T> MyList)
        {
            context.Set<T>().RemoveRange(MyList);
            context.SaveChanges();
        }
    }
}
