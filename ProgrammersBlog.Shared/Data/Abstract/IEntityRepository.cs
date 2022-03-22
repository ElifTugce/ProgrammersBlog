using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new() 
        //Buraya sadece veritabanı nesnelerimizin gelmesi gerektiği şartını koymuş olduk.
        //newlenebilir bir veritabanı nesnesi olabilir. Ayrıca IEntity imzamızı attık.
        //T yazmasının sebebi bir tip verecek olmamızdır yani generic tipte olmasıdır.
    {
        Task<T> GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T,object>>[] includeProperties); 
        // var kullanici=repository.GetAsync(k=>k.Id==15);
        //predicate kısmı bizim filtremizdir. Yani derdimizi anlattığımız bir bölümdür.
        //params aslında birden fazla parametreyi tek tek includeproperties ile ekler.
        // Örn: 25 id'li makaleyi getirirken, makale ile birlikte kullanıcıyı ve yorumları da birlikte getirmek istiyoruz. 
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null, params Expression<Func<T, object>>[] includeProperties); //Tüm kategorileri getirmek istiyoruz.
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        // entity daha öncesinde var mı diye kontrol ederken yani örnek verirsek bu email ile daha önce kayıt olundu mu diye bakmak istersek kullanırız. "Any"
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
