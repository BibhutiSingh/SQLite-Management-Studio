using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Collections;
using System.Xml;


namespace SQLite_Management_Studio
{
   public static class cls_connection
    {
       public static Dictionary<string, SQLiteConnection> conn_list = new Dictionary<string, SQLiteConnection>();

       public static string Result = "SUCCESS";

       public static bool add_connection(string nm, string pth)
       {
           SQLiteConnection conn=new SQLiteConnection("Data Source="+ pth);

           try
           {
               conn.Open ();

               conn_list.Add(nm,conn);
               
               return true;
           }
           catch (Exception ex)
           {
               Result ="Error in opening Connection: " + ex.Message ;
               return false ;
           }
       }


       public static void close_connection(string nm)
       {
           try
           {
               conn_list[nm].Close();
               conn_list.Remove(nm);

               
 
           }
           catch (Exception ex)
           {
               Result = ex.Message;
           }
       }

       public static bool SaveConnection(string nm, string pth)
       {
           SQLiteConnection conn = new SQLiteConnection("Data Source=" + pth);
           bool test = false;

           try
           {
               conn.Open();

               conn_list.Add(nm, conn);

               test = true;
           }
           catch (Exception ex)
           {
               Result = "Error in opening Connection: " + ex.Message;
               test = false;
           }

           if(test==true )
           {
           XmlDocument doc = new XmlDocument();
           doc.Load("Conn_Config.xml");
           XmlElement records = doc.CreateElement("conn_details");
           records.InnerXml = "<name>" + nm + "</name>  <path>" + pth + "</path>";
           doc.DocumentElement.AppendChild(records);

           doc.Save("Conn_Config.xml");


           }

           return test;
       }

       public static bool RemoveConnection(string nm) 
       {
           XmlDocument doc = new XmlDocument();
           doc.Load("Conn_Config.xml");

           XmlNode xmlroot=null;
           XmlNode xmlchild = null;
           //XmlNode xmlnd = null;

            xmlroot = doc.DocumentElement;
            xmlchild= xmlroot.ChildNodes[1];

           foreach(XmlNode xmlnd in xmlchild )
           {
               string str = xmlnd.InnerText;

               if (str.Contains("<name>" + nm))
               {

                   doc.ParentNode.RemoveChild(xmlnd);
                   return true;
               }

           }
           return false ;
       }

    }
}
