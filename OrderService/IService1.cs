using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OrderService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/GetOrderMaster/")]
        List<OrderDataContract.OrderMasterDataContract> GetOrderMaster();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/SearchOrderMaster/{Order_No}")]
        OrderDataContract.OrderMasterDataContract SearchOrderMaster(string Order_No);
        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/OrderDetails/{Order_No}")]
        List<OrderDataContract.OrderDetailDataContract> OrderDetails(string Order_No);
    }


    public class OrderDataContract
    {
        [DataContract]
        public class OrderMasterDataContract
        {
            [DataMember]
            public string Order_No { get; set; }
            [DataMember]
            public string Table_ID { get; set; }
            [DataMember]
            public string Description { get; set; }
            [DataMember]
            public string Order_DATE { get; set; }
            [DataMember]
            public string Waiter_Name { get; set; }

        }


        [DataContract]
        public class OrderDetailDataContract
        {
            [DataMember]
            public string Order_Detail_No { get; set; }
            [DataMember]
            public string Order_No { get; set; }
            [DataMember]
            public string Item_Name { get; set; }
            [DataMember]
            public string Notes { get; set; }
            [DataMember]
            public string QTY { get; set; }
            [DataMember]
            public string Price { get; set; }
        }

    }
}
