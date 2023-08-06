﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : NorthwindContext, IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext Context = new NorthwindContext())
            {
                var AddedEntity = Context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                Context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext Context = new NorthwindContext())
            {
                var DeletedEntity = Context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext Context=new NorthwindContext())
            {
                return Context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext Context = new NorthwindContext())
            {
                return filter == null
                    ? Context.Set<Product>().ToList()
                    : Context.Set<Product>().Where(filter).ToList();
            }

        }

        public List<Product> GetAllByCategory(int categoryid)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            using (NorthwindContext Context = new NorthwindContext())
            {
                var UpdatedEntity = Context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                Context.SaveChanges();
            }
        }
    }
}
