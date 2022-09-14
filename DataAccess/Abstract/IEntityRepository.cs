using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Generic Constraint
    //where T : class yazımının anlamı, T verisinin class türünde
    //yani referans türünde bir nesne olabileceğine dair kısıtlamadır
    //bu kısıtlamaya generic constraint deriz
    //bu kısıtlama sayesinde; IEntityRepository arayüzü
    //int, string gibi değer türünde verileri kabul etmeyecektir
    //ardından, sadece IEntity türündeki nesneleri kabul edebilecegi bir constraint ekledik
    //class : referans tip
    //IEntity : IEntity olabilir veya onu implemente eden bir nesne olabilir.
    //new() : newlenebilir olmalı, IEntity new'lenemediği icin, soyut bir nesne üretilemez, bu nedenle onu ekleyemeyiz.
    //sistemimiz artık sadece veritabanı nesneleriyle çalışabilen bir repository oldu.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
