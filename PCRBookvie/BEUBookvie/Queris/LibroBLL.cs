using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBookvie.Queris
{
    public class LibroBLL
    {
        public static void Create(Libro a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Libro.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Libro Get(int? id)
        {
            Entities db = new Entities();
            return db.Libro.Find(id);
        }

        public static void Update(Libro Libro)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Libro.Attach(Libro);
                        db.Entry(Libro).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Libro Libro = db.Libro.Find(id);
                        db.Entry(Libro).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Libro> List()
        {
            Entities db = new Entities();
            return db.Libro.ToList();
        }

        public static List<Libro> List(int cat_id)
        {
            Entities db = new Entities();
            return db.Libro.Where(x => x.cat_id.Equals(cat_id)).ToList();
        }
    }
}
