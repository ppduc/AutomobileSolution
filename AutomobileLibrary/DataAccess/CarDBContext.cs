using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BusinessObject;

namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext  
    {

        // Khai báo danh sách Car (CarList) chứa những car  
        private static List<Car> CarList = new List<Car>()
        {
            new Car {CarID = 1, CarName = "CRV", Manufacturer = "Honda", Price = 30000, ReleaseYear = 2021},
            new Car {CarID = 2, CarName = "Ford Focus", Manufacturer = "Ford", Price = 150000, ReleaseYear = 2020}
        };

        //Tạo 1 singleton cho CarDBContext
        //để tạo 1 phiên làm việc CarDBContext duy nhất trong ứng dụng
        private static CarDBContext instance = null;
        private static readonly object instanceLock = new object();

        //khai báo hàm dựng
        private CarDBContext() { }

        //Triển khai singleTon cho CarDBContext
        //Instance: có thể truy cập mà không cần tạo một phiên bản của lớp CarDBContext
        public static CarDBContext Instance
        {
            get
            {
                //lock: sử dụng để đồng hóa dữ liệu đến biến instance, đảm bảo rằng chỉ có 1 luồng truy cập vào
                lock (instanceLock)
                {
                    // Kiểm tra xem instance có được tạo chưa, nếu chưa thì tạo mới và gán vào CarDBContext
                    if(instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    // trả về giá trị instance
                    return instance;
                }
            }
        }

        // Hàm trả về một danh sách Car (CarList được lấy từ danh sách ở dòng 14)
        public List<Car> GetCarList => CarList; 
        
        //Hàm lấy ra một đối tượng car trong danh sách car bằng cách truyền carId và kiểm tra trong list carId có
        // trong danh sách không, nếu có thì lấy ra
        public Car GetCarByID (int carId)
        {
            //sử dụng linq SingleOrDefault để trả về 1 đối tượng car trong danh sách 
            Car car = CarList.SingleOrDefault(pro => pro.CarID == carId);
            //trả về một object car đã được lấy từ danh sách car
            return car;
        }

        //Hàm thêm mới một car (Nhận tham số object Car)
        public void AddNew (Car car)
        {
            //Kiểm tra xem tham số object car truyền vào có tồn tại trong list không
            Car pro = GetCarByID (car.CarID);
            // nếu null thì thêm vào list
            if (pro == null)
            {
                CarList.Add(car);
            } else
            // nếu có thì xuất ra thông báo đã tồn tại 
            {
                throw new Exception("Car is already exists.");
            }
        }

        //Chỉnh sửa object car (Tham số truyền vào object car)
        public void Update (Car car)
        {
            //Kiểm tra xem tham số object car truyền vào có tồn tại trong list không
            Car c = GetCarByID(car.CarID);
            // nếu khác null (tồn tại) thì update Car
            if(c != null)
            {
                // Lấy object car tại vị trí index Of để gán một object car mới vào vị trí đó
                var index = CarList.IndexOf (c);
                CarList[index] = car;
            } else
            {
            // nếu null thì xuất ra thông báo không tồn tại
                throw new Exception("Car does not already exsits");
            }
        }

        // Xóa object car từ danh sách carlist bằng cách truyền carId
        public void Remove(int carId)
        {
            //Kiểm tra xem tham số object car truyền vào có tồn tại trong list không
            Car p = GetCarByID(carId);
            // nếu khác null (tồn tại) 
            if(p != null)
            {
                // xóa object car trong danh carlist
                CarList.Remove(p);
            } else
            {
                //nếu null, xuất ra thông báo không tồn tại
                throw new Exception("Car does not already exists");
            }
        }
    }
}
