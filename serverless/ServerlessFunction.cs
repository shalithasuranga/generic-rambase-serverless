using System;
using System.Collections.Generic;
using System.Text;
using RambaseCOSLib.Constants;
using RambaseCOSLib.Core.Data;
using RambaseCOSLib.Sales.Order;

namespace GenericServerlessFunction.serverless
{
    class ServerlessFunction
    {
        public string Handle(string input) {
            DataTable ARG = new DataTable(1, "HANDLE", "OFFSET", "SORTBY", "FILTER");
            DataTable RES = new DataTable(1, "HANDLE", "POS", "SIZE");
            DataTable RTB = new DataTable(80, "CS", "DOC", "NO", "ACCOUNT", "ST", "CUR", "REGDATE", "DOCTYPE", "NAME", "FIRSTNAME", "YOURNO", "YOURREF", "OURNO", "ITM4", "ST4", "CS4", "MSG", "TRANSLATEDMSG", "DMSNO", "MSGTYPE", "MSGDOCID", "FREIGHT", "FEE", "SUM", "VAT", "TOTAL", "USERID", "USERIDFIRSTNAME", "USERIDNAME");


            List<DataTable> tmpResult = SalesOrder.GetList(input);
            RTB.fillData(tmpResult[0]);
            RES.fillData(tmpResult[1]);


            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><SalesOrders>";
            for (int i = 0; i < RTB.getSize(); i++)
            {
                xml += $"<SalesOrder><SalesOrderId field=\"{ RTB.getValue(i, "NO") }\" type=\"Integer\" descr=\"{COA.NO}\" /><Status field=\"{ RTB.getValue(i, "ST") }\" type=\"Integer\" descr=\"{COA.ST}\" dov=\"COA.ST\" /><Type field=\"{ RTB.getValue(i, "DOCTYPE") }\" type=\"String\" descr=\"{COA.DOCTYPE}\" dov=\"COA.DOCTYPE\" /><CreatedAt field=\"{ RTB.getValue(i, "CS") }\" type=\"Datetime\" descr=\"{OBJECT.CS}\" /><RegistrationDate field=\"{ RTB.getValue(i, "REGDATE") }\" type=\"Date\" descr=\"{DOC.REGDATE}\" /><SellersReferenceNumber field=\"{ RTB.getValue(i, "OURNO") }\" type=\"String\" descr=\"{CUSDOC.OURNO}\" /><CustomersReference field=\"{ RTB.getValue(i, "YOURREF") }\" type=\"String\" descr=\"{CUSDOC.YOURREF}\" /><CustomersReferenceNumber field=\"{ RTB.getValue(i, "YOURNO") }\" type=\"String\" descr=\"{CUSDOC.YOURNO}\" /><Assignee expandable=\"True\" descr=\"{ DOC.USERID }\"><UserId field=\"{ RTB.getValue(i, "USERID") }\" type=\"Docref-no\" descr=\"{USR.PID}\" /><Name field=\"{ RTB.getValue(i, "USERIDNAME") }\" type=\"String\" descr=\"{USR.NAME}\" /><FirstName field=\"{ RTB.getValue(i, "USERIDFIRSTNAME") }\" type=\"String\" descr=\"{USR.FIRSTNAME}\" /><UserLink field=\"{ RTB.getValue(i, "USERID") }\" type=\"Docref-link\" descr=\"{USR.DOC}\" /></Assignee><Customer><CustomerId field=\"{ RTB.getValue(i, "ACCOUNT") }\" type=\"Integer\" descr=\"{CUS.ACCOUNT}\" /><Name field=\"{ RTB.getValue(i, "NAME") }\" type=\"String\" descr=\"{CUS.NAME}\" /><Firstname field=\"{ RTB.getValue(i, "FIRSTNAME") }\" type=\"String\" descr=\"{CUS.FIRSTNAME}\" /><CustomerLink field=\"CUS/{ RTB.getValue(i, "ACCOUNT") }\" type=\"Docref-link\" descr=\"{CUS.DOC}\" /></Customer><Totals><Currency field=\"{ RTB.getValue(i, "CUR") }\" type=\"String\" descr=\"{OBJECT.Currency}\" /><FreightAmount field=\"{ RTB.getValue(i, "FREIGHT") }\" type=\"Decimal\" descr=\"{DOC.FREIGHT}\" /><FeeAmount field=\"{ RTB.getValue(i, "FEE") }\" type=\"Decimal\" descr=\"{DOC.FEE}\" /><SubTotalAmount field=\"{ RTB.getValue(i, "SUM") }\" type=\"Decimal\" descr=\"{DOC.SUM}\" /><VATAmount field=\"{ RTB.getValue(i, "VAT") }\" type=\"Decimal\" descr=\"{DOC.VAT}\" /><TotalAmount field=\"{ RTB.getValue(i, "TOTAL") }\" type=\"Decimal\" descr=\"{DOC.TOTAL}\" /></Totals><HighlightedNotification expandable=\"True\"><NotificationId field=\"{ RTB.getValue(i, "ITM4") }\" type=\"Integer\" descr=\"{DOC4.ITM4}\" /><Status field=\"{ RTB.getValue(i, "ST4") }\" type=\"Integer\" descr=\"{DOC4.ST4}\" /><CreatedAt field=\"{ RTB.getValue(i, "CS4") }\" type=\"Datetime\" descr=\"{OBJECT.CS}\" /><Message field=\"{ RTB.getValue(i, "MSG") }\" type=\"String\" descr=\"{DOC4.MSG}\" /><TranslatedMessage field=\"{ RTB.getValue(i, "TRANSLATEDMSG") }\" type=\"String\" descr=\"{DOC4.TranslatedMessage}\" /><NotificationType><NotificationTypeId field=\"{ RTB.getValue(i, "DMSNO") }\" type=\"String\" descr=\"{DMS.NO}\" /><Category field=\"{ RTB.getValue(i, "MSGTYPE") }\" type=\"String\" descr=\"{DMS.Type}\" dov=\"DMS.TYPE\" /><NotificationTypeLink field=\"DMS/{ RTB.getValue(i, "DMSNO") }\" type=\"Docref-link\" descr=\"{DMS.DOC}\" /></NotificationType><NotificationLink field=\"{ RTB.getValue(i, "MSGDOCID") }\" type=\"Docref-itmlink\" descr=\"{DOC4.DOCID}\" /></HighlightedNotification><SalesOrderLink field=\"{ RTB.getValue(i, "DOC") }\" type=\"Docref-link\" descr=\"{COA.DOC}\" /></SalesOrder>";
            }
            xml += "</SalesOrders>";
            return xml;
        }
    }
}