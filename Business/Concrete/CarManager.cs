using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        IResult ICarService.Add(Car car)
        {
            //if ((car.Description.Length >= 2) && (car.DailyPrice > 0))
            //{
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            //}
            //return new ErrorResult(Messages.CarInvalid);
        }
        IResult ICarService.Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        IResult ICarService.Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
        IDataResult<List<Car>> ICarService.GetAll()
        {
            if (DateTime.Now.Hour == 00.00)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByCarId(int carId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == carId));
        }

        IDataResult<List<Car>> ICarService.GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        IDataResult<List<Car>> ICarService.GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

    }
}
