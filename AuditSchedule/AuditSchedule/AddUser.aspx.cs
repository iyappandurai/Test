using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;


namespace AuditSchedule
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind();
            }
            
        }

        public void GridBind() {
            using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~/Files/Auditor.JSON")))
            {
                string json = r.ReadToEnd();

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                grvAuditor.DataSource = dt;
                grvAuditor.DataBind();
            }
        }
       
       // DataSet ds = new DataSet();
        [WebMethod]
        public static string GetData() {
            
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~/Files/Auditor.JSON")))
                {
                    string json = r.ReadToEnd();

                    dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                }

                ds.Tables.Add(dt);
                string daresult = DataSetToJSON(ds);
                return daresult;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static string DataSetToJSON(DataSet ds)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (DataTable dt in ds.Tables)
            {
                object[] arr = new object[dt.Rows.Count + 1];

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    arr[i] = dt.Rows[i].ItemArray;
                }

                dict.Add(dt.TableName, arr);
            }

            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(dict);
        }

     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string json1 = string.Empty;
                List<Auditor> _data = new List<Auditor>();
                _data.Add(new Auditor()
                {
                    Id = txtId.Text,
                    Name = txtUser.Text

                });
                using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~/Files/Auditor.JSON")))
                {
                    string json = r.ReadToEnd();
                    List<Auditor> items = JsonConvert.DeserializeObject<List<Auditor>>(json);
                    if (items != null)
                    {
                        items.Add(new Auditor()
                        {
                            Id = txtId.Text,
                            Name = txtUser.Text

                        });
                         json1 = JsonConvert.SerializeObject(items.ToArray());
                    }
                    else {
                        json1 = JsonConvert.SerializeObject(_data.ToArray());
                    }

                    r.Close();
                    //write string to file
                    System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath("~/Files/Auditor.JSON"), json1);
                }

            }
            catch (Exception ex) {
                return;
            }
            txtUser.Text = string.Empty;
            txtId.Text = string.Empty;
            GridBind();
            lblMsg.InnerText = "Auditor Added successfully!!";
            //string json = JsonConvert.SerializeObject(_data.ToArray());
            
            ////write string to file
            //System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath("~/Files/Auditor.JSON"), json);
        }
    }
}