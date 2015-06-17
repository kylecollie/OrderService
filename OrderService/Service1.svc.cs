using OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OrderService
{

    public class Service1 : IService1
    {
        OrderManagementEntities OME;

        public Service1()
        {
            OME = new OrderManagementEntities();
        }

        public List<OrderDataContract.OrderMasterDataContract> GetOrderMaster()
        {
            var query = (from a in OME.OrderMasters select a).Distinct();
            List<OrderDataContract.OrderMasterDataContract> orderMasterList = new List<OrderDataContract.OrderMasterDataContract>();
            query.ToList().ForEach(rec =>
            {
                orderMasterList.Add(new OrderDataContract.OrderMasterDataContract
                {
                    Order_No = Convert.ToString(rec.Order_No),
                    Table_ID = rec.Table_ID,
                    Description = rec.Description,
                    Order_DATE = Convert.ToString(rec.Order_DATE),
                    Waiter_Name = rec.Waiter_Name
                });
            });
            return orderMasterList;
        }

        public OrderDataContract.OrderMasterDataContract SearchOrderMaster(string Order_No)
        {
            OrderDataContract.OrderMasterDataContract OrderMaster = new OrderDataContract.OrderMasterDataContract();

            try
            {

                var query = (from a in OME.OrderMasters
                             where a.Order_No.Equals(Order_No)
                             select a).Distinct().FirstOrDefault();

                OrderMaster.Order_No = Convert.ToString(query.Order_No);
                OrderMaster.Table_ID = query.Table_ID;
                OrderMaster.Description = query.Description;
                OrderMaster.Order_DATE = Convert.ToString(query.Order_DATE);
                OrderMaster.Waiter_Name = query.Waiter_Name;
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                       (ex.Message);
            }
            return OrderMaster;
        }

        public List<OrderDataContract.OrderDetailDataContract> OrderDetails(string Order_No)
        {
            var query = (from a in OME.OrderDetails
                         where a.Order_No.Equals(Order_No)
                         select a).Distinct();

            List<OrderDataContract.OrderDetailDataContract> OrderDetailList = new List<OrderDataContract.OrderDetailDataContract>();

            query.ToList().ForEach(rec =>
            {
                OrderDetailList.Add(new OrderDataContract.OrderDetailDataContract
                {
                    Order_Detail_No = Convert.ToString(rec.Order_Detail_No),
                    Order_No = Convert.ToString(rec.Order_No),
                    Item_Name = rec.Item_Name,
                    Notes = rec.Notes,
                    QTY = Convert.ToString(rec.QTY),
                    Price = Convert.ToString(rec.Price)
                });
            });
            return OrderDetailList;
        }
    }
}