using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //soyut bir data access layer erişimi;
        //constructorda parametre olarak gelir.
        //buraya bir orm teknolojisi gelecek
        //bu yarın bir gün nhibernate, entityframework veya dapper olabilir  : 

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            //iş kodları
            //yetkisi var mı? şartlar uyugn mu? vb. kodlar
            //business layerda bu kodlar yazılır
            return _carDal.GetAll();
        }
    }
}
