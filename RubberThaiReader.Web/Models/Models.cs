using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RubberThaiReader.Web.Models
{
    public class RubberPrice
    {
        public string RawDate { get; set; }
        public DateTime Date { get; set; }
        public List<Uss> UssPrices { get; set; }
        public List<RibbedSmokedSheet> RssPrices { get; set; }
        public string Remark { get; set; }

        public RubberPrice() {
            this.UssPrices = new List<Uss>();
            this.RssPrices = new List<RibbedSmokedSheet>();
        }

        public override string ToString() {

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Report as <strong>{0}</strong>", this.RawDate);

            sb.AppendFormat("<ul>");
            foreach (var uss in this.UssPrices) {
                sb.AppendFormat("<li>{0} {1} {2} {3} {4} {5}</li>", uss.RubberMarketTh, uss.Price1.GetValueOrDefault(0), uss.Price2.GetValueOrDefault(0), uss.Price3.GetValueOrDefault(0), uss.Price4.GetValueOrDefault(0), uss.Price5.GetValueOrDefault(0));
            }
            sb.AppendFormat("</ul>");

            return sb.ToString();
        }
    }

    /// <summary>
    /// ยางแผ่นดิบ
    /// </summary>
    public class Uss
    {
        /// <summary>
        /// ตลาดกลางยางพารา (ภาษาไทย)
        /// </summary>
        public string RubberMarketTh { get; set; }

        /// <summary>
        /// ตลาดกลางยางพารา (ภาษาอังกฤษ)
        /// </summary>
        public string RubberMarketEn { get; set; }

        /// <summary>
        /// ราคาซื้อขายที่ตลาดกลางยางพารา (บาท/ก.ก.) - ยางแผ่นดิบคุณภาพดี
        /// </summary>
        public decimal? Price1 { get; set; }
        /// <summary>
        /// ราคาซื้อขายที่ตลาดกลางยางพารา (บาท/ก.ก.) - ยางแผ่นดิบความชิ้น 3-5%
        /// </summary>
        public decimal? Price2 { get; set; }
        /// <summary>
        /// ราคาซื้อขายที่ตลาดกลางยางพารา (บาท/ก.ก.) - ยางแผ่นดิบความชิ้น 5-7%
        /// </summary>
        public decimal? Price3 { get; set; }
        /// <summary>
        /// ราคาซื้อขายที่ตลาดกลางยางพารา (บาท/ก.ก.) - ยางแผ่นดิบความชิ้น 7-10%
        /// </summary>
        public decimal? Price4 { get; set; }
        /// <summary>
        /// ราคาซื้อขายที่ตลาดกลางยางพารา (บาท/ก.ก.) - ยางแผ่นดิบความชิ้น 10-15%
        /// </summary>
        public decimal? Price5 { get; set; }

        /// <summary>
        /// ปริมาณซื้อขายที่ตลาดกลางยางพารา - ยางแผ่นดิบคุณภาพดี
        /// </summary>
        public decimal? Quantity1 { get; set; }
        /// <summary>
        /// ปริมาณซื้อขายที่ตลาดกลางยางพารา - ยางแผ่นดิบความชิ้น 3-5%
        /// </summary>
        public decimal? Quantity2 { get; set; }
        /// <summary>
        /// ปริมาณซื้อขายที่ตลาดกลางยางพารา - ยางแผ่นดิบความชิ้น 5-7%
        /// </summary>
        public decimal? Quantity3 { get; set; }
        /// <summary>
        /// ปริมาณซื้อขายที่ตลาดกลางยางพารา - ยางแผ่นดิบความชิ้น 7-10%
        /// </summary>
        public decimal? Quantity4 { get; set; }
        /// <summary>
        /// ปริมาณซื้อขายที่ตลาดกลางยางพารา - ยางแผ่นดิบความชิ้น 10-15%
        /// </summary>
        public decimal? Quantity5 { get; set; }

        /// <summary>
        /// น้ำยางสด
        /// </summary>
        public decimal? FieldLatex { get; set; }
    }

    /// <summary>
    /// แผ่นยางรมควัน
    /// </summary>
    public class RibbedSmokedSheet
    {
        /// <summary>
        /// ตลาดกลางยางพารา (ภาษาไทย)
        /// </summary>
        public string RubberMarketTh { get; set; }

        /// <summary>
        /// ตลาดกลางยางพารา (ภาษาอังกฤษ)
        /// </summary>
        public string RubberMarketEn { get; set; }

        /// <summary>
        /// ราคายางซื้อขายที่ตลาดกลาง (บาท/ก.ก.) - ชั้น 1-3
        /// </summary>
        public decimal? Price1 { get; set; }

        /// <summary>
        /// ราคายางซื้อขายที่ตลาดกลาง (บาท/ก.ก.) - ชั้น 4
        /// </summary>
        public decimal? Price2 { get; set; }

        /// <summary>
        /// ราคายางซื้อขายที่ตลาดกลาง (บาท/ก.ก.) - ชั้น 5
        /// </summary>
        public decimal? Price3 { get; set; }

        /// <summary>
        /// ราคายางซื้อขายที่ตลาดกลาง (บาท/ก.ก.) - ชั้นฟอง
        /// </summary>
        public decimal? Price4 { get; set; }

        /// <summary>
        /// ราคายางซื้อขายที่ตลาดกลาง (บาท/ก.ก.) - ชั้น Cutting
        /// </summary>
        public decimal? Price5 { get; set; }

        /// <summary>
        /// ปริมาณยางซื้อขายที่ตลาดกลาง (ก.ก.)
        /// </summary>
        public decimal? Quantity { get; set; }
    }
}