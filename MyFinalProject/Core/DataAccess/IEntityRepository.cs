using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic constraint
    //T:class = referans tip
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Expression Filtre uygulamamıza yarıyor,Null olursa hepsini getirir.
        //filter=null yazmamızın nedeni tüm hepsini de getirmek isteyebiliriz
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
